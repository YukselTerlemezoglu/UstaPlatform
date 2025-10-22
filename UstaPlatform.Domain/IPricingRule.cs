using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UstaPlatform.Domain
{
    public interface IPricingRule
    {
        string Name { get; }
        decimal Apply(decimal basePrice, WorkOrder order);
    }
}