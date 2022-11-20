using SuperSimpleTcp;
using System.Diagnostics.Eventing.Reader;
using System.Text;

namespace tcp_client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SimpleTcpClient client;

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new(serverIP.Text);
            client.Events.Connected += Events_Connected;
            client.Events.Disconnected += Events_Disconnected;
            client.Events.DataReceived += Events_DataReceived;
            btnStop.Enabled = false;
        }

        private void Events_DataReceived(object? sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                rData.Text += $"{Encoding.UTF8.GetString(e.Data)}{Environment.NewLine}";
            });
            
        }

        private void Events_Disconnected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                rData.Text = $"Server disconnected {Environment.NewLine}";
                btnStop.Enabled = false;
                btnSend.Enabled = false;
                btnConnect.Enabled = true;
            });
            
        }

        private void Events_Connected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                rData.Text += $"Server connected {Environment.NewLine}";
            });
            
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            rData.Text = string.Empty;
            try
            {
                client = new SimpleTcpClient(serverIP.Text);
                client.Events.Connected += Events_Connected;
                client.Events.Disconnected += Events_Disconnected;
                client.Events.DataReceived += Events_DataReceived;

                client.Connect();
                btnSend.Enabled = true;
                btnConnect.Enabled = false;
                btnStop.Enabled = true ;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if(client.IsConnected)
            {
                if(!string.IsNullOrEmpty(msgBox.Text))
                {
                    client.Send(msgBox.Text);
                    rData.Text += $"Me: {msgBox.Text}{Environment.NewLine}";
                    msgBox.Text = string.Empty;
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            client.Disconnect();
            btnStop.Enabled = false;
            btnSend.Enabled = false;
            btnConnect.Enabled = true;
            rData.Text = "Client disconnected!";
        }
    }
}