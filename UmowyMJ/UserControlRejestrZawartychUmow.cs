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
    public partial class UserControlRejestrZawartychUmow : UserControl
    {
        DataTable dt = new DataTable();
        UmowyMJ parent;

        public UserControlRejestrZawartychUmow(UmowyMJ parent)
        {
            this.parent = parent;
            InitializeComponent();
            parent.refreshUmowyNaZewnatrz();
            AddColumns();
            AddRowToGrid();
        }

        private void AddColumns()
        {
            dt.Columns.Add("Typ usługi");
            dt.Columns.Add("Data imprezy");
            dt.Columns.Add("Rodzaj imprezy");
            dt.Columns.Add("Imię");
            dt.Columns.Add("Nazwisko");
            dt.Columns.Add("PESEL");
            dt.Columns.Add("Nr dowodu osobistego");
            dt.Columns.Add("Nr telefonu");
            dt.Columns.Add("Adres zamieszkania");
            dt.Columns.Add("Godzina rozpoczęcia");
            dt.Columns.Add("Godzina zakonczenia");
            dt.Columns.Add("Sala");
            dt.Columns.Add("Poprawiny");
            dt.Columns.Add("Cena usługi muzycznej (zł)");
            dt.Columns.Add("Opcje Dodatkowe");
            dt.Columns.Add("Cena opcji dodatkowych (zł)");
            dt.Columns.Add("Data podpisania umowy");

            dataGridView1.DataSource = dt;
        }

        private void AddRowToGrid()
        {
            foreach (Umowa item in parent.spisUmow)
            {
                if (item.kompletnoscUmowy == true)
                {
                    DataRow row = dt.NewRow();
                    if (item.cenaOpcjiDodatkowych > 0 && item.cenaUslugiMuzycznej > 0)
                        row["Typ usługi"] = "Muzyczna + Oświetlenie";
                    else if (item.cenaOpcjiDodatkowych == 0 && item.cenaUslugiMuzycznej > 0)
                        row["Typ usługi"] = "Muzyczna";
                    else if (item.cenaOpcjiDodatkowych > 0 && item.cenaUslugiMuzycznej == 0)
                        row["Typ usługi"] = "Oświetlenie";
                    row["Data imprezy"] = item.dataImprezy;
                    row["Rodzaj imprezy"] = item.rodzajImprezy;
                    row["Imię"] = item.imie;
                    row["Nazwisko"] = item.nazwisko;
                    row["PESEL"] = item.pesel;
                    row["Nr dowodu osobistego"] = item.nrDowoduOsobistego;
                    row["Nr telefonu"] = item.nrTelefonu;
                    row["Adres zamieszkania"] = item.ulica + ", " + item.kodPocztowy + " " + item.miejscowosc;
                    row["Godzina rozpoczęcia"] = item.godzinaRozpoczecia;
                    row["Godzina zakonczenia"] = item.godzinaZakonczenia;
                    row["Sala"] = item.miejsceImprezy;
                    if (item.poprawiny == true)
                        row["Poprawiny"] = "tak";
                    else row["Poprawiny"] = "nie";
                    row["Cena usługi muzycznej (zł)"] = item.cenaUslugiMuzycznej;
                    row["Opcje Dodatkowe"] = item.opcjeDodatkowe;
                    row["Cena opcji dodatkowych (zł)"] = item.cenaOpcjiDodatkowych;
                    row["Data podpisania umowy"] = item.dataPodpisaniaUmowy;
                    dt.Rows.Add(row);
                }
            }
        }

        private async void buttonUsun_Click(object sender, EventArgs e)
        {
            if (!parent.CheckForInternetConnection()) return;
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                string DataPodpisaniaUmowy = row.Cells["Data podpisania umowy"].Value.ToString();
                string DataImprezy = row.Cells["Data imprezy"].Value.ToString();
                string Imie = row.Cells["Imię"].Value.ToString();
                string Nazwisko = row.Cells["Nazwisko"].Value.ToString();

                DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz usunąć umowę " + Imie + " " + Nazwisko + ", termin " + DataImprezy + "?", "Usuń umowę", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    FirebaseResponse response = await parent.client.DeleteTaskAsync("Umowy/" + DataPodpisaniaUmowy);
                    MessageBox.Show("Umowa została pomyślnie usunieta z bazy danych.");
                    dataGridView1.Rows.RemoveAt(rowIndex);
                    buttonUsun.Visible = false;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
                buttonUsun.Visible = true;
            else buttonUsun.Visible = false;
        }
    }
}
