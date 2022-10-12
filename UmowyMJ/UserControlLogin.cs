using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firebase.Auth;

namespace UmowyMJ
{
    public partial class UserControlLogin : UserControl
    {
        UmowyMJ parent;

        public UserControlLogin(UmowyMJ parent)
        {
            this.parent = parent;
            InitializeComponent();
        }
        

        private void buttonWroc_Click(object sender, EventArgs e)
        {
            UserControlStart UCS = new UserControlStart(parent);
            UCS.Location = new Point((parent.getPanel().Width - UCS.Width) / 2, (parent.getPanel().Height - UCS.Height) / 2);
            parent.getPanel().Controls.Add(UCS);
            UCS.Show();
            parent.clearPanel();
        }

        private void buttonZaloguj_Click(object sender, EventArgs e)
        {
            if (!parent.CheckForInternetConnection()) return;
            var authProvider = new FirebaseAuthProvider(new Firebase.Auth.FirebaseConfig("AIzaSyCpl3xUEugHd3lpTtwHJWODzNf4y_DsVcI"));
            try
            {
                authProvider.SignInWithEmailAndPasswordAsync(textBoxLogin.Text, textBoxHaslo.Text).Wait();
            }
            catch
            {
                MessageBox.Show("Niepoprawna nazwa użytkownika lub hasło");
                return;
            }

            var auth = authProvider.SignInWithEmailAndPasswordAsync(textBoxLogin.Text, textBoxHaslo.Text).Result;

            UserControlStworzUmowe UCSU = new UserControlStworzUmowe(parent);
            UCSU.Location = new Point((parent.getPanel().Width - UCSU.Width) / 2, (parent.getPanel().Height - UCSU.Height) / 2);
            parent.getPanel().Controls.Clear();
            parent.getPanel().Controls.Add(UCSU);
            UCSU.Show();
            parent.buttonWyloguj.Visible = true;
            parent.refreshUmowyNaZewnatrz();
            parent.setKonto(textBoxLogin.Text, textBoxHaslo.Text);
            if (auth != null)
                MessageBox.Show("Zalogowano pomyślnie");
        }


        private void textBoxHaslo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                buttonZaloguj_Click(sender, e);
        }
    }
}
