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
using RRentingProjekat.RRentingBaza.DataSource;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;

namespace RRentingProjekat.RRentingBaza.ViewModels
{

    class RegistracijaViewModel
    {
        private static int m_Counter = 0;

        public int Id { get; set; }
        public Gost RegistrovaniKorisnik { get; set; }
        public string UIme { get; set; }
        public string UPrezime { get; set; }
        public string UAdresa { get; set; }
        public string UTelefon { get; set; }
        public string UEmail { get; set; }
        public string UPassword { get; set; }

        public INavigacija NavigationServis { get; set; }
        public ICommand SignupKorisnika { get; set; }
        public RegistracijaViewModel()
        {
            NavigationServis = new NavigationService();
            RegistrovaniKorisnik = new Gost();
            UIme = "";
            UPassword = "";
            UPrezime = "";
            UAdresa = "";
            UEmail = "";
            UTelefon = "";
            SignupKorisnika = new RelayCommand<object>(signup, mozeLiSeRegistrovati);
            this.Id = System.Threading.Interlocked.Increment(ref m_Counter);


        }
        public bool mozeLiSeRegistrovati(object parametar)
        {
            return true;
        }

      
        private async void signup(object parametar)
        {
            var UnosPassBox1 = parametar as PasswordBox;
            UPassword = UnosPassBox1.Password;
            //using (var db = new RRentingDbContext()) { --> validacija }


            //validacija:
            if (UIme.Length == 0 || UPrezime.Length == 0 || UAdresa.Length == 0 || UTelefon.Length == 0 || UPassword.Length == 0 || UEmail.Length == 0)
            {
                var dialog = new MessageDialog("Unesite sve tražene podatke", "Neuspješna prijava");
                await dialog.ShowAsync();
            }
            else if (UIme.Length < 3 || UPrezime.Length < 3 || UAdresa.Length < 3)
            {
                var dialog = new MessageDialog("Prekratki su ime/prezime/adresa.", "Neuspješna prijava");
                await dialog.ShowAsync();
            }
            else if (UTelefon.Length < 6)
            {

                var dialog = new MessageDialog("Neispravan format telefona", "Neuspješna prijava");
                await dialog.ShowAsync();
            }
        
            else if (UPassword.Length < 4 || !UEmail.Contains("@") || !UEmail.Contains("."))
            {
               
                var dialog = new MessageDialog("Password je prekratak/Email nije ispravan.", "Neuspješna prijava");
                await dialog.ShowAsync();
            }

            else
            {
                var dialog = new MessageDialog("Prijava uspješno završena.Dobrodošli!", "Uspješna prijava");
                await dialog.ShowAsync();

                //using (var db = new RRentingDbContext())
                // db.Korisnici.Add(RegistrovaniKorisnik);
                //db.SaveChanges();
                RegistrovaniKorisnik = new Gost(Id, UIme, UPrezime, UTelefon, UAdresa, UPassword, UEmail, 0);

                NavigationServis.Navigate(typeof(RezervacijaView), new RezervacijaViewModel(this));
            }
               

        }
    }
}
