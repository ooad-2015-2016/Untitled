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
    class RezervacijaViewModel : INotifyPropertyChanged
    {
        public Gost RegistrovaniGost { get; set; }
        public int Id { get; set; }
        public int BrojOdraslihInput { get; set; }
        public int BrojDjeceInput { get; set; }

        public DateTime Dolazak { get; set; }
        public DateTime Odlazak { get; set; }
        public Boolean ParkingRB { get; set; }
        public Boolean LjubimacRB { get; set; }
        public Boolean DodatnikrevetRB { get; set; }
        private int izabraniNacin;
        private static int m_Counter2 = 0;
        public float CijenaInput { get; set; }
        public string nacin_str { get; set; }
        public NacinPlacanja nacin { get; set; }

        public Rezervacija DodanaRezervacija { get; set; }
        public INavigacija NavigationServis { get; set; }

        public ICommand DodajRezervaciju { get; set; }


        RegistracijaViewModel parent;



        Random rnd;
        public RezervacijaViewModel(RegistracijaViewModel rvm)
        {
            NavigationServis = new NavigationService();

            
            rnd = new Random();

            DodajRezervaciju = new RelayCommand<object>(rezervisi, mozeLiRezervisati);
            this.Id = System.Threading.Interlocked.Increment(ref m_Counter2);
            RegistrovaniGost = rvm.RegistrovaniKorisnik;
            this.parent = rvm;
        }

        public bool mozeLiRezervisati(object parametar)
        {
            return true;
        }
        private async void rezervisi(object parametar)
        {
            using (var db = new RRentingDbContext())
            {

                //validacija
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
                    nacin_str = IzabraniNacin.ToString();
                    if (nacin_str == "Gotovinsko") nacin = NacinPlacanja.Gotovinsko;
                    else nacin = NacinPlacanja.Karticom;
                    Dolazak = ConvertFromDateTimeOffset(Dolazak.Date);
                    Odlazak = ConvertFromDateTimeOffset(Odlazak.Date);

                    Rezervacija nova = new Rezervacija(Convert.ToInt32(BrojOdraslihInput), Convert.ToInt32(BrojDjeceInput), Dolazak, Odlazak, ParkingRB, LjubimacRB, DodatnikrevetRB, nacin);
                    Soba slobodnaSoba = DataSource.DataSourceRRenting.dajSlobodnuSobu(nova);

                    /* if (slobodnaSoba.CijenaSobe != 0)
                     {
                         Gost gost;
                         int tiket = rnd.Next(1000);
                         using (var rdb = new RRentingDbContext())
                         {
                             gost = rdb.Gosti.Where(x => x.Email ==  parent.RegistrovaniKorisnik.Email && x.Sifra == parent.RegistrovaniKorisnik.Sifra && x.SigurnosniID == 0).FirstOrDefault();
                             if (gost != null)
                             {
                                 gost.brojSobe = slobodnaSoba.BrojSobe;
                                 gost.dodijeliTiket(tiket);
                             }
                         }
                         //update changes
                         using (var rdb = new RRentingDbContext())
                         {
                             rdb.Entry(gost).State = Microsoft.Data.Entity.EntityState.Modified;
                             rdb.SaveChanges();
                         }
                         nova.izracunajCijenu(Dolazak, Odlazak, slobodnaSoba);
                         
     */


                    db.Rezervacije.Add(nova);
                    db.SaveChanges();

                    // var dialog = new MessageDialog("Vaš broj tiketa: " + tiket.ToString(), "Rezervacija uspješna");
                    //await dialog.ShowAsync();

                    BrojDjeceInput = 0;
                    BrojOdraslihInput = 0;
                    Dolazak = DateTime.Now;
                    Odlazak = DateTime.Now;
                    ParkingRB = false;
                    LjubimacRB = false;
                    DodatnikrevetRB = false;
                    CijenaInput = 0;

                    NavigationServis.Navigate(typeof(Pocetna));



                    /* else
                     {
                     NavigationServis.Navigate(typeof(Login));
                     var d = new MessageDialog("U tom periodu nemamo soba koje odgovaraju Vašim zahtjevima.", "Žao nam je");
                     await d.ShowAsync();
                 }
                 */
                }

            }
        }











        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public int IzabraniNacin
        {
            get { return izabraniNacin; }
            set
            {
                OnPropertyChanged("IzabraniNacin");
                izabraniNacin = value;
            }
        }

        static DateTime ConvertFromDateTimeOffset(DateTimeOffset dateTime)
        {
            if (dateTime.Offset.Equals(TimeSpan.Zero))
                return dateTime.UtcDateTime;
            else if (dateTime.Offset.Equals(TimeZoneInfo.Local.GetUtcOffset(dateTime.DateTime)))
                return DateTime.SpecifyKind(dateTime.DateTime, DateTimeKind.Local);
            else
                return dateTime.DateTime;
        }
    }
}
