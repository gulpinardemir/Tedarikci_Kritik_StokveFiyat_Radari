using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//yazdığımız dll kütüphanesini burada çağırıyoruz
using Tedarikci.Core;

namespace Tedarikci_Kritik_StokveFiyat_Radari
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- B2B Tedarikçi Radar Sistemi Başlatıldı ---");

            //önce bağımlılıkları oluşturmamız lazım
            ILoggerService logger = new TextFileLogger();

            //api servisi üretiyoruz ve çalışırken kullanması için logger nesnesi veriyoruz
            IProductApiService apiService = new ProductApiService(logger);

            // Veritabanı servisini de logger vererek üretiyoruz
            IDatabaseService dbService = new SqlDatabaseService(logger);

            //excel servisini üretiyoruz
            IExcelExportService excelService= new ExcelExportService(logger);

            Console.WriteLine("API'den veriler çekiliyor, lütfen bekleyin...\n");

            //apiden veri çekme
            // GetProductsAsync asenkron bir metot olduğu için ve .NET Framework 4.7.2'de varsayılan Main metodu senkron (void) olduğu için,
            // .GetAwaiter().GetResult() kullanarak işlemin bitmesini bekleyip sonucu alıyoruz.
            List<Product> products = apiService.GetProductsAsync().GetAwaiter().GetResult();

            //ekrana yadırma
            if( products != null && products.Count > 0)
            {
                Console.WriteLine($"Başarılı. Toplam {products.Count} adet ürün çekildi.\n");

                //gelen ürünleri tek tek dönüp ekrana yazdır
                foreach(var urun in products)
                {
                    int stokAdedi = urun.Rating != null ? urun.Rating.Count : 0;    //bazı ürünlerin stok (rating) bilgisi boş gelebilir o yüzden kontrol yapıyoruz

                    Console.WriteLine($"ID: {urun.Id} | Ad: {urun.Title.Substring(0,Math.Min(urun.Title.Length, 20))}... | Kategori: {urun.Category} | Fiyat: {urun.Price} | Stok: {stokAdedi}");
                }

                //ürünleri db ye gönder
                Console.WriteLine("\nVeritabanına kayıt işlemi yapılıyor, lütfen bekleyin...");
                dbService.SaveProducts(products);
                Console.WriteLine("Kayıt işlemi tamamlandı!");

                //kritik stoklar için excel raporu oluştur
                Console.WriteLine("\nKritik stoklar analiz ediliyor ve Excel raporu hazırlanıyor...");
                excelService.ExportCriticalStockToExcel(products);
                Console.WriteLine("Excel raporu başarıyla oluşturuldu! (C:\\TedarikciRadari\\Raporlar)");
            }
            else
            {
                Console.WriteLine("Ürünler çekilemedi veya API boş döndü. Lütfen log dosyasını kontrol edin.");
            }

            Console.WriteLine("\nSüreç tamamlandı. Kapatmak için X'ya basın.");
            Console.ReadLine();

        }
    }
}
