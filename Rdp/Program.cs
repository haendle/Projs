namespace Neophron
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            
            WelcomeDialog welcomeDialog = new WelcomeDialog();
            welcomeDialog.ShowDialog();

            if (welcomeDialog.switchClient)
            {
                welcomeDialog.Dispose();
                ClientDialog clientDialog = new ClientDialog();
                clientDialog.ShowDialog();
            }

            if (welcomeDialog.switchServer)
            {
                welcomeDialog.Dispose();
                ServerDialog serverDialog = new ServerDialog();
                serverDialog.ShowDialog();
            }

        }
    }
}