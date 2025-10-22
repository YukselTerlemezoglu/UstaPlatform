using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UstaPlatform.Domain;

namespace DistancePlus15RulePlugin
{
    // Talep konumu ile (0,0) Manhattan mesafesi > 10 ise %15 ekle
    public sealed class DistancePlus15Rule : IPricingRule
    {
        public string Name => "DistancePlus15Rule (>10 -> +%15)";

        private static int Manhattan((int X, int Y) a, (int X, int Y) b)
            => Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);

        public decimal Apply(decimal basePrice, WorkOrder order)
        {
            var merkez = (0, 0); // basit varsayılan
            var d = Manhattan(order.Talep.Konum, merkez);
            if (d > 10)
                return Math.Round(basePrice * 1.15m, 2);
            return basePrice;
        }
    }
}