using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace RRentingProjekat.RRentingBaza.Models
{
    class Prognoza
    {
        public async static Task<RootObject> GetWeather(double lat, double lon)
        {
            // ovdje se obavlja poziv upucen web servisu
            var http = new HttpClient();
            var response = await http.GetAsync("http://api.openweathermap.org/data/2.5/weather?lat=43.86&lon=18.41&appid=68b3e153ace869e304bdc2087ec0f6f5");
            var result = await response.Content.ReadAsStringAsync();
            //konverzija JSon objecta
            var serializer = new DataContractJsonSerializer(typeof(RootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serializer.ReadObject(ms);

            return data;
        }
    }

    [DataContract]
    public class Coord
    {
        [DataMember]
        public double lon { get; set; }

        [DataMember]
        public double lat { get; set; }
    }

    [DataContract]
    public class Weather
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string main { get; set; }

        [DataMember]
        public string description { get; set; }

        [DataMember]
        public string icon { get; set; }
    }

    [DataContract]
    public class Main
    {
        double temperatura;

        [DataMember]
        public double temp
        {
            get { return temperatura - 273.15; }
            set { temperatura = value; }
        }

        [DataMember]
        public int pressure { get; set; }

        [DataMember]
        public int humidity { get; set; }

        [DataMember]
        public double temp_min { get; set; }

        [DataMember]
        public double temp_max { get; set; }
    }

    [DataContract]
    public class Wind
    {
        [DataMember]
        public double speed { get; set; }

        [DataMember]
        public double deg { get; set; }
    }

    [DataContract]
    public class Clouds
    {
        [DataMember]
        public int all { get; set; }
    }

    [DataContract]
    public class Sys
    {
        [DataMember]
        public int type { get; set; }

        [DataMember]
        public int id { get; set; }

        [DataMember]
        public double message { get; set; }

        [DataMember]
        public string country { get; set; }

        [DataMember]
        public int sunrise { get; set; }

        [DataMember]
        public int sunset { get; set; }
    }

    [DataContract]
    public class RootObject
    {
        [DataMember]
        public Coord coord { get; set; }

        [DataMember]
        public List<Weather> weather { get; set; }

        [DataMember]
        public string @base { get; set; }

        [DataMember]
        public Main main { get; set; }

        [DataMember]
        public Wind wind { get; set; }

        [DataMember]
        public Clouds clouds { get; set; }

        [DataMember]
        public int dt { get; set; }

        [DataMember]
        public Sys sys { get; set; }

        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public int cod { get; set; }
    }
}
