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
    class OsobljeViewModel
    {
        public INavigacija NavigationServis { get; set; }
        public PrijavaViewModel Parent { get; set; }
        public Zahtjev Zahtjev_ { get; set; }
        public Soba Soba_ { get; set; }
        public int brojSobe_ { get; set; }
        public bool Obavljeno_ { get; set; }
        public ICommand SpasiPromjene { get; set; }
        public OsobljeViewModel(PrijavaViewModel parent)
        {

            NavigationServis = new NavigationService();
            SpasiPromjene = new RelayCommand<object>(spasiPromjene, mozeLiUpdateovati);
            this.Parent = parent;
        }
        public void spasiPromjene(object parametar)
        {


        }
        public bool mozeLiUpdateovati(object parametar)
        {
            return true;
        }

    }
}
