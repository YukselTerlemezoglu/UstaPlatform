using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UstaPlatform.Domain
{
    public sealed class Usta
    {
        public Guid Id { get; private set; }
        public string Ad { get; private set; }
        public string Uzmanlik { get; private set; } // "Tesisat", "Elektrik" vb.
        public double Puan { get; set; }
        public int GunlukYuk { get; set; }

        public Usta(string ad, string uzmanlik, double puan = 0)
        {
            Id = Guid.NewGuid();
            Ad = ad ?? throw new ArgumentNullException(nameof(ad));
            Uzmanlik = uzmanlik ?? throw new ArgumentNullException(nameof(uzmanlik));
            Puan = puan;
        }

        public override string ToString() => $"{Ad} ({Uzmanlik}) - Puan:{Puan:0.0}, Yük:{GunlukYuk}";
    }
}