using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UmowyMJ
{
    public partial class UserControlStart : UserControl
    {
        UmowyMJ parent;
        public UserControlStart(UmowyMJ parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void buttonLogowanie_Click(object sender, EventArgs e)
        {
            UserControlLogin UCL = new UserControlLogin(parent);
            UCL.Location = new Point((parent.getPanel().Width - UCL.Width) / 2, (parent.getPanel().Height - UCL.Height) / 2);
            parent.getPanel().Controls.Add(UCL);
            UCL.Show();
            parent.clearPanel();
        }
        private void buttonRejestracja_Click(object sender, EventArgs e)
        {
            UserControlRejestracja UCL = new UserControlRejestracja(parent);
            UCL.Location = new Point((parent.getPanel().Width - UCL.Width) / 2, (parent.getPanel().Height - UCL.Height) / 2);
            parent.getPanel().Controls.Add(UCL);
            UCL.Show();
            parent.clearPanel();
        }
        
    }
}
