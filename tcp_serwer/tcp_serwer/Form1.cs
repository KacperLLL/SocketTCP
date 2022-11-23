using SuperSimpleTcp;
using System.Text;

namespace tcp_serwer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SimpleTcpServer server;
        List<string> users = new List<string>();
        List<string> nicks = new List<string>();

        private void bntStart_Click(object sender, EventArgs e)
        {
            rData.Text = string.Empty;
            server = new SimpleTcpServer(serverIP.Text);
            server.Events.ClientConnected += Events_ClientConnected;
            server.Events.ClientDisconnected += Events_ClientDisconnected;
            server.Events.DataReceived += Events_DataReceived;
            server.Start();
            rData.Text += $"Starting...{Environment.NewLine}";
            bntStart.Enabled = false;
            bntSend.Enabled = true;
            btnStop.Enabled = true;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            server = new(serverIP.Text);
            server.Events.ClientConnected += Events_ClientConnected;
            server.Events.ClientDisconnected += Events_ClientDisconnected;
            server.Events.DataReceived += Events_DataReceived;
            btnStop.Enabled = false;
        }

        private void Events_DataReceived(object? sender, DataReceivedEventArgs e)
        {
            
            this.Invoke((MethodInvoker)delegate
            {
                if(Encoding.UTF8.GetString(e.Data)=="//dys")
                {
                    server.DisconnectClient(e.IpPort);
                }

                else if(!isUserExist(e.IpPort))
                {
                    users.Add(e.IpPort);
                    nicks.Add(Encoding.UTF8.GetString(e.Data));
                }
                   
                else
                {
                    int index = users.IndexOf(e.IpPort);

                    rData.Text += $"{e.IpPort}({nicks[index]}): {Encoding.UTF8.GetString(e.Data)}{Environment.NewLine}";
                    foreach (string s in clientIP.Items)
                    {
                        if (e.IpPort != s)
                        {
                            server.Send(s, $"{nicks[index]}: " + Encoding.UTF8.GetString(e.Data));
                        }
                    }
                }
            });
        }

        private void Events_ClientDisconnected(object? sender, ConnectionEventArgs e)
        {
            
            this.Invoke((MethodInvoker)delegate
            {
                rData.Text += $"Disconnected: {e.IpPort}{Environment.NewLine}";
                clientIP.Items.Remove(e.IpPort);
                foreach (string s in clientIP.Items)
                {
                    server.Send(s, $"Disconnected: {e.IpPort}");
                }
            });
        }

        private void Events_ClientConnected(object? sender, ConnectionEventArgs e)
        {
            
            this.Invoke((MethodInvoker)delegate
            {
                rData.Text += $"Connected: {e.IpPort}{Environment.NewLine}";
                foreach (string s in clientIP.Items)
                {
                    server.Send(s, $"Connected: {e.IpPort}");
                }
                clientIP.Items.Add(e.IpPort);
            });
        }

        private void bntSend_Click(object sender, EventArgs e)
        {
            if(server.IsListening)
            {
                if(!string.IsNullOrEmpty(msgBox.Text))
                {
                    foreach (string s in clientIP.Items)
                    {
                        server.Send(s, "Serwer: "+msgBox.Text);
                    }
                    rData.Text+= $"Serwer: {msgBox.Text}{Environment.NewLine}";
                    msgBox.Text = String.Empty;
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            foreach(string s in clientIP.Items)
            {
                server.DisconnectClient(s);
            }
            clientIP.Items.Clear();

            server.Stop();
            btnStop.Enabled = false;
            bntSend.Enabled = false;
            bntStart.Enabled = true;
            rData.Text = "Server stopped!";
        }

        private bool isUserExist(string ipAdress)
        {
            bool isTrue = false;
            foreach(string s in users)
            {
                if(s==ipAdress)
                {
                    isTrue = true;
                }
            }
            return isTrue;
        }
    }
}