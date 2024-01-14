using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using static klavyekullaniciadisifre.Personel;

namespace klavyekullaniciadisifre
{
    class Program
    {


        static void Main()
        {
            // Kullanıcıya hoş geldin mesajı


            Console.WriteLine("Hoş geldiniz! Lütfen aşağıdaki bilgileri eksiksiz ve doğru bir şekilde giriniz.");
            Console.Write("Kullanıcı tipinizi seçiniz.(Doktor/Personel):   ");
            string kullaniciTipi = Console.ReadLine();

            // Kullanıcının girdiği tip doğrultusunda işlem yapılıyor
            if (kullaniciTipi.ToLower() == "personel")
            {
                Personel personelGirisi = new Personel();//Personel sınıfından bir nesne oluşturuluyor.
                personelGirisi.GirisIslemleriPersonel();//Personel sınıfının 'Giriş İşlemleri Personel' metodu çağırılıyor.


            }
            else if (kullaniciTipi.ToLower() == "doktor")
            {

                Doktor doktorGirisi = new Doktor();
                //Doktor sınıfından bir  nesne oluşturuluyor.
                doktorGirisi.GirisIslemleriDoktor();
            }

            else
            {
                Console.WriteLine("Geçersiz Kullanıcı Tipi.Program Kapatılıyor");
            }
        }




    }

    // Hasta kayıt sistemi için abstract sınıf
    abstract class HastaKayitSistemi
    {
        public abstract bool GirisYap(string kullaniciAdi, string sifre);
        public abstract void hastaBilgiYazdir();

        public abstract void RandevuTakibi();
        public abstract void RandevuEkle();
        public abstract void TedaviPlaniEkle();
        public abstract void RaporYaz();

    }

    // Personel işlemleri arayüzü
    interface IPersonelIslemleri
    {
        void GirisYap();

        void hastaBilgiYazdir();
        void RandevuEkle();
        void RandevuTakibi();
    }

    // Doktor işlemleri arayüzü
    interface IDoktorIslemleri
    {
        void GirisYap();


        void hastaBilgiYazdir();
        void TedaviPlaniEkle();
        void RaporYaz();
    }

    class Doktor : IDoktorIslemleri
    {
        //Alan Tanımlamaları
        private string gorulenHastalik;
        private string ilaclar;
        private List<string> tedaviPlani = new List<string>();
        private List<string> raporlar = new List<string>();



        public void GirisIslemleriDoktor()
        {

            // Kullanıcı girişi işlemleri
            string Kadı, şifre;
            int hak = 3;

        Kadı:
            Console.Write("\nKullanıcı adı girin = ");
            Kadı = Console.ReadLine();

            if (Kadı == "admin" || Kadı == "admin")
            {
                Console.WriteLine("\nDoğru Kullanıcı adı girilmiştir");
            }
            else
            {
                Console.WriteLine("\nYanlış Kullanıcı adı girilmiştir!!");
                hak = hak - 1;

                Console.WriteLine("\nKalan Hakkınız = " + hak);


                if (hak > 0)
                {
                    goto Kadı;
                }
                while (hak == 0)
                {
                    Console.Write("Hakkınız bitmiştir");
                    Console.ReadLine();
                }
            }
        şifre:
            Console.Write("Şifre girin = ");
            şifre = Console.ReadLine();

            if (şifre == "1234" || şifre == "1234")
            {
                Console.Write("Doğru Şifre");
            }
            else
            {
                Console.Write("Yanlış Şifre");
                if (hak > 0)
                {
                    goto şifre;
                }
                if (hak == 0)
                {
                    Console.Write("Yanlış şifre");
                }
            }


            // Ana menü döngüsü
            while (true)
            {
                Console.WriteLine("\n\n***Doktor Menüsü*");//Doktor menüsü seçenekleri ve işlemleri
                Console.WriteLine("1. Hasta Bilgilerini Göster");
                Console.WriteLine("2. Tedavi Planı Ekle");
                Console.WriteLine("3. Rapor Yazma");
                Console.WriteLine("4. Çıkış");

                Console.Write("Seçiminiz (1-4): ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        hastaBilgiYazdir();
                        break;
                    case "2":
                        TedaviPlaniEkle();
                        break;
                    case "3":
                        RaporYaz();
                        break;
                    case "4":
                        Console.WriteLine("Sistemden Çıkış Yapılıyor. İyi Günler Dileriz");
                        return;
                    default:
                        Console.WriteLine("Geçersiz Seçim. Lütfen Tekrar Deneyin.");
                        break;
                }
            }

        }

        // IDoktorIslemleri arayüzünden implement edilmiş metotlar
        public void GirisYap()
        {
            //Console.Write("Doktor Girişi - Kullanıcı Adı: ");
            //string kullaniciAdi = Console.ReadLine();

            //Console.Write("Doktor Girişi - Şifre: ");
            //string sifre = Console.ReadLine();

            //// Kullanıcı adı ve şifre kontrolü
            //if (GirisYap(kullaniciAdi, sifre))
            //{
            //    Console.WriteLine("Giriş başarılı!");

            //    // Giriş işlemleri burada devam edebilir
            //    GirisIslemleriDoktor();
            //}
            //else
            //{
            //    Console.WriteLine("Hatalı kullanıcı adı veya şifre. Giriş başarısız. Program kapatılıyor.");
            //}
        }










        public void hastaBilgiYazdir()
        {
            // Doktorun hasta bilgilerini gösterme işlemleri buraya eklenir.
            Console.WriteLine("\nHastanın bilgilersi \n");

            Console.Write("Ad: ");
            string ad = Console.ReadLine();

            Console.Write("Soyad: ");
            string soyad = Console.ReadLine();

            //Console.Write("Cinsiyet: ");
            //string cinsiyet = Console.ReadLine();

            //Console.Write("Yaş: ");
            //string yasString = Console.ReadLine();

            Console.Write("TC: ");
            string tcKimlikNo = Console.ReadLine();

            // TC Kimlik No kontrolü
            Console.Write("TC Kimlik No: ");
            string TcKimlikNo = Console.ReadLine();

            while (tcKimlikNo.Length != 11)
            {
                Console.WriteLine("Hata: TC Kimlik No 11 hane olmalıdır. Lütfen tekrar giriniz.");
                Console.Write("TC Kimlik No: ");
                tcKimlikNo = Console.ReadLine();
            }

            //if (int.TryParse(yasString, out int yas))
            //{
            //    HastaBase yeniHasta = new Hasta
            //    {
            //        Ad = ad,
            //        Soyad = soyad,
            //        Yas = yasString,
            //        Cinsiyet = cinsiyet,
            //        TcKimlikNo = tcKimlikNo,
            //    };


            //    Console.WriteLine("Hasta Başarıyla Eklendi.");
            //    Console.WriteLine("\nHasta Bilgileri:\n" +
            //        $"Ad: {yeniHasta.Ad}\n" +
            //        $"Soyad: {yeniHasta.Soyad}\n" +
            //        $"Yaş: {yeniHasta.Yas}\n" +
            //        $"Cinsiyet: {yeniHasta.Cinsiyet}\n" +
            //        $"Tc Kimlik No: {yeniHasta.TcKimlikNo}\n");
            //}

            //Console.WriteLine($"Görülen Hastalık: {gorulenHastalik}");
        }




        public void TedaviPlaniEkle()
        {
            // Doktorun tedavi planı ekleme işlemleri
            Console.WriteLine("\nTedavi Planı Ekleme");
            Console.WriteLine("----------------------");

            Console.Write("Tedavi Tarihi (GG.AA.YYYY): ");
            string tarihInput = Console.ReadLine();
            DateTime tedaviTarihi;

            while (!DateTime.TryParseExact(tarihInput, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out tedaviTarihi))
            {
                Console.WriteLine("Hata: Geçersiz tarih formatı. Lütfen GG.AA.YYYY formatında girin.");
                Console.Write("Tedavi Tarihi (GG.AA.YYYY): ");
                tarihInput = Console.ReadLine();
            }

            Console.Write("Tedavi Açıklaması: ");
            string tedaviAciklamasi = Console.ReadLine();

            Console.Write("Görülen Hastalık: ");
            gorulenHastalik = Console.ReadLine();

            Console.Write("İlaç Bilgisi: ");
            ilaclar = Console.ReadLine();

            tedaviPlani.Add($"{tedaviTarihi:dd.MM.yyyy} - Hastalık: {gorulenHastalik} - Tedavi Açıklaması: {tedaviAciklamasi} - İlaçlar: {ilaclar}");
            Console.WriteLine("Tedavi planı başarıyla eklendi.");
        }



        public void RaporYaz()
        {
            Console.WriteLine("\nRapor Yazma");
            Console.WriteLine("----------------------------");

            Console.Write("Rapor Başlığı: ");
            string raporBasligi = Console.ReadLine();

            Console.Write("Rapor İçeriği: ");
            string raporIcerigi = Console.ReadLine();

            string rapor = $"{DateTime.Now:dd.MM.yyyy HH:mm} - {raporBasligi}: {raporIcerigi}";
            raporlar.Add(rapor);

            Console.WriteLine("Rapor başarıyla eklendi.");

        }
        //public bool GirisYap(string kullaniciAdi, string sifre)
        //{
        //    // Kullanıcı girişi kontrolü burada gerçekleştirilir.
        //    // Gerçek bir uygulamada genellikle bir veritabanı veya başka bir kimlik doğrulama mekanizması kullanılır.
        //    // Bu örnekte sadece basit bir şifre kontrolü yaptım.
        //    return kullaniciAdi == "admin" && sifre == "123";
        //}


    }
    class Personel : IPersonelIslemleri
    {

        public List<string> randevular = new List<string>();


        public void GirisIslemleriPersonel()
        {
            string Kadı, şifre;
            int hak = 3;

        Kadı:
            Console.Write("\nKullanıcı adı girin = ");
            Kadı = Console.ReadLine();

            if (Kadı == "admin" || Kadı == "admin")
            {
                Console.WriteLine("\nDoğru Kullanıcı adı girilmiştir");
            }
            else
            {
                Console.WriteLine("\nYanlış Kullanıcı adı girilmiştir!!");
                hak = hak - 1;

                Console.WriteLine("\nKalan Hakkınız = " + hak);


                if (hak > 0)
                {
                    goto Kadı;
                }
                while (hak == 0)
                {
                    Console.Write("Hakkınız bitmitir");
                    Console.ReadLine();
                }
            }
        şifre:

            Console.Write("\nŞifre girin = ");
            şifre = Console.ReadLine();

            if (şifre == "1234" || şifre == "1234")
            {
                Console.Write("Doğru Şifre");
            }
            else
            {
                Console.Write("Yanlış Şifre");
                if (hak > 0)
                {
                    goto şifre;
                }
                if (hak == 0)
                {
                    Console.Write("Yanlış şifre");
                }
            }
            while (true)
            {
                Console.WriteLine("\n\n***Personel Menüsü*");
                Console.WriteLine("1. Hasta Bilgilerini Göster");
                Console.WriteLine("2. Randevu Ekle");
                Console.WriteLine("3. Randevu Takibi");
                Console.WriteLine("4. Randevu Güncelle");
                Console.WriteLine("5. Çıkış");
                Console.Write("Seçiminiz (1-5): ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        hastaBilgiYazdir();
                        break;
                    case "2":
                        RandevuEkle();
                        break;
                    case "3":
                        RandevuTakibi();
                        break;
                    case "4":
                        RandevuGuncelle();
                        break;
                    case "5":
                        Console.WriteLine("Sistemden Çıkış Yapılıyor. İyi Günler Dileriz");
                        return;
                    default:
                        Console.WriteLine("Geçersiz Seçim. Lütfen Tekrar Deneyin.");
                        break;
                }
            }
        }














        public void hastaBilgiYazdir()
        {
            Console.WriteLine("Personel'in hasta bilgilerini gösterme metodu.");

        }
        public void TedaviPlaniEkle()
        {
            Console.WriteLine("Personel'in tedavi planı ekleme metodu.");
        }

        public void GirisYap()
        {
            Console.WriteLine("Personel Girişi Yapılıyor...");
        }


        public void RandevuEkle()
        {
            Console.WriteLine("\nRandevu bilgileri \n");
            //Hasta bilgileri alınır.
            Console.Write("Ad: ");
            string ad = Console.ReadLine();

            Console.Write("Soyad: ");
            string soyad = Console.ReadLine();

            Console.Write("Cinsiyet: ");
            string cinsiyet = Console.ReadLine();

            Console.Write("Yaş: ");
            string yasString = Console.ReadLine();

            Console.Write("TC Kimlik No: ");
            string tcKimlikNo = Console.ReadLine();

            // TC Kimlik No kontrolü
            Console.Write("TC Kimlik No: ");
            string TcKimlikNo = Console.ReadLine();

            while (tcKimlikNo.Length != 11)
            {
                Console.WriteLine("Hata: TC Kimlik No 11 hane olmalıdır. Lütfen tekrar giriniz.");
                Console.Write("TC Kimlik No: ");
                tcKimlikNo = Console.ReadLine();
            }
            if (int.TryParse(yasString, out int yas))
            {
                //Hasta nesnesi oluşturulur ve bilgiler atanır.
                HastaBase yeniHasta = new Hasta
                {
                    Ad = ad,
                    Soyad = soyad,
                    Yas = yasString,
                    Cinsiyet = cinsiyet,
                    TcKimlikNo = tcKimlikNo,
                };

                //Hasta bilgileri konsola yazdırılır.
                Console.WriteLine("HastaBaşarıylaEklendi.");
                Console.WriteLine("\nHasta Bilgileri:\n" +
                    $"Ad: {yeniHasta.Ad}\n" +
                    $"Soyad: {yeniHasta.Soyad}\n" +
                    $"Yaş: {yeniHasta.Yas}\n" +
                    $"Cinsiyet: {yeniHasta.Cinsiyet}\n" +
                    $"Tc Kimlik No: {yeniHasta.TcKimlikNo}\n");
            }
            else
            {
                Console.WriteLine("Geçerli bir yaş giriniz.");
            }
            Console.WriteLine("Randevu Ekleme");
            Console.WriteLine("--------------------");

            string tarihInput;
            DateTime randevuTarihi;
            //Randevu tarihi ve saat alınır.
            do
            {
                Console.Write("Randevu Tarihi (GG.AA.YYYY): ");
                tarihInput = Console.ReadLine();

            } while (!DateTime.TryParseExact(tarihInput, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out randevuTarihi));
            //DateTime.TryParseExact fonksiyonu, bir string'in belirli bir tarih formatına uygun olup olmadığını kontrol etmek ve uygunsa bu string'i bir DateTime nesnesine dönüştürmek için kullanılır.
            if (randevuTarihi < DateTime.Now)
            {
                Console.WriteLine("Hata: Geçmiş tarihli randevu eklenemez. Lütfen ileri bir tarih seçin.");
                return;
            }

            string saatInput;
            DateTime randevuSaati;

            do
            {
                Console.Write("Randevu Saati (HH:mm): ");
                saatInput = Console.ReadLine();

            } while (!DateTime.TryParseExact(saatInput, "HH:mm", null, System.Globalization.DateTimeStyles.None, out randevuSaati));

            DateTime tamRandevu = randevuTarihi.AddHours(randevuSaati.Hour).AddMinutes(randevuSaati.Minute);
            randevular.Add($"{tamRandevu:dd.MM.yyyy HH:mm} - Randevu");
            Console.WriteLine($"Randevu başarıyla eklendi. Tarih: {tamRandevu:dd.MM.yyyy HH:mm}");
        }

        public void RandevuTakibi()
        {


            Console.WriteLine("\n*** Personel Randevu Takibi ***\n");
            //Eğer randevu listesinde en az bir randevu varsa
            if (randevular.Count > 0)
            {
                //Randevu ekrana yazdır.
                foreach (var randevu in randevular)
                {
                    Console.WriteLine(randevu);
                }
            }
            else
            {
                Console.WriteLine("Hasta henüz randevu almamış.");
            }
            Console.WriteLine("*************");


        }
        public void RandevuGuncelle()
        {
            Console.WriteLine("\nRandevu Güncelleme");
            Console.WriteLine("--------------------");

            // Güncellenecek randevu tarihini al
            Console.Write("Güncellenecek Randevu Tarihi (GG.AA.YYYY): ");
            string tarihInput = Console.ReadLine();
            DateTime guncellenecekRandevuTarihi;

            while (!DateTime.TryParseExact(tarihInput, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out guncellenecekRandevuTarihi))
            {
                Console.WriteLine("Hata: Geçersiz tarih formatı. Lütfen GG.AA.YYYY formatında girin.");
                Console.Write("Güncellenecek Randevu Tarihi (GG.AA.YYYY): ");
                tarihInput = Console.ReadLine();
            }

            // Güncellenecek randevu saatini al
            Console.Write("Güncellenecek Randevu Saati (HH:mm): ");
            string saatInput = Console.ReadLine();
            DateTime guncellenecekRandevuSaati;

            while (!DateTime.TryParseExact(saatInput, "HH:mm", null, System.Globalization.DateTimeStyles.None, out guncellenecekRandevuSaati))
            {
                Console.WriteLine("Hata: Geçersiz saat formatı. Lütfen HH:mm formatında girin.");
                Console.Write("Güncellenecek Randevu Saati (HH:mm): ");
                saatInput = Console.ReadLine();
            }

            // Güncellenecek randevu tam tarihini hesapla
            DateTime tamGuncellenecekRandevu = guncellenecekRandevuTarihi.AddHours(guncellenecekRandevuSaati.Hour).AddMinutes(guncellenecekRandevuSaati.Minute);

            // Güncellenen randevu bilgilerini kullanıcıdan al
            Console.Write("Yeni Randevu Bilgisi: ");
            string yeniRandevuBilgisi = Console.ReadLine();

            // Güncelleme işlemini gerçekleştir
            bool randevuGuncellendi = false;
            for (int i = 0; i < randevular.Count; i++)
            {
                // Güncellenecek randevu bulundu
                if (randevular[i].Contains($"{tamGuncellenecekRandevu:dd.MM.yyyy HH:mm} - Randevu"))
                {
                    randevular[i] = $"{tamGuncellenecekRandevu:dd.MM.yyyy HH:mm} - {yeniRandevuBilgisi}";
                    randevuGuncellendi = true;
                    break;
                }
            }

            // Güncelleme durumunu kullanıcıya bildir
            if (randevuGuncellendi)
            {
                Console.WriteLine("Randevu başarıyla güncellendi.");
            }
            else
            {
                Console.WriteLine("Hata: Güncellenecek randevu bulunamadı.");
            }
        }




        //abstract ve kapsülleme
        //HastaBase, hasta nesnelerinin temel özelliklerini tanımlayan bir abstract sınıftır.
        public abstract class HastaBase
        {
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public string Yas { get; set; }
            public string Cinsiyet { get; set; }
            public string TcKimlikNo { get; set; }


        }

        //Miras alma
        //Hasta sınıfı, HastaBase sınıfından miras alarak bu temel özelliklere sahip olur.
        public class Hasta : HastaBase
        {

            public abstract class HastaBase
            {
                public string Ad { get; set; }
                public string Soyad { get; set; }
                public string Yas { get; set; }
                public string Cinsiyet { get; set; }
                public string TcKimlikNo { get; set; }


            }

        }
    }
}
