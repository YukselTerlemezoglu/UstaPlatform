using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UstaPlatform.Domain;

namespace LoyaltyDiscountRulePlugin
{
    // Müşterinin geçmişte tamamladığı iş sayısı >= 5 ise %10 indirim
    public sealed class LoyaltyDiscountRule : IPricingRule
    {
        public string Name => "LoyaltyDiscountRule (>=5 jobs -> -%10)";

        public decimal Apply(decimal basePrice, WorkOrder order)
        {
            var jobs = order.Talep.Vatandas?.CompletedJobs ?? 0;
            if (jobs >= 5)
            {
                var discounted = Math.Round(basePrice * 0.90m, 2);
                // Negatife düşmeyi her zaman engelle
                return discounted < 0 ? 0 : discounted;
            }
            return basePrice;
        }
    }
}