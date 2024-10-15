using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace C_SHARP_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Soru
            /* NxN boyutunda spiral matris oluştur ve yazdır
            int N = 5; // Matris boyutu
            SpiralMatris.SpiralOlusturVeYazdir(N);
            Console.ReadKey(); */


            //2.Soru
            /* Kullanıcıdan NxN boyutunda matrisler alınacak
            int N = 3; // Örnek olarak matris boyutu       
            // Örnek matrisler (kullanıcıdan da alınabilir)
            int[,] matris1 = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
            };
            int[,] matris2 = {
            { 9, 8, 7 },
            { 6, 5, 4 },
            { 3, 2, 1 }
            };
            // Matris çarpımını gerçekleştir ve sonucu yazdır
            MatrisCarpim.MatrisCarpiminiYazdir(matris1, matris2, N);
            Console.ReadKey();*/


            //3.Soru
            /*AsalToplami.asalToplam();
            Console.ReadKey();*/


            //4.Soru
            /* Grid tanımlanıyor
            int[,] grid = {
            { 1, 1, 0, 1 },
            { 0, 1, 0, 0 },
            { 1, 1, 1, 0 },
            { 0, 0, 1, 1 }
            };
            // Robotların başlangıç pozisyonları
            List<Tuple<int, int>> robotlar = new List<Tuple<int, int>>
            {
            new Tuple<int, int>(0, 0), // Robot 1
            new Tuple<int, int>(2, 2), // Robot 2
            new Tuple<int, int>(3, 3)  // Robot 3
            };
            // Kaç düğüm kurtarıldığını hesapla
            int kurtarilanDugumler = TechCityRobots.DugumleriKurtar(grid, robotlar);
            Console.WriteLine("Toplam kurtarılan düğüm sayısı: " + kurtarilanDugumler);
            Console.ReadKey();*/


            //5.Soru
            /* Labirent tanımlanıyor
            int[,] labirent = {
            { 1, 0, 0, 0 },
            { 1, 1, 0, 1 },
            { 0, 1, 1, 1 },
            { 0, 0, 0, 1 }
            };
            // En kısa yolu bulma fonksiyonunu çağır
            string sonuc = AltinTapinak.EnKisaYoluBul(labirent);
            Console.WriteLine(sonuc);
            Console.ReadKey();*/
        }
    }

    //1.Soru
    class SpiralMatris
    {
        // Verilen boyuttaki spiral matrisi oluşturur ve yazdırır
        public static void SpiralOlusturVeYazdir(int N)
        {
            int[,] matris = new int[N, N]; // NxN matris oluşturuluyor
            int sayi = 1; // Başlangıç sayısı
            int sol = 0, sag = N - 1, ust = 0, alt = N - 1; // Kenar sınırları

            // Spiral olarak sayıları matrise yerleştirme işlemi
            while (sayi <= N * N)
            {
                // Üst kenar
                for (int i = sol; i <= sag; i++)
                {
                    matris[ust, i] = sayi++;
                }
                ust++; // Üst sınırı bir satır aşağı çekiyoruz

                // Sağ kenar
                for (int i = ust; i <= alt; i++)
                {
                    matris[i, sag] = sayi++;
                }
                sag--; // Sağ sınırı bir sütun sola çekiyoruz

                // Alt kenar
                for (int i = sag; i >= sol; i--)
                {
                    matris[alt, i] = sayi++;
                }
                alt--; // Alt sınırı bir satır yukarı çekiyoruz

                // Sol kenar
                for (int i = alt; i >= ust; i--)
                {
                    matris[i, sol] = sayi++;
                }
                sol++; // Sol sınırı bir sütun sağa çekiyoruz
            }

            // Matrisi ekrana yazdırma
            MatrisYazdir(matris, N);
        }

        // Matrisi ekrana yazdırma fonksiyonu
        private static void MatrisYazdir(int[,] matris, int N)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(matris[i, j].ToString().PadLeft(3) + " ");
                }
                Console.WriteLine();
            }
        }
    }


    //2.Soru
    class MatrisCarpim
    {
        // Kullanıcıdan iki NxN matris alıp çarpımını yapan fonksiyon
        public static int[,] MatrisCarp(int[,] matris1, int[,] matris2, int N)
        {
            int[,] sonucMatrisi = new int[N, N]; // Sonuç matrisi

            // Matris çarpımı işlemi
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    sonucMatrisi[i, j] = 0;
                    for (int k = 0; k < N; k++)
                    {
                        sonucMatrisi[i, j] += matris1[i, k] * matris2[k, j]; // Matris çarpımı kuralı
                    }
                }
            }

            return sonucMatrisi; // Çarpım sonucu döndürülüyor
        }

        // İki matrisi çarp ve sonucu yazdır
        public static void MatrisCarpiminiYazdir(int[,] matris1, int[,] matris2, int N)
        {
            int[,] sonuc = MatrisCarp(matris1, matris2, N); // Matris çarpımını çağır

            Console.WriteLine("Sonuç Matrisi:");
            MatrisYazdir(sonuc, N); // Sonucu yazdır
        }

        // Matrisi ekrana yazdıran fonksiyon
        private static void MatrisYazdir(int[,] matris, int N)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(matris[i, j].ToString().PadLeft(4) + " ");
                }
                Console.WriteLine();
            }
        }
    }


    //3.Soru
    class AsalToplami
    {
        // asalToplam() metodu, verilen sayıya kadar olan asal sayıların toplamını hesaplar
        public static void asalToplam()
        {
            string temp = "E"; // Kullanıcının devam edip etmeyeceğini kontrol eden değişken
            while (temp == "E") // Kullanıcı "E" yazdığı sürece döngü devam eder
            {
                // Kullanıcıdan 2'den büyük bir sayı girmesini ister
                Console.Write("Lütfen ikiden büyük bir sayı girin:");
                string input = Console.ReadLine();
                int sayi = int.Parse(input); // Girdiği sayıyı tam sayı formatına çevirir
                int toplam = 2; // Asal sayıların toplamı için başlangıç değeri (2 asaldır)

                // Eğer kullanıcı 2'den küçük bir sayı girerse, uyarı verir
                if (sayi < 2)
                {
                    Console.WriteLine("Lütfen 2'den büyük bir sayı girin.");
                }
                else if (sayi == 2) // Eğer kullanıcı sadece 2 girerse, toplamı direkt verir
                {
                    Console.WriteLine("Toplam:" + toplam);
                }
                else
                {
                    // 3'ten başlayarak girilen sayıya kadar olan tüm sayıları kontrol eder
                    for (int i = 3; i <= sayi; i++)
                    {
                        bool asal = true; // Sayının asal olup olmadığını kontrol eden değişken
                        for (int j = 2; j < i; j++) // Sayının asallığını kontrol etmek için bölünebilirliğini test eder
                        {
                            if (i % j == 0) // Eğer sayı, j'ye tam bölünürse asal değildir
                            {
                                asal = false;
                                break; // Bölündüğü an asallık kontrolünü sonlandırır
                            }
                        }
                        if (asal) // Eğer sayı asal ise, toplam değişkenine eklenir
                        {
                            toplam += i;
                        }
                    }
                }

                // Girilen sayıdaki asal sayıların toplamını ekrana yazdırır
                Console.WriteLine("Toplam: " + toplam);

                // Kullanıcıya devam etmek isteyip istemediğini sorar
                Console.Write("Devam etmek istiyor musunuz? E/H: ");
                temp = Console.ReadLine(); // Kullanıcının cevabını alır ve döngü buna göre devam eder
                Console.WriteLine("Hoşçakalın..."); //Kullanıcıya veda mesajı verir
            }
        }
    }


    //4.Soru
    class TechCityRobots
    {
        // Hareket yönleri: yukarı, aşağı, sol, sağ
        private static readonly int[] dx = { -1, 1, 0, 0 };
        private static readonly int[] dy = { 0, 0, -1, 1 };

        // Grid ve başlangıç pozisyonlarını alır ve düğüm sayısını hesaplar
        public static int DugumleriKurtar(int[,] grid, List<Tuple<int, int>> robotlar)
        {
            int boyut = grid.GetLength(0); // Grid boyutu
            bool[,] ziyaretEdildi = new bool[boyut, boyut]; // Hangi düğümlerin ziyaret edildiği

            int toplamKurtarilan = 0;

            // Her robot için kurtarılabilir düğümleri hesapla
            foreach (var robot in robotlar)
            {
                toplamKurtarilan += RobotHareketi(grid, ziyaretEdildi, robot.Item1, robot.Item2);
            }

            return toplamKurtarilan;
        }

        // Robotun hangi düğümleri kurtarabileceğini BFS ile bulur
        private static int RobotHareketi(int[,] grid, bool[,] ziyaretEdildi, int baslangicX, int baslangicY)
        {
            int boyut = grid.GetLength(0);

            // Başlangıç noktasının zarar görüp görmediğini kontrol et
            if (grid[baslangicX, baslangicY] == 0 || ziyaretEdildi[baslangicX, baslangicY])
                return 0;

            int kurtarilanDugum = 0;
            Queue<Tuple<int, int>> kuyruk = new Queue<Tuple<int, int>>();
            kuyruk.Enqueue(new Tuple<int, int>(baslangicX, baslangicY));
            ziyaretEdildi[baslangicX, baslangicY] = true;
            kurtarilanDugum++;

            // Kuyruktaki düğümler bitene kadar devam et
            while (kuyruk.Count > 0)
            {
                var dugum = kuyruk.Dequeue();
                int x = dugum.Item1;
                int y = dugum.Item2;

                // Komşu düğümleri kontrol et
                for (int i = 0; i < 4; i++)
                {
                    int yeniX = x + dx[i];
                    int yeniY = y + dy[i];

                    // Eğer komşu düğüm grid sınırları içindeyse ve ziyaret edilmemişse
                    if (yeniX >= 0 && yeniX < boyut && yeniY >= 0 && yeniY < boyut && grid[yeniX, yeniY] == 1 && !ziyaretEdildi[yeniX, yeniY])
                    {
                        kuyruk.Enqueue(new Tuple<int, int>(yeniX, yeniY));
                        ziyaretEdildi[yeniX, yeniY] = true;
                        kurtarilanDugum++;
                    }
                }
            }

            return kurtarilanDugum; // Robotun kurtardığı düğüm sayısını döner
        }
    }


    //5.Soru
    class AltinTapinak
    {
        // Hareket yönleri: yukarı, aşağı, sağ, sol
        private static readonly int[] dx = { -1, 1, 0, 0 };
        private static readonly int[] dy = { 0, 0, 1, -1 };

        // Labirenti ve en kısa yolu bulacak fonksiyon
        public static string EnKisaYoluBul(int[,] labirent)
        {
            int N = labirent.GetLength(0); // Labirent boyutu
            bool[,] ziyaretEdildi = new bool[N, N]; // Ziyaret edilen hücreler
            Queue<Tuple<int, int, int>> kuyruk = new Queue<Tuple<int, int, int>>(); // BFS için kuyruk

            // Başlangıç noktasını kuyruğa ekle
            kuyruk.Enqueue(new Tuple<int, int, int>(0, 0, 0));
            ziyaretEdildi[0, 0] = true;

            // Kuyruk boşalana kadar devam et
            while (kuyruk.Count > 0)
            {
                var mevcut = kuyruk.Dequeue();
                int x = mevcut.Item1;
                int y = mevcut.Item2;
                int adimSayisi = mevcut.Item3;

                // Hazine noktasına ulaşıldığında adım sayısını döndür
                if (x == N - 1 && y == N - 1)
                {
                    return $"En Kısa Yol: {adimSayisi + 1} adım";
                }

                // Komşu hücreleri kontrol et
                for (int i = 0; i < 4; i++)
                {
                    int yeniX = x + dx[i];
                    int yeniY = y + dy[i];

                    // Geçerli bir hücre ise (sınırlar içinde, yürünebilir ve ziyaret edilmemişse)
                    if (yeniX >= 0 && yeniX < N && yeniY >= 0 && yeniY < N && labirent[yeniX, yeniY] == 1 && !ziyaretEdildi[yeniX, yeniY])
                    {
                        kuyruk.Enqueue(new Tuple<int, int, int>(yeniX, yeniY, adimSayisi + 1));
                        ziyaretEdildi[yeniX, yeniY] = true;
                    }
                }
            }

            // Hazineye ulaşılamadıysa
            return "Yol Yok";
        }
    }
}
