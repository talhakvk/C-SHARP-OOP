using System;
using System.Collections.Generic;

namespace SoruCozumleri2
{
    // 1. Görev: Banka Hesap Yönetim Sistemi
    #region Banka Hesap Yönetimi
    // Soyut Hesap Sınıfı
    public abstract class Hesap
    {
        public string HesapNo { get; set; }
        public decimal Bakiye { get; set; }

        public Hesap(string hesapNo, decimal bakiye)
        {
            HesapNo = hesapNo;
            Bakiye = bakiye;
        }

        public abstract void ParaYatir(decimal miktar);
        public abstract void ParaCek(decimal miktar);
    }

    // IBankaHesabi Arayüzü
    public interface IBankaHesabi
    {
        DateTime HesapAcilisTarihi { get; set; }
        void HesapOzeti();
    }

    // BirikimHesabi Sınıfı
    public class BirikimHesabi : Hesap, IBankaHesabi
    {
        public decimal FaizOrani { get; set; }
        public DateTime HesapAcilisTarihi { get; set; }

        public BirikimHesabi(string hesapNo, decimal bakiye, decimal faizOrani)
            : base(hesapNo, bakiye)
        {
            FaizOrani = faizOrani;
            HesapAcilisTarihi = DateTime.Now;
        }

        public override void ParaYatir(decimal miktar)
        {
            Bakiye += miktar + (miktar * FaizOrani / 100);
        }

        public override void ParaCek(decimal miktar)
        {
            if (Bakiye >= miktar)
                Bakiye -= miktar;
            else
                Console.WriteLine("Yetersiz bakiye.");
        }

        public void HesapOzeti()
        {
            Console.WriteLine($"Birikim Hesabı: {HesapNo}, Bakiye: {Bakiye:C}, Faiz Oranı: {FaizOrani}%, Açılış Tarihi: {HesapAcilisTarihi}");
        }
    }

    // VadesizHesap Sınıfı
    public class VadesizHesap : Hesap, IBankaHesabi
    {
        public DateTime HesapAcilisTarihi { get; set; }
        private decimal IslemUcreti = 2m;

        public VadesizHesap(string hesapNo, decimal bakiye)
            : base(hesapNo, bakiye)
        {
            HesapAcilisTarihi = DateTime.Now;
        }

        public override void ParaYatir(decimal miktar)
        {
            Bakiye += miktar;
        }

        public override void ParaCek(decimal miktar)
        {
            decimal toplamCekim = miktar + IslemUcreti;
            if (Bakiye >= toplamCekim)
                Bakiye -= toplamCekim;
            else
                Console.WriteLine("Yetersiz bakiye.");
        }

        public void HesapOzeti()
        {
            Console.WriteLine($"Vadesiz Hesap: {HesapNo}, Bakiye: {Bakiye:C}, Açılış Tarihi: {HesapAcilisTarihi}");
        }
    }
    #endregion

    // 2. Görev: Mağaza Yönetim Sistemi
    #region Magaza Urun Yönetimi
    // Soyut Ürün Sınıfı
    public abstract class Urun
    {
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }

        public Urun(string ad, decimal fiyat)
        {
            Ad = ad;
            Fiyat = fiyat;
        }

        public abstract decimal HesaplaOdeme();
        public abstract void BilgiYazdir();
    }

    // Kitap Sınıfı
    public class Kitap : Urun
    {
        public Kitap(string ad, decimal fiyat) : base(ad, fiyat) { }

        public override decimal HesaplaOdeme()
        {
            return Fiyat * 1.10m; // %10 vergi
        }

        public override void BilgiYazdir()
        {
            Console.WriteLine($"Kitap: {Ad}, Fiyat: {Fiyat:C}, Ödenecek: {HesaplaOdeme():C}");
        }
    }

    // Elektronik Sınıfı
    public class Elektronik : Urun
    {
        public Elektronik(string ad, decimal fiyat) : base(ad, fiyat) { }

        public override decimal HesaplaOdeme()
        {
            return Fiyat * 1.25m; // %25 vergi
        }

        public override void BilgiYazdir()
        {
            Console.WriteLine($"Elektronik: {Ad}, Fiyat: {Fiyat:C}, Ödenecek: {HesaplaOdeme():C}");
        }
    }
    #endregion

    // 3. Görev: Observer Design Pattern ile Yayıncı-Abone Sistemi
    #region Observer Yayinci-Abone Sistemi
    public interface IYayinci
    {
        void AboneEkle(IAbone abone);
        void AboneCikar(IAbone abone);
        void Bildir();
    }

    public interface IAbone
    {
        void BilgiAl(string mesaj);
    }

    public class Yayinci : IYayinci
    {
        private List<IAbone> aboneler = new List<IAbone>();
        private string guncelleme;

        public void AboneEkle(IAbone abone) => aboneler.Add(abone);
        public void AboneCikar(IAbone abone) => aboneler.Remove(abone);

        public void GuncellemeYap(string mesaj)
        {
            guncelleme = mesaj;
            Bildir();
        }

        public void Bildir()
        {
            foreach (var abone in aboneler)
                abone.BilgiAl(guncelleme);
        }
    }

    public class Abone : IAbone
    {
        private string Ad { get; set; }

        public Abone(string ad)
        {
            Ad = ad;
        }

        public void BilgiAl(string mesaj)
        {
            Console.WriteLine($"{Ad} adlı aboneye gelen güncelleme: {mesaj}");
        }
    }
    #endregion

    // Main Programı
    class Program
    {
        static void Main(string[] args)
        {
            #region Banka Hesap Yönetimi Test
            // Banka Hesap Yönetimi
            BirikimHesabi birikimHesap = new BirikimHesabi("12345", 1000, 5);
            VadesizHesap vadesizHesap = new VadesizHesap("67890", 500);

            birikimHesap.ParaYatir(500);
            vadesizHesap.ParaCek(100);

            birikimHesap.HesapOzeti();
            vadesizHesap.HesapOzeti();
            #endregion

            #region Mağaza Ürün Yönetimi Test
            // Mağaza Ürün Yönetimi
            List<Urun> urunler = new List<Urun>
            {
                new Kitap("C# Programlama", 50),
                new Elektronik("Laptop", 3000)
            };

            foreach (var urun in urunler)
            {
                urun.BilgiYazdir();
            }
            #endregion

            #region Observer Yayıncı-Abone Test
            // Observer Design Pattern
            Yayinci yayinci = new Yayinci();
            Abone abone1 = new Abone("Talha");
            Abone abone2 = new Abone("Ahmet");

            yayinci.AboneEkle(abone1);
            yayinci.AboneEkle(abone2);

            yayinci.GuncellemeYap("Yeni içerik yüklendi!");
            #endregion
        }
    }
}
