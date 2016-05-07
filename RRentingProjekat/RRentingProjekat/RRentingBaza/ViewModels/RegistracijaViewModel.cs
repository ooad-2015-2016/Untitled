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
    
    class RegistracijaViewModel
    {
        private static int m_Counter = 0;

        public int Id { get; set; }
        public Gost RegistrovaniKorisnik { get; set; }
        //public string Validacija { get; set; }
        public string txtIme{ get; set; }
        public string txtPrezime { get; set; }
        public string txtAdresa { get; set; }
        public string txtTelefon{ get; set; }
        public string txtEmail { get; set; }
        public string txtPassword { get; set; }

        public INavigacija NavigationServis { get; set; }
        public ICommand SignupKorisnika { get; set; }
        public RegistracijaViewModel()
        {
            NavigationServis = new NavigationService();
            RegistrovaniKorisnik = new Gost();
            SignupKorisnika = new RelayCommand<object>(signup);
            this.Id= System.Threading.Interlocked.Increment(ref m_Counter); ;
        }
        private void signup(object parametar)
        {
            //using (var db = new RRentingDbContext())
                RegistrovaniKorisnik = new Gost(Id, txtIme, txtPrezime, txtTelefon, txtAdresa, txtPassword, txtEmail);
                NavigationServis.Navigate(typeof(RezervacijaListView), new RezervacijaViewModel(this));
                
            

        }
    }
}
