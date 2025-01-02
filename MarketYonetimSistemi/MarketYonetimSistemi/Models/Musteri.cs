using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketYonetimSistemi.Models
{
    public abstract class Musteri
    {
        public int MusteriId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }

        public abstract double IndirimHesapla(double tutar);
    }

    public class BireyselMusteri : Musteri
    {
        public string TCKN { get; set; }

        public override double IndirimHesapla(double tutar)
        {
            return tutar >= 500 ? tutar * 0.05 : 0; // 500 TL üzeri %5 indirim
        }
    }

    public class KurumsalMusteri : Musteri
    {
        public string VergiNo { get; set; }
        public string SirketAdi { get; set; }

        public override double IndirimHesapla(double tutar)
        {
            return tutar >= 1000 ? tutar * 0.10 : tutar * 0.05; // 1000 TL üzeri %10, altı %5 indirim
        }
    }
}
