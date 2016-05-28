using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RRentingProjekat.RRentingBaza.Models
{
    [DataContract]
    class Uplata : INotifyPropertyChanged
    {
        public string Pozicija { get; set; }
        private string rfidKartica;//Rfid string procitan sa kartice
        [DataMember]//Regex da ocisti simbole koji bi mogli prouzrokovati probleme poput enter znaka i slicno
        //mora prozvati property changed jer je na njega vezano polje koje se treba promijeniti kad se povuce kartica, bez ovog, textbox prazan
        public string RfidKartica { get { return rfidKartica; } set { rfidKartica = Regex.Replace(value, "[^0-9a-zA-Z]+", ""); OnNotifyPropertyChanged("RfidKartica"); } }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            //? je skracena verzija ako nije null
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
