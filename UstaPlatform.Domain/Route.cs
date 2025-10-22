using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UstaPlatform.Domain
{
    public sealed class Route : IEnumerable<(int X, int Y)>
    {
        private readonly List<(int X, int Y)> _stops = new List<(int X, int Y)>();

        public void Add(int x, int y) => _stops.Add((x, y));

        public IEnumerator<(int X, int Y)> GetEnumerator() => _stops.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}