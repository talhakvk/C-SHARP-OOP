using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalismaSoru
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class Kitap
    {
        public string Ad { get; set; }
        public string ISBN { get; set; }

        public Kitap(string ad, string isbn)
        {
            Ad = ad;
            ISBN = isbn;
        }
    }

    class Yazar
    {
        public string Ad { get; set; }
        public string Ülke { get; set; }
        public List<Kitap> Kitaplar { get; set; } = new List<Kitap>();

        public Yazar(string ad, string ülke)
        {
            Ad = ad;
            Ülke = ülke;
        }

        public void KitapEkle(Kitap kitap)
        {
            Kitaplar.Add(kitap);
        }
    }

    class Departman
    {
        public string Ad { get; set; }
        public string Lokasyon { get; set; }

        public Departman(string ad, string lokasyon)
        {
            Ad = ad;
            Lokasyon = lokasyon;
        }
    }

    class Çalışan
    {
        public string Ad { get; set; }
        public string Pozisyon { get; set; }
        public Departman Departman { get; set; }

        public Çalışan(string ad, string pozisyon)
        {
            Ad = ad;
            Pozisyon = pozisyon;
        }

        public void DepartmanAtama(Departman departman)
        {
            Departman = departman;
        }
    }

    class Ürün
    {
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }

        public Ürün(string ad, decimal fiyat)
        {
            Ad = ad;
            Fiyat = fiyat;
        }
    }

    class Sipariş
    {
        public DateTime Tarih { get; set; }
        public string Durum { get; set; }

        public Sipariş(DateTime tarih, string durum)
        {
            Tarih = tarih;
            Durum = durum;
        }
    }

    class Müşteri
    {
        public string Ad { get; set; }
        public string Telefon { get; set; }
        public List<Sipariş> Siparişler { get; set; } = new List<Sipariş>();

        public Müşteri(string ad, string telefon)
        {
            Ad = ad;
            Telefon = telefon;
        }

        public void SiparişEkle(Sipariş sipariş)
        {
            Siparişler.Add(sipariş);
        }
    }

    class Yazar
    {
        public string Ad { get; set; }
        public string Ulke { get; set; }
        public List<Kitap> Kitaplar { get; set; }

        public Yazar(string ad, string ulke)
        {
            Ad = ad;
            Ulke = ulke;
            Kitaplar1 = new List<Kitap>();
        }

        public void KitapEkle(Kitap kitap)
        {
            if (!Kitaplar1.Contains(kitap))
            {
                Kitaplar.Add(kitap);
                kitap.YazarAtama(this);
            }
        }
    }

    class Kitap1
    {
        public string Baslik { get; set; }
        public DateTime YayınTarihi { get; set; }
        public Yazar Yazar { get; private set; }

        public Kitap1(string baslik, DateTime yayinTarihi)
        {
            Baslik = baslik;
            YayınTarihi = yayinTarihi;
        }

        public void YazarAtama(Yazar yazar)
        {
            Yazar = yazar;
            if (!yazar.Kitaplar1.Contains(this))
            {
                yazar.KitapEkle(this);
            }
        }
    }

    class Sirket
    {
        public string Ad { get; set; }
        public string Konum { get; set; }
        public List<Calisan> Calisanlar { get; set; }

        public Sirket(string ad, string konum)
        {
            Ad = ad;
            Konum = konum;
            Calisanlar = new List<Calisan>();
        }

        public void CalisanEkle(Calisan calisan)
        {
            if (!Calisanlar.Contains(calisan))
            {
                Calisanlar.Add(calisan);
                calisan.SirketAtama(this);
            }
        }
    }

    class Calisan
    {
        public string Isim { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public Sirket Sirket { get; private set; }

        public Calisan(string isim, DateTime baslangicTarihi)
        {
            Isim = isim;
            BaslangicTarihi = baslangicTarihi;
        }

        public void SirketAtama(Sirket sirket)
        {
            Sirket = sirket;
            if (!sirket.Calisanlar.Contains(this))
            {
                sirket.CalisanEkle(this);
            }
        }
    }

    class Ebeveyn
    {
        public string Ad { get; set; }
        public int Yas { get; set; }
        public List<Cocuk> Cocuklar { get; set; }

        public Ebeveyn(string ad, int yas)
        {
            Ad = ad;
            Yas = yas;
            Cocuklar = new List<Cocuk>();
        }

        public void CocukEkle(Cocuk cocuk)
        {
            if (!Cocuklar.Contains(cocuk))
            {
                Cocuklar.Add(cocuk);
                cocuk.EbeveynAtama(this);
            }
        }
    }

    class Cocuk
    {
        public string Ad { get; set; }
        public int Yas { get; set; }
        public Ebeveyn Ebeveyn { get; private set; }

        public Cocuk(string ad, int yas)
        {
            Ad = ad;
            Yas = yas;
        }

        public void EbeveynAtama(Ebeveyn ebeveyn)
        {
            Ebeveyn = ebeveyn;
            if (!ebeveyn.Cocuklar.Contains(this))
            {
                ebeveyn.CocukEkle(this);
            }
        }
    }

    // Oda sınıfı
    class Oda
    {
        public string Boyut { get; set; }
        public string Tip { get; set; }

        public Oda(string boyut, string tip)
        {
            Boyut = boyut;
            Tip = tip;
        }

        public string OdaBilgisi()
        {
            return $"Boyut: {Boyut}, Tip: {Tip}";
        }
    }

    // Ev sınıfı
    class Ev
    {
        public string Ad { get; set; }
        private List<Oda> Odalar = new List<Oda>();

        public Ev(string ad)
        {
            Ad = ad;
        }

        public void OdaEkle(Oda oda)
        {
            Odalar.Add(oda);
        }

        public void EvBilgisi()
        {
            Console.WriteLine($"Ev Adı: {Ad}");
            Console.WriteLine("Odalar:");
            foreach (var oda in Odalar)
            {
                Console.WriteLine($"  - {oda.OdaBilgisi()}");
            }
        }
    }

    // Test
    class Program
    {
        static void Main(string[] args)
        {
            Ev ev = new Ev("Aile Evi");
            ev.OdaEkle(new Oda("20m²", "Yatak Odası"));
            ev.OdaEkle(new Oda("30m²", "Oturma Odası"));

            ev.EvBilgisi();
        }
    }

    // Çalışan sınıfı
    class Calisan
    {
        public string Ad { get; set; }

        public Calisan(string ad)
        {
            Ad = ad;
        }

        public string CalisanBilgisi()
        {
            return $"Ad: {Ad}";
        }
    }

    // Şirket sınıfı
    class Sirket
    {
        public string Ad { get; set; }
        private List<Calisan> Calisanlar = new List<Calisan>();

        public Sirket(string ad)
        {
            Ad = ad;
        }

        public void CalisanEkle(Calisan calisan)
        {
            Calisanlar.Add(calisan);
        }

        public void SirketBilgisi()
        {
            Console.WriteLine($"Şirket Adı: {Ad}");
            Console.WriteLine("Çalışanlar:");
            foreach (var calisan in Calisanlar)
            {
                Console.WriteLine($"  - {calisan.CalisanBilgisi()}");
            }
        }
    }

    // Test
    class Program
    {
        static void Main(string[] args)
        {
            Sirket sirket = new Sirket("Teknoloji A.Ş.");
            sirket.CalisanEkle(new Calisan("Ali"));
            sirket.CalisanEkle(new Calisan("Ayşe"));

            sirket.SirketBilgisi();
        }
    }

    // Kitap sınıfı
    class Kitap
    {
        public string Baslik { get; set; }
        public string Yazar { get; set; }

        public Kitap(string baslik, string yazar)
        {
            Baslik = baslik;
            Yazar = yazar;
        }

        public string KitapBilgisi()
        {
            return $"Başlık: {Baslik}, Yazar: {Yazar}";
        }
    }

    // Kütüphane sınıfı
    class Kutuphane
    {
        public string Ad { get; set; }
        private List<Kitap> Kitaplar = new List<Kitap>();

        public Kutuphane(string ad)
        {
            Ad = ad;
        }

        public void KitapEkle(Kitap kitap)
        {
            Kitaplar.Add(kitap);
        }

        public void KutuphaneBilgisi()
        {
            Console.WriteLine($"Kütüphane Adı: {Ad}");
            Console.WriteLine("Kitaplar:");
            foreach (var kitap in Kitaplar)
            {
                Console.WriteLine($"  - {kitap.KitapBilgisi()}");
            }
        }
    }

    // Test
    class Program
    {
        static void Main(string[] args)
        {
            Kutuphane kutuphane = new Kutuphane("Fırat Üniversitesi Kütüphanesi");
            kutuphane.KitapEkle(new Kitap("Simyacı", "Paulo Coelho"));
            kutuphane.KitapEkle(new Kitap("1984", "George Orwell"));

            kutuphane.KutuphaneBilgisi();
        }
    }

    // İşlemci sınıfı
    class Islemci
    {
        public int CekirdekSayisi { get; set; }
        public int Frekans { get; set; } // GHz cinsinden

        public Islemci(int cekirdekSayisi, int frekans)
        {
            CekirdekSayisi = cekirdekSayisi;
            Frekans = frekans;
        }

        public string IslemciBilgisi()
        {
            return $"Çekirdek Sayısı: {CekirdekSayisi}, Frekans: {Frekans} GHz";
        }
    }

    // Bilgisayar sınıfı
    class Bilgisayar
    {
        public string Model { get; set; }
        private Islemci Islemci; // İşlemci bileşeni

        public Bilgisayar(string model, Islemci islemci)
        {
            Model = model;
            Islemci = islemci;
        }

        public void BilgisayarBilgisi()
        {
            Console.WriteLine($"Bilgisayar Modeli: {Model}");
            Console.WriteLine($"İşlemci Bilgileri: {Islemci.IslemciBilgisi()}");
        }
    }

    // Test
    class Program
    {
        static void Main(string[] args)
        {
            Islemci islemci = new Islemci(8, 3); // 8 çekirdekli, 3 GHz
            Bilgisayar bilgisayar = new Bilgisayar("HP Pavilion", islemci);
            bilgisayar.BilgisayarBilgisi();
        }
    }

    // Motor sınıfı
    class Motor
    {
        public int Guc { get; set; } // Beygir gücü
        public string Tip { get; set; } // Motor tipi (örn: Dizel, Benzin)

        public Motor(int guc, string tip)
        {
            Guc = guc;
            Tip = tip;
        }

        public string MotorBilgisi()
        {
            return $"Güç: {Guc} HP, Tip: {Tip}";
        }
    }

    // Otomobil sınıfı
    class Otomobil
    {
        public string Marka { get; set; }
        private Motor Motor; // Motor bileşeni

        public Otomobil(string marka, Motor motor)
        {
            Marka = marka;
            Motor = motor;
        }

        public void OtomobilBilgisi()
        {
            Console.WriteLine($"Otomobil Markası: {Marka}");
            Console.WriteLine($"Motor Bilgileri: {Motor.MotorBilgisi()}");
        }
    }

    // Test
    class Program
    {
        static void Main(string[] args)
        {
            Motor motor = new Motor(150, "Benzin"); // 150 HP benzinli motor
            Otomobil otomobil = new Otomobil("Toyota Corolla", motor);
            otomobil.OtomobilBilgisi();
        }
    }

    // Öğrenci sınıfı
    class Ogrenci
    {
        public string Ad { get; set; }

        public Ogrenci(string ad)
        {
            Ad = ad;
        }

        public string OgrenciBilgisi()
        {
            return $"Ad: {Ad}";
        }
    }

    // Okul sınıfı
    class Okul
    {
        public string Isim { get; set; }
        private List<Ogrenci> Ogrenciler = new List<Ogrenci>(); // Öğrenci listesi

        public Okul(string isim)
        {
            Isim = isim;
        }

        public void OgrenciEkle(Ogrenci ogrenci)
        {
            Ogrenciler.Add(ogrenci);
        }

        public void OkulBilgisi()
        {
            Console.WriteLine($"Okul İsmi: {Isim}");
            Console.WriteLine("Öğrenciler:");
            foreach (var ogrenci in Ogrenciler)
            {
                Console.WriteLine($"  - {ogrenci.OgrenciBilgisi()}");
            }
        }
    }

    // Test
    class Program
    {
        static void Main(string[] args)
        {
            Okul okul = new Okul("Fırat Üniversitesi");
            okul.OgrenciEkle(new Ogrenci("Ali"));
            okul.OgrenciEkle(new Ogrenci("Ayşe"));

            okul.OkulBilgisi();
        }
    }


}
