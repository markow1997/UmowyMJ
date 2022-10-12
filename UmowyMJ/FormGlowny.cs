using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UmowyMJ
{
     public partial class UmowyMJ : Form
    {
        List<Umowa> SpisUmow = new List<Umowa>();
        internal List<Umowa> spisUmow { get => SpisUmow; set => SpisUmow = value; }
        public string FolderSzablonow = "";
        public string FolderZawarteUmowy = "";
        IFirebaseConfig config = new FireSharp.Config.FirebaseConfig
        {
            AuthSecret = "kGvPawUFoscx1H3xS1HqLnbt90JJXgb3woNl8vKa",
            BasePath = "https://umowy-17973.firebaseio.com/"
        };
        public IFirebaseClient client;

        public UmowyMJ()
        {
            InitializeComponent();
            menuStrip1.Renderer = new ToolStripColors(); 
            FolderSzablonow += Application.StartupPath.ToString() + @"\Resources\";
            FolderZawarteUmowy += Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MJ - Zawarte umowy\";
            StworzFolderZawarteUmowy();
        }

        private string login = "";
        private string haslo = "";

        private void StworzFolderZawarteUmowy()
        {
            if (Directory.Exists(FolderZawarteUmowy))
                return;
            Directory.CreateDirectory(FolderZawarteUmowy);
            MessageBox.Show("Uruchomiłeś program po raz pierwszy. Twoje stworzone umowy będą znajdować się w katalogu Moje dokumenty\\MJ - Zawarte umow");
            return;
        }

        public void setKonto(string login, string haslo)
        {
            this.login = login;
            this.haslo = haslo;
        }

        public string getLogin()
        {
            return login;
        }

        public string getHaslo()
        {
            return haslo;
        }

        public void RunSplash()
        {
            Application.Run(new FormSplash());
        }

        public Panel getPanel()
        {
            return panelGlowny;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            UserControlStart UCS = new UserControlStart(this);
            UCS.Location = new Point((panelGlowny.Width - UCS.Width) / 2, (panelGlowny.Height - UCS.Height) / 2);
            panelGlowny.Controls.Clear();
            panelGlowny.Controls.Add(UCS);
            UCS.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }



        private void polaczenieTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckForInternetConnection()) return;
            if (login == "" || haslo == "")
                MessageBox.Show("Aby sprawdzić połączenie z bazą danych musisz być zalogowany");
            else
                MessageBox.Show("Jesteś połączony z bazą danych");
        }

        private void zakonczProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        public bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                MessageBox.Show("Brak połączenia z internetem. Spróbuj ponownie");
                return false;
            }
        }

        private void buttonWyloguj_Click(object sender, EventArgs e)
        {
            Form1_Load(null, null);
            buttonWyloguj.Visible = false;
            login = "";
            haslo = "";
        }

        private void usługaMuzycznaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckForInternetConnection()) return;
            if (login == "" || haslo == "")
            {
                MessageBox.Show("Aby wypelnić formularz musisz być zalogowany");
            }
            else
            {
                UserControlStworzUmowe UCSU = new UserControlStworzUmowe(this);
                UCSU.Location = new Point((panelGlowny.Width - UCSU.Width) / 2, (panelGlowny.Height - UCSU.Height) / 2);
                panelGlowny.Controls.Add(UCSU);
                UCSU.Show();
                clearPanel();
            }
        }

        private void usługaOświetleniowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckForInternetConnection()) return;
            if (login == "" || haslo == "")
            {
                MessageBox.Show("Aby wypelnić formularz musisz być zalogowany");
            }
            else
            {
                UserControlStworzUmoweSwiatla UCSUS = new UserControlStworzUmoweSwiatla(this);
                UCSUS.Location = new Point((panelGlowny.Width - UCSUS.Width) / 2, (panelGlowny.Height - UCSUS.Height) / 2);
                panelGlowny.Controls.Add(UCSUS);
                UCSUS.Show();
                clearPanel();
            }
        }

        public void clearPanel()
        {
            int i = 0;
            foreach (Control ctrl in panelGlowny.Controls)
            {
                ctrl.Hide();
                panelGlowny.Controls.RemoveAt(0);
                if (i == panelGlowny.Controls.Count - 1)
                    break;
                i++;
            }
        }

        private async void refreshUmowy()
        {
            try
            {
                FirebaseResponse response = await client.GetTaskAsync("Umowy/");
                Dictionary<string, Umowa> result = response.ResultAs<Dictionary<string, Umowa>>();
                SpisUmow.Clear();
                foreach (Umowa item in result.Values)
                    spisUmow.Add(item);
            }
            catch
            {
                MessageBox.Show("Nastąpił problem z pobraniem danych z serwera.");
            }

        }

        public void refreshUmowyNaZewnatrz()
        {
            refreshUmowy();
        }

        private void rejestrRezerwacjiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckForInternetConnection()) return;
            if (login == "" || haslo == "")
            {
                MessageBox.Show("Aby zobaczyc rejestr zawartych umów musisz być zalogowany");
            }
            else
            {
                UserControlRejestrRezerwacji UCRR = new UserControlRejestrRezerwacji(this);
                UCRR.Location = new Point((panelGlowny.Width - UCRR.Width) / 2, (panelGlowny.Height - UCRR.Height) / 2);
                panelGlowny.Controls.Add(UCRR);
                UCRR.Show();
                clearPanel();
            }
        }

        private void RejestrZawartychUmowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckForInternetConnection()) return;
            if (login == "" || haslo == "")
            {
                MessageBox.Show("Aby zobaczyc rejestr zawartych umów musisz być zalogowany");
            }
            else
            {
                UserControlRejestrZawartychUmow UCRZU = new UserControlRejestrZawartychUmow(this);
                UCRZU.Location = new Point((panelGlowny.Width - UCRZU.Width) / 2, (panelGlowny.Height - UCRZU.Height) / 2);
                panelGlowny.Controls.Add(UCRZU);
                UCRZU.Show();
                clearPanel();
            }
        }
    }
}
