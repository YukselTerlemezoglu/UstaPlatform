using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UstaPlatform.Domain;

namespace UstaPlatform.Infrastructure
{
    public interface IUstaRepository
    {
        IReadOnlyList<Usta> GetAll();
    }

    public interface IRequestRepository
    {
        IReadOnlyList<Request> GetAll();
    }

    public class InMemoryUstaRepository : IUstaRepository
    {
        private readonly List<Usta> _ustalar = new List<Usta>
        {
            new Usta("Ahmet Usta", "Elektrik", 4.7),
            new Usta("Mehmet Usta", "Tesisat", 4.5),
            new Usta("Ayşe Usta", "Elektrik", 4.8),
        };

        public IReadOnlyList<Usta> GetAll() => _ustalar;
    }

    public class InMemoryRequestRepository : IRequestRepository
    {
        private readonly List<Request> _talepler;

        public InMemoryRequestRepository()
        {
            var c1 = new Citizen("Kemal Yılmaz", completedJobs: 6);
            _talepler = new List<Request>
            {
                new Request(c1, "Elektrik", "Sigorta atıyor", 5, 7)
            };
        }

        public IReadOnlyList<Request> GetAll() => _talepler;
    }

    public static class Matcher
    {
        // En az yükü olan ve kategoriye uyan ustayı seç
        public static Usta Match(Request req, IEnumerable<Usta> ustalar)
        {
            var uygun = ustalar.Where(u => string.Equals(u.Uzmanlik, req.Kategori, StringComparison.OrdinalIgnoreCase));
            var secim = uygun.OrderBy(u => u.GunlukYuk).ThenByDescending(u => u.Puan).FirstOrDefault();
            if (secim == null)
            {
                // Uygun yoksa, herkes arasından en az yükü olan
                secim = ustalar.OrderBy(u => u.GunlukYuk).ThenByDescending(u => u.Puan).First();
            }
            secim.GunlukYuk++;
            return secim;
        }
    }
}