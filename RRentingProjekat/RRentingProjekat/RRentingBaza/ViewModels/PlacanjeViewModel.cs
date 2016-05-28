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
        Rfid rfid;
        public PlacanjeViewModel()
        {
              CreateUplata = new Uplata();
            rfid = new Rfid();
            rfid.InitializeReader(RfidReadSomething);
        }
        public void RfidReadSomething(string rfidKod)
        {
            CreateUplata.RfidKartica = rfidKod;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            //? je skracena verzija ako nije null
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
