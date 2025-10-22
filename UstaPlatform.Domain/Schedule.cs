using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UstaPlatform.Domain
{
    public sealed class Schedule
    {
        private readonly Dictionary<DateTime, List<WorkOrder>> _byDay = new Dictionary<DateTime, List<WorkOrder>>();

        public List<WorkOrder> this[DateTime day]
        {
            get
            {
                var key = day.Date;
                if (!_byDay.TryGetValue(key, out var list))
                {
                    list = new List<WorkOrder>();
                    _byDay[key] = list;
                }
                return list;
            }
        }
    }
}