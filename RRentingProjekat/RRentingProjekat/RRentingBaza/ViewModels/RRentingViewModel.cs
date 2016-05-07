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
    class RRentingViewModel 
    {
        public Korisnik korisnik { get; set; }

        public INavigacija NavigationServis { get; set; }
        public ICommand Login { get; set; }
        public ICommand Signup { get; set; }

        public RRentingViewModel()
        {
            NavigationServis = new NavigationService();
            NavigationServis = new NavigationService();
     
            Login = new RelayCommand<object>(login, mozeLiSePrijaviti);
            Signup = new RelayCommand<object>(signup, mozeLiSeRegistrovati);


        }
        private void login(object parametar)
        {
            NavigationServis.Navigate(typeof(Login), new PrijavaViewModel());
        }
        private void signup(object parametar)
        {
            NavigationServis.Navigate(typeof(SignupKorisnik), new RegistracijaViewModel());
        }


        public bool mozeLiSePrijaviti(object parametar)
        {
            return true;
        }
        public bool mozeLiSeRegistrovati(object parametar)
        {
            return true;
        }
    }
}
