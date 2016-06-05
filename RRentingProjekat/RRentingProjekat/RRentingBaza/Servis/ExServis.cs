using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRentingProjekat.RRentingBaza.Models;
using Windows.Web.Http;
using Windows.Web.Http.Headers;
using Windows.Data.Json;
using System.IO;
using Newtonsoft.Json;

namespace RRentingProjekat.RRentingBaza.Servis
{
    class ExServis
    {
        JsonObject servicesConfig;
        string serviceHost;
        public static string korisnikName = "_KorisnikService";

        public ExServis()
        {
            servicesConfig = JsonValue.Parse(File.ReadAllText("ExServis.json")).GetObject();
            serviceHost = servicesConfig.GetNamedString("serviceHost");
        }

        public async void dodajKorisnika(Korisnik _korisnik)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new HttpMediaTypeWithQualityHeaderValue("application/json"));
            string jsonContents = JsonConvert.SerializeObject(_korisnik);
            HttpResponseMessage response = await httpClient.PostAsync(new Uri(serviceHost + '/' + korisnikName), new HttpStringContent(jsonContents, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
            JsonValue value = JsonValue.Parse(response.Content.ToString());
        }
        public async void dodajSveKorisnike()
        {
            HttpClient httpClient = new HttpClient();
            string response = await httpClient.GetStringAsync(new Uri(serviceHost + '/' + korisnikName));
            JsonValue value = JsonValue.Parse(response);
        }

    }
}
