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
        private string[][] _networkAdapterArray;
        private bool runThread = true;
        private bool _innerAdapterEnabled = false;
        private bool _outerAdapterEnabled = false;
        private bool _proxyEnabled = false;

        private string _innerAdapterIndex = "7";
        private string _outerAdapterIndex = "11";

        private string[] COLUMN_HEADERS = { "Index", "NIC - Name", "Adapter Name", "Status" };
        //private string[] _columnHeaders = {"Indeks", "NIC - nosaukums", "Adaptera nosaukums", "Status"};

        private const string PROXY_REG_KEY_NAME = "HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings";
        private const string PROXY_REG_VALUE_NAME = "ProxyEnable";
        private const int PROXY_OFF = 0;
        private const int PROXY_ON = 1;

        
        public string[][] NetworkAdapterArray
        {
            get 
            {
                return this._networkAdapterArray;
            }

            set
            {
                this._networkAdapterArray = value;
            }
        }
        public bool InnerAdapterEnabled
        {
            get
            {
                return this._innerAdapterEnabled;
            }
            set
            {
                this._innerAdapterEnabled = value;
            }
        }
        public bool OuterAdapterEnabled
        {
            get
            {
                return this._outerAdapterEnabled;
            }
            set
            {
                this._outerAdapterEnabled = value;
            }
        }
        public bool ProxyEnabled
        {
            get { return _proxyEnabled; }
            set { _proxyEnabled = value; }
        }
        public string OuterAdapterIndex
        {
            get { return _outerAdapterIndex; }
            set { _outerAdapterIndex = value; }
        }
        public string InnerAdapterIndex
        {
            get { return _innerAdapterIndex; }
            set { _innerAdapterIndex = value; }
        }

        //public int[] asd = { 7964, 7958, 7961, 7962, 7941, 7951, 7940, 7948, 7954, 7957, 7955, 7953, 7956, 7952, 7963, 7965, 7960, 7959, 7967, 7966, 8378, 8379, 8380, 16673, 20350, 20351, 19106, 19110, 19104, 19103, 19105, 19535, 41697, 41926, 42280, 42330, 42793, 42797 };

        delegate void SetNetAdapterGridViewInfoCallback();


        //////////////////////
        // @FORM ENTRY POINT//
        /// //////////////////
        public aplicationForm()
        {
            InitializeComponent();
               
            loadAppConfig();
            NetworkAdapterArray = getNetworkAdapterInfo();
            initNetAdapterGridView();
            initNetworkStatusComponents();

            runRefresher();
                
            //Array.Sort(asd);
            //foreach (int a in asd) {
            //    Console.Write(a + ", ");
            //}

            //string test1 = "This is my test string, so pls be careful!";
            //string test2 = "racecar";

            //Console.WriteLine("String entered: " + test1);
            //MyClass.MyString.Reverse(test1);
            //MyClass.MyString.countVovel(test1);
            //Console.WriteLine(MyClass.MyString.isPalindrom(test1));
            //Console.WriteLine(MyClass.MyString.isPalindrom(test2));

            

            //byte[] values = (byte[]) Registry.GetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\\Connections", "DefaultConnectionSettings", null);
            
            //foreach (byte i in values)
            //    Console.WriteLine("{0:X2}", i);

           
            //displayAdapterInfo(networkAdapterArray);           
        }

        #region adapterDataGridView Functions
        // Initialize grid view for 1st time
        public void initNetAdapterGridView()
        {
            // Setting column headers
            foreach (string element in COLUMN_HEADERS)
                networkAdapterDataGridView.Columns.Add(element, element);

            // Fill GridView with data
            updateNetAdapterGridView();

            // Setting DataGridView width
            this.networkAdapterDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.networkAdapterDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.networkAdapterDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.networkAdapterDataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            // Disabling and hiding unneded things
            networkAdapterDataGridView.RowHeadersVisible = false;
            networkAdapterDataGridView.AllowUserToAddRows = false;
            networkAdapterDataGridView.AllowUserToResizeRows = false;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        //Refresh info about adapter GridView
        public void updateNetAdapterGridView()
        {
            NetworkAdapterArray = getNetworkAdapterInfo();
            setNetAdapterGridViewInfo();
            setNetAdapterGridViewColors();
            networkAdapterDataGridView.ClearSelection();
        }

        // Creating and setting table information
        private void setNetAdapterGridViewInfo()
        {
            // For Background proccessing ...
            if (this.networkAdapterDataGridView.InvokeRequired)
            {
                SetNetAdapterGridViewInfoCallback d = new SetNetAdapterGridViewInfoCallback(setNetAdapterGridViewInfo);
                this.Invoke(d);
            }
            else 
            {
                networkAdapterDataGridView.Rows.Clear();
                networkAdapterDataGridView.Refresh();

                foreach (string[] row in NetworkAdapterArray)
                {
                    if (row.Length > 2)
                    {
                        networkAdapterDataGridView.Rows.Add(row);
                    }
                }
            }            
        }

        // Setting GridViewColors
        private void setNetAdapterGridViewColors()
        {
            networkAdapterDataGridView.BackgroundColor = Color.White;

            foreach (DataGridViewRow row in networkAdapterDataGridView.Rows)
            {
                if (row.Cells[3].Value != null && row.Cells[3].Value.ToString() == "TRUE")
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
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings["innerAdapterIndex"].Value = "11";
            config.AppSettings.Settings["outerAdapterIndex"].Value = "20";
            //config.AppSettings["outerAdapterIndex"] = "20";
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

        // @RETURN: string[][] of WMIC query data.
        private string[][] getNetworkAdapterInfo()
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

            // filling array with info
            for (int i = 0; i <= fullLine.Length - 1; i++)
            {
                // avoiding 1st row wich contains column names
                if (i > 0)
                    splitedNetworkArray[i - 1] = fullLine[i].Trim().Split(new string[] { "  " }, StringSplitOptions.None);
            }

            return splitedNetworkArray;
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
                string[][] tempNetworkAdapterArray = getNetworkAdapterInfo();

                foreach (string[] row in tempNetworkAdapterArray)
                {
                    // Inner network started
                    if (row[0].Equals(InnerAdapterIndex) && row[3].Equals("TRUE") && !InnerAdapterEnabled)
                    {
                        InnerAdapterEnabled = true;
                        Console.WriteLine("INNER ENABLED..");
                        updateNetAdapterGridView();
                        innerNetworkStatusPanel.BackColor = Color.Green;
                        innerNetworkButton.ForeColor = Color.Green;
                    }

                    // Inner network shutdown
                    if (row[0].Equals(InnerAdapterIndex) && row[3].Equals("FALSE") && InnerAdapterEnabled)
                    {
                        InnerAdapterEnabled = false;
                        Console.WriteLine("INNER DISABLED..");
                        updateNetAdapterGridView();
                        innerNetworkStatusPanel.BackColor = Color.Red;
                        innerNetworkButton.ForeColor = Color.Red;
                    }

                    // Outer network started
                    if (row[0].Equals(OuterAdapterIndex) && row[3].Equals("TRUE") && !OuterAdapterEnabled)
                    {
                        OuterAdapterEnabled = true;
                        Console.WriteLine("OUTER ENABLED..");
                        updateNetAdapterGridView();
                        outerNetworkStatusPanel.BackColor = Color.Green;
                        outerNetworkButton.ForeColor = Color.Green;
                    }

                    // Outer network shutdown
                    if (row[0].Equals(OuterAdapterIndex) && row[3].Equals("FALSE") && OuterAdapterEnabled)
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
            networkAdapterDataGridView.ClearSelection();
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

        #region Testing functions
        // Totally for testing purposes
        public void test()
        {
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in interfaces)
            {
                Console.WriteLine("Name: {0}", adapter.Name);
                Console.WriteLine(adapter.Description);
                Console.WriteLine(String.Empty.PadLeft(adapter.Description.Length, '='));
                Console.WriteLine("  Interface type .......................... : {0}", adapter.NetworkInterfaceType);
                Console.WriteLine("  Operational status ...................... : {0}",
                    adapter.OperationalStatus);
                string versions = "";

                // Create a display string for the supported IP versions.
                if (adapter.Supports(NetworkInterfaceComponent.IPv4))
                {
                    versions = "IPv4";
                }
                if (adapter.Supports(NetworkInterfaceComponent.IPv6))
                {
                    if (versions.Length > 0)
                    {
                        versions += " ";
                    }
                    versions += "IPv6";
                }
                Console.WriteLine("  IP version .............................. : {0}", versions);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // For testing mainly
        // @HINT: can delete this if want
        private void displayAdapterInfo(string[][] splitedNetworkArray, bool narrow = true)
        {
            foreach (string[] row in splitedNetworkArray)
            {
                if (narrow && row.Length > 2)
                {
                    foreach (string element in row)
                        Console.Write(element + ' ');
                    Console.WriteLine();
                }

                if (!narrow)
                {
                    foreach (string element in row)
                        Console.Write(element + ' ');
                    Console.WriteLine();
                }
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            saveAppConfig();
            loadAppConfig();
        }

        
    }
}
