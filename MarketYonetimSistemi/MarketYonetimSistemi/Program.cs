using MarketYonetimSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketYonetimSistemi
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Market Yönetim Sistemine Hoşgeldiniz!");

                // Örnek ürünleri oluştur
                List<Urun> urunListesi = new List<Urun>
            {
                new Urun { UrunId = 1, Ad = "Elma", Fiyat = 10.99, StokMiktari = 100, Kategori = "Meyve" },
                new Urun { UrunId = 2, Ad = "Armut", Fiyat = 12.99, StokMiktari = 50, Kategori = "Meyve" },
                new Urun { UrunId = 3, Ad = "Süt", Fiyat = 15.99, StokMiktari = 75, Kategori = "Süt Ürünleri" }
            };

                // Müşteri oluştur
                Console.WriteLine("\nMüşteri Tipi Seçin:");
                Console.WriteLine("1 - Bireysel Müşteri");
                Console.WriteLine("2 - Kurumsal Müşteri");

                Musteri musteri;
                int musteriTipi = Convert.ToInt32(Console.ReadLine());

                if (musteriTipi == 1)
                {
                    Console.Write("Ad: ");
                    string ad = Console.ReadLine();
                    Console.Write("Soyad: ");
                    string soyad = Console.ReadLine();
                    Console.Write("TCKN: ");
                    string tckn = Console.ReadLine();

                    musteri = new BireyselMusteri
                    {
                        MusteriId = 1,
                        Ad = ad,
                        Soyad = soyad,
                        TCKN = tckn
                    };
                }
                else
                {
                    Console.Write("Şirket Adı: ");
                    string sirketAdi = Console.ReadLine();
                    Console.Write("Vergi No: ");
                    string vergiNo = Console.ReadLine();

                    musteri = new KurumsalMusteri
                    {
                        MusteriId = 1,
                        SirketAdi = sirketAdi,
                        VergiNo = vergiNo
                    };
                }

                // Sepet işlemleri
                Sepet sepet = new Sepet(musteri);
                bool alisverisDevam = true;

                while (alisverisDevam)
                {
                    Console.WriteLine("\nMevcut Ürünler:");
                    foreach (var urun in urunListesi)
                    {
                        Console.WriteLine($"{urun.UrunId} - {urun.Ad} - {urun.Fiyat:C2} - Stok: {urun.StokMiktari}");
                    }

                    Console.WriteLine("\nÜrün ID girin (Çıkış için 0):");
                    int secim = Convert.ToInt32(Console.ReadLine());

                    if (secim == 0)
                    {
                        alisverisDevam = false;
                        continue;
                    }

                    var secilenUrun = urunListesi.FirstOrDefault(u => u.UrunId == secim);
                    if (secilenUrun != null)
                    {
                        sepet.UrunEkle(secilenUrun);
                        Console.WriteLine($"{secilenUrun.Ad} sepete eklendi.");
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz ürün ID'si!");
                    }
                }

                // Siparişi oluştur
                var siparis = sepet.SipariseDonus();
                double indirimliTutar = siparis.IndirimliTutarHesapla();

                Console.WriteLine("\nSipariş Özeti:");
                Console.WriteLine($"Toplam Tutar: {siparis.ToplamTutar:C2}");
                Console.WriteLine($"İndirimli Tutar: {indirimliTutar:C2}");

                // Ödeme işlemi
                Console.WriteLine("\nÖdeme Yöntemi Seçin:");
                Console.WriteLine("1 - Kredi Kartı");
                Console.WriteLine("2 - Havale");

                int odemeSecim = Convert.ToInt32(Console.ReadLine());
                Odeme odeme;

                if (odemeSecim == 1)
                {
                    Console.Write("Kart Numarası: ");
                    string kartNo = Console.ReadLine();
                    Console.Write("Son Kullanma Tarihi: ");
                    string skt = Console.ReadLine();
                    Console.Write("CVV: ");
                    string cvv = Console.ReadLine();

                    odeme = new KrediKartiOdeme
                    {
                        OdemeId = 1,
                        Tutar = indirimliTutar,
                        OdemeTarihi = DateTime.Now,
                        KartNumarasi = kartNo,
                        SonKullanmaTarihi = skt,
                        CVV = cvv
                    };
                }
                else
                {
                    Console.Write("IBAN: ");
                    string iban = Console.ReadLine();

                    odeme = new HavaleOdeme
                    {
                        OdemeId = 1,
                        Tutar = indirimliTutar,
                        OdemeTarihi = DateTime.Now,
                        IBAN = iban
                    };
                }

                if (odeme.OdemeYap())
                {
                    siparis.Odeme = odeme;
                    siparis.Durum = Siparis.SiparisDurumu.Hazirlaniyor;
                    Console.WriteLine("\nÖdeme başarılı! Siparişiniz hazırlanıyor.");
                    Console.WriteLine($"Sipariş Durumu: {siparis.Durum}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nHata oluştu: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nProgram sonlandı. Çıkmak için bir tuşa basın...");
                Console.ReadKey();
            }
        }
    }
}
