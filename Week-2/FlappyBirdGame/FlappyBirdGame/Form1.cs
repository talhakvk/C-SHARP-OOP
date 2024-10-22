using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FlappyBirdGame
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        // Oyun parametreleri
        int pipeSpeed = 8; // Boruların hareket hızı
        int upwardForce = 11; // Kuşun yukarı hareket kuvveti
        int currentScore = 0; // Oyuncunun mevcut puanı

        public Form1()
        {
            InitializeComponent(); // Form bileşenlerini başlat
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            // Kuşun düşmesini sağla
            flappyBird.Top += upwardForce; // Kuşun yukseklik konumunu artır
            boruAlt.Left -= pipeSpeed; // Alt borunun x konumunu sola kaydır
            boruUst.Left -= pipeSpeed; // Üst borunun x konumunu sola kaydır
            scoreName.Text = "Score: " + currentScore; // Skoru güncelle

            // Alt boru ekran dışına çıkarsa
            if (boruAlt.Left < -150)
            {
                boruAlt.Left = 800; // Alt boruyu sağdan yerleştir
                currentScore++; // Puanı artır
            }
            // Üst boru ekran dışına çıkarsa
            if (boruUst.Left < -180)
            {
                boruUst.Left = 950; // Üst boruyu sağdan yerleştir
                currentScore++; // Puanı artır
            }

            // Çarpışma kontrolü
            if (flappyBird.Bounds.IntersectsWith(boruAlt.Bounds) || flappyBird.Bounds.IntersectsWith(boruUst.Bounds) || flappyBird.Bounds.IntersectsWith(zemin.Bounds))
            {
                EndGame(); // Çarpışma varsa oyunu bitir
            }

            // Ekranın üstüne çıkma kontrolü
            if (flappyBird.Top < -15)
            {
                EndGame(); // Kuş ekranın üstüne çıkarsa oyunu bitir
            }

            // Hız artışı
            if (currentScore > 5)
            {
                pipeSpeed = 15; // Puan 5'i geçerse boru hızını artır
            }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            // Eğer SPACE tuşuna basıldıysa
            if (e.KeyCode == Keys.Space)
            {
                upwardForce = -11; // Kuşu yukarı kaldır
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            // Eğer SPACE tuşu bırakıldıysa
            if (e.KeyCode == Keys.Space)
            {
                upwardForce = 11; // Kuşun aşağı inmesini sağla
            }
        }

        private void EndGame()
        {
            gameTimer.Stop(); // Oyunu durdur
            scoreName.Text = "Game Over!!!"; // Oyun bitti mesajını göster
        }
    }
}
