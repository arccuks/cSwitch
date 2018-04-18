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
        private BindingList<NetworkAdapter> netAdapterList { get; set; }
        private BindingSource source { get; set; }
        private bool runThread { get; set; } = true;

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
            dataGridViewNetworkAdapter.DataSource = source;

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
            // Fill GridView with data
            updateNetAdapterGridView();

            // Setting DataGridView width
            dataGridViewNetworkAdapter.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewNetworkAdapter.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewNetworkAdapter.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewNetworkAdapter.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewNetworkAdapter.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        //Refresh info about adapter GridView
        public void updateNetAdapterGridView()
        {
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
            NetworkAdapter.InnerAdapterIndex = int.Parse(AppSettings.readAppSetting("innerAdapterIndex"));
            NetworkAdapter.OuterAdapterIndex = int.Parse(AppSettings.readAppSetting("outerAdapterIndex"));
            checkBoxHideVirtualAdapter.Checked = bool.Parse(AppSettings.readAppSetting("hideVirtualNetworkAdapters"));
        }

        private void setInnerAdapterIndex(int index)
        {
            AppSettings.setAppSettingValue("innerAdapterIndex", index.ToString());
        }

        private void setOuterAdapterIndex(int index)
        {
            AppSettings.setAppSettingValue("outerAdapterIndex", index.ToString());
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="netAdapList"></param>
        private void setNetworkAdapterInfo()
        {
            string output = CommandLine.getCommandOutput("nic get name, index, NetConnectionID, netenabled", "wmic.exe");

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

            for (int i = 1; i < fullLine.Length; i++)
            {
                int idx = i - 1;
                // avoiding 1st row wich contains column names
                splitedNetworkArray[idx] = fullLine[i].Trim().Split(new string[] { "  " }, StringSplitOptions.None);
                if (splitedNetworkArray[idx].Length == 4)
                {
                    NetworkAdapter na = new NetworkAdapter(int.Parse(splitedNetworkArray[idx][0]), splitedNetworkArray[idx][1], splitedNetworkArray[idx][2], bool.Parse(splitedNetworkArray[idx][3]));

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

                if (splitedNetworkArray[idx].Length == 2 && !checkBoxHideVirtualAdapter.Checked)
                {
                    NetworkAdapter na = new NetworkAdapter(int.Parse(splitedNetworkArray[idx][0]), splitedNetworkArray[idx][1], null, false);

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
                updateNetAdapterGridView();

                foreach (NetworkAdapter na in netAdapterList)
                {
                    // Inner network started
                    if (na.Index.Equals(NetworkAdapter.InnerAdapterIndex) && na.NetEnabled.Equals(true) && !NetworkAdapter.InnerAdapterEnabled)
                    {
                        NetworkAdapter.InnerAdapterEnabled = true;
                        Console.WriteLine("INNER ENABLED..");
                        innerNetworkStatusPanel.BackColor = Color.Green;
                        innerNetworkButton.ForeColor = Color.Green;
                    }

                    // Inner network shutdown
                    if (na.Index.Equals(NetworkAdapter.InnerAdapterIndex) && na.NetEnabled.Equals(false) && NetworkAdapter.InnerAdapterEnabled)
                    {
                        NetworkAdapter.InnerAdapterEnabled = false;
                        Console.WriteLine("INNER DISABLED..");
                        innerNetworkStatusPanel.BackColor = Color.Red;
                        innerNetworkButton.ForeColor = Color.Red;
                    }

                    // Outer network started
                    if (na.Index.Equals(NetworkAdapter.OuterAdapterIndex) && na.NetEnabled.Equals(true) && !NetworkAdapter.OuterAdapterEnabled)
                    {
                        NetworkAdapter.OuterAdapterEnabled = true;
                        Console.WriteLine("OUTER ENABLED..");
                        outerNetworkStatusPanel.BackColor = Color.Green;
                        outerNetworkButton.ForeColor = Color.Green;
                    }

                    // Outer network shutdown
                    if (na.Index.Equals(NetworkAdapter.OuterAdapterIndex) && na.NetEnabled.Equals(false) && NetworkAdapter.OuterAdapterEnabled)
                    {
                        NetworkAdapter.OuterAdapterEnabled = false;
                        Console.WriteLine("OUTER DISABLED..");
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
                if (Proxy.getProxyStatus() && !Proxy.ProxyEnabled)
                {
                    Proxy.ProxyEnabled = true;
                    proxyStatusPanel.BackColor = Color.Green;
                }

                if (!Proxy.getProxyStatus() && Proxy.ProxyEnabled)
                {
                    Proxy.ProxyEnabled = false;
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
            dataGridViewNetworkAdapter.ClearSelection();
        }

        // Refresh table information
        private void clearSelectionButton_Click(object sender, EventArgs e)
        {
            resetGridView();
        }

        // Stop background threads
        private void aplicationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.runThread = false;
        }

        // Enable/Disable Inner Netowrk
        private void innerNetworkButton_Click(object sender, EventArgs e)
        {
            NetworkAdapter.enableNetworkAdapter(NetworkAdapter.InnerAdapterIndex, !NetworkAdapter.InnerAdapterEnabled);
        }

        // Enable/Disable Outer Netowrk
        private void outerNetworkButton_Click(object sender, EventArgs e)
        {
            NetworkAdapter.enableNetworkAdapter(NetworkAdapter.OuterAdapterIndex, !NetworkAdapter.OuterAdapterEnabled);
        }

        private void resetGridView()
        {
            netAdapterList.Clear();
            setNetworkAdapterInfo();
            initNetAdapterGridView();
        }

        // Open Internet options
        private void proxyStatusLabel_Click(object sender, EventArgs e)
        {
            string cmd = "/c start inetcpl.cpl";
            CommandLine.executeCommand(cmd);
        }

        // Enable/Disable Proxy
        private void proxyButton_Click(object sender, EventArgs e)
        {
            Proxy.enableProxy(!Proxy.ProxyEnabled);
        }
        #endregion

        private void setAsInnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NetworkAdapter na = netAdapterList.ElementAt(int.Parse(contextMenuStripTable.Tag.ToString()));
            setInnerAdapterIndex(na.Index);
            NetworkAdapter.InnerAdapterIndex = na.Index;
            resetGridView();
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
            NetworkAdapter.OuterAdapterIndex = na.Index;
            resetGridView();

        }

        private void checkBoxHideVirtualAdapter_CheckedChanged(object sender, EventArgs e)
        {
            if(netAdapterList != null)
            {
                resetGridView();
                AppSettings.setAppSettingValue("hideVirtualNetworkAdapters", checkBoxHideVirtualAdapter.Checked.ToString());
            }            
        }
    }
}
