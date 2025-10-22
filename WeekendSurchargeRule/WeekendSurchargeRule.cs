using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UstaPlatform.Domain;

namespace WeekendSurchargeRule
{
    // Hafta sonu (Cumartesi/Pazar) işleri için %20 zam
    public sealed class WeekendSurchargeRule : IPricingRule
    {
        public string Name => "WeekendSurchargeRule (+%20)";

        public decimal Apply(decimal basePrice, WorkOrder order)
        {
            var day = order.Tarih.DayOfWeek;
            bool isWeekend = (day == DayOfWeek.Saturday || day == DayOfWeek.Sunday);
            if (isWeekend)
            {
                return Math.Round(basePrice * 1.20m, 2);
            }
            return basePrice;
        }
    }
}