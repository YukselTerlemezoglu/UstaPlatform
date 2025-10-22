using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UstaPlatform.Domain
{
    public sealed class WorkOrder
    {
        public Guid Id { get; private set; }
        public Request Talep { get; private set; }
        public Usta AtananUsta { get; private set; }
        public DateTime Tarih { get; private set; }
        public decimal BasePrice { get; set; }
        public decimal FinalPrice { get; set; }

        public WorkOrder(Request talep, Usta usta, DateTime tarih, decimal basePrice)
        {
            Id = Guid.NewGuid();
            Talep = talep ?? throw new ArgumentNullException(nameof(talep));
            AtananUsta = usta ?? throw new ArgumentNullException(nameof(usta));
            Tarih = tarih;
            BasePrice = basePrice;
            FinalPrice = basePrice;
        }

        public override string ToString()
            => $"{Tarih:yyyy-MM-dd} - {Talep.Kategori} - {AtananUsta.Ad} - Base:{BasePrice}₺ Final:{FinalPrice}₺";
    }
}