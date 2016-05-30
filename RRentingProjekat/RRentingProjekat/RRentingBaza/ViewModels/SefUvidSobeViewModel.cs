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
    class SefUvidSobeViewModel : INotifyPropertyChanged
    {
        private string sobeOpis;
        public string SobeOpis
        {
            get { return sobeOpis; }
            set { sobeOpis = value; OnPropertyChanged("SobeOpis"); }
        }

        public List<Soba> Sobe { get; set; }

        SefViewModel parent;

        public SefUvidSobeViewModel(SefViewModel svm)
        {
            this.parent = svm;

            Sobe = DataSourceRRenting.DajSveSobe();

            for (int i = 0; i < Sobe.Count(); i++)
            {             
                SobeOpis += "Broj sobe: " + Sobe[i].BrojSobe + "\nBroj kreveta: " + Sobe[i].BrojKreveta + "\nStatus sobe: " + Sobe[i].Status.ToString() + "\nCijena: " + Sobe[i].CijenaSobe + "\n\n";              
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
