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
using Windows.UI.Popups;

namespace RRentingProjekat.RRentingBaza.ViewModels
{
    class RezervacijaViewModel
    {
        public Gost RegistrovaniGost {get; set; }
        public int Id { get; set; }
        public int BrojOdraslihInput { get; set; }
        public int BrojDjeceInput { get; set; }
        public DateTime Dolazak { get; set; }
        public DateTime Odlazak { get; set; }
        public Boolean ParkingRB { get; set; }
        public Boolean LjubimacRB { get; set; }
        public Boolean DodatnikrevetRB { get; set; }

        private static int m_Counter2 = 0;
        public float CijenaInput { get; set; }
        public NacinPlacanja NacinPlacanjaListBox { get; set; }

        public Rezervacija DodanaRezervacija { get; set; }
        public INavigacija NavigationServis { get; set; }
        public ICommand DodajRezervaciju { get; set; }

        RegistracijaViewModel parent;


        Random rnd = new Random();
        public RezervacijaViewModel(RegistracijaViewModel rvm)
        {
           
            RegistrovaniGost = rvm.RegistrovaniKorisnik;
            DodajRezervaciju = new RelayCommand<object>(rezervisi);
            this.Id = System.Threading.Interlocked.Increment(ref m_Counter2);

            BrojDjeceInput = 0;
            BrojOdraslihInput = 0;
            Dolazak = DateTime.Now;
            Odlazak = DateTime.Now;
            ParkingRB = false;
            LjubimacRB = false;
            DodatnikrevetRB = false;
            NacinPlacanjaListBox = NacinPlacanja.Gotovinsko;
            CijenaInput = 0;

            this.parent = rvm;
        }
        private async void rezervisi(object parametar)
        {

   
           
            using (var db = new RRentingDbContext())
            {
                if (BrojOdraslihInput == 0)
                {
                    var d = new MessageDialog("Unesite broj odraslih", "Neuspješna rezervacija");
                    await d.ShowAsync();
                }
                else if (Dolazak.Date == DateTime.Now && Odlazak.Date == DateTime.Now)
                {
                    var d = new MessageDialog("Molimo unesite ispravan datum dolaska i odlaska.", "Neuspješna rezervacija");
                    await d.ShowAsync();
                }
                else
                {
                    Soba slobodnaSoba = DataSource.DataSourceRRenting.dajSlobodnuSobu(DodanaRezervacija);
                    if (slobodnaSoba.CijenaSobe != 0)
                    {
                        parent.RegistrovaniKorisnik.brojSobe = slobodnaSoba.BrojSobe;

                        Rezervacija nova = new Rezervacija(Convert.ToInt32(BrojOdraslihInput), Convert.ToInt32(BrojDjeceInput), Dolazak, Odlazak, ParkingRB, LjubimacRB, DodatnikrevetRB, NacinPlacanjaListBox);
                        nova.izracunajCijenu(Dolazak, Odlazak, slobodnaSoba);

                        int tiket = rnd.Next(1000);
                        parent.RegistrovaniKorisnik.dodijeliTiket(tiket);

                        var dialog = new MessageDialog("Vaš broj tiketa: " + tiket.ToString(), "Rezervacija uspješna");
                        await dialog.ShowAsync();

                        db.Rezervacije.Add(nova);
                        db.SaveChanges();

                        NavigationServis.Navigate(typeof(Pocetna));
                    }
                    else
                    {
                        var d = new MessageDialog("U tom periodu nemamo soba koje odgovaraju Vašim zahtjevima.", "Žao nam je");
                        await d.ShowAsync();
                    }
                }

            }


        }
    }
}
