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
    class RezervacijaViewModel
    {
        public Gost RegistrovaniGost {get; set; }
        public INavigacija NavigationServis { get; set; }
        public ICommand DodajRezervaciju { get; set; }
        public RezervacijaViewModel(RegistracijaViewModel rvm)
        {
            RegistrovaniGost = rvm.RegistrovaniKorisnik;
        }
    }
}
