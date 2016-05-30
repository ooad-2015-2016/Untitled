using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRentingProjekat.RRentingBaza.Models;
using System.Windows.Input;
using Windows.UI.Xaml;
using RRentingProjekat.RRentingBaza.Helper;
using RRentingProjekat.RRentingBaza.Views;
using System.ComponentModel;
using System.Collections.ObjectModel;
using RRentingProjekat.RRentingBaza.DataSource;

namespace RRentingProjekat.RRentingBaza.ViewModels
{
    class SefViewModel : INotifyPropertyChanged
    {

        public ICommand Sobe{ get; set; }  
        public ICommand Uposlenici { get; set; }
        public ICommand Statistika { get; set; }

        public INavigacija NavigationServis { get; set; }

        public PrijavaViewModel Parent { get; set; }

       

        public SefViewModel(PrijavaViewModel parent)
        {

            NavigationServis = new NavigationService();

            Sobe = new RelayCommand<object>(sobaIzbor, mozeLiSobuNaci);
            Uposlenici = new RelayCommand<object>(uposlenici, mozeLiUposlenikaNaci);
            Statistika = new RelayCommand<object>(statistika, mozeLiStatistika);

            this.Parent = parent;
        }

        public void sobaIzbor(object parametar)
        {
            NavigationServis.Navigate(typeof(UvidSobaView), new SefUvidSobeViewModel(this));

        }

        public void uposlenici(object parametar)
        {
            NavigationServis.Navigate(typeof(UvidUposlenikaView), new SefUvidUposlenikaViewModel(this));
        }

        public void statistika(object parametar)
        {

        }

        public bool mozeLiSobuNaci(object parametar)
        {
            return true;
        }
        public bool mozeLiUposlenikaNaci(object parametar)
        {
            return true;
        }
        public bool mozeLiStatistika(object parametar)
        {
            return true;
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
