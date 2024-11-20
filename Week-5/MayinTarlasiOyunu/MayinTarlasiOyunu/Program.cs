using System;

namespace MayinTarlasiOyunu
{
    // Her bir hücreyi temsil eden sınıf
    public class Hucre
    {
        public bool MayinVarMi { get; set; } // Hücrede mayın olup olmadığını belirler
        public bool AcildiMi { get; set; } // Hücrenin açılıp açılmadığını belirler
        public int CevredekiMayinSayisi { get; set; } // Hücre çevresindeki mayın sayısını tutar
    }

    // Mayın tarlasını temsil eden sınıf
    public class MayinTarlasi
    {
        private const int Boyut = 20; // Mayın tarlası boyutu (20x20)
        private const int ToplamMayin = 40; // Oyunda bulunacak toplam mayın sayısı
        private Hucre[,] tarla; // Hücrelerden oluşan 2D dizi (Mayın tarlası)

        public MayinTarlasi()
        {
            tarla = new Hucre[Boyut, Boyut]; // 20x20 boyutunda tarla oluşturulur
            TarlaOlustur(); // Hücreler başlangıç değerleriyle oluşturulur
            MayinlariYerlestir(); // Rastgele mayınlar tarlaya yerleştirilir
            CevredekiMayinlariHesapla(); // Her hücre için çevresindeki mayın sayısı hesaplanır
        }

        // Tarlayı başlangıçta boş hücrelerle doldurur
        private void TarlaOlustur()
        {
            for (int i = 0; i < Boyut; i++)
            {
                for (int j = 0; j < Boyut; j++)
                {
                    tarla[i, j] = new Hucre(); // Her hücre için yeni bir Hucre nesnesi oluşturulur
                }
            }
        }

        // Rastgele hücrelere mayın yerleştirir
        private void MayinlariYerlestir()
        {
            Random rastgele = new Random();
            int yerlestirilenMayin = 0;

            while (yerlestirilenMayin < ToplamMayin) // Toplam mayın sayısına ulaşana kadar döner
            {
                int satir = rastgele.Next(Boyut); // Rastgele bir satır seçilir
                int sutun = rastgele.Next(Boyut); // Rastgele bir sütun seçilir

                if (!tarla[satir, sutun].MayinVarMi) // Hücrede mayın yoksa
                {
                    tarla[satir, sutun].MayinVarMi = true; // Mayın yerleştirilir
                    yerlestirilenMayin++;
                }
            }
        }

        // Her hücre için çevresindeki mayınların sayısını hesaplar
        private void CevredekiMayinlariHesapla()
        {
            for (int i = 0; i < Boyut; i++)
            {
                for (int j = 0; j < Boyut; j++)
                {
                    if (!tarla[i, j].MayinVarMi) // Hücrede mayın yoksa
                    {
                        tarla[i, j].CevredekiMayinSayisi = CevredekiMayinlariSay(i, j); // Çevresindeki mayınları say
                    }
                }
            }
        }

        // Belirtilen hücre etrafındaki mayınların sayısını döndürür
        private int CevredekiMayinlariSay(int satir, int sutun)
        {
            int sayac = 0;

            // Çevresindeki 8 hücreyi kontrol eder
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int yeniSatir = satir + i;
                    int yeniSutun = sutun + j;

                    // Hücrenin tarlanın içinde olup olmadığını kontrol eder
                    if (yeniSatir >= 0 && yeniSatir < Boyut && yeniSutun >= 0 && yeniSutun < Boyut &&
                        tarla[yeniSatir, yeniSutun].MayinVarMi)
                    {
                        sayac++;
                    }
                }
            }

            return sayac; // Çevredeki mayınların toplam sayısını döndürür
        }

        // Belirtilen hücreyi açar (oyuncu bir hücreyi seçtiğinde çalışır)
        public void HucreyiAc(int satir, int sutun)
        {
            // Hücre geçersiz ya da zaten açılmışsa işlemi sonlandır
            if (satir < 0 || satir >= Boyut || sutun < 0 || sutun >= Boyut || tarla[satir, sutun].AcildiMi)
                return;

            tarla[satir, sutun].AcildiMi = true; // Hücre açılmış olarak işaretlenir

            if (tarla[satir, sutun].CevredekiMayinSayisi == 0 && !tarla[satir, sutun].MayinVarMi)
            {
                // Çevresindeki hücreleri de açar (rekürsif çağrı)
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        HucreyiAc(satir + i, sutun + j);
                    }
                }
            }
        }

        // Mayın tarlasının mevcut durumunu ekrana yazdırır
        public void Goster()
        {
            for (int i = 0; i < Boyut; i++)
            {
                for (int j = 0; j < Boyut; j++)
                {
                    if (tarla[i, j].AcildiMi)
                    {
                        // Hücre açıksa mayın mı, yoksa çevredeki mayın sayısı mı gösterilecek
                        Console.Write(tarla[i, j].MayinVarMi ? "*" : tarla[i, j].CevredekiMayinSayisi.ToString());
                    }
                    else
                    {
                        Console.Write("#"); // Açılmamış hücreleri temsil eder
                    }
                }
                Console.WriteLine(); // Bir satır bittiğinde alt satıra geçer
            }
        }
    }

    // Programın ana giriş noktası
    public class Program
    {
        public static void Main(string[] args)
        {
            // Yeni bir mayın tarlası oluşturulur
            MayinTarlasi mayinTarlasi = new MayinTarlasi();
            Console.WriteLine("Mayın Tarlası oyununa hoş geldiniz!");
            mayinTarlasi.Goster();

            while (true)
            {
                // Oyuncudan satır ve sütun bilgisi alınır
                Console.Write("Açmak istediğiniz hücreyi girin (örnek: 5 7): ");
                string girdi = Console.ReadLine();
                string[] parcalar = girdi.Split(' ');

                // Girilen değerler kontrol edilir
                if (parcalar.Length != 2 || !int.TryParse(parcalar[0], out int satir) || !int.TryParse(parcalar[1], out int sutun))
                {
                    Console.WriteLine("Geçersiz giriş. Lütfen tekrar deneyin.");
                    continue;
                }

                // Seçilen hücre açılır
                mayinTarlasi.HucreyiAc(satir, sutun);
                mayinTarlasi.Goster();
            }
        }
    }
}
