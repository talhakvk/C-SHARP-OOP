using System;
using System.Collections.Generic;
using System.Threading;

namespace ArabaYarisiOOP
{
    // Oyuncu arabasını temsil eden sınıf
    class Araba
    {
        public int X { get; set; } // Arabanın yatay konumu
        public int Y { get; set; } // Arabanın dikey konumu (sabit)
        public char Sembol { get; } = 'A'; // Arabayı temsil eden sembol

        public Araba(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void SolaGit()
        {
            if (X > 1) X--; // Sol sınır kontrolü
        }

        public void SagaGit(int yolGenisligi)
        {
            if (X < yolGenisligi - 2) X++; // Sağ sınır kontrolü
        }
    }

    // Engelleri temsil eden sınıf
    class Engel
    {
        public int X { get; set; } // Engel konumu (yatay)
        public int Y { get; set; } // Engel konumu (dikey)
        public char Sembol { get; } = '#'; // Engeli temsil eden sembol

        public Engel(int x, int y)
        {
            X = x;
            Y = y;
        }

        // Engelin bir adım aşağı inmesini sağlar
        public void AsagiGit()
        {
            Y++;
        }
    }

    // Oyunun işleyişini kontrol eden sınıf
    class Oyun
    {
        private Araba araba; // Oyuncunun arabası
        private List<Engel> engeller; // Engeller listesi
        private int yolGenisligi; // Yolun genişliği
        private int hiz; // Oyunun hızı (milisaniye)
        private bool oyunDevamEdiyor;

        public Oyun()
        {
            yolGenisligi = 20; // Yol genişliği
            araba = new Araba(yolGenisligi / 2, 18); // Araba başlangıç konumu
            engeller = new List<Engel>();
            hiz = 100; // Oyunun hızı
            oyunDevamEdiyor = true;
        }

        public void Baslat()
        {
            Console.CursorVisible = false;
            while (oyunDevamEdiyor)
            {
                InputAl(); // Kullanıcıdan giriş al
                EngelleriGuncelle(); // Engelleri güncelle
                Ciz(); // Oyunu ekrana çiz
                CarpismaKontrolu(); // Çarpışma kontrolü
                Thread.Sleep(hiz); // Oyunun hızını kontrol eder
            }

            // Oyun bitti mesajı
            Console.Clear();
            Console.WriteLine("ÇARPIŞMA OLDU! OYUN BİTTİ!");
            Console.WriteLine("Tekrar oynamak için programı yeniden başlat.");
        }

        private void InputAl()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo tus = Console.ReadKey(true);
                if (tus.Key == ConsoleKey.A)
                    araba.SolaGit();
                else if (tus.Key == ConsoleKey.D)
                    araba.SagaGit(yolGenisligi);
            }
        }

        private void EngelleriGuncelle()
        {
            Random rnd = new Random();
            // Rastgele engel oluştur
            if (rnd.Next(0, 10) < 3) // %30 ihtimalle yeni engel oluşturur
            {
                engeller.Add(new Engel(rnd.Next(1, yolGenisligi - 1), 0));
            }

            // Tüm engelleri aşağı hareket ettir
            foreach (var engel in engeller)
            {
                engel.AsagiGit();
            }

            // Ekrandan çıkan engelleri temizle
            engeller.RemoveAll(e => e.Y > 20);
        }

        private void Ciz()
        {
            Console.Clear();
            // Yolun üst çizgisi
            Console.WriteLine("╔" + new string('═', yolGenisligi) + "╗");

            // Yol ve içeriği çiz
            for (int y = 0; y < 20; y++)
            {
                Console.Write("║");
                for (int x = 0; x < yolGenisligi; x++)
                {
                    // Arabayı çiz
                    if (araba.X == x && araba.Y == y)
                        Console.Write(araba.Sembol);
                    // Engelleri çiz
                    else if (engeller.Exists(e => e.X == x && e.Y == y))
                        Console.Write('#');
                    else
                        Console.Write(' '); // Boşluk
                }
                Console.WriteLine("║");
            }

            // Yolun alt çizgisi
            Console.WriteLine("╚" + new string('═', yolGenisligi) + "╝");
        }

        private void CarpismaKontrolu()
        {
            if (engeller.Exists(e => e.X == araba.X && e.Y == araba.Y))
            {
                oyunDevamEdiyor = false; // Çarpışma durumu
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Oyun oyun = new Oyun();
            oyun.Baslat();
        }
    }
}
