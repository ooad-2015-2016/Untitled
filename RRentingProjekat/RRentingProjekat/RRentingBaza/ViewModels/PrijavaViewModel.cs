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
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using RRentingProjekat.RRentingBaza.DataSource;

namespace RRentingProjekat.RRentingBaza.ViewModels
{
    class PrijavaViewModel
    {

        public Gost PrijavljeniGost { get; set; }
        public Korisnik PrijavljeniUposlenik { get; set; }


        public string UnosMail { get; set; }
        public string UnosPass { get; set; }
        public string UnosID { get; set; }

        public ICommand LoginGost { get; set; }
        public ICommand LoginUposlenik { get; set; }
        public INavigacija NavigationServis { get; set; }



        public PrijavaViewModel()
        {
            NavigationServis = new NavigationService();

            UnosMail = "";
            UnosPass = "";
            UnosID = "";

            LoginGost = new RelayCommand<object>(loginGost, mozeLiSePrijavitiGost);
            LoginUposlenik = new RelayCommand<object>(loginUposlenik, mozeLiSePrijavitiUposlenik);
        }


        public bool mozeLiSePrijavitiGost(object parametar)
        {
            return true;
        }
        public bool mozeLiSePrijavitiUposlenik(object parametar)
        {
            return true;
        }

        
        public async void loginGost(object parametar)
        {
            var UnosPassBox = parametar as PasswordBox;
            UnosPass = UnosPassBox.Password;
            
           
            using (var db = new RRentingDbContext())
            {
                PrijavljeniGost = db.Gosti.Where(x => x.Email == UnosMail && x.Sifra == UnosPass && x.SigurnosniID == 0).FirstOrDefault();

                   if (PrijavljeniGost != null)
                    {
                        NavigationServis.Navigate(typeof(GostView), new GostViewModel(this));
                    }
                
                else
                {
                    var dialog = new MessageDialog("Pogrešno korisničko ime/šifra!", "Neuspješna prijava");
                    await dialog.ShowAsync();
                }
                
            }
        }

        public async void loginUposlenik(object parametar)
        {
            var UnosPassBox = parametar as PasswordBox;
            UnosPass = UnosPassBox.Password;

            
            using (var db = new RRentingDbContext())
            {

                int unos = int.Parse(UnosID);
                PrijavljeniUposlenik = DataSourceRRenting.ProvjeraUposlenika(UnosMail, UnosPass, unos);


                if (PrijavljeniUposlenik.Email != null && PrijavljeniUposlenik.Sifra!= null && PrijavljeniUposlenik.SigurnosniID != 0)
                {

                    if (PrijavljeniUposlenik is Sef && PrijavljeniUposlenik.SigurnosniID == unos) NavigationServis.Navigate(typeof(SefView), new SefViewModel(this));
                    else if (PrijavljeniUposlenik is Osoblje) NavigationServis.Navigate(typeof(OsobljeView), new OsobljeViewModel(this));
                    else if (PrijavljeniUposlenik is Recepcioner) NavigationServis.Navigate(typeof(RecepcionerView), new RecepcionerViewModel(this));

                }
                else
                {
                     var dialog = new MessageDialog("Pogrešno korisničko ime/šifra!", "Neuspješna prijava");
                     await dialog.ShowAsync();
                }

            }
        }

        
    }
}
