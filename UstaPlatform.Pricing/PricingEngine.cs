using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UstaPlatform.Domain;

namespace UstaPlatform.Pricing
{
    public sealed class PricingEngine
    {
        private readonly List<IPricingRule> _rules = new List<IPricingRule>();

        public IReadOnlyList<IPricingRule> Rules => _rules;

        public PricingEngine(string pluginsFolder)
        {
            if (!Directory.Exists(pluginsFolder)) return;

            foreach (var dllPath in Directory.GetFiles(pluginsFolder, "*.dll"))
            {
                try
                {
                    // .NET Framework 4.8 için güvenli ve basit yol:
                    var asm = Assembly.LoadFrom(dllPath);
                    var types = asm.GetTypes()
                                   .Where(t => typeof(IPricingRule).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);
                    foreach (var t in types)
                    {
                        var instance = (IPricingRule)Activator.CreateInstance(t);
                        _rules.Add(instance);
                    }
                }
                catch (Exception ex)
                {
                    // İsteyene log yazılabilir; demo için yoksay
                    System.Diagnostics.Debug.WriteLine(ex);
                }
            }
        }

        public decimal Calculate(decimal basePrice, WorkOrder order)
        {
            decimal price = basePrice;
            foreach (var rule in _rules)
                price = rule.Apply(price, order);

            return price;
        }
    }
}