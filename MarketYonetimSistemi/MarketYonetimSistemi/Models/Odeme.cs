using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketYonetimSistemi.Models
{
    public abstract class Odeme
    {
        public int OdemeId { get; set; }
        public double Tutar { get; set; }
        public DateTime OdemeTarihi { get; set; }

        public abstract bool OdemeYap();
    }

    public class KrediKartiOdeme : Odeme
    {
        public string KartNumarasi { get; set; }
        public string SonKullanmaTarihi { get; set; }
        public string CVV { get; set; }

        public override bool OdemeYap()
        {
            try
            {
                // Kredi kartı ödeme işlemleri simülasyonu
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Kredi kartı ödemesi başarısız: " + ex.Message);
            }
        }
    }

    public class HavaleOdeme : Odeme
    {
        public string IBAN { get; set; }

        public override bool OdemeYap()
        {
            try
            {
                // Havale işlemleri simülasyonu
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Havale ödemesi başarısız: " + ex.Message);
            }
        }
    }
}
