# Tedarikçi Kritik Stok ve Fiyat Radarı (Tedarikci_Kritik_StokveFiyat_Radari)

FakeStoreAPI üzerinden ürün, fiyat ve stok verilerini çekerek analiz eden ve bu verileri yapılandırılmış bir şekilde MSSQL veritabanına kaydeden C# tabanlı entegrasyon uygulamasıdır. Proje, sürdürülebilirliği ve test edilebilirliği artırmak amacıyla modern yazılım tasarım desenleri kullanılarak geliştirilmiştir.

## 🚀 Öne Çıkan Özellikler

- **Katmanlı Mimari (Multi-Project Solution):** Proje sorumlulukları farklı katmanlara ayrılarak temiz bir yapı (Clean Code) oluşturulmuştur.
- **REST API Entegrasyonu:** Dış veri kaynağı olarak [FakeStoreAPI](https://fakestoreapi.com/) kullanılmış ve JSON verileri çözümlenerek sisteme dahil edilmiştir.
- **Dependency Injection & Interface Soyutlamaları:** Servisler ve veritabanı işlemleri arayüzler (interfaces) üzerinden soyutlanmış, bağımlılıklar DI konteyneri ile yönetilmiştir. Bu sayede API kaynağı veya veritabanı türü ileride kolayca değiştirilebilir.
- **Güvenilir Loglama:** Çalışma sırasındaki kritik işlemler ve olası hatalar, sistem takibini kolaylaştırmak için dosya bazlı loglama (File Logging) mekanizması ile kaydedilir.
- **MSSQL Entegrasyonu:** İşlenen veriler ilişkisel veritabanı kurallarına uygun olarak SQL Server'a aktarılır.

## 🛠️ Kullanılan Teknolojiler ve Prensipler

- C# (.NET Framework / .NET Core)
- MSSQL Server
- Dependency Injection (DI)
- HTTP Client & JSON Parsing (FakeStoreAPI)
- Dosya Loglama (File I/O)

## ⚙️ Kurulum ve Çalıştırma

1. Projeyi bilgisayarınıza klonlayın veya indirin.
2. Klasör içindeki `.sln` (Solution) dosyasına çift tıklayarak projeyi Visual Studio'da açın.
3. Projenin başlangıç projesi (Startup Project) olarak ana konsol uygulamasının seçili olduğundan emin olun.
4. Çözüm (Solution) üzerindeki bağımlılıkları yüklemek için NuGet paketlerini geri yükleyin (Restore NuGet Packages).
5. MSSQL bağlantınız için ilgili yapılandırma dosyasındaki (appsettings.json veya App.config) `ConnectionString` değerini kendi veritabanı sunucunuza göre güncelleyin.
6. Veritabanı tablolarının oluşturulduğundan emin olduktan sonra projeyi derleyip (Build) çalıştırın.

## 📦 Çalıştırılabilir Sürüm (Release)
Uygulamanın kaynak kodlarını derlemeden doğrudan test etmek isterseniz, [Releases](../../releases) sayfasından en son derlenmiş halini indirebilir, konfigürasyon dosyasını düzenledikten sonra hemen kullanmaya başlayabilirsiniz.
