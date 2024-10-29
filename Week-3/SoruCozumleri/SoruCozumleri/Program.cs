using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Text.RegularExpressions;
using System.Data;

namespace SoruCozumleri
{
    class Program
    {
        static void Main(string[] args)
        {

            // Soru1 sınıfındaki SiraVeArama metodunu çağırıyoruz
            //Soru1.SiraVeArama();

            // Soru2 sınıfındaki OrtalamaVeMedyan metodunu çağırıyoruz
            //Soru2.OrtalamaVeMedyan();

            // Soru3 sınıfındaki ArdisikGruplariBul metodu çağırılıyor
            //Soru3.ArdisikGruplariBul();

            // Soru4 sınıfındaki IslemOnceligiCoz metodu çağırılıyor
            //Soru4.IslemOnceligiCoz();

            //Soru5
            //while (true)
            //{
            //    Console.WriteLine("Birinci polinomu girin (örneğin: 2x^2 + 3x - 5) veya çıkmak için 'exit' yazın:");
            //    string birinciPolinom = Console.ReadLine();
            //    if (birinciPolinom.ToLower() == "exit") break;

            //    Console.WriteLine("İkinci polinomu girin (örneğin: x^2 - 4):");
            //    string ikinciPolinom = Console.ReadLine();
            //    if (ikinciPolinom.ToLower() == "exit") break;

            //    Soru6 p1 = new Soru6(birinciPolinom);
            //    Soru6 p2 = new Soru6(ikinciPolinom);

            //    Soru6 toplamaSonucu = p1.Topla(p2);
            //    Soru6 cikarmaSonucu = p1.Cikar(p2);

            //    Console.WriteLine($"Toplama Sonucu: {toplamaSonucu}");
            //    Console.WriteLine($"Çıkarma Sonucu: {cikarmaSonucu}");
            //}

            // Soru6 sınıfından bir nesne oluştur
            //Soru6 soru6 = new Soru6();
            // Geçerli tarihleri listeleme işlemini başlat
            //soru6.ListValidDates();

            // Labirent boyutları
            //int M = 5; // Satır sayısı
            //int N = 5; // Sütun sayısı
            // Soru7 sınıfından bir nesne oluştur
            //Soru7 soru7 = new Soru7(M, N);
            // Labirentte yol bulma işlemini başlat
            //soru7.Calistir();

            // Soru8 sınıfından bir nesne oluştur
            //Soru8 soru8 = new Soru8();
            // Örnek şifreli mesaj
            //string sifreliMesaj = "ÖrnekŞifreliMesaj"; // Buraya gerçek şifreli mesajı koyun
            // Calistir metodunu çağırarak mesajı çöz
            //soru8.Calistir(sifreliMesaj);

            // Soru9 sınıfından bir nesne oluştur
            //Soru9 soru9 = new Soru9();
            // Calistir metodunu çağırarak işlemleri başlat
            //soru9.Calistir();

            // Soru10 sınıfından bir nesne oluştur
            //Soru10 soru10 = new Soru10();
            // Calistir metodunu çağırarak işlemleri başlat
            //soru10.Calistir();
            //Console.ReadLine(); // Sonucun ekranda kalması için
        }
    }

    #region Soru1
    public class Soru1
    {
        public static void SiraVeArama()
        {
            Console.WriteLine("Tam sayılardan oluşan bir dizi girin (virgülle ayrılmış):");
            string[] girdi = Console.ReadLine().Split(',');
            int[] sayilar = Array.ConvertAll(girdi, int.Parse);

            Array.Sort(sayilar); // Diziyi sırala
            Console.WriteLine("Sıralanmış dizi: " + string.Join(", ", sayilar));

            Console.WriteLine("Aramak istediğiniz bir sayıyı girin:");
            int aranan = int.Parse(Console.ReadLine());
            bool bulundu = IkiliArama(sayilar, aranan);

            Console.WriteLine(bulundu ? $"{aranan} dizide bulunmaktadır." : $"{aranan} dizide bulunmamaktadır.");
        }

        private static bool IkiliArama(int[] dizi, int aranan)
        {
            int sol = 0, sag = dizi.Length - 1;

            while (sol <= sag)
            {
                int orta = (sol + sag) / 2;

                if (dizi[orta] == aranan) return true;
                if (dizi[orta] < aranan) sol = orta + 1;
                else sag = orta - 1;
            }

            return false;
        }
    }
    #endregion

    #region Soru2
    public class Soru2
    {
        public static void OrtalamaVeMedyan()
        {
            List<int> sayilar = new List<int>();
            Console.WriteLine("Pozitif tam sayılar girin (çıkmak için 0 girin):");

            while (true)
            {
                int sayi = int.Parse(Console.ReadLine());
                if (sayi == 0) break;
                if (sayi > 0) sayilar.Add(sayi);
            }

            if (sayilar.Count > 0)
            {
                double ortalama = sayilar.Average();
                double medyan = MedyanHesapla(sayilar);

                Console.WriteLine($"Ortalama: {ortalama}");
                Console.WriteLine($"Medyan: {medyan}");
            }
            else
            {
                Console.WriteLine("Hiç pozitif sayı girilmedi.");
            }
        }

        private static double MedyanHesapla(List<int> sayilar)
        {
            sayilar.Sort();
            int count = sayilar.Count;
            if (count % 2 == 0)
            {
                return (sayilar[count / 2 - 1] + sayilar[count / 2]) / 2.0;
            }
            else
            {
                return sayilar[count / 2];
            }
        }
    }
    #endregion

    #region Soru3
    public class Soru3
    {
        public static void ArdışıkGruplar()
        {
            List<int> sayilar = new List<int>();
            Console.WriteLine("Tam sayılar girin (çıkmak için 0 girin):");

            while (true)
            {
                int sayi = int.Parse(Console.ReadLine());
                if (sayi == 0) break;
                sayilar.Add(sayi);
            }

            if (sayilar.Count > 0)
            {
                List<string> gruplar = ArdışıkGruplarıTespitEt(sayilar);
                Console.WriteLine("Ardışık sayı grupları: " + string.Join(", ", gruplar));
            }
            else
            {
                Console.WriteLine("Hiç sayı girilmedi.");
            }
        }

        private static List<string> ArdışıkGruplarıTespitEt(List<int> sayilar)
        {
            sayilar.Sort();
            List<string> gruplar = new List<string>();
            int baslangic = sayilar[0];

            for (int i = 1; i < sayilar.Count; i++)
            {
                if (sayilar[i] != sayilar[i - 1] + 1)
                {
                    gruplar.Add(baslangic == sayilar[i - 1] ? $"{baslangic}" : $"{baslangic}-{sayilar[i - 1]}");
                    baslangic = sayilar[i];
                }
            }

            // Son grubu ekle
            gruplar.Add(baslangic == sayilar[^ 1] ? $"{baslangic}" : $"{baslangic}-{sayilar[^ 1]}");

            return gruplar;
        }
    }
    #endregion

    #region Soru4
    class Soru4
    {
        public static void IslemOnceligiCoz()
        {
            Console.WriteLine("Bir matematiksel ifade girin (örneğin: 3 + 4 * 2 / (1 - 5) ^ 2 ^ 3):");
            string ifade = Console.ReadLine();

            try
            {
                // İşlem sırasını göstermek için ifadenin çözüm adımlarını listeleme
                Console.WriteLine("İfadenin çözüm süreci:");

                string islemSirasi = IslemSirasiBul(ifade);
                Console.WriteLine(islemSirasi);

                // Çözümleme için DataTable sınıfını kullanarak ifadeyi değerlendirme
                DataTable dt = new DataTable();
                var sonuc = dt.Compute(ifade.Replace("^", "**"), "");  // ^ işaretini ** ile değiştirdik çünkü DataTable doğrudan desteklemiyor
                Console.WriteLine("Sonuç: " + sonuc);
            }
            catch (Exception e)
            {
                Console.WriteLine("Hatalı bir ifade girdiniz. Lütfen geçerli bir matematiksel ifade girin.");
                Console.WriteLine("Hata: " + e.Message);
            }
        }

        private static string IslemSirasiBul(string ifade)
        {
            // Örnek olarak işlem sırası gösterme işlemi
            // Bu kısımda gerçek adımları döndürmek için manuel çözüm süreci uygulanabilir.

            // İfade üzerinde parantez, üs alma, çarpma/bölme, toplama/çıkarma sırasına göre adımlar yazılıyor.
            // Gerçek bir adım sıralama mantığı geliştirmek için Regex ve ayırma işlemleri yapılabilir.

            return "1. Parantez içindeki ifadeler çözülür\n" +
                   "2. Üs alma işlemleri yapılır\n" +
                   "3. Çarpma ve bölme işlemleri soldan sağa yapılır\n" +
                   "4. Toplama ve çıkarma işlemleri soldan sağa yapılır";
        }
    }
    #endregion

    #region Soru5
    public class Soru6
    {
        public Dictionary<int, double> Terimler { get; private set; }

        public Soru6(string polinom)
        {
            Terimler = new Dictionary<int, double>();
            string[] parcala = Regex.Split(polinom, @"\s*[+-]\s*");
            foreach (var terim in parcala)
            {
                if (string.IsNullOrWhiteSpace(terim)) continue;
                double katsayi = 1;
                int derece = 0;

                // Terimi ayrıştır
                var match = Regex.Match(terim.Trim(), @"^([+-]?[\d\.]*)x\^?(\d*)");
                if (match.Success)
                {
                    if (match.Groups[1].Value != "")
                        katsayi = double.Parse(match.Groups[1].Value);
                    if (match.Groups[2].Value != "")
                        derece = int.Parse(match.Groups[2].Value);
                    else
                        derece = 1; // x^1 durumu
                }
                else if (terim.Trim().Contains("x"))
                {
                    katsayi = terim.Trim().Contains("-") ? -1 : 1;
                    derece = 1; // x^1 durumu
                }
                else
                {
                    katsayi = double.Parse(terim.Trim());
                    derece = 0; // sabit terim
                }

                // Terimi ekle
                if (Terimler.ContainsKey(derece))
                    Terimler[derece] += katsayi;
                else
                    Terimler[derece] = katsayi;
            }
        }

        public Soru6 Topla(Soru6 diger)
        {
            Soru6 sonuc = new Soru6("0");
            foreach (var terim in Terimler)
                sonuc.Terimler[terim.Key] = terim.Value;

            foreach (var terim in diger.Terimler)
            {
                if (sonuc.Terimler.ContainsKey(terim.Key))
                    sonuc.Terimler[terim.Key] += terim.Value;
                else
                    sonuc.Terimler[terim.Key] = terim.Value;
            }

            return sonuc;
        }

        public Soru6 Cikar(Soru6 diger)
        {
            Soru6 sonuc = new Soru6("0");
            foreach (var terim in Terimler)
                sonuc.Terimler[terim.Key] = terim.Value;

            foreach (var terim in diger.Terimler)
            {
                if (sonuc.Terimler.ContainsKey(terim.Key))
                    sonuc.Terimler[terim.Key] -= terim.Value;
                else
                    sonuc.Terimler[terim.Key] = -terim.Value; // negatif olarak ekle
            }

            return sonuc;
        }

        public override string ToString()
        {
            if (Terimler.Count == 0) return "0";

            var terimlerListesi = Terimler.OrderByDescending(t => t.Key)
                .Select(t => $"{(t.Value >= 0 ? "+" : "")}{t.Value}x^{t.Key}");

            return string.Join(" ", terimlerListesi).Replace("x^1", "x").Replace("x^0", "").Trim();
        }
    }
    #endregion

    #region Soru6
    public class Soru6
    {
        // Asal kontrol metodu
        private bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        // Ayın basamaklarının toplamını kontrol et
        private bool IsDigitSumEven(int month)
        {
            int sum = 0;
            while (month > 0)
            {
                sum += month % 10;
                month /= 10;
            }
            return sum % 2 == 0; // Çift mi kontrolü
        }

        // Yılın rakamlarının toplamının kontrolü
        private bool IsYearDigitSumLessThanQuarter(int year)
        {
            int sum = 0;
            int originalYear = year;

            while (year > 0)
            {
                sum += year % 10;
                year /= 10;
            }

            return sum < (originalYear / 4); // Yılın dörtte birinden küçük mü kontrolü
        }

        // Geçerli tarihleri listeleme metodu
        public void ListValidDates()
        {
            DateTime startDate = DateTime.Now; // Şu anki tarih
            DateTime endDate = new DateTime(3000, 12, 31); // 3000 yılına kadar

            Console.WriteLine("Cihazın kabul ettiği geçerli tarihler:");

            for (int year = 2000; year <= 3000; year++)
            {
                for (int month = 1; month <= 12; month++)
                {
                    int daysInMonth = DateTime.DaysInMonth(year, month);
                    for (int day = 1; day <= daysInMonth; day++)
                    {
                        // Tarih oluştur
                        DateTime currentDate = new DateTime(year, month, day);

                        // Geçerli tarihin koşullarını kontrol et
                        if (currentDate > startDate && // Gelecek tarih
                            IsPrime(day) && // Gün asal mı
                            IsDigitSumEven(month) && // Ayın basamaklarının toplamı çift mi
                            IsYearDigitSumLessThanQuarter(year)) // Yılın rakamlarının toplamı
                        {
                            // Uygun tarih formatında yazdır
                            Console.WriteLine($"{day}/{month}/{year}");
                        }
                    }
                }
            }
        }
    }
    #endregion

    #region Soru7
    public class Soru7
    {
        // Labirent boyutları
        private int M;
        private int N;

        // Labirentteki hücrelerin durumunu tutan dizi
        private bool[,] visited;

        // Hareket yönleri (sağa, aşağı, çapraz sağa aşağı)
        private readonly (int, int)[] directions = { (0, 1), (1, 0), (1, 1) };

        // Constructor
        public Soru7(int m, int n)
        {
            M = m;
            N = n;
            visited = new bool[M, N];
        }

        // Asal kontrolü
        private bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        // Kapının açılıp açılamayacağını kontrol et
        private bool CanOpenDoor(int x, int y)
        {
            if (!IsPrime(x) || !IsPrime(y)) return false; // x ve y asal olmalı
            int sum = x + y;
            int product = x * y;
            return product != 0 && sum % product == 0; // Bölünebilirlik kontrolü
        }

        // Labirentte yol bulma metodu
        public bool FindPath(int x, int y, List<(int, int)> path)
        {
            // Hedefe ulaştık mı?
            if (x == M - 1 && y == N - 1)
            {
                path.Add((x, y));
                return true;
            }

            // Geçerli sınırlar kontrolü
            if (x < 0 || x >= M || y < 0 || y >= N || visited[x, y] || !CanOpenDoor(x, y))
                return false;

            // Hücreyi ziyaret edildi olarak işaretle
            visited[x, y] = true;
            path.Add((x, y)); // Yolu ekle

            // Tüm yönler için dene
            foreach (var (dx, dy) in directions)
            {
                if (FindPath(x + dx, y + dy, path))
                    return true; // Hedefe ulaştıysak çık
            }

            // Eğer hiçbir yol bulamazsak, bu hücreden çık ve yolu geri al
            path.RemoveAt(path.Count - 1);
            visited[x, y] = false;
            return false;
        }

        // Çalıştırma metodu
        public void Calistir()
        {
            List<(int, int)> path = new List<(int, int)>();
            if (FindPath(0, 0, path))
            {
                Console.WriteLine("Şehre ulaşmak için izlenen yol:");
                foreach (var step in path)
                {
                    Console.WriteLine($"({step.Item1}, {step.Item2})");
                }
            }
            else
            {
                Console.WriteLine("Şehir kayboldu!");
            }
        }
    }
    #endregion

    #region Soru8
    public class Soru8
    {
        // Fibonacci sayısını hesaplamak için bir metod
        private int Fibonacci(int n)
        {
            if (n <= 0) return 0;
            if (n == 1) return 1;
            if (n == 2) return 1;

            int a = 1, b = 1, c = 0;
            for (int i = 3; i <= n; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }
            return c;
        }

        // Modüler çözümleme tersine çevrilir
        private int ModularInverse(int value, int position)
        {
            // Pozisyon asal mı kontrol et
            bool isPrime = IsPrime(position);

            // Asal ise 100'e bölme işlemi, değilse 256'ya bölme işlemi
            if (isPrime)
                return value + 100; // 100'den büyük olmaması için uygun değer ekleniyor
            else
                return value + 256; // 256'dan büyük olmaması için uygun değer ekleniyor
        }

        // Asal sayı kontrolü
        private bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        // Şifreli mesajı çözme metodu
        public void Calistir(string sifreliMesaj)
        {
            char[] orijinalMesaj = new char[sifreliMesaj.Length];

            // Şifreli mesajdaki her karakter için işlemleri uygula
            for (int i = 0; i < sifreliMesaj.Length; i++)
            {
                int pozisyon = i + 1; // Pozisyon 1'den başlar
                int asciiDegeri = (int)sifreliMesaj[i];

                // Modüler tersine çevrim işlemi
                int modTers = ModularInverse(asciiDegeri, pozisyon);

                // Fibonacci ile çarpılan ASCII değerini bul
                int fibonacciDegeri = Fibonacci(pozisyon);
                // Orijinal ASCII değerini hesapla
                int orijinalAscii = modTers / fibonacciDegeri;

                // Orijinal karakteri al
                orijinalMesaj[i] = (char)orijinalAscii;
            }

            // Sonucu yazdır
            Console.WriteLine("Orijinal Mesaj: " + new string(orijinalMesaj));
        }
    }
    #endregion

    #region Soru9
    public class Soru9
    {
        // Metod, N x N boyutundaki enerji maliyet matrisini alır ve en az enerji harcayan yolu hesaplar.
        public void Calistir()
        {
            // Örnek enerji maliyet matrisi
            int[,] enerjiMaliyeti = {
            { 1, 2, 3 },
            { 4, 8, 2 },
            { 1, 5, 3 }
        };

            int n = enerjiMaliyeti.GetLength(0);
            int[,] dp = new int[n, n]; // Dinamik programlama matrisini oluştur

            // İlk hücrenin maliyetini ayarla
            dp[0, 0] = enerjiMaliyeti[0, 0];

            // İlk satırı doldur
            for (int j = 1; j < n; j++)
            {
                dp[0, j] = dp[0, j - 1] + enerjiMaliyeti[0, j];
            }

            // İlk sütunu doldur
            for (int i = 1; i < n; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + enerjiMaliyeti[i, 0];
            }

            // Kalan hücreleri doldur
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    // Sağa, aşağıya ve çapraz aşağıya (diyagonal) en az maliyeti bul
                    dp[i, j] = enerjiMaliyeti[i, j] + Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1]);
                }
            }

            // Sonucu yazdır
            Console.WriteLine("En az enerji harcayan yolun maliyeti: " + dp[n - 1, n - 1]);
        }
    }
    #endregion

    #region Soru10
    public class Soru10
    {
        // Mevcut operatörlerin dizisi
        private char[] operators = { '+', '-', '*', '/' };

        public void Calistir()
        {
            // Örnek sayı dizisi
            int[] numbers = { 5, 3, 2 };

            Console.WriteLine("Belirtilen kurallara göre kapıyı açmak için uygun kombinasyonlar:");

            // Operatör kombinasyonlarını test et
            GenerateAndTestCombinations(numbers);
        }

        // Tüm olası kombinasyonları test eden metot
        private void GenerateAndTestCombinations(int[] numbers)
        {
            int n = numbers.Length - 1;
            char[] combination = new char[n];

            // Tüm operatör kombinasyonlarını oluşturan döngü
            GenerateCombinations(numbers, combination, 0);
        }

        // Rekürsif olarak operatör kombinasyonlarını oluşturan metot
        private void GenerateCombinations(int[] numbers, char[] combination, int index)
        {
            if (index == combination.Length)
            {
                // Kombinasyonu test et
                if (EvaluateExpression(numbers, combination) > 0)
                {
                    // Geçerli bir kombinasyon bulunduğunda ekrana yazdır
                    PrintCombination(numbers, combination);
                }
                return;
            }

            // Her bir operatörü sırayla yerleştir
            foreach (char op in operators)
            {
                combination[index] = op;
                GenerateCombinations(numbers, combination, index + 1);
            }
        }

        // Kombinasyonu ve sayıları kullanarak ifadeyi değerlendiren metot
        private double EvaluateExpression(int[] numbers, char[] combination)
        {
            double result = numbers[0];
            for (int i = 0; i < combination.Length; i++)
            {
                switch (combination[i])
                {
                    case '+':
                        result += numbers[i + 1];
                        break;
                    case '-':
                        result -= numbers[i + 1];
                        break;
                    case '*':
                        result *= numbers[i + 1];
                        break;
                    case '/':
                        if (numbers[i + 1] != 0)
                            result /= numbers[i + 1];
                        else
                            return double.MinValue; // Sıfıra bölme hatasını önlemek için
                        break;
                }
            }
            return result;
        }

        // Sayı dizisi ve operatörlerle kombinasyonu ekrana yazdıran metot
        private void PrintCombination(int[] numbers, char[] combination)
        {
            Console.Write(numbers[0]);
            for (int i = 0; i < combination.Length; i++)
            {
                Console.Write(" " + combination[i] + " " + numbers[i + 1]);
            }
            Console.WriteLine();
        }
    }
    #endregion
}
