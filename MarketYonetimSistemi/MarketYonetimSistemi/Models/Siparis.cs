using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketYonetimSistemi.Models
{
    public class Siparis
    {
        public int SiparisId { get; set; }
        public Musteri Musteri { get; set; }
        public List<Urun> Urunler { get; set; }
        public double ToplamTutar { get; set; }
        public SiparisDurumu Durum { get; set; }
        public Odeme Odeme { get; set; }
        public DateTime SiparisTarihi { get; set; }

        public enum SiparisDurumu
        {
            Onaylandi,
            Hazirlaniyor,
            TeslimEdildi
        }

        public double IndirimliTutarHesapla()
        {
            try
            {
                double indirimMiktari = Musteri.IndirimHesapla(ToplamTutar);
                return ToplamTutar - indirimMiktari;
            }
            catch (Exception ex)
            {
                throw new Exception("İndirim hesaplama hatası: " + ex.Message);
            }
        }
    }
}
