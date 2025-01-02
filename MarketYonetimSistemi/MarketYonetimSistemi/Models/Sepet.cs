using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MarketYonetimSistemi.Models
{
    public class Sepet
    {
        private List<Urun> urunler;
        private Musteri musteri;

        public Sepet(Musteri musteri)
        {
            this.musteri = musteri;
            urunler = new List<Urun>();
        }

        public void UrunEkle(Urun urun)
        {
            try
            {
                if (urun.StokMiktari > 0)
                {
                    urunler.Add(urun);
                    urun.StokMiktari--;
                }
                else
                {
                    throw new Exception("Ürün stokta yok!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ürün ekleme hatası: " + ex.Message);
            }
        }

        public double ToplamTutarHesapla()
        {
            return urunler.Sum(u => u.Fiyat);
        }

        public Siparis SipariseDonus()
        {
            return new Siparis
            {
                Musteri = musteri,
                Urunler = new List<Urun>(urunler),
                ToplamTutar = ToplamTutarHesapla(),
                Durum = Siparis.SiparisDurumu.Onaylandi,
                SiparisTarihi = DateTime.Now
            };
        }
    }
}
