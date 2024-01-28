using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Client
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            
            LogIn authenticationDialog = new LogIn();
            authenticationDialog.ShowDialog();

            if (authenticationDialog.SwitchWnd)
            {
                Client maingDialog = new Client
                (authenticationDialog.Username);

                authenticationDialog.Close();
                maingDialog.ShowDialog();
            }
        }
    }
}