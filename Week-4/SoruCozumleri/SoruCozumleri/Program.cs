using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoruCozumleri
{
    class Program
    {
        static void Main(string[] args)
        {
            // Soru 1: BankaHesabi kullanımı
            var bankaHesabi = new BankaHesabi("123456", 500);
            bankaHesabi.ParaYatir(200);  // 200 birim para yatır
            bankaHesabi.ParaCek(100);    // 100 birim para çek
            Console.WriteLine($"Bakiye: {bankaHesabi.GetBakiye()}");

            // Soru 2: Urun kullanımı
            var urun = new Urun("Laptop", 5000);
            urun.Indirim = 10;  // %10 indirim yap
            Console.WriteLine($"İndirimli Fiyat: {urun.IndirimliFiyat()}");

            // Soru 3: KiralikArac kullanımı
            var arac = new KiralikArac("34XYZ78", 200);
            arac.AraciKirala();  // Aracı kirala
            Console.WriteLine($"Araç Müsait mi? {arac.MusaitMi}");
            arac.AraciTeslimEt();  // Aracı teslim et
            Console.WriteLine($"Araç Müsait mi? {arac.MusaitMi}");

            // Soru 4: Kisi kullanımı
            var kisi = new Kisi("Ahmet", "Yılmaz", "05001234567");
            Console.WriteLine(kisi.KisiBilgisi());

            // Soru 5: Kutuphane kullanımı
            var kutuphane = new Kutuphane();
            var kitap1 = new Kitap("Suç ve Ceza", "Dostoyevski");
            var kitap2 = new Kitap("Savaş ve Barış", "Tolstoy");
            kutuphane.KitapEkle(kitap1);  // İlk kitabı ekle
            kutuphane.KitapEkle(kitap2);  // İkinci kitabı ekle
            kutuphane.KitaplariListele(); // Tüm kitapları listele

            Console.Read();
        }
    }
    // Soru 1: Banka Hesabı Sınıfı
    public class BankaHesabi
    {
        // Hesap numarası ve bakiye özellikleri
        public string HesapNumarasi { get; private set; }
        private decimal Bakiye { get; set; }

        // Yapıcı metot: Hesap numarası ve ilk bakiye değerleriyle sınıfı başlatır
        public BankaHesabi(string hesapNumarasi, decimal ilkBakiye)
        {
            HesapNumarasi = hesapNumarasi;
            Bakiye = ilkBakiye;
        }

        // Para yatırma işlemi
        public void ParaYatir(decimal miktar)
        {
            Bakiye += miktar;
        }

        // Para çekme işlemi, eğer bakiye yeterli değilse işlem yapılmaz
        public void ParaCek(decimal miktar)
        {
            if (miktar <= Bakiye)
                Bakiye -= miktar;
            else
                Console.WriteLine("Yetersiz bakiye.");
        }

        // Bakiye bilgisi döndüren metot
        public decimal GetBakiye()
        {
            return Bakiye;
        }
    }

    // Soru 2: Ürün Sınıfı
    public class Urun
    {
        // Ürün adı ve fiyatı
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }

        // İndirim oranı, 0-50 arasında sınırlandırılacak
        private decimal indirim;

        public decimal Indirim
        {
            get { return indirim; }
            set
            {
                if (value >= 0 && value <= 50)
                    indirim = value;
                else
                    Console.WriteLine("İndirim 0 ile 50 arasında olmalıdır.");
            }
        }

        // Yapıcı metot: Ürün adı ve fiyat bilgilerini alır
        public Urun(string ad, decimal fiyat)
        {
            Ad = ad;
            Fiyat = fiyat;
        }

        // İndirimli fiyatı hesaplayan metot
        public decimal IndirimliFiyat()
        {
            return Fiyat * (1 - Indirim / 100);
        }
    }

    // Soru 3: Araç Kiralama Sınıfı
    public class KiralikArac
    {
        // Araç plakası, günlük ücret ve müsaitlik durumu
        public string Plaka { get; private set; }
        public decimal GunlukUcret { get; private set; }
        public bool MusaitMi { get; private set; } = true;

        // Yapıcı metot: Plaka ve günlük ücret alarak başlatır
        public KiralikArac(string plaka, decimal gunlukUcret)
        {
            Plaka = plaka;
            GunlukUcret = gunlukUcret;
        }

        // Aracı kiralamak için kullanılan metot
        public void AraciKirala()
        {
            if (MusaitMi)
                MusaitMi = false;
            else
                Console.WriteLine("Araç zaten kiralanmış.");
        }

        // Aracı teslim etme işlemi, müsaitliği tekrar true yapar
        public void AraciTeslimEt()
        {
            MusaitMi = true;
        }
    }

    // Soru 4: Adres Defteri Sınıfı
    public class Kisi
    {
        // Kişi bilgileri: ad, soyad ve telefon numarası
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TelefonNumarasi { get; set; }

        // Yapıcı metot: Ad, soyad ve telefon numarası ile başlatır
        public Kisi(string ad, string soyad, string telefonNumarasi)
        {
            Ad = ad;
            Soyad = soyad;
            TelefonNumarasi = telefonNumarasi;
        }

        // Kişi bilgilerini döndürme metodu
        public string KisiBilgisi()
        {
            return $"{Ad} {Soyad}, Telefon: {TelefonNumarasi}";
        }
    }

    // Soru 5: Kütüphane Sınıfı
    public class Kutuphane
    {
        // Kitap listesi özelliği, kütüphaneye eklenen kitapları tutar
        public List<Kitap> Kitaplar { get; private set; } = new List<Kitap>();

        // Yeni kitap ekleme metodu
        public void KitapEkle(Kitap yeniKitap)
        {
            Kitaplar.Add(yeniKitap);
            Console.WriteLine($"Kitap '{yeniKitap.Ad}' kütüphaneye eklendi.");
        }

        // Kitapları listeleme metodu
        public void KitaplariListele()
        {
            foreach (var kitap in Kitaplar)
            {
                Console.WriteLine($"Kitap: {kitap.Ad}, Yazar: {kitap.Yazar}");
            }
        }
    }

    // Kitap sınıfı, kütüphane sınıfında kullanılmak üzere tanımlandı
    public class Kitap
    {
        public string Ad { get; set; }
        public string Yazar { get; set; }

        // Yapıcı metot: Kitap adı ve yazar bilgisi ile başlatır
        public Kitap(string ad, string yazar)
        {
            Ad = ad;
            Yazar = yazar;
        }
    }
}
