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
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Drawing.Printing;

namespace UmowyMJ
{
    public partial class UserControlStworzUmowe : UserControl
    {
        string dataPodpisaniaUmowy = "";
        UmowyMJ parent;
        public UserControlStworzUmowe(UmowyMJ parent)
        {
            this.parent = parent;
            parent.refreshUmowyNaZewnatrz();
            InitializeComponent();
            dateTimePickerDataImprezy.Value = DateTime.Now;
        }

        public UserControlStworzUmowe(UmowyMJ parent, String[] Rezerwacja)
        {
            this.parent = parent;
            InitializeComponent();
            parent.refreshUmowyNaZewnatrz();
            textBoxImie.Text = Rezerwacja[0];
            textBoxNazwisko.Text = Rezerwacja[1];
            textBoxNrTelefonu.Text = Rezerwacja[2];
            dateTimePickerDataImprezy.Value = DateTime.Parse (Rezerwacja[3]);
            dataPodpisaniaUmowy = Rezerwacja[4];
            comboBoxRodzajImprezy.SelectedItem = Rezerwacja[5];
        }




        private async void buttonStworzUmowe_Click(object sender, EventArgs e)
        {
            //sprawdzenie połączenia z internetem
            if (!parent.CheckForInternetConnection()) return;
            //walidacja pól formularza
            if (!CzyZwalidowany())
            {
                MessageBox.Show("Niepoprawnie wypełniony formularz !", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!walidujTermin())
            {
                MessageBox.Show("Ten termin na usługę muzyczną jest już zajęty !", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dataPodpisaniaUmowy=="" && !walidujRezerwacje())
            {
                MessageBox.Show("Posiadasz rezerwację na termin. Aby sporządzić umowę skorzystaj z rezerwacji, bądź usuń rezerwację na dany termin!", "Usługa muzyczna - błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //stworzenie klasy Umowa
                Umowa nowa = new Umowa();
                string kluczGlowny = null;
                //przypisania wartości z formularza do pól klasy Umowa
                nowa.imie = textBoxImie.Text.ToString();   
                nowa.nazwisko = textBoxNazwisko.Text;
                nowa.pesel = textBoxPesel.Text;
                nowa.nrDowoduOsobistego = textBoxNrDowoduOsobistego.Text;
                nowa.nrTelefonu = textBoxNrTelefonu.Text;
                nowa.ulica = textBoxUlica.Text;
                nowa.kodPocztowy = textBoxKodPocztowy1.Text + "-" + textBoxKodPocztowy2.Text;
                nowa.miejscowosc = textBoxMiejscowosc.Text;
                nowa.rodzajImprezy = comboBoxRodzajImprezy.SelectedItem.ToString();
                nowa.dataImprezy = dateTimePickerDataImprezy.Value.ToString("yyyy-MM-dd");
                nowa.godzinaRozpoczecia = dateTimePickerGodzinaRozpoczecia.Value.ToString("HH:mm");
                nowa.godzinaZakonczenia = dateTimePickerGodzinaZakonczenia.Value.ToString("HH:mm");
                nowa.miejsceImprezy = textBoxMiejsceImprezy.Text;
                if (checkBoxPoprawinyTak.Checked) nowa.poprawiny = true;
                else nowa.poprawiny = false;
                nowa.cenaUslugiMuzycznej = (int)numericUpDownCenaUslugiMuzycznej.Value;
                foreach (string item in checkedListBoxOpcjeDodatkowe.CheckedItems)
                {
                    nowa.opcjeDodatkowe += item + ", ";
                }
                if (nowa.opcjeDodatkowe.Length > 0)

                nowa.opcjeDodatkowe = nowa.opcjeDodatkowe.Substring(0, nowa.opcjeDodatkowe.Length - 2);
                nowa.cenaOpcjiDodatkowych = (int)numericUpDownCenaOpcjiDodatkowych.Value;
                nowa.dataPodpisaniaUmowy = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
               
                //Tworzenie klucza głównego 
                if (dataPodpisaniaUmowy == "")               
                    kluczGlowny = nowa.dataPodpisaniaUmowy;
                else
                    kluczGlowny = dataPodpisaniaUmowy;


                nowa.kompletnoscUmowy = true;
                //Tworzenie klasy Umowa w JSON oraz zapisanie jej na serwerze Firebase.
                SetResponse response = await parent.client.SetTaskAsync("Umowy/" + kluczGlowny, nowa);
                Umowa result = response.ResultAs<Umowa>();
                DialogResult dialogResult = MessageBox.Show("Pomyślnie dodano umowę do bazy danych. Czy chcesz wydrukować umowę?", 
                                                            "", MessageBoxButtons.YesNo);
                //Odświeżenie rekordów w kontrolkach UserControlRejestrRezerwacji oraz UserControlRejestZawartychUmow
                parent.refreshUmowyNaZewnatrz();

                parent.FolderZawarteUmowy = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MJ - Zawarte umowy\" + dateTimePickerDataImprezy.Value.ToString("yyyy") + @"\";
                if (!Directory.Exists(parent.FolderZawarteUmowy))
                    Directory.CreateDirectory(parent.FolderZawarteUmowy);

                //Pytanie o wydrukowanie umowy
                if (dialogResult == DialogResult.Yes)
                {
                    //Stworzenie pliku WORD wraz z wypełnionymi danymi z klasy Umowa na dysku
                    CreateWordDocument(parent.FolderSzablonow + @"\Umowa - szablon.doc", parent.FolderZawarteUmowy + nowa.dataImprezy + rodzajUslugi() + ".doc" );
                    //Stworzenie ścieżki do pliku do wydruku.
                    string docName = nowa.dataImprezy + rodzajUslugi() + ".doc";
                    PrintWordDocument(parent.FolderZawarteUmowy + docName);
                }
                else if (dialogResult == DialogResult.No)
                {

                    CreateWordDocument(parent.FolderSzablonow + @"Umowa - szablon.doc", parent.FolderZawarteUmowy + nowa.dataImprezy + rodzajUslugi() + ".doc");
                }
                UserControlStworzUmowe UCSU = new UserControlStworzUmowe(parent);
                UCSU.Location = new Point((parent.getPanel().Width - UCSU.Width) / 2, (parent.getPanel().Height - UCSU.Height) / 2);
                parent.getPanel().Controls.Clear();
                parent.getPanel().Controls.Add(UCSU);
                UCSU.Show();
            }



        }


        private void PrintWordDocument(object filename)
        {
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;

            if (File.Exists((string)filename))
            {
                object readOnly = false;
                object isVisible = false;
                wordApp.Visible = false;

                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();
                object copies = 2;
                myWordDoc.PrintOut(ref missing, ref missing, ref missing,
                                     ref missing, ref missing, ref missing,
                                     ref missing, ref copies, ref missing,
                                     ref missing, ref missing, ref missing,
                                     ref missing, ref missing, ref missing,
                                     ref missing, ref missing, ref missing);
            }
            else
            {
                MessageBox.Show("Nie odnaleziono pliku!");
            }
            myWordDoc.Close();
            wordApp.Quit();
        }

        private void checkBoxPoprawinyTak_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPoprawinyTak.Checked)
            {
                checkBoxPoprawinyNie.Checked = false;
                checkBoxPoprawinyTak.Checked = true;
            }
            if (checkBoxPoprawinyTak.ForeColor != Color.Black)
            {
                checkBoxPoprawinyTak.ForeColor = Color.Black;
                checkBoxPoprawinyNie.ForeColor = Color.Black;
            }
        }

        private void checkBoxPoprawinyNie_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPoprawinyNie.Checked)
            {
                checkBoxPoprawinyTak.Checked = false;
                checkBoxPoprawinyNie.Checked = true;
            }
            if (checkBoxPoprawinyNie.ForeColor != Color.Black)
            {
                checkBoxPoprawinyNie.ForeColor = Color.Black;
                checkBoxPoprawinyTak.ForeColor = Color.Black;
            }       
        }

        private bool WalidujDate()
        {
            DateTime DT = DateTime.Now;
            if (DT.ToOADate() < dateTimePickerDataImprezy.Value.ToOADate())
                return false;
            else return true;
        }

        private bool CzyZwalidowany()
        {
            bool wynik = true;

            if(textBoxImie.Text=="")
            {
                textBoxImie.BackColor = Color.LightPink;
                wynik = false;
            }
            else if (!textBoxImie.Text.All(Char.IsLetter))
            {
                textBoxImie.BackColor = Color.LightPink;
                wynik = false;
            }

            if (textBoxNazwisko.Text == "")
            {
                textBoxNazwisko.BackColor = Color.LightPink;
                wynik = false;
            }
            else if(!textBoxNazwisko.Text.All(Char.IsLetter))
            {
                textBoxNazwisko.BackColor = Color.LightPink;
                wynik = false;
            }

            if (!WalidujPesel())
            {
                textBoxPesel.BackColor = Color.LightPink;
                wynik = false;
            }

            if (textBoxNrDowoduOsobistego.Text == "" || textBoxNrDowoduOsobistego.Text.Length != 9)
            {
                textBoxNrDowoduOsobistego.BackColor = Color.LightPink;
                wynik = false;
            }

            else if(!textBoxNrDowoduOsobistego.Text.Substring(0, 3).All(char.IsLetter) ||
                    !textBoxNrDowoduOsobistego.Text.Substring(3).All(char.IsDigit))
            {
                textBoxNrDowoduOsobistego.BackColor = Color.LightPink;
                wynik = false;
            }

            if (textBoxNrTelefonu.Text == "" || !textBoxNrTelefonu.Text.All(Char.IsDigit))
            {
                textBoxNrTelefonu.BackColor = Color.LightPink;
                wynik = false;
            }
                
            if (textBoxUlica.Text == "")
            {
                textBoxUlica.BackColor = Color.LightPink;
                wynik = false;
            }

            if (textBoxKodPocztowy1.Text=="" || textBoxKodPocztowy1.Text.Length != 2)
            {
                textBoxKodPocztowy1.BackColor = Color.LightPink;                
                wynik = false;
            }
            else if(!textBoxKodPocztowy1.Text.All(Char.IsDigit))
            {
                textBoxKodPocztowy1.BackColor = Color.LightPink;
                wynik = false;                
            }

            if (textBoxKodPocztowy2.Text == "" || textBoxKodPocztowy2.Text.Length != 3)
            {
                textBoxKodPocztowy2.BackColor = Color.LightPink;
                wynik = false;
            }
            else if(!textBoxKodPocztowy2.Text.All(Char.IsDigit))
            {
                textBoxKodPocztowy2.BackColor = Color.LightPink;
                wynik = false;
            }

            if (textBoxMiejscowosc.Text == "")
            {
                textBoxMiejscowosc.BackColor = Color.LightPink;
                wynik = false;
            }

            char[] Miejscowosc = textBoxMiejscowosc.Text.ToCharArray();
            for (int i = 0; i < textBoxMiejscowosc.Text.Length; i++)
            {
                if (!Char.IsDigit(Miejscowosc[i]) && !Char.IsLetter(Miejscowosc[i]) && !Char.IsWhiteSpace(Miejscowosc[i]))
                {
                    textBoxMiejscowosc.BackColor = Color.LightPink;
                    wynik = false;
                    break;
                }
            }

            if (comboBoxRodzajImprezy.Text == "")
            {
                comboBoxRodzajImprezy.BackColor = Color.LightPink;
                wynik = false;
            }
            
            if (WalidujDate())
            {
                panelCheckDate.Visible = true;
                wynik = false;
            }

            if (textBoxMiejsceImprezy.Text == "")
            {
                textBoxMiejsceImprezy.BackColor = Color.LightPink;
                wynik = false;
            }

            if (checkBoxPoprawinyTak.Checked==false && checkBoxPoprawinyNie.Checked==false)
            {
                checkBoxPoprawinyTak.ForeColor = Color.LightPink;
                checkBoxPoprawinyNie.ForeColor = Color.LightPink;
                wynik = false;
            }

            return wynik;
        }
        
        private void Ctrl_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            ctrl.BackColor = Color.White;            
        }

        private bool walidujTermin()
        {
            bool wynik = true;
            foreach (Umowa item in parent.spisUmow)
            {
                if (item.kompletnoscUmowy == true)
                {
                    if (item.dataImprezy == dateTimePickerDataImprezy.Value.ToString("yyyy-MM-dd") && item.cenaUslugiMuzycznej > 0)
                    {
                        panelCheckDate.Visible = true;
                        wynik = false;
                        break;
                    }
                }
            }
            return wynik;
        }
        private bool walidujRezerwacje()
        {
            bool wynik = true;
            foreach (Umowa item in parent.spisUmow)
            {
                if (item.kompletnoscUmowy == false)
                {
                    if (item.dataImprezy == dateTimePickerDataImprezy.Value.ToString("yyyy-MM-dd") && item.cenaUslugiMuzycznej > 0)
                    {
                        panelCheckDate.Visible = true;
                        wynik = false;
                        break;
                    }
                }
            }
            return wynik;
        }

        private bool WalidujPesel()
        {
            if (textBoxPesel.Text == "" || !textBoxPesel.Text.All(Char.IsDigit) || textBoxPesel.Text.Length != 11)
                return false;

            int[] mnoznik = { 9, 7, 3, 1, 9, 7, 3, 1, 9, 7 };
            int suma = 0;

            for (int i = 0; i < 10; i++)
            {
                suma += mnoznik[i] * int.Parse(textBoxPesel.Text[i].ToString());
            }
            int reszta = suma % 10;
            if (reszta == int.Parse(textBoxPesel.Text[10].ToString()))
                return true;

            return false;
        }

        private void dateTimePickerDataImprezy_ValueChanged(object sender, EventArgs e)
        {
            panelCheckDate.Visible = false;
        }

        private void FindAndReplace(Word.Application wordApp, object ToFindText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object nmatchAllforms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiactitics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            wordApp.Selection.Find.Execute(ref ToFindText,
            ref matchCase, ref matchWholeWord,
            ref matchWildCards, ref matchSoundLike,
            ref nmatchAllforms, ref forward,
            ref wrap, ref format, ref replaceWithText,
            ref replace, ref matchKashida,
            ref matchDiactitics, ref matchAlefHamza,
            ref matchControl);
        }

        private void CreateWordDocument(object filename, object SaveAs)
        {
        Word.Application wordApp = new Word.Application();
        object missing = Missing.Value;
        Word.Document myWordDoc = null;

        if (File.Exists((string)filename))
        {
        object readOnly = false;
        object isVisible = false;
        wordApp.Visible = false;

        myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                              ref missing, ref missing, ref missing,
                              ref missing, ref missing, ref missing,
                              ref missing, ref missing, ref missing,
                              ref missing, ref missing, ref missing, ref missing);
        myWordDoc.Activate();

                this.FindAndReplace(wordApp, "<DATA NOW()>", DateTime.Now.ToShortDateString());
                this.FindAndReplace(wordApp, "<IMIE I NAZWISKO>", textBoxImie.Text + " " + textBoxNazwisko.Text);
                this.FindAndReplace(wordApp, "<ULICA>", textBoxUlica.Text);
                this.FindAndReplace(wordApp, "<KOD POCZTOWY MIEJSCOWOSC>", textBoxKodPocztowy1.Text + "-" + textBoxKodPocztowy2.Text + " " + textBoxMiejscowosc.Text);
                this.FindAndReplace(wordApp, "<NR DOWODU>", textBoxNrDowoduOsobistego.Text);
                this.FindAndReplace(wordApp, "<NR PESELU>", textBoxPesel.Text);
                this.FindAndReplace(wordApp, "<NR TEL>", textBoxNrTelefonu.Text);
                this.FindAndReplace(wordApp, "<RODZAJ IMPREZY>", comboBoxRodzajImprezy.Text);
                this.FindAndReplace(wordApp, "<DATA IMPREZY>", dateTimePickerDataImprezy.Value.ToShortDateString());
                this.FindAndReplace(wordApp, "<GODZ OD>", dateTimePickerGodzinaRozpoczecia.Value.ToShortTimeString());
                this.FindAndReplace(wordApp, "<GODZ DO>", dateTimePickerGodzinaZakonczenia.Value.ToShortTimeString());
                this.FindAndReplace(wordApp, "<MIEJSCE IMPREZY>", textBoxMiejsceImprezy.Text);
                if (checkBoxPoprawinyTak.Checked)
                    this.FindAndReplace(wordApp, "<TAK/NIE>", "Tak");
                else
                    this.FindAndReplace(wordApp, "<TAK/NIE>", "Nie");
                string tekst = "";
                foreach (string item in checkedListBoxOpcjeDodatkowe.CheckedItems)
                {
                    tekst += item + ", ";
                }
                if (tekst.Length > 0)
                    tekst = tekst.Substring(0, tekst.Length - 2);
                this.FindAndReplace(wordApp, "<OPCJE DODATKOWE>", tekst);
                int koszt = (int) numericUpDownCenaOpcjiDodatkowych.Value + (int)numericUpDownCenaUslugiMuzycznej.Value;
                this.FindAndReplace(wordApp, "<KOSZT IMPREZY>", koszt.ToString());

            }
        else
        {
                MessageBox.Show("Nie znaleziono szablonu umowy! Spróbuj ponownie");
                return;
            }

            myWordDoc.SaveAs(ref SaveAs, ref missing, ref missing, ref missing,
                      ref missing, ref missing, ref missing,
                      ref missing, ref missing, ref missing,
                      ref missing, ref missing, ref missing,
                      ref missing, ref missing, ref missing);

            myWordDoc.Close();
            wordApp.Quit();
            MessageBox.Show("Pomyślnie wygenerowano umowę. Znajdziesz ją w folderze\n" + parent.FolderZawarteUmowy.Substring(0, parent.FolderZawarteUmowy.Length-1));
        }

        private string rodzajUslugi()
        {
            string wynik ="";
            if (numericUpDownCenaUslugiMuzycznej.Value > 0 && numericUpDownCenaOpcjiDodatkowych.Value > 0)
            {
                wynik = " Muzyczna + Oświetlenie";
            }
            else if (numericUpDownCenaUslugiMuzycznej.Value > 0)
            {
                wynik = " Muzyczna";
            }
            return wynik;
        }



        private void checkedListBoxOpcjeDodatkowe_SelectedValueChanged(object sender, EventArgs e)
        {
            if (checkedListBoxOpcjeDodatkowe.CheckedItems.Count > 0)
            {
                checkedListBoxOpcjeDodatkowe.ForeColor = Color.Black;
                checkedListBoxOpcjeDodatkowe.Font = new Font(checkedListBoxOpcjeDodatkowe.Font, FontStyle.Regular);
            }

        }

        private void UserControlStworzUmowe_Click(object sender, EventArgs e)
        {
            checkedListBoxOpcjeDodatkowe.ClearSelected();
        }
    }
}
