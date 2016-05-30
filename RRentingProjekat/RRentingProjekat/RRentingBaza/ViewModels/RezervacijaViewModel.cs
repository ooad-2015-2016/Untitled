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
        
        public int Id { get; set; }

        
       
        private static int m_Counter2 = 0;
        public string nacin_str { get; set; }
        public NacinPlacanja nacin { get; set; }

        public INavigacija NavigationServis { get; set; }
        public ICommand DodajRezervaciju { get; set; }


        public Gost gost { get; set; }
        public RegistracijaViewModel parent { get; set; }
        public KorisnikViewModel parent2 { get; set; }
        Boolean rv = false;
        Random rnd;

        

        private Boolean parking;
        public Boolean Parking
        {
            get { return parking; }
            set { parking = value;  OnPropertyChanged("Parking"); }
        }

        private Boolean ljubimac;
        public Boolean Ljubimac
        {
            get { return ljubimac; }
            set { ljubimac = value; OnPropertyChanged("Ljubimac"); }
        }

        private Boolean krevet;
        public Boolean Krevet
        {
            get { return krevet; }
            set { krevet = value; OnPropertyChanged("Krevet"); }
        }

        private DateTime dolazak;
        public DateTime Dolazak
        {
            get { return dolazak; }
            set { dolazak = value; OnPropertyChanged("Dolazak"); }
        }

        private DateTime odlazak;
        public DateTime Odlazak
        {
            get { return odlazak; }
            set { odlazak = value; OnPropertyChanged("Odlazak"); }
        }

        private string brojOdraslih;
        public string BrojOdraslih
        {
            get { return brojOdraslih; }
            set { brojOdraslih = value; OnPropertyChanged("BrojOdraslih"); }
        }

        private string brojDjece;
        public string BrojDjece
        {
            get { return brojDjece; }
            set { brojDjece = value; OnPropertyChanged("BrojDjece"); }
        }

        private List<string> _myList = new List<string>() { "Gotovinsko", "Karticom" };
        private List<string> placanje;
        public List<string> Placanje
        {
            get { return placanje; }
            set { placanje = value; OnPropertyChanged("Placanje"); }
        }

        private string izabraniNacin;
        public string IzabraniNacin
        {
            get { return izabraniNacin; }
            set
            {
                OnPropertyChanged("IzabraniNacin");
                izabraniNacin = value;
            }
        }

        //ukoliko gost prelazi na rezervaciju iz signup
        public RezervacijaViewModel(RegistracijaViewModel rvm)
        {
            NavigationServis = new NavigationService();
            rnd = new Random();
            Placanje = _myList;

            Dolazak = DateTime.Now;
            Odlazak = DateTime.Now;

            DodajRezervaciju = new RelayCommand<object>(rezervisi, mozeLiRezervisati);
            this.Id = System.Threading.Interlocked.Increment(ref m_Counter2);

            this.parent = rvm;

            rv = true;
        }


        //ukoliko recepcioner prelazi na rezervaciju
        public RezervacijaViewModel(KorisnikViewModel kvm)
        {
            NavigationServis = new NavigationService();
            rnd = new Random();
            Placanje = _myList;

            Dolazak = DateTime.Now;
            Odlazak = DateTime.Now;

            DodajRezervaciju = new RelayCommand<object>(rezervisi, mozeLiRezervisati);
            this.Id = System.Threading.Interlocked.Increment(ref m_Counter2);

            this.parent2 = kvm;
            rv = false;
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
                if (Convert.ToInt32(BrojOdraslih) == 0)
                {
                    var d = new MessageDialog("Unesite broj odraslih", "Neuspješna rezervacija");
                    await d.ShowAsync();
                }
                else if (Dolazak.Date == DateTime.Now && Odlazak.Date == DateTime.Now)
                {
                    var d = new MessageDialog("Molimo unesite ispravan datum dolaska i odlaska.", "Neuspješna rezervacija");
                    await d.ShowAsync();
                }

                //uspjela validacija
                else
                {
                    nacin_str = IzabraniNacin;
                    if (nacin_str == "Gotovinsko") nacin = NacinPlacanja.Gotovinsko;
                    else nacin = NacinPlacanja.Karticom;


                    Rezervacija nova = new Rezervacija(Convert.ToInt32(BrojOdraslih), Convert.ToInt32(BrojDjece), Dolazak, Odlazak, Parking, Ljubimac, Krevet, nacin);
                    Soba slobodnaSoba = DataSource.DataSourceRRenting.dajSlobodnuSobu(nova);

                    if (slobodnaSoba.CijenaSobe != 0)
                    {
                        int tiket = rnd.Next(1000);
                        using (var rdb = new RRentingDbContext())
                        {
                            if (rv)
                            {
                                
                                //gost se dodaje u bazu tek kada ce se rezervacija izvrsiti

                                db.Gosti.Add(parent.RegistrovaniKorisnik);
                                db.SaveChanges();
                              
                                gost = db.Gosti.Where(x => x.Email == parent.RegistrovaniKorisnik.Email && x.Sifra == parent.RegistrovaniKorisnik.Sifra && x.SigurnosniID == 0).FirstOrDefault();
                            }
                            else
                            {

                                //  -||-

                                db.Gosti.Add(parent2.RegistrovaniKorisnik);
                                db.SaveChanges();

                                gost = gost = db.Gosti.Where(x => x.Email == parent2.RegistrovaniKorisnik.Email && x.Sifra == parent2.RegistrovaniKorisnik.Sifra && x.SigurnosniID == 0).FirstOrDefault();
                            }

                            if (gost != null)
                            {
                                gost.brojSobe = slobodnaSoba.BrojSobe;
                                gost.dodijeliTiket(tiket);

                                //update changes
                                using (var rr = new RRentingDbContext())
                                {
                                    rr.Entry(gost).State = Microsoft.Data.Entity.EntityState.Modified;
                                    rr.SaveChanges();
                                }



                                nova.izracunajCijenu(Dolazak, Odlazak, slobodnaSoba);

                                db.Rezervacije.Add(nova);
                                db.SaveChanges();

                                var dialog = new MessageDialog("Vaš broj tiketa: " + tiket.ToString(), "Rezervacija uspješna");
                                await dialog.ShowAsync();

                                // if (!rv) NavigationServis.Navigate(typeof(RecepcionerView), new RecepcionerViewModel(this)); -DODATI
                                NavigationServis.Navigate(typeof(Pocetna));
                            }
                        }
                    }



                    else
                    {
                        NavigationServis.Navigate(typeof(Login));
                        var d = new MessageDialog("U tom periodu nemamo soba koje odgovaraju Vašim zahtjevima.", "Žao nam je");
                        await d.ShowAsync();
                    }

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
    }
}
