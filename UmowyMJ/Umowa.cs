using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmowyMJ
{
    class Umowa
    {
        private string Imie;
        private string Nazwisko;
        private string PESEL;
        private string NrDowoduOsobistego;
        private string NrTelefonu;
        private string Ulica;
        private string KodPocztowy;
        private string Miejscowosc;
        private string RodzajImprezy;
        private string DataImprezy;
        private string GodzinaRozpoczecia;
        private string GodzinaZakonczenia;
        private string MiejsceImprezy;
        private bool Poprawiny;
        private int CenaUslugiMuzycznej;
        private string OpcjeDodatkowe = "";
        private int CenaOpcjiDodatkowych;
        private string DataPodpisaniaUmowy;
        private bool KompletnoscUmowy;

        public string imie { get => Imie; set => Imie = value; }
        public string nazwisko { get => Nazwisko; set => Nazwisko = value; }
        public string pesel { get => PESEL; set => PESEL = value; }
        public string nrDowoduOsobistego { get => NrDowoduOsobistego; set => NrDowoduOsobistego = value; }
        public string ulica { get => Ulica; set => Ulica = value; }
        public string kodPocztowy { get => KodPocztowy; set => KodPocztowy = value; }
        public string miejscowosc { get => Miejscowosc; set => Miejscowosc = value; }
        public string rodzajImprezy { get => RodzajImprezy; set => RodzajImprezy = value; }
        public string dataImprezy { get => DataImprezy; set => DataImprezy = value; }
        public string godzinaRozpoczecia { get => GodzinaRozpoczecia; set => GodzinaRozpoczecia = value; }
        public string godzinaZakonczenia { get => GodzinaZakonczenia; set => GodzinaZakonczenia = value; }
        public string miejsceImprezy { get => MiejsceImprezy; set => MiejsceImprezy = value; }
        public bool poprawiny { get => Poprawiny; set => Poprawiny = value; }
        public int cenaUslugiMuzycznej { get => CenaUslugiMuzycznej; set => CenaUslugiMuzycznej = value; }
        public string opcjeDodatkowe { get => OpcjeDodatkowe; set => OpcjeDodatkowe = value; }
        public int cenaOpcjiDodatkowych { get => CenaOpcjiDodatkowych; set => CenaOpcjiDodatkowych = value; }
        public string dataPodpisaniaUmowy { get => DataPodpisaniaUmowy; set => DataPodpisaniaUmowy = value; }
        public bool kompletnoscUmowy { get => KompletnoscUmowy; set => KompletnoscUmowy = value; }
        public string nrTelefonu { get => NrTelefonu; set => NrTelefonu = value; }
    }
}
