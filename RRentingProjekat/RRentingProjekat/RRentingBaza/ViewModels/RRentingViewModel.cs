using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRentingProjekat.RRentingBaza.Models;
using RRentingProjekat.RRentingBaza.Helper;
using System.Windows.Input;
using RRentingProjekat.RRentingBaza.Views;
using RRentingProjekat.RRentingBaza.Forms;

namespace RRentingProjekat.RRentingBaza.ViewModels
{
    class RRentingViewModel 
    {
        public Osoba korisnik { get; set; }
        //public string Validacija { get; set; }
       // public string Email { get; set; }
        //public string Password { get; set; }

        public INavigacija NavigationServis { get; set; }
        public ICommand LoginKorisnika { get; set; }
        public ICommand SignupKorisnika { get; set; }
        public RRentingViewModel()
        {
            NavigationServis = new NavigationService();
            korisnik = new Osoba();
            LoginKorisnika = new RelayCommand<object>(login);


        }
        private void login(object parametar)
        {
            //NavigationServis.Navigate(typeof(Login),new )
        }
    }
}
