using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HangmanGame
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        // Adam asmaca oyununun çeşitli aşamalarındaki görselleri tutan dizi
        private string[] adamAsmaDurumu = new string[] 
        {
            @"
               --------
               |      |
               |      
               |    
               |      
               |     
               -",
            @"
               --------
               |      |
               |      O
               |    
               |      
               |     
               -",
            @"
               --------
               |      |
               |      O
               |      |
               |      
               |     
               -",
            @"
               --------
               |      |
               |      O
               |     \|
               |      
               |     
               -",
            @"
               --------
               |      |
               |      O
               |     \|/
               |      
               |     
               -",
            @"
               --------
               |      |
               |      O
               |     \|/
               |      |
               |     
               -",
            @"
               --------
               |      |
               |      O
               |     \|/
               |      |
               |     / 
               -",
            @"
               --------
               |      |
               |      O
               |     \|/
               |      |
               |     / \
               -"
        };

        // Oyuncunun toplamda 8 deneme hakkı var
        private int kalanHak = 8; 
        private string secilenKelime; // Oyunda tahmin edilecek kelime
        private List<char> girilenHarfler = new List<char>(); // Girilen harflerin listesi
        private string[] tahminDurumu; // Kelimenin tahmin edilen durumu

        public Form1()
        {
            InitializeComponent();
            BaslatOyunu(); // Oyun başlatılıyor
        }

        // Oyunu başlatma metodu
        private void BaslatOyunu()
        {
            // Rastgele kelime seçimi
            string[] kelimeler = new string[] { "CLASS", "OBJECT", "DATA", "UNITY", "BACKEND", "FRONTEND" };
            Random random = new Random();
            secilenKelime = kelimeler[random.Next(0, kelimeler.Length)]; // Rastgele kelime seçiliyor
            tahminDurumu = new string[secilenKelime.Length]; // Kelimenin uzunluğu kadar boş tahmin durumu oluşturuluyor

            // Kelimenin her harfi için başlangıçta "_" yerleştiriliyor
            for (int i = 0; i < tahminDurumu.Length; i++)
            {
                tahminDurumu[i] = "_";
            }

            // Ekrandaki asma adam görseli ve kelime durumu sıfırlanıyor
            labelHangman.Text = adamAsmaDurumu[0]; // İlk adam asma görseli
            labelKelimeDurumu.Text = string.Join(" ", tahminDurumu); // Kelime durumu "_ _ _" şeklinde gösteriliyor
            girilenHarfler.Clear(); // Girilen harfler temizleniyor
            kalanHak = 8; // Hakkı sıfırlanıyor
        }

        // Tahmin et butonuna tıklandığında çalışacak metot
        private void buttonTahminEt_Click(object sender, EventArgs e)
        {
            string girilenHarfStr = textBoxHarf.Text.ToUpper(); // Girilen harf büyük harfe çevriliyor
            if (girilenHarfStr.Length == 1) // Eğer tek harf girildiyse
            {
                char girilenHarf = girilenHarfStr[0];

                // Daha önce bu harf girildiyse uyarı veriliyor
                if (girilenHarfler.Contains(girilenHarf))
                {
                    XtraMessageBox.Show("Bu harfi zaten girdiniz, başka bir harf deneyin.");
                    return;
                }

                // Girilen harf listeye ekleniyor
                girilenHarfler.Add(girilenHarf);

                // Girilen harf kelimede var mı kontrol ediliyor
                bool harfBulundu = false;
                for (int i = 0; i < secilenKelime.Length; i++)
                {
                    if (secilenKelime[i] == girilenHarf)
                    {
                        tahminDurumu[i] = girilenHarf.ToString();
                        harfBulundu = true;
                    }
                }

                // Eğer harf bulunamadıysa kalan hak azalıyor ve hangman görseli güncelleniyor
                if (!harfBulundu)
                {
                    kalanHak--;
                    if (kalanHak > 0) // Hakkın bitip bitmediği kontrol ediliyor
                    {
                        labelHangman.Text = adamAsmaDurumu[8 - kalanHak]; // Hatalı tahminlerde hangman görseli güncelleniyor
                    }
                }

                // Eğer tüm haklar bitti ise oyun sona eriyor
                if (kalanHak == 0)
                {
                    XtraMessageBox.Show($"Game Over! Tahmin edilen kelime: {secilenKelime}"); // Oyuncuya kaybettiği bildirilir
                    BaslatOyunu(); // Oyun yeniden başlatılıyor
                }

                // Tahmin edilen kelimenin güncel durumu ekrana yazdırılıyor
                labelKelimeDurumu.Text = string.Join(" ", tahminDurumu);

                // Eğer tüm harfler doğru tahmin edildiyse oyuncu kazanır
                if (string.Join("", tahminDurumu) == secilenKelime)
                {
                    XtraMessageBox.Show("Tebrikler, kazandınız!"); // Oyuncuya kazandığı bildirilir
                    BaslatOyunu(); // Oyun yeniden başlatılıyor
                }

                // Son kalan hakkın kontrolü tekrar yapılıyor ve oyunu kaybetme durumu varsa kaybedildiği bildiriliyor
                if (kalanHak == 0)
                {
                    labelHangman.Text = adamAsmaDurumu[7]; // Son asma adam görseli gösteriliyor
                    XtraMessageBox.Show($"Game Over! Kelime: {secilenKelime}"); // Kaybedilen oyun mesajı
                    BaslatOyunu(); // Oyun yeniden başlatılıyor
                }
            }
            else
            {
                XtraMessageBox.Show("Lütfen tek bir harf girin!"); // Birden fazla karakter girilirse uyarı veriliyor
            }

            textBoxHarf.Text = string.Empty; // Harf giriş kutusu temizleniyor
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
