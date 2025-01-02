using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketYonetimSistemi.Models
{
    public class Urun
    {
        public int UrunId { get; set; }
        public string Ad { get; set; }
        public double Fiyat { get; set; }
        public int StokMiktari { get; set; }
        public string Kategori { get; set; }
    }
}
