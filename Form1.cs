using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuantumVPN
{
    public partial class Form1 : Form
    {
        public static string currentVersion = "1.0.0.0";
        string openVPNLocation = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
        string udpConfigLocation = $@"{Application.StartupPath}\QuantumVPN\Dependencies\OpenVPN\sydneyudp.ovpn";
        string tcpConfigLocation = $@"{Application.StartupPath}\QuantumVPN\Dependencies\OpenVPN\sydneytcp.ovpn";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form aboutForm = new About();
            aboutForm.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form settingsForm = new Settings();
            settingsForm.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem == null) 
            {
                MessageBox.Show("Please select a VPN server to connect to.");
            } else if(comboBox1.Text == "Sydney_1")
            {
                if (Properties.Settings.Default.isConnected == false)
                {
                    var selectedServer = comboBox1.SelectedItem.ToString();
                    Properties.Settings.Default.isConnected = true;
                    connectButton.Text = "Disconnect";
                    connectedText.Text = "   Connected";
                    comboBox1.Enabled = false;
                    // Connect to server
                    Connect(Properties.Settings.Default.connectionMethod.ToString(), selectedServer);

                }
                else if (Properties.Settings.Default.isConnected == true)
                {
                    Properties.Settings.Default.isConnected = false;
                    connectButton.Text = "Connect";
                    connectedText.Text = "Not connected";
                    comboBox1.Enabled = true;
                    // Disconnect from server
                    Disconnect();
                }
            } else if(comboBox1.Text == "Custom .OVPN Connection")
            {
                if(Properties.Settings.Default.isConnected == true)
                {
                    Disconnect();
                } else
                {
                    customConnection();
                }
                
            }
            
        }

        private void Connect(string connMethod, string connServer)
        {
            if (!File.Exists(udpConfigLocation))
            {
                restoreOVPNConfig("udp");
            }

            if (!File.Exists(tcpConfigLocation))
            {
                restoreOVPNConfig("tcp");
            }

            if (connMethod == "udp" && connServer == "Sydney_1")
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();

                startInfo.UseShellExecute = true;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = openVPNLocation;
                startInfo.Arguments = $"--config {udpConfigLocation}";
                startInfo.Verb = "runas";  
                process.StartInfo = startInfo;
                process.Start();

            } else if(connMethod == "tcp" && connServer == "Sydney_1")
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();

                startInfo.UseShellExecute = true;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = openVPNLocation;
                startInfo.Arguments = $"--config {udpConfigLocation}";
                startInfo.Verb = "runas";            
                process.StartInfo = startInfo;
                process.Start();

            }  else if(connServer == "" && (connMethod == "udp" || connMethod == "udp" || connMethod == ""))               
            {
                MessageBox.Show("Something went wrong parsing your configuration. Check your settings and try again.");
            } else
            {
                Properties.Settings.Default.connectionMethod = "udp";
                Connect(Properties.Settings.Default.connectionMethod.ToString(), "Sydney_1");
            }
        }

        private void Disconnect()
        {
            
            Process.Start(new ProcessStartInfo
            {
                FileName = "taskkill",
                Arguments = "/f /im openvpn.exe",
                CreateNoWindow = true,
                UseShellExecute = true,
                WindowStyle = ProcessWindowStyle.Hidden

            }).WaitForExit();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.isConnected == true)
            {
                Disconnect();
            }

            versionLabel.Text = currentVersion;

            CheckForUpdates(false);

            if(!File.Exists(udpConfigLocation))
            {
                restoreOVPNConfig("udp");
            }

            if(!File.Exists(tcpConfigLocation))
            {
                restoreOVPNConfig("tcp");
            }

            if (!File.Exists(openVPNLocation))
            {
                if(Environment.Is64BitOperatingSystem == true)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show("OpenVPN is needed to use Quantum. Would you like to install it?", "OpenVPN is not installed! (64-Bit)", buttons);
                    if (result == DialogResult.Yes)
                    {
                        downloadOpenVPN("64bit");

                        if(File.Exists($@"{Application.StartupPath}\QuantumVPN\temp\OpenVPN-2.5.5-I602-amd64.msi"))
                        {
                            Process process = new Process();
                            process.StartInfo.FileName = "msiexec";
                            process.StartInfo.WorkingDirectory = $@"{Application.StartupPath}\QuantumVPN\temp";
                            process.StartInfo.Arguments = " /i OpenVPN-2.5.5-I602-amd64.msi";
                            process.StartInfo.Verb = "runas";
                            process.Start();
                            process.WaitForExit(60000);
                        } else
                        {
                            MessageBox.Show("Something went wrong installing OpenVPN. Please try again.");
                            Application.Exit();
                        }

                    }
                    else
                    {
                        Application.Exit();
                    }
                } else if(Environment.Is64BitOperatingSystem == false)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show("OpenVPN is needed to use Quantum. Would you like to install it?", "OpenVPN is not installed! (32-Bit)", buttons);
                    if (result == DialogResult.Yes)
                    {
                        downloadOpenVPN("32bit");

                        if (File.Exists($@"{Application.StartupPath}\QuantumVPN\temp\OpenVPN-2.5.5-I602-x86.msi"))
                        {
                            Process process = new Process();
                            process.StartInfo.FileName = "msiexec";
                            process.StartInfo.WorkingDirectory = $@"{Application.StartupPath}\QuantumVPN\temp";
                            process.StartInfo.Arguments = " /i OpenVPN-2.5.5-I602-x86.msi";
                            process.StartInfo.Verb = "runas";
                            process.Start();
                            process.WaitForExit(60000);
                        }
                        else
                        {
                            MessageBox.Show("Something went wrong installing OpenVPN. Please try again.");
                            Application.Exit();
                        }
                    }
                    else
                    {
                        Application.Exit();
                    }
                } else
                {
                    // Something clearly went wrong checking...ask user to install themselves.
                    DialogResult result = MessageBox.Show("OpenVPN is needed to use Quantum. Please go install OpenVPN.", "OpenVPN is not installed!");
                    Application.Exit();
                }         
            } else
            {

            }
        }

        void restoreOVPNConfig(string protocol)
        {
            WebClient client = new WebClient();
           
            switch (protocol)
            {
                case "tcp":

                    var tcpappData = $@"{Application.StartupPath}\QuantumVPN\Dependencies\OpenVPN";
                    string tcpAddress = "https://www.dropbox.com/s/68ft199p5ooeitz/sydneytcp.ovpn?dl=1";         
                    Directory.CreateDirectory(tcpappData);
                    string tcpfileName = tcpappData + @"\sydneytcp.ovpn";

                    if (!File.Exists(tcpfileName))
                    {
                        client.DownloadFile(tcpAddress, tcpfileName);
                    }

                break;

                case "udp":

                    var udpappData = $@"{Application.StartupPath}\QuantumVPN\Dependencies\OpenVPN";
                    string udpAddress = "https://www.dropbox.com/s/x62ib9bd54aual6/sydneyudp.ovpn?dl=1";           
                    Directory.CreateDirectory(udpappData);
                    string udpfileName = udpappData + @"\sydneyudp.ovpn";

                    if (!File.Exists(udpfileName))
                    {
                        client.DownloadFile(udpAddress, udpfileName);
                    }

                break;

                default:

                    MessageBox.Show("An error occurred while parsing a request with .ovpn files.");
                    Application.Exit();

                break;
            }
            
        }

        void downloadOpenVPN(string protocol)
        {
            WebClient client = new WebClient();

            switch (protocol)
            {
                case "64bit":

                    var tcpappData = $@"{Application.StartupPath}\QuantumVPN\temp";
                    string tcpAddress = "https://swupdate.openvpn.org/community/releases/OpenVPN-2.5.5-I602-amd64.msi";         
                    Directory.CreateDirectory(tcpappData);
                    string tcpfileName = tcpappData + @"\OpenVPN-2.5.5-I602-amd64.msi";

                    if (!File.Exists(tcpfileName))
                    {
                        client.DownloadFile(tcpAddress, tcpfileName);
                    }

                    break;

                case "32bit":

                    var udpappData = $@"{Application.StartupPath}\QuantumVPN\temp";
                    string udpAddress = "https://swupdate.openvpn.org/community/releases/OpenVPN-2.5.5-I602-x86.msi";           
                    Directory.CreateDirectory(udpappData);
                    string udpfileName = udpappData + @"\OpenVPN-2.5.5-I602-x86.msi";

                    if (!File.Exists(udpfileName))
                    {
                        client.DownloadFile(udpAddress, udpfileName);
                    }

                    break;

                default:

                    MessageBox.Show("An error occurred while parsing a request with downloading OpenVPN");
                    Application.Exit();

                break;
            }

        }

        public static void CheckForUpdates(bool userActivated)
        {
             var request = WebRequest.Create("https://www.dropbox.com/s/59xaj55macosuat/quantum_version.txt?dl=1");
             var response = request.GetResponse();
             var sr = new StreamReader(response.GetResponseStream());

             string serverVersion = sr.ReadToEnd();

             if (serverVersion == currentVersion)
             {
                 if(userActivated == true)
                 {
                     MessageBoxButtons buttons = MessageBoxButtons.OK;
                     DialogResult result = MessageBox.Show("No new updates are available.", "You are up to date.", buttons);
                 } else
                 {

                 }

             }
             else if (serverVersion != currentVersion)
             {
                 string message = $"An update is available ({serverVersion})! Would you like to update?";
                 string title = "An update is available!";
                 MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                 DialogResult result = MessageBox.Show(message, title, buttons);
                 if (result == DialogResult.Yes)
                 {
                    Process.Start("https://github.com/Pixlox/Quantum/releases");
                 }
                 else
                 {
                     // Quit
                 }
             }
        }

        void customConnection()
        {
            OpenFileDialog ovpnFileDialog = new OpenFileDialog();

            ovpnFileDialog.InitialDirectory = "c:\\";
            ovpnFileDialog.Filter = "OpenVPN Configuration Files|*.ovpn";
            ovpnFileDialog.FilterIndex = 0;
            ovpnFileDialog.RestoreDirectory = true;

            if (ovpnFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = ovpnFileDialog.FileName;

                if (Properties.Settings.Default.connectionMethod == "udp")
                {
                    Process process = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo();

                    startInfo.UseShellExecute = true;
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    startInfo.FileName = openVPNLocation;
                    startInfo.Arguments = $"--config {selectedFileName}";
                    startInfo.Verb = "runas";
                    process.StartInfo = startInfo;
                    process.Start();

                    Properties.Settings.Default.isConnected = true;
                    connectButton.Text = "Disconnect";
                    connectedText.Text = "   Connected";
                    comboBox1.Enabled = false;

                }
                else if (Properties.Settings.Default.connectionMethod == "tcp")
                {
                    Process process = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo();

                    startInfo.UseShellExecute = true;
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    startInfo.FileName = openVPNLocation;
                    startInfo.Arguments = $"--config {selectedFileName}";
                    startInfo.Verb = "runas";
                    process.StartInfo = startInfo;
                    process.Start();

                    Properties.Settings.Default.isConnected = true;
                    connectButton.Text = "Disconnect";
                    connectedText.Text = "   Connected";
                    comboBox1.Enabled = false;

                }
            }
        }
    }
}
