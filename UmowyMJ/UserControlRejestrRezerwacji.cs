using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Response;

namespace UmowyMJ
{
    public partial class UserControlRejestrRezerwacji : UserControl
    {
        DataTable dt = new DataTable();
        UmowyMJ parent;
        public UserControlRejestrRezerwacji(UmowyMJ parent)
        {
            this.parent = parent;
            InitializeComponent();
            AddColumns();
            AddRowToGrid();
        }

        private void AddColumns()
        {
            dt.Columns.Add("Rodzaj usługi");
            dt.Columns.Add("Typ imprezy");
            dt.Columns.Add("Rezerwowany termin");
            dt.Columns.Add("Imię");
            dt.Columns.Add("Nazwisko");
            dt.Columns.Add("Nr telefonu");
            dt.Columns.Add("Data rezerwacji");
            dataGridView1.DataSource = dt;
        }

        private void AddRowToGrid()
        {
            foreach (Umowa item in parent.spisUmow)
            {
                if (item.kompletnoscUmowy == false)
                {
                    DataRow row = dt.NewRow();
                    if (item.cenaOpcjiDodatkowych > 0 && item.cenaUslugiMuzycznej > 0)
                        row["Rodzaj usługi"] = "Muzyczna + Oświetlenie";
                    else if (item.cenaOpcjiDodatkowych == 0 && item.cenaUslugiMuzycznej > 0)
                        row["Rodzaj usługi"] = "Muzyczna";
                    else if (item.cenaOpcjiDodatkowych > 0 && item.cenaUslugiMuzycznej == 0)
                        row["Rodzaj usługi"] = "Oświetlenie";
                    row["Typ imprezy"] = item.rodzajImprezy;
                    row["Rezerwowany termin"] = item.dataImprezy;
                    row["Imię"] = item.imie;
                    row["Nazwisko"] = item.nazwisko;
                    row["Nr telefonu"] = item.nrTelefonu;
                    row["Data rezerwacji"] = item.dataPodpisaniaUmowy;
                    dt.Rows.Add(row);
                }
            }
        }

        private void buttonOdswiez_Click(object sender, EventArgs e)
        {
            if (!parent.CheckForInternetConnection()) return;
            parent.refreshUmowyNaZewnatrz();
            if (dt.Rows.Count != parent.spisUmow.Count)
            {
                dt.Clear();
                AddRowToGrid();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                buttonUsun.Visible = true;
                buttonStworzUmowe.Visible = true;
            }
            else
            {
                buttonUsun.Visible = false;
                buttonStworzUmowe.Visible = false;
            }
        }

        private async void buttonUsun_Click(object sender, EventArgs e)
        {
            if (!parent.CheckForInternetConnection()) return;
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                string DataImprezy = row.Cells["Rezerwowany termin"].Value.ToString();
                string DataPodpisaniaUmowy = row.Cells["Data rezerwacji"].Value.ToString();
                string Imie = row.Cells["Imię"].Value.ToString();
                string Nazwisko = row.Cells["Nazwisko"].Value.ToString();

                DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz usunąć rezerwację? " + Imie + " " + Nazwisko + ", termin " + DataImprezy, "Usuń umowę", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    FirebaseResponse response = await parent.client.DeleteTaskAsync("Umowy/" + DataPodpisaniaUmowy);
                    MessageBox.Show("Rezerwacja została pomyślnie usunięta z bazy danych.");
                    dataGridView1.Rows.RemoveAt(rowIndex);
                    parent.refreshUmowyNaZewnatrz();
                    buttonUsun.Visible = false;
                    buttonStworzUmowe.Visible = false;
                }
            }
        }

        private void buttonStworzUmowe_Click(object sender, EventArgs e)
        {
            if (!parent.CheckForInternetConnection()) return;
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                
                string[] Rezerwacja = new string[6];
                Rezerwacja[0] = row.Cells["Imię"].Value.ToString();
                Rezerwacja[1] = row.Cells["Nazwisko"].Value.ToString();
                Rezerwacja[2] = row.Cells["Nr telefonu"].Value.ToString();
                Rezerwacja[3] = row.Cells["Rezerwowany termin"].Value.ToString();
                Rezerwacja[4] = row.Cells["Data rezerwacji"].Value.ToString();
                Rezerwacja[5] = row.Cells["Typ imprezy"].Value.ToString();
                string typ = row.Cells["Rodzaj usługi"].Value.ToString();
                if (typ == "Oświetlenie")
                {
                    UserControlStworzUmoweSwiatla UCSUS = new UserControlStworzUmoweSwiatla(parent, Rezerwacja);
                    UCSUS.Location = new Point((parent.getPanel().Width - UCSUS.Width) / 2, (parent.getPanel().Height - UCSUS.Height) / 2);
                    parent.getPanel().Controls.Add(UCSUS);
                    UCSUS.Show();
                    parent.clearPanel();
                }
                else
                {
                    UserControlStworzUmowe UCSU = new UserControlStworzUmowe(parent, Rezerwacja);
                    UCSU.Location = new Point((parent.getPanel().Width - UCSU.Width) / 2, (parent.getPanel().Height - UCSU.Height) / 2);
                    parent.getPanel().Controls.Add(UCSU);
                    UCSU.Show();
                    parent.clearPanel();
                }

            }
        }

        
    }
}
