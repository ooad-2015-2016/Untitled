![Untitled](https://raw.githubusercontent.com/ooad-2015-2016/Untitled/master/logo.png)

# Untitled
## RRenting
#### Članovi tima: 
  1. Hanić Džana 
  2. Karkelja Adna 
  3. Keško Lejla 
  4. Ljevo Dženita

#### Opis teme
U današnje vrijeme, zbog sve većeg broja turista, sve je veći broj objekata koji nude smještaj. *RRenting* je sistem koji će omogućavati objektima koji nude smještaj (sobe, hosteli, apartmani, hoteli) lakše poslovanje uvođenjem informacionih tehnologija. Svrha ovog sistema je omogućavanje online rezervacije soba, online plaćanja, iznajmljivanje soba preko interfejsa, uvid u statistike objekta. Također, sistem pruža mogućnost administrativnog upravljanja ovim objektom i mogućnost posebnog ulogovanja i interfejsa zavisno od aktera.

Sistem je karakterističan jer bi omogućio lakše poslovanje i modernizaciju objekta. Gostima su ovakvi objekti pristupačniji, privlačniji i olakšana im je komunikacija sa osobljem objekta preko aplikacije. Zaposlenicima i šefu je omogućen jednostavan pregled zahtjeva korisnika i poslova koje trebaju obaviti, omogućen je i pregled rasporeda soba i pristup podacima gostiju u određenim sobama. *RRenting* nije ograničen na određen tip objekta, već je napravljen na taj način da je koristan za poslovanje svim objektima koji nude smještaj. 


#### Procesi	
###### Proces iznajmljivanja soba
Korisniku je putem interfejsa omogućena online rezervacija sobe ili izbor i iznajmljivanje sobe prilikom dolaska u objekat.   Automatski se prikazuju slobodne sobe za uneseni datum za koji je korisnik zainteresovan da rezerviše/iznajmi, a uz to navodi i informacije koju sobu želi i posebne zahtjeve ukoliko ih ima (popust za djecu, dodatni krevet, kućni ljubimac, parking) i koliko dugo će odsjedati. 
U slučaju da nema slobodnih soba u željenom periodu (npr. trenutno su neke sobe slobodne, ali postoje određene rezervacije, a naš trenutni korisnik želi da ostane preko tog datuma), korisniku se prikazuje prvi slobodan datum za rezervaciju određenih soba ili do kojeg datuma su sobe slobodne, nakon čega, kada odabare validan datum, vodi ga u daljni proces specifikacije rezervacije. Nakon potvrđivanja rezervacije, vrši se obračun (mogući su popusti ili dodatni troškovi), te korisnik bira način plaćanja.

###### Proces plaćanja
Poslije obračuna cijene, korisnik bira način plaćanja. Omogućena su tri načina plaćanja: 
  1.	plaćanje unaprijed kreditnom karticom (korisniku se prikazuje interfejs za unos odgovarajućih podataka i vrši se validacija podataka, a zatim se šalju eksternom sistemu za autorizaciju kartica koji treba da odobri ili odbije transakciju plaćanja), 
  2.	plaćanje na recepciji karticom ili 
  3.	gotovinsko plaćanje na recepciji.  
Ukoliko korisnik uplati preko interneta, dodjeljuje  mu se tiket/račun kao dokaz da je uplatio sa jedinstvenim indentifikacijskim brojem rezervacije. U slučaju plaćanja na recepciji, recepcionar unosi u sistem podatke i kreira tiket, te vrši potvrdu uplate i izdaje sobu korisniku (gostu).

###### Proces realizacija rezervacije
Nakon što se validira rezervacija, podaci se unose u sistem, čistačice i osoblje prilagođavanju sobe eventualnim dodatnim zahtjevima korisnika i pripremaju sobu. Po završetku odsjedanja čistačica čisti sobu, mjenja posteljinu, iznosi smeće itd. Recepcionar potvrdi da li je ključ vraćen ili za izgubljeni ključ naplaćuje dodatno.

###### Proces Izvršavanje zahtjeva gosta prilikom boravka
Nakon što je izvršena prijava u sistem i korisniku (gostu) iznajmljena soba, korisniku je putem interfejsa prilikom boravka pružena mogućnost postavljanja osnovnih zahtjeva: promjena posteljine, čišćenje sobe, iznošenja smeća, poziv servisera. Nakon izbora pojedinog zahtjeva od strane gosta, čistačica ili serviser dobija obavijest o zahtjevu i broju sobe i izvršavaju svoj posao.  
Nakon završetka odsjedanja gost boduje usluge i kako je zadovoljan sa sobom i osobljem, kako bi omogućili statistiku objekta. 

###### Proces pristupa i kontrole podataka
Kako je omogućena prijava u sistem sa različitim privilegijama, šef objekta ima pristup podacima svih korisnika. Njemu se pokazuje poseban interfejs svih soba, te klikom na njih može pristupiti podacima gostiju ukoliko je soba zauzeta, i dobiti podatke o radniku zaduženog za tu sobu. Može vidjeti i statistiku, prema utiscima korisnika i procenat zadovoljnih korisnika u cilju pobošljanja budućeg poslovanja. On kontroliše i postojeće zalihe posteljine i sredstava za čiščenje. Jednom mjesečno vrši nabavku posteljina, sredstava za čišćenje itd. u skladu sa brojem soba.


#### Funkcionalnosti
*	mogućnost prijave u sistem sa različitim privilegijama,
*	mogućnost online rezervacije sobe (uz navođenje zahtjeva kakvu sobu korisnik želi),
*	mogućnost izbora sobe putem interfejsa,
*	mogućnost izbora dodatnih zahtjeva korisnika: da li korisnik želi parking mjesto, da li ima kucnog ljubimca, da li želi dodatni krevet,
*	mogućnost online plaćanja, pri čemu se izdaje račun sa ID brojem kao dokaz da je izvršena uplata,
*	mogućnost plaćanja na recepciji (kreditnom karticom ili gotovinsko plaćanje)
*	mogućnost komunikacije korisnika (gosta) sa osobljem prilikom boravka u objektu, u smislu postavljanja osnovnih zahtjeva kao što su: promjena posteljine, čišćenje sobe, poziv servisera i sl.
*	mogućnost osoblja (čistačica, servisera) da vidi zahtjeve gostiju (korisnika) i poslova koje trebaju obaviti,
*	mogućnost bodovanja usluga ili sobe od strane gostiju koji su boravili u objektu,
*	mogućnost određivanja trenutne udaljenosti gosta od objekta pomoću gps-a,
*	osoblje sa administrativnim pristupom ima mogućnost pristupa podacima gostiju u rezervisanim/zauzetim sobama,
*	mogućnost uvida u statistike objekta,


#### Akteri
1.	**Korisnik usluga (gost)** - Korisnik usluga je osoba koja ima mogućnost iznajmljivanja i rezervacije sobe.
2.	**Recepcionar** – Recepcionar je osoba koja radi na recepciji objekta i vrši naplaćivanje smještaja, izdaje odgovarajaći račun i izdaje sobu gostu (daje gostu ključ od sobe). 
3. **Šef** – Šef objekta predstavlja supervizora koji nadgleda izdavanje soba, provjera podatke gostiju i vrši mjesečnu nabavku posteljine, sredstava za čišćenje i sl. 
4. 	**Serviser** – Serviser je osoba koja se poziva u slučaju potrebnih popravki uređaja.
5.	**Sistem za autorizaciju kartica** – sistem koji je izvan domena našeg sistema, ali koji komunicira sa našom aplikacijom za realizaciju transakcija plaćanja putem kreditnih kartica.  


#### Update; Dovršene funkcionalnosti:
1.   Naša baza je SqlLite; dakle u projektu koristimo lokalnu bazu
2.  Za eksterni uređaj odabrali smo serial Rfid. 
Kod se nalazi u Rfid.cs i poziva se u PlacanjeViewModel-u i PlacanjeView. 
https://github.com/ooad-2015-2016/Untitled/blob/master/RRentingProjekat/RRentingProjekat/RRentingBaza/Views/PlacanjeView.xaml
https://github.com/ooad-2015-2016/Untitled/blob/master/RRentingProjekat/RRentingProjekat/RRentingBaza/Views/PlacanjeView.xaml.cs
3.  Za eksterni servis korišten je asp.net MVC eksterni servis.
https://github.com/ooad-2015-2016/Untitled/tree/master/RRentingProjekat/IISExpress
4.  Podaci se validiraju prilikom registracije i rezervacije.
https://github.com/ooad-2015-2016/Untitled/blob/master/RRentingProjekat/RRentingProjekat/RRentingBaza/ViewModels/RegistracijaViewModel.cs
https://github.com/ooad-2015-2016/Untitled/blob/master/RRentingProjekat/RRentingProjekat/RRentingBaza/ViewModels/RezervacijaViewModel.cs
5.  Što se tiče mobilne funkcionalnosti, implementiran je GPS kojeg poziva GostView.
https://github.com/ooad-2015-2016/Untitled/blob/master/RRentingProjekat/RRentingProjekat/RRentingBaza/Views/GostView.xaml.cs
https://github.com/ooad-2015-2016/Untitled/blob/master/RRentingProjekat/RRentingProjekat/RRentingBaza/Views/GPSView.xaml
6.  Za web servis koristimo vremensku prognozu koja je implementirana u klasi Prognoza.cs, te u view-u VremenskaPrognoza.view-u.
Pristupa joj se u pogledu GostView.
https://github.com/ooad-2015-2016/Untitled/blob/master/RRentingProjekat/RRentingProjekat/RRentingBaza/Views/VremenskaPrognoza.xaml
https://github.com/ooad-2015-2016/Untitled/blob/master/RRentingProjekat/RRentingProjekat/RRentingBaza/Models/Prognoza.cs
7.  Za igricu je napravljen exe file.


![Untitled](https://raw.githubusercontent.com/ooad-2015-2016/Untitled/master/rezervacija.png)


#### THE END.
