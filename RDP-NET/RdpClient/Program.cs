using System;
using System.Windows.Forms;
using RdpClient.Forms;

namespace RdpClient
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            StartDialog startDialog = new StartDialog();
            startDialog.ShowDialog();

            if (startDialog.SwitchWnd && startDialog.IsLocal)
            {
                ViewerDialog viewerDialog = new ViewerDialog
                (
                    startDialog.ConnectionString,
                    startDialog.HostnameLAN,
                    startDialog.AccessLevel,
                    startDialog.PasswordLAN,
                    startDialog.UsernameLAN,
                    startDialog.IsLocal
                );

                startDialog?.Dispose();

                viewerDialog.ShowDialog();
            }

            else if (startDialog.SwitchWnd && (!startDialog.IsLocal))
            {
                ViewerDialog viewerDialog = new ViewerDialog
                (
                    startDialog.ConnectionString,
                    startDialog.HostnameWAN,
                    startDialog.AccessLevel,
                    startDialog.PasswordWAN,
                    startDialog.UsernameWAN,
                    startDialog.IsLocal
                );

                startDialog?.Dispose();

                viewerDialog.ShowDialog();
            }
        }
    }
}
