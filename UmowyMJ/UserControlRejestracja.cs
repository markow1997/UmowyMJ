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
using System.Net.Mail;

namespace UmowyMJ
{
    public partial class UserControlRejestracja : UserControl
    {
        UmowyMJ parent;

        public UserControlRejestracja(UmowyMJ parent)
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

        private void buttonStwórz_Click(object sender, EventArgs e)
        {
             if (!parent.CheckForInternetConnection()) return;
            try
            {
                new MailAddress(textBoxLogin.Text);
            }
            catch
            {
                MessageBox.Show("Email niepoprawny!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxHaslo.Text.Length < 6)
            {
                MessageBox.Show("Haslo musi byc co najmniej 6 znakowe\n");

                return;
            }
            if (!String.Equals(textBoxHaslo.Text, textBoxPowtorzHaslo.Text))
            {
                MessageBox.Show("Twoje hasła róźnią się", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            if (!String.Equals(textBoxKodAutoryzacyjny.Text, "Belchow2008"))
            {
                MessageBox.Show("Błędny kod autoryzacyjny!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            var authProvider = new FirebaseAuthProvider(new Firebase.Auth.FirebaseConfig("AIzaSyCpl3xUEugHd3lpTtwHJWODzNf4y_DsVcI"));
            try
            {
                authProvider.CreateUserWithEmailAndPasswordAsync(textBoxLogin.Text, textBoxHaslo.Text).Wait();
            }
            catch
            {
                MessageBox.Show("Niepoprawna nazwa użytkownika lub hasło", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Konto utworzono pomyślnie");

            UserControlStworzUmowe UCSU = new UserControlStworzUmowe(parent);
            UCSU.Location = new Point((parent.getPanel().Width - UCSU.Width) / 2, (parent.getPanel().Height - UCSU.Height) / 2);
            parent.getPanel().Controls.Clear();
            parent.getPanel().Controls.Add(UCSU);
            UCSU.Show();
            parent.buttonWyloguj.Visible = true;
            parent.refreshUmowyNaZewnatrz();
            parent.setKonto(textBoxLogin.Text, textBoxHaslo.Text);
            MessageBox.Show("Zalogowano pomyślnie");
        }
    }
}