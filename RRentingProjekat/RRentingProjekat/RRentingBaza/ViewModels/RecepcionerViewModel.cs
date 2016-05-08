using RRentingProjekat.RRentingBaza.Helper;
using RRentingProjekat.RRentingBaza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RRentingProjekat.RRentingBaza.ViewModels
{
    class RecepcionerViewModel
    {
        //public string Validacija { get; set; }


        public INavigacija NavigationServis { get; set; }
        public ICommand LoginKorisnika { get; set; }
        //public RecepcionerViewModel(PrijavaViewModel pvm)
        //{
        //    Recepcioner = pvm.Recepcioner;
        //}

        public RecepcionerViewModel()
        {
            NavigationServis = new NavigationService();
            //            logout = new RelayCommand<object>(logout);
        }
        private void logout(object parametar)
        {
            //using (var db = new RRentingDbContext())

            //          NavigationServis.Navigate(typeof(Login), new PrijavaViewModel(this));



        }
    }
}