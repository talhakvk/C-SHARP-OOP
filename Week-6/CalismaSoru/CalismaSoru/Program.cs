using System;
using System.Linq;

// Matematiksel İşlemleri Çeşitlendiren Sınıf
public class MatematikselIslemler
{
    // İki tam sayıyı toplar
    public int Topla(int a, int b) => a + b;

    // Üç tam sayıyı toplar
    public int Topla(int a, int b, int c) => a + b + c;

    // Bir dizi tam sayıyı toplar
    public int Topla(int[] sayilar) => sayilar.Sum();
}

// Farklı Şekillerin Alanını Hesaplayan Sınıf
public class SekilAlanlari
{
    // Karenin alanını hesaplar
    public int Alan(int kenar) => kenar * kenar;

    // Dikdörtgenin alanını hesaplar
    public int Alan(int uzunluk, int genislik) => uzunluk * genislik;

    // Dairenin alanını hesaplar
    public double Alan(double yaricap) => Math.PI * yaricap * yaricap;
}

// Zaman Farkını Farklı Formatlarda Hesaplayan Sınıf
public class ZamanFarki
{
    // İki tarih arasındaki farkı gün cinsinden döndürür
    public int Fark(DateTime baslangic, DateTime bitis) => (bitis - baslangic).Days;

    // İki tarih arasındaki farkı saat cinsinden döndürür
    public int FarkSaat(DateTime baslangic, DateTime bitis) => (int)(bitis - baslangic).TotalHours;

    // İki tarih arasındaki farkı yıl, ay ve gün cinsinden döndürür
    public (int yil, int ay, int gun) FarkAyrinti(DateTime baslangic, DateTime bitis)
    {
        int yil = bitis.Year - baslangic.Year;
        int ay = bitis.Month - baslangic.Month;
        int gun = bitis.Day - baslangic.Day;

        if (gun < 0)
        {
            ay--;
            gun += DateTime.DaysInMonth(baslangic.Year, baslangic.Month);
        }

        if (ay < 0)
        {
            yil--;
            ay += 12;
        }

        return (yil, ay, gun);
    }
}

// Kitaplık Yönetim Sınıfı
public class Kitaplik
{
    private string[] kitaplar;

    // Kitaplık boyutunu belirler
    public Kitaplik(int boyut)
    {
        kitaplar = new string[boyut];
    }

    // İndeksleyici ile kitaplara erişim sağlar
    public string this[int indeks]
    {
        get => indeks >= 0 && indeks < kitaplar.Length ? kitaplar[indeks] : "Geçersiz indeks!";
        set
        {
            if (indeks >= 0 && indeks < kitaplar.Length)
                kitaplar[indeks] = value;
        }
    }
}

// Zaman İşlemleri Struct
public struct Zaman
{
    public int Saat { get; }
    public int Dakika { get; }

    // Zaman nesnesi oluştururken geçerli saat ve dakika değerleri atar
    public Zaman(int saat, int dakika)
    {
        Saat = (saat >= 0 && saat < 24) ? saat : 0;
        Dakika = (dakika >= 0 && dakika < 60) ? dakika : 0;
    }

    // Toplam dakikayı hesaplar
    public int ToplamDakika() => Saat * 60 + Dakika;

    // İki zaman arasındaki farkı dakika olarak hesaplar
    public static int Fark(Zaman z1, Zaman z2) => Math.Abs(z1.ToplamDakika() - z2.ToplamDakika());
}

// Trafik Işığı Durumlarını Temsil Eden Enum ve İlgili Sınıf
public enum TrafikIsigi { Kirmizi, Sari, Yesil }

public class TrafikDurumu
{
    // Trafik ışığına göre yapılması gerekeni döndürür
    public string NeYapmali(TrafikIsigi isik)
    {
        return isik switch
        {
            TrafikIsigi.Kirmizi => "Dur",
            TrafikIsigi.Sari => "Hazırlan",
            TrafikIsigi.Yesil => "Geç",
            _ => "Bilinmiyor"
        };
}
}

// Program Sınıfı: Tüm Sınıfları Test Etmek İçin Kullanılır
class Program
{
    static void Main(string[] args)
    {
        // Matematiksel İşlemler
        MatematikselIslemler matematik = new MatematikselIslemler();
        Console.WriteLine(matematik.Topla(2, 3)); // 5
        Console.WriteLine(matematik.Topla(1, 2, 3)); // 6
        Console.WriteLine(matematik.Topla(new int[] { 1, 2, 3, 4 })); // 10

        // Şekillerin Alanı
        SekilAlanlari sekil = new SekilAlanlari();
        Console.WriteLine(sekil.Alan(4)); // 16 (kare)
        Console.WriteLine(sekil.Alan(4, 5)); // 20 (dikdörtgen)
        Console.WriteLine(sekil.Alan(3.5)); // 38.4845 (daire)

        // Zaman Farkı
        ZamanFarki zamanFarki = new ZamanFarki();
        DateTime baslangic = new DateTime(2024, 11, 1);
        DateTime bitis = new DateTime(2024, 11, 27);
        Console.WriteLine(zamanFarki.Fark(baslangic, bitis)); // 26 gün
        Console.WriteLine(zamanFarki.FarkSaat(baslangic, bitis)); // 624 saat
        var fark = zamanFarki.FarkAyrinti(baslangic, bitis);
        Console.WriteLine($"{fark.yil} yıl, {fark.ay} ay, {fark.gun} gün"); // 0 yıl, 0 ay, 26 gün

        // Kitaplık
        Kitaplik kitaplik = new Kitaplik(3);
        kitaplik[0] = "Harry Potter";
        Console.WriteLine(kitaplik[0]); // Harry Potter
        Console.WriteLine(kitaplik[5]); // Geçersiz indeks!

        // Zaman Struct
        Zaman z1 = new Zaman(10, 30);
        Zaman z2 = new Zaman(12, 45);
        Console.WriteLine(Zaman.Fark(z1, z2)); // 135 dakika

        // Trafik Işıkları
        TrafikDurumu trafik = new TrafikDurumu();
        Console.WriteLine(trafik.NeYapmali(TrafikIsigi.Yesil)); // Geç
    }
}

