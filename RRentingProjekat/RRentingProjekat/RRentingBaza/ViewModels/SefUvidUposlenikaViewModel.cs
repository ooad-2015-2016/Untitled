using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRentingProjekat.RRentingBaza.DataSource;
using RRentingProjekat.RRentingBaza.Models;

namespace RRentingProjekat.RRentingBaza.ViewModels
{
    class SefUvidUposlenikaViewModel : INotifyPropertyChanged
    {

        private string osobljeOpis;
        public string OsobljeOpis
        {
            get { return osobljeOpis; }
            set { osobljeOpis = value; OnPropertyChanged("OsobljeOpis"); }
        }

        public List<Korisnik> Radnici { get; set; }


        public SefUvidUposlenikaViewModel(SefViewModel svm)
        {

            Radnici = DataSourceRRenting.DajSveKorisnike();

            for (int i = 0; i < Radnici.Count(); i++)
            {
                if (Radnici[i] is Osoblje || Radnici[i] is Recepcioner)
                {
                    OsobljeOpis += "Ime i prezime: " + Radnici[i].Ime + " " + Radnici[i].Prezime + "\nAdresa: " + Radnici[i].Adresa + "\nTelefon: " + Radnici[i].Telefon + "\nEmail: " + Radnici[i].Email + "\n\n";
                }
            }
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
}
