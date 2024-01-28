using Neophron.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neophron
{
    public partial class ItemDialog : Form
    {
        AuthenticationRequest data;

        public ItemDialog(AuthenticationRequest userData)
        {
            InitializeComponent();
            this.data = userData;
        }

        private void ItemDialog_Load(object sender, EventArgs e)
        {
            propertyGrid.SelectedObject = data;
        }
    }
}
