using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UstaPlatform.Domain
{
    public sealed class Request
    {
        public Guid Id { get; private set; }
        public Citizen Vatandas { get; private set; }
        public string Kategori { get; private set; } // "Elektrik", "Tesisat"
        public string Aciklama { get; private set; }
        public (int X, int Y) Konum { get; private set; }

        public Request(Citizen vatandas, string kategori, string aciklama, int x, int y)
        {
            Id = Guid.NewGuid();
            Vatandas = vatandas ?? throw new ArgumentNullException(nameof(vatandas));
            Kategori = kategori ?? throw new ArgumentNullException(nameof(kategori));
            Aciklama = aciklama ?? throw new ArgumentNullException(nameof(aciklama));
            Konum = (x, y);
        }
    }
}