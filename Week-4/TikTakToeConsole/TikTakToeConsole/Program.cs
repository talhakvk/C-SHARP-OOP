using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTakToeConsole
{
    class Program
    {
        // Oyun tahtası (3x3 matris)
        static char[,] tahta = {
            { '1', '2', '3' },
            { '4', '5', '6' },
            { '7', '8', '9' }
        };
        static char mevcutOyuncu = 'X'; // Şu an oynayan oyuncu ('X' veya 'O')

        static void Main(string[] args)
        {
            int hamleSayisi = 0; // Toplam yapılan hamle sayısı
            bool oyunKazandi = false; // Oyunun kazanılıp kazanılmadığını belirten bayrak

            // Oyun devam ettiği sürece çalışacak döngü
            while (!oyunKazandi && hamleSayisi < 9)
            {
                Console.Clear();
                TahtayiCiz();
                Console.WriteLine($"Oyuncu {mevcutOyuncu}, lütfen bir pozisyon seçin:");

                // Oyuncudan pozisyon girişi alıyoruz ve geçerliliğini kontrol ediyoruz
                if (int.TryParse(Console.ReadLine(), out int pozisyon) && PozisyonGecerliMi(pozisyon))
                {
                    HamleYap(pozisyon);
                    hamleSayisi++;

                    // Kazanma durumu kontrol ediliyor
                    oyunKazandi = KazandiMi();
                    if (!oyunKazandi)
                        mevcutOyuncu = mevcutOyuncu == 'X' ? 'O' : 'X'; // Oyuncu değişimi
                }
                else
                {
                    Console.WriteLine("Geçersiz pozisyon, lütfen tekrar deneyin.");
                    Console.ReadLine();
                }
            }

            // Oyun sonucu ekrana yazılıyor
            Console.Clear();
            TahtayiCiz();
            if (oyunKazandi)
            {
                Console.WriteLine($"Tebrikler! Oyuncu {mevcutOyuncu} kazandı!");
            }
            else
            {
                Console.WriteLine("Oyun berabere!");
            }
        }

        // Oyun tahtasını ekrana çizen metod
        static void TahtayiCiz()
        {
            Console.WriteLine("   |   |   ");
            Console.WriteLine($" {tahta[0, 0]} | {tahta[0, 1]} | {tahta[0, 2]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {tahta[1, 0]} | {tahta[1, 1]} | {tahta[1, 2]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {tahta[2, 0]} | {tahta[2, 1]} | {tahta[2, 2]} ");
            Console.WriteLine("   |   |   ");
        }

        // Seçilen pozisyonun geçerli olup olmadığını kontrol eden metod
        static bool PozisyonGecerliMi(int pozisyon)
        {
            int satir = (pozisyon - 1) / 3;
            int sutun = (pozisyon - 1) % 3;
            return tahta[satir, sutun] != 'X' && tahta[satir, sutun] != 'O';
        }

        // Seçilen pozisyona hamle yapma metod
        static void HamleYap(int pozisyon)
        {
            int satir = (pozisyon - 1) / 3;
            int sutun = (pozisyon - 1) % 3;
            tahta[satir, sutun] = mevcutOyuncu;
        }

        // Kazanma durumunu kontrol eden metod
        static bool KazandiMi()
        {
            // Satırları kontrol et
            for (int i = 0; i < 3; i++)
            {
                if (tahta[i, 0] == mevcutOyuncu && tahta[i, 1] == mevcutOyuncu && tahta[i, 2] == mevcutOyuncu)
                    return true;
            }

            // Sütunları kontrol et
            for (int i = 0; i < 3; i++)
            {
                if (tahta[0, i] == mevcutOyuncu && tahta[1, i] == mevcutOyuncu && tahta[2, i] == mevcutOyuncu)
                    return true;
            }

            // Çaprazları kontrol et
            if (tahta[0, 0] == mevcutOyuncu && tahta[1, 1] == mevcutOyuncu && tahta[2, 2] == mevcutOyuncu)
                return true;
            if (tahta[0, 2] == mevcutOyuncu && tahta[1, 1] == mevcutOyuncu && tahta[2, 0] == mevcutOyuncu)
                return true;

            return false;
        }
    }
}
