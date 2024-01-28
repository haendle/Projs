using AxRDPCOMAPILib;
using NATUPNPLib;
using Neophron.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neophron
{
    public partial class ClientDialog : Form
    {
        private AxRDPViewer rdpViewer;
        private TlsClient tlsClient;
        private int exterPort = -1;

        public ClientDialog()
        {
            InitializeComponent();
            this.Init();
        }

        private void Init()
        {
            try
            {
                AppDomain.CurrentDomain.ProcessExit += new EventHandler(ExitHandler);

                rdpViewer = new AxRDPViewer();
                axRDPViewerBox.Controls.Add(rdpViewer);
                rdpViewer.Dock = DockStyle.Fill;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExitHandler(object sender, EventArgs e) 
        {
            UPnPNAT uPnPNAT = new UPnPNAT();

            IStaticPortMappingCollection PortMapping
            = uPnPNAT.StaticPortMappingCollection;

            PortMapping.Remove(exterPort, "TCP");
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectionDialog connectionDialog = new ConnectionDialog();
                connectionDialog.ShowDialog();

                if (!string.IsNullOrEmpty(connectionDialog.connectionString))
                {
                    rdpViewer.Connect
                    (connectionDialog.connectionString,
                    Environment.UserName,
                    connectionDialog.sessionPassword);

                    rdpViewer.SmartSizing = true;               
                    tlsClient = connectionDialog.tlsClient;

                    connectionDialog.Dispose();

                    fiToolStripMenuItem.Enabled = true;
                    connectToolStripMenuItem.Enabled = false;
                    exterNetworkToolStripMenuItem.Enabled = false;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void connectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectionDialog2 connectionDialog = new ConnectionDialog2();
                connectionDialog.ShowDialog();

                if (!string.IsNullOrEmpty(connectionDialog.connectionString))
                {
                    rdpViewer.Connect
                    (connectionDialog.connectionString,
                    Environment.UserName,
                    connectionDialog.sessionPassword);

                    rdpViewer.SmartSizing = true;

                    tlsClient = connectionDialog.tlsClient;
                    connectionDialog.Dispose();

                    interNetworkToolStripMenuItem.Enabled = false;
                    connectToolStripMenuItem1.Enabled = false;
                    fileSharingToolStripMenuItem.Enabled = true;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string res = tlsClient.Send(openFileDialog.FileName);
                    MessageBox.Show($"Sent: {res}");
                }

                openFileDialog.Reset();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void receiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                await Task.Run
                (() =>
                {
                    string res = tlsClient.Recv();

                    if (InvokeRequired)
                    {
                        Invoke
                        (() =>
                        {
                            MessageBox.Show($"Recv: {res}");
                        });
                    }

                    else
                    {
                        MessageBox.Show($"Recv: {res}");
                    }
                });
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
