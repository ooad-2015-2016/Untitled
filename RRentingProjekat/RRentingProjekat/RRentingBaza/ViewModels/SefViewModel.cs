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

namespace RRentingProjekat.RRentingBaza.ViewModels
{
    class SefViewModel
    {

        public ICommand SobaIzbor { get; set; }  
        public ICommand Uposlenici { get; set; }
        public ICommand Statistika { get; set; }
        public INavigacija NavigationServis { get; set; }

        public PrijavaViewModel Parent { get; set; }

        public Soba Soba_ { get; set; }

        public SefViewModel(PrijavaViewModel parent)
        {

            NavigationServis = new NavigationService();

            SobaIzbor = new RelayCommand<object>(sobaIzbor, mozeLiSobuNaci);
            Uposlenici = new RelayCommand<object>(uposlenici, mozeLiUposlenikaNaci);
            Statistika = new RelayCommand<object>(statistika, mozeLiStatistika);

            this.Parent = parent;
        }

        public void sobaIzbor(object parametar)
        {
            
           
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
    }
}
