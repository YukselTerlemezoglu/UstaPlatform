using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UstaPlatform.Domain;
using UstaPlatform.Infrastructure;
using UstaPlatform.Pricing;

namespace UstaPlatform.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("|===| UstaPlatform Demo |===|");

            // 1) Örnek veriler
            var ustaRepo = new InMemoryUstaRepository();
            var reqRepo = new InMemoryRequestRepository();

            //var today = DateTime.Today;
            var today = new DateTime(2025, 10, 25); // Cumartesi
            var schedule = new Schedule();

            // 2) İlk talebi al ve eşleştir
            var talep = reqRepo.GetAll()[0];
            var usta = Matcher.Match(talep, ustaRepo.GetAll());

            // 3) İş emri oluştur ve planla
            decimal basePrice = 1000m;
            var order = new WorkOrder(talep, usta, today, basePrice);
            schedule[today].Add(order);

            // 4) Plugins klasörünü ayarla
            var exeDir = AppDomain.CurrentDomain.BaseDirectory;
            var plugins = Path.Combine(exeDir, "Plugins");
            Directory.CreateDirectory(plugins);

            //Console.WriteLine($"\nPlugins klasörü: {plugins}");
            //Console.WriteLine(">>> İlk koşu: (Plugins klasörü BOŞ olsun)\n");

            // 5) PricingEngine'i yükle ve fiyat hesapla
            var engine = new PricingEngine(plugins);

            Console.WriteLine("\nYüklenen kurallar:");
            foreach (var r in engine.Rules) Console.WriteLine($" - {r.Name}");
            if (engine.Rules.Count == 0) Console.WriteLine(" - (Kural yok)");

            var finalPrice = engine.Calculate(order.BasePrice, order);
            order.FinalPrice = finalPrice;

            Console.WriteLine($"\nİlk Çıktı => BasePrice: {order.BasePrice}₺  |  FinalPrice: {order.FinalPrice}₺");

            //Console.WriteLine("\nŞimdi bir eklenti (DLL) ekleyip programı tekrar çalıştırıcam.");
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}