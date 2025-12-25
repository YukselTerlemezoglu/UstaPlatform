# UstaPlatform

# UstaPlatform – C# Plugin Tabanlı Fiyatlandırma Projesi

Bu proje, **.NET Framework 4.8** kullanılarak geliştirilen, **plugin (eklenti)** tabanlı fiyatlandırma sistemine sahip bir usta eşleştirme platformudur.  
Vatandaşın oluşturduğu talep uygun ustayla eşleştirilir, ardından fiyat hesaplaması **`IPricingRule`** arayüzünü uygulayan eklentiler (DLL’ler) aracılığıyla dinamik olarak yapılır.

---

## Proje Özeti

- **Amaç:**  
  Gerçek zamanlı olarak vatandaş taleplerini uygun ustalarla eşleştirip, fiyatlandırmayı dışarıdan yüklenen kural DLL’lerine göre hesaplamak.

- **Teknoloji Yığını:**  
  - C# (.NET Framework 4.8)  
  - Katmanlı Mimari (Domain, Infrastructure, Pricing, App, Plugins)  
  - Reflection API (dynamic plugin loading)  
  - Konsol arayüzü (CLI)

---

## Proje Yapısı

UstaPlatform.sln

UstaPlatform.Domain → Temel varlıklar ve IPricingRule arayüzü
Usta.cs
Citizen.cs
Request.cs
WorkOrder.cs
Route.cs
Schedule.cs
IPricingRule.cs

UstaPlatform.Infrastructure → In-memory veri kaynakları ve Matcher
Repositories.cs

UstaPlatform.Pricing → PricingEngine (plugin loader)
PricingEngine.cs

UstaPlatform.App → Konsol uygulaması (Main Program)
Program.cs

Plugins (DLL klasörü)
WeekendSurchargeRule.dll → Hafta sonu +%20
DistancePlus15Rule.dll → Uzak mesafe +%15
LoyaltyDiscountRule.dll → Sadık müşteri -%10

## Çalışma Mantığı

1. Vatandaş bir **talep (Request)** oluşturur.  
2. **Matcher** uygun ustayı seçer (en az iş yükü + yüksek puan).  
3. **WorkOrder** (iş emri) oluşturulur.  
4. **PricingEngine**, `Plugins` klasöründeki tüm `.dll` dosyalarını tarar.  
5. Her DLL içindeki **`IPricingRule`** implementasyonları bulunur.  
6. Kurallar sırayla çalışır ve `BasePrice` → `FinalPrice` dönüşümü yapılır.  
7. Sonuç konsolda gösterilir.

---

## Kurulum ve Çalıştırma

Visual Studio 2022 (.NET Framework 4.8) yükle.

Projeyi aç → UstaPlatform.App’i başlangıç projesi yap.

Plugins klasörünü kontrol et (DLL’ler var mı?).

F5 (Çalıştır).

Konsoldaki Base ve Final fiyat farkını gözlemle.

## Geliştirilebilir Alanlar

GUI (Windows Forms veya WPF) arayüzü eklenebilir.

Gerçek veritabanı (Entity Framework + SQL Server) entegrasyonu.

Eklenti sıralama ve filtreleme mantığı geliştirilebilir.

Kuralların JSON veya XML konfigürasyonu eklenebilir.

## Geliştirici

Yüksel Terlemezoğlu
📧 GitHub: @YukselTerlemezoğlu
