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
using Windows.UI.Xaml;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace RRentingProjekat.RRentingBaza.ViewModels
{
    class PlacanjeViewModel : INotifyPropertyChanged
    {
        public Uplata CreateUplata { get; set; }
        public ICommand PotvrdaUplate { get; set; }
        public INavigacija NavigationServis { get; set; }
        Rfid rfid;
        public PlacanjeViewModel()
        {
              CreateUplata = new Uplata();
            rfid = new Rfid();
            rfid.InitializeReader(RfidReadSomething);
            NavigationServis = new NavigationService();
            PotvrdaUplate = new RelayCommand<object>(potvrda, mozeLiPotvrditi);
        }
        public void RfidReadSomething(string rfidKod)
        {
            CreateUplata.RfidKartica = rfidKod;
        }
        public bool mozeLiPotvrditi(object parametar)
        {
            return true;
        }
        private void potvrda(object parametar)
        {
            Uplata uplata = CreateUplata;
            if (uplata != null) {

                NNavigationServis.Navigate(typeof(KorisnikListView), new KorisnikViewModel(CreateUplata));

            }
            
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            //? je skracena verzija ako nije null
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
