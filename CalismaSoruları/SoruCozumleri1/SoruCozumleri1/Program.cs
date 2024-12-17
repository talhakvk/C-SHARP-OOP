using System;

namespace SoruCozumleri1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program başlatılıyor...\n");

            // Soru 1: Şirket Çalışan Yönetimi
            // Soru1CalisanYonetimi.Run();

            // Soru 2: Hayvanat Bahçesi Yönetim Sistemi
            // Soru2HayvanatBahcesi.Run();

            // Soru 3: Banka Hesap Yönetimi
            // Soru3BankaHesapYonetimi.Run();

            Console.WriteLine("\nProgram sonlandırılıyor...");
            Console.ReadLine();
        }
    }

    #region Soru 1: Şirket Çalışan Yönetimi
    // Temel Calisan sınıfı
    class Calisan
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public decimal Maas { get; set; }
        public string Pozisyon { get; set; }

        // Virtual metod
        public virtual void BilgiYazdir()
        {
            Console.WriteLine($"Ad: {Ad}, Soyad: {Soyad}, Maaş: {Maas}, Pozisyon: {Pozisyon}");
        }
    }

    // Yazilimci sınıfı
    class Yazilimci : Calisan
    {
        public string YazilimDili { get; set; }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Yazılım Dili: {YazilimDili}");
        }
    }

    // Muhasebeci sınıfı
    class Muhasebeci : Calisan
    {
        public string MuhasebeYazilimi { get; set; }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Muhasebe Yazılımı: {MuhasebeYazilimi}");
        }
    }

    // Soru 1 Çalıştırma sınıfı
    class Soru1CalisanYonetimi
    {
        public static void Run()
        {
            Console.WriteLine("1. Çalışan Yönetimi\n");

            Console.WriteLine("Çalışan türü seçiniz: (1- Yazilimci, 2- Muhasebeci)");
            int secim = int.Parse(Console.ReadLine());

            if (secim == 1)
            {
                Yazilimci yazilimci = new Yazilimci
                {
                    Ad = "Ali",
                    Soyad = "Yılmaz",
                    Maas = 15000,
                    Pozisyon = "Kıdemli Yazılım Geliştirici",
                    YazilimDili = "C#"
                };
                yazilimci.BilgiYazdir();
            }
            else if (secim == 2)
            {
                Muhasebeci muhasebeci = new Muhasebeci
                {
                    Ad = "Ayşe",
                    Soyad = "Kara",
                    Maas = 12000,
                    Pozisyon = "Muhasebe Müdürü",
                    MuhasebeYazilimi = "Logo"
                };
                muhasebeci.BilgiYazdir();
            }
            else
            {
                Console.WriteLine("Geçersiz seçim!");
            }
        }
    }
    #endregion

    #region Soru 2: Hayvanat Bahçesi Yönetimi
    // Temel Hayvan sınıfı
    class Hayvan
    {
        public string Ad { get; set; }
        public string Tur { get; set; }
        public int Yas { get; set; }

        public virtual void SesCikar()
        {
            Console.WriteLine("Hayvan sesi çıkarıyor...");
        }
    }

    // Memeli sınıfı
    class Memeli : Hayvan
    {
        public string TuyRengi { get; set; }

        public override void SesCikar()
        {
            Console.WriteLine($"{Ad} adlı memeli mırıldanıyor.");
        }
    }

    // Kuş sınıfı
    class Kus : Hayvan
    {
        public double KanatGenisligi { get; set; }

        public override void SesCikar()
        {
            Console.WriteLine($"{Ad} adlı kuş ötüyor.");
        }
    }

    class Soru2HayvanatBahcesi
    {
        public static void Run()
        {
            Console.WriteLine("2. Hayvanat Bahçesi Yönetimi\n");

            Console.WriteLine("Hayvan türü seçiniz: (1- Memeli, 2- Kuş)");
            int secim = int.Parse(Console.ReadLine());

            if (secim == 1)
            {
                Memeli memeli = new Memeli
                {
                    Ad = "Aslan",
                    Tur = "Memeli",
                    Yas = 5,
                    TuyRengi = "Altın Sarısı"
                };
                memeli.SesCikar();
            }
            else if (secim == 2)
            {
                Kus kus = new Kus
                {
                    Ad = "Kartal",
                    Tur = "Kuş",
                    Yas = 3,
                    KanatGenisligi = 2.5
                };
                kus.SesCikar();
            }
            else
            {
                Console.WriteLine("Geçersiz seçim!");
            }
        }
    }
    #endregion

    #region Soru 3: Banka Hesap Yönetimi
    // Temel Hesap sınıfı
    class Hesap
    {
        public string HesapNumarasi { get; set; }
        public decimal Bakiye { get; set; }
        public string HesapSahibi { get; set; }

        public virtual void ParaYatir(decimal miktar)
        {
            Bakiye += miktar;
        }

        public virtual void ParaCek(decimal miktar)
        {
            if (Bakiye >= miktar)
            {
                Bakiye -= miktar;
            }
        }

        public virtual void BilgiYazdir()
        {
            Console.WriteLine($"Hesap Sahibi: {HesapSahibi}, Bakiye: {Bakiye}");
        }
    }

    class VadesizHesap : Hesap
    {
        public decimal EkHesapLimiti { get; set; }
    }

    class VadeliHesap : Hesap
    {
        public int Vade { get; set; }
        public decimal FaizOrani { get; set; }
    }

    class Soru3BankaHesapYonetimi
    {
        public static void Run()
        {
            Console.WriteLine("3. Banka Hesap Yönetimi\n");

            Console.WriteLine("Hesap türü seçiniz: (1- Vadesiz Hesap, 2- Vadeli Hesap)");
            int secim = int.Parse(Console.ReadLine());

            if (secim == 1)
            {
                VadesizHesap vadesiz = new VadesizHesap
                {
                    HesapNumarasi = "12345",
                    HesapSahibi = "Ahmet",
                    Bakiye = 1000,
                    EkHesapLimiti = 500
                };
                vadesiz.BilgiYazdir();
            }
            else if (secim == 2)
            {
                VadeliHesap vadeli = new VadeliHesap
                {
                    HesapNumarasi = "67890",
                    HesapSahibi = "Mehmet",
                    Bakiye = 5000,
                    Vade = 12,
                    FaizOrani = 0.05m
                };
                vadeli.BilgiYazdir();
            }
            else
            {
                Console.WriteLine("Geçersiz seçim!");
            }
        }
    }
    #endregion
}
