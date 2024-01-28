namespace Neophron
{
    public partial class WelcomeDialog : Form
    {
        public bool switchClient { get; private set; }
        public bool switchServer { get; private set; }

        public WelcomeDialog()
        {
            InitializeComponent();
        }

        private void clientLaunch_Click(object sender, EventArgs e)
        {
            this.switchClient = true;
            this.Close();
        }

        private void serverLaunch_Click(object sender, EventArgs e)
        {
            this.switchServer = true;
            this.Close();
        }
    }
}