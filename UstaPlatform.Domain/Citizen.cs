using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UstaPlatform.Domain
{
    public sealed class Citizen
    {
        public Guid Id { get; private set; }
        public string AdSoyad { get; private set; }
        public int CompletedJobs { get; set; }

        public Citizen(string adSoyad, int completedJobs = 0)
        {
            Id = Guid.NewGuid();
            AdSoyad = adSoyad ?? throw new ArgumentNullException(nameof(adSoyad));
            CompletedJobs = completedJobs;
        }

        public override string ToString() => AdSoyad;
    }
}