using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace WFA
{
    public partial class aplicationForm : Form
    {
        private BindingList<NetworkAdapter> netAdapterList;
        private BindingSource source;
        private bool runThread { get; set; } = true;
        private bool InnerAdapterEnabled { get; set; } = false;
        private bool OuterAdapterEnabled { get; set; } = false;
        private bool ProxyEnabled { get; set; } = false;

        private string InnerAdapterIndex { get; set; } = "7";
        private string OuterAdapterIndex { get; set; } = "11";

        private string[] COLUMN_HEADERS = { "Index", "NIC - Name", "Adapter Name", "Status" };
        //private string[] _columnHeaders = {"Indeks", "NIC - nosaukums", "Adaptera nosaukums", "Status"};

        private string PROXY_REG_KEY_NAME => "HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings";
        private string PROXY_REG_VALUE_NAME => "ProxyEnable";
        private int PROXY_OFF => 0;
        private int PROXY_ON => 1;

        delegate void setNetworkAdapterInfoCallback(object p, ListChangedEventArgs e);


        //////////////////////
        // @FORM ENTRY POINT//
        /// //////////////////
        public aplicationForm()
        {
            InitializeComponent();

            loadAppConfig();
            netAdapterList = new BindingList<NetworkAdapter>();
            netAdapterList.ListChanged += new ListChangedEventHandler(eventAdapterListChanged);
            source = new BindingSource(netAdapterList, null);
            

            setNetworkAdapterInfo();

            initNetAdapterGridView();
            initNetworkStatusComponents();

            runRefresher();
        }

        private void eventAdapterListChanged(object sender, ListChangedEventArgs e)
        {
            if (dataGridViewNetworkAdapter.InvokeRequired)
            {
                dataGridViewNetworkAdapter.Invoke(new setNetworkAdapterInfoCallback(this.eventAdapterListChanged), sender, e);
                return;
            }
            else
            {
                if (e.ListChangedType == ListChangedType.Reset)
                {
                    dataGridViewNetworkAdapter.DataSource = null;
                    source = new BindingSource(netAdapterList, null);
                    dataGridViewNetworkAdapter.DataSource = source;
                }
                else
                    source.ResetBindings(false);
            }
        }

        #region adapterDataGridView Functions
        // Initialize grid view for 1st time
        public void initNetAdapterGridView()
        {
            dataGridViewNetworkAdapter.DataSource = source;
            // Fill GridView with data
            updateNetAdapterGridView();

            // Setting DataGridView width
            this.dataGridViewNetworkAdapter.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewNetworkAdapter.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewNetworkAdapter.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewNetworkAdapter.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        //Refresh info about adapter GridView
        public void updateNetAdapterGridView()
        {
            setNetworkAdapterInfo();
            setNetAdapterGridViewColors();
            dataGridViewNetworkAdapter.ClearSelection();
        }

        // Setting GridViewColors
        private void setNetAdapterGridViewColors()
        {
            dataGridViewNetworkAdapter.BackgroundColor = Color.White;

            foreach (DataGridViewRow row in dataGridViewNetworkAdapter.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[3];


                if (chk.Value.Equals(true))
                    row.DefaultCellStyle.BackColor = Color.Green;
                else
                    row.DefaultCellStyle.BackColor = Color.Red;
            }
        }
        #endregion

        // Inits App.config file
        private void loadAppConfig()
        {
            if (String.IsNullOrEmpty(ConfigurationManager.AppSettings["innerAdapterIndex"]))
                throw new NullReferenceException("ERROR at: app.config \n\tinnerAdapterIndex must be filled!");
            InnerAdapterIndex = ConfigurationManager.AppSettings["innerAdapterIndex"];

            if (String.IsNullOrEmpty(ConfigurationManager.AppSettings["outerAdapterIndex"]))
                throw new NullReferenceException("ERROR at: app.config \n\touterAdapterIndex must be filled!");
            OuterAdapterIndex = ConfigurationManager.AppSettings["outerAdapterIndex"];
        }

        // Save App.config file
        private void saveAppConfig()
        {
            setInnerAdapterIndex("11");
            InnerAdapterIndex = "11";
            setOuterAdapterIndex("20");
            OuterAdapterIndex = "20";
        }

        private void setInnerAdapterIndex(string index)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings["innerAdapterIndex"].Value = index;

            config.Save();

            ConfigurationManager.RefreshSection("appSettings");
        }

        private void setOuterAdapterIndex(string index)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings["outerAdapterIndex"].Value = index;

            config.Save();

            ConfigurationManager.RefreshSection("appSettings");
        }

        // Inits Network Status compoenets
        private void initNetworkStatusComponents()
        {
            innerNetworkStatusPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            outerNetworkStatusPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            proxyStatusPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            innerNetworkStatusPanel.BackColor = Color.Red;
            outerNetworkStatusPanel.BackColor = Color.Red;
            proxyStatusPanel.BackColor = Color.Red;

            innerNetworkButton.BackColor = Color.Black;
            innerNetworkButton.ForeColor = Color.Red;

            outerNetworkButton.BackColor = Color.Black;
            outerNetworkButton.ForeColor = Color.Red;
        }

        // Returns proxy status from Windows Registry
        private bool getProxyStatus()
        {
            return Registry.GetValue(PROXY_REG_KEY_NAME, PROXY_REG_VALUE_NAME, PROXY_OFF).ToString().Equals("1");
        }

        // For Executing CMD comands
        private void execCMD(string command, string filename = "CMD.exe")
        {
            Process p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.FileName = filename;
            p.StartInfo.Arguments = command;
            p.Start();

            //Process.Start("CMD.exe", command);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="netAdapList"></param>
        private void setNetworkAdapterInfo()
        {
            Process p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.FileName = "wmic.exe";
            p.StartInfo.Arguments = "nic get name, index, NetConnectionID, netenabled";
            p.Start();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            // p.WaitForExit();
            // Read the output stream first and then wait.
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            //splited wmic output with NEW_LINE to get array
            string[] fullLine = output.Split(new string[] { "\n" }, StringSplitOptions.None);

            int c = -1;

            //normalizing wmic output by removing unneeded characters
            for (int i = 0; i <= fullLine.Length - 1; i++)
            {
                c++;

                while (fullLine[i].Contains("\r"))
                {
                    fullLine[i] = fullLine[i].Replace("\r", "");
                };

                if (fullLine[i].Contains("  "))
                {
                    do
                    {
                        fullLine[i] = fullLine[i].Replace("   ", "  ");
                    } while (fullLine[i].Contains("   "));
                }
            }

            //setting array
            string[][] splitedNetworkArray = new string[c][];

            //netAdapterList.Clear();

            for (int i = 1; i < fullLine.Length; i++)
            {
                int idx = i - 1;
                // avoiding 1st row wich contains column names
                splitedNetworkArray[idx] = fullLine[i].Trim().Split(new string[] { "  " }, StringSplitOptions.None);
                if (splitedNetworkArray[idx].Length == 4)
                {
                    NetworkAdapter na = new NetworkAdapter(splitedNetworkArray[idx][0], splitedNetworkArray[idx][1], splitedNetworkArray[idx][2], bool.Parse(splitedNetworkArray[idx][3]));

                    if (netAdapterList.Contains(na))
                    {
                        int index = netAdapterList.IndexOf(na);
                        NetworkAdapter na2 = netAdapterList.ElementAt(index);
                        na2.NetEnabled = na.NetEnabled;
                    }
                    else
                    {
                        netAdapterList.Add(na);
                    }
                }

            }
        }

        #region Refresher Functions
        // Job that refresh info about Adapter status
        private void runRefresher()
        {
            Thread newThread = new Thread(new ThreadStart(this.refreshAdapters));
            newThread.Start();

            Thread proxyThread = new Thread(new ThreadStart(this.refreshProxy));
            proxyThread.Start();
        }

        // Refresh information about adapters
        private void refreshAdapters()
        {
            while (runThread)
            {
                setNetworkAdapterInfo();

                foreach (NetworkAdapter na in netAdapterList)
                {
                    // Inner network started
                    if (na.Index.Equals(InnerAdapterIndex) && na.NetEnabled.Equals(true) && !InnerAdapterEnabled)
                    {
                        InnerAdapterEnabled = true;
                        Console.WriteLine("INNER ENABLED..");
                        updateNetAdapterGridView();
                        innerNetworkStatusPanel.BackColor = Color.Green;
                        innerNetworkButton.ForeColor = Color.Green;
                    }

                    // Inner network shutdown
                    if (na.Index.Equals(InnerAdapterIndex) && na.NetEnabled.Equals(false) && InnerAdapterEnabled)
                    {
                        InnerAdapterEnabled = false;
                        Console.WriteLine("INNER DISABLED..");
                        updateNetAdapterGridView();
                        innerNetworkStatusPanel.BackColor = Color.Red;
                        innerNetworkButton.ForeColor = Color.Red;
                    }

                    // Outer network started
                    if (na.Index.Equals(OuterAdapterIndex) && na.NetEnabled.Equals(true) && !OuterAdapterEnabled)
                    {
                        OuterAdapterEnabled = true;
                        Console.WriteLine("OUTER ENABLED..");
                        updateNetAdapterGridView();
                        outerNetworkStatusPanel.BackColor = Color.Green;
                        outerNetworkButton.ForeColor = Color.Green;
                    }

                    // Outer network shutdown
                    if (na.Index.Equals(OuterAdapterIndex) && na.NetEnabled.Equals(false) && OuterAdapterEnabled)
                    {
                        OuterAdapterEnabled = false;
                        Console.WriteLine("OUTER DISABLED..");
                        updateNetAdapterGridView();
                        outerNetworkStatusPanel.BackColor = Color.Red;
                        outerNetworkButton.ForeColor = Color.Red;
                    }
                }

                Thread.Sleep(1000);
            }
        }

        // Refresh information about proxy
        private void refreshProxy()
        {
            while (runThread)
            {
                if (getProxyStatus() && !ProxyEnabled)
                {
                    ProxyEnabled = true;
                    proxyStatusPanel.BackColor = Color.Green;
                }

                if (!getProxyStatus() && ProxyEnabled)
                {
                    ProxyEnabled = false;
                    proxyStatusPanel.BackColor = Color.Red;
                }

                Thread.Sleep(1000);
            }
        }
        #endregion

        #region Form Related-Auto Generated Functions
        // Small tweak for better look
        private void Form1_Load(object sender, EventArgs e)
        {
            //dataGridViewNetworkAdapter.ClearSelection();
        }

        // Refresh table information
        private void clearSelectionButton_Click(object sender, EventArgs e)
        {
            updateNetAdapterGridView();
        }

        // Stop background threads
        private void aplicationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.runThread = false;
        }

        // Enable/Disable Inner Netowrk
        private void innerNetworkButton_Click(object sender, EventArgs e)
        {
            if (InnerAdapterEnabled)
            {
                String cmd = "/c start wmic path win32_networkadapter where index=" + InnerAdapterIndex + " call disable";
                execCMD(cmd);
            }
            else
            {
                String cmd = "/c start wmic path win32_networkadapter where index=" + InnerAdapterIndex + " call enable";
                execCMD(cmd);
            }
        }

        // Enable/Disable Outer Netowrk
        private void outerNetworkButton_Click(object sender, EventArgs e)
        {
            if (OuterAdapterEnabled)
            {
                String cmd = "/c start wmic path win32_networkadapter where index=" + OuterAdapterIndex + " call disable";
                execCMD(cmd);
            }
            else
            {
                String cmd = "/c start wmic path win32_networkadapter where index=" + OuterAdapterIndex + " call enable";
                execCMD(cmd);
            }
        }

        // Open Internet options
        private void proxyStatusLabel_Click(object sender, EventArgs e)
        {
            string cmd = "/c start inetcpl.cpl";
            execCMD(cmd);
        }

        // Enable/Disable Proxy
        private void proxyButton_Click(object sender, EventArgs e)
        {
            if (ProxyEnabled)
                Registry.SetValue(PROXY_REG_KEY_NAME, PROXY_REG_VALUE_NAME, PROXY_OFF, RegistryValueKind.DWord);
            else
                Registry.SetValue(PROXY_REG_KEY_NAME, PROXY_REG_VALUE_NAME, PROXY_ON, RegistryValueKind.DWord);
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            saveAppConfig();
            //loadAppConfig();
        }

        private void setAsInnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NetworkAdapter na = netAdapterList.ElementAt(int.Parse(contextMenuStripTable.Tag.ToString()));
            setInnerAdapterIndex(na.Index);
            InnerAdapterIndex = na.Index;

        }

        private void networkAdapterDataGridView_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                e.ContextMenuStrip = contextMenuStripTable;
                contextMenuStripTable.Tag = e.RowIndex;
            }
        }

        private void setAsOuterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NetworkAdapter na = netAdapterList.ElementAt(int.Parse(contextMenuStripTable.Tag.ToString()));
            setOuterAdapterIndex(na.Index);
            OuterAdapterIndex = na.Index;
        }
    }
}
