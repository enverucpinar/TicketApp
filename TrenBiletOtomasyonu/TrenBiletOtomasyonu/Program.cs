/*
 Bir tren bileti otomasyonu yapılacak. Program çalıştığında kullanıcıdan
güzergah seçimi, yolcu bilgileri ve bilet işlemleri için girdiler alınacak.
Kullanıcı güzergah ekleme, bilet satışı, bilet iptali ve raporlama
şeklinde seçeneklerden birini seçerek işlemi gerçekleştirecek. Rota ekleme işleminde
kullanıcıdan rota adı istenecek ve temel fiyat girilecek. Bilet satış işleminde
kullanıcı adı alınacak, rota adı yazılacak, yolcunun yaşı alınacak.Ve bu bilgilerle
bilet satışı gerçekleştirilecek. Bilet iptali için iptal edilecek yolcunun adı girilecek.

Her biletin detayını tutan bir Ticket class'ı olacak. Bu class'ta aynı zamanda
fir fiyat hesaplayan metot olacak. Bu metot yaş ve temel fiyatı(parametre) baz alarak
hesap yapacak. Yaş 18den küçükse %50 indirim olacak.
Güzergah detaylarını tutan bir Route class'ımız olacak. Burada güzergah
adı ve basePrice temel fiyatı da tutacak.

Üçüncü class son class olarak da bilet işlemlerini yönetecek olan TicketSystem
class'ı olacak. Bu classta biletler ve güzergahlar tutulacak. Rota ekleme
Bilet satışı bilet iptali ve rapor hazırlama bu classta metotlar halinde tutulacak.

*/


namespace TrenBiletOtomasyonu;

using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Reflection;

class Program
{
    
    static void Main(string[] args)
    {
        TicketSystem ticketSystem = new TicketSystem();
        while (true)
        {
            
            Console.WriteLine("1) Guzergah Ekle\n" +
                "2) Guzergah Goster\n" +
                "3) Bilet Göster\n" +
                "4) Bilet Sat\n" +
                "5) Bilet İptali\n" +
                "6) Çıkış");
            Console.WriteLine("Bir secim yapiniz: ");
            int secim = int.Parse(Console.ReadLine());

            switch (secim)
            {
                case 1:
                    Console.WriteLine("Menuye dönmek icin 1e devam icin herhangi bir tusa basin:");
                    string menuyeDonme1 = Console.ReadLine();
                    if (menuyeDonme1 == "1")
                    {
                        break;
                    }
                    else
                    {
                        ticketSystem.GuzergahEkle();
                    }
                   
                    break;
                case 2:
                    ticketSystem.GuzergahGoster();
                    break;
                case 3:
                    ticketSystem.BiletGoster();
                    break;
                case 4:
                    Console.WriteLine("Menuye dönmek icin 1e devam icin herhangi bir tusa basin:");
                    string menuyeDonme4 = Console.ReadLine();
                    if (menuyeDonme4 == "1")
                    {
                        break;
                    }
                    else
                    {
                        ticketSystem.BiletSat();
                    }
                    
                    break;
                case 5:
                    Console.WriteLine("Menuye dönmek icin 1e devam icin herhangi bir tusa basin:");
                    string menuyeDonme5 = Console.ReadLine();
                    if (menuyeDonme5 == "1")
                    {
                        break;
                    }
                    else 
                    {
                        ticketSystem.BiletIptal();
                    }

                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Lutfen gecerli bir numara giriniz.");
                    break;
            }
        }
        Console.ReadLine();
    }

}

class Guzergah // Guzergah bilgileri icin bir sınıf açıldı
{
    public string GuzergahAdi { get; set; }
    public int GuzergahFiyati{ get; set; }

}

class Ticket // Ticket bilgileri icin bir sıfıf açıldı
{
    public string İsim { get; set; }
    public string Guzergah { get; set; }
    public int Yas { get; set; }
    public double BiletFiyati { get; set; }

    public double BiletFiyatHesapla()
    {
        if (Yas <= 18)
        {
            return BiletFiyati * 0.5;
        }
        return BiletFiyati;
    }

}



class TicketSystem
{
    public List<Guzergah> guzergahs = new List<Guzergah> // içinde hazır iki adet rota ve fiyat bilgisi olan güzergahlar listesi oluşturuldu
    {
        new Guzergah { GuzergahAdi = "Istanbul-Ayvalık", GuzergahFiyati =  1200},
        new Guzergah { GuzergahAdi = "Istanbul-Muğla", GuzergahFiyati =  1800},
    };


    public List<Ticket> tickets = new List<Ticket>(); // Ticket listesi


    public void GuzergahEkle()
    {
        Console.WriteLine("Yeni güzergah adini giriniz:"); 
        string yeniGuzergahAdi = Console.ReadLine();
        Console.WriteLine("Yeni Güzergahin Ücretini giriniz: ");
        int yeniGuzergahUcreti = int.Parse(Console.ReadLine());

        Guzergah yeniGuzergah = new Guzergah 
        {
            GuzergahAdi = yeniGuzergahAdi,
            GuzergahFiyati = yeniGuzergahUcreti,
        };

        guzergahs.Add(yeniGuzergah);

        // Otomasyon kullanıcısından yeni güzergah ve fiyat bilgileri alındıktan sonra yeniGuzergah oluşturulup Add metodu ile guzergahs listesi eklendi
    }

    public void GuzergahGoster()
    {
        Console.Clear();
        Console.WriteLine("Guzergahlar");
        Console.WriteLine("***********************");
        foreach (Guzergah guzergahlar in guzergahs) 
        {
            Console.WriteLine($"Guzergah: {guzergahlar.GuzergahAdi} Ucret: {guzergahlar.GuzergahFiyati} ");
        }

        // foreach döngüsüyle bulunan güzergahlar listelendi
    }

    public void BiletGoster()
    {
        // Ticket listesinde bulunan satılmoş biletleri görebilmek için; tickets listesi dolu mu boş mu diye if else ile kontrol edildi. 
        // Eğer uzunluk 0dan büyükse foreach ile ekrana yazdırıldı. Eğer uzunluk yoksa yani liste boşsa "bilet yoktur" yazdırıldı.
        Console.Clear();
        if (tickets.Count>0)
        {
            Console.WriteLine("Satılan Biletler");
            foreach (Ticket ticket in tickets)
            {
                Console.WriteLine($"İsim: {ticket.İsim} Guzergah: {ticket.Guzergah} Yas: {ticket.Yas} Bilet Fiyatı: {ticket.BiletFiyati}");
            }
        }
        else
        {
            Console.WriteLine("Satılmış bilet bulunmamaktadır.");
        }


    }
    public void BiletSat()
    {
        Console.Clear(); 
        Console.WriteLine("İsmi giriniz:");
        string isim = Console.ReadLine();
        isim = isim.ToLower();
        isim = isim.Trim();
        
        Console.WriteLine("Guzergah seciniz:");

        for (int i = 0; i < guzergahs.Count; i++) // Satılacak bilette güzergahları ve fiyatını görebilme adına ekrana guzergahın icindeki bilgiler yazdırıldı
        {
            
                Console.WriteLine($"{i+1}) Guzergah: {guzergahs[i].GuzergahAdi} Ucret: {guzergahs[i].GuzergahFiyati} ");
            
        }


        int index = int.Parse(Console.ReadLine());
        string guzergah = guzergahs[index-1].GuzergahAdi;

        
        

        Console.WriteLine("Yasi giriniz:");
        int yas = int.Parse(Console.ReadLine());

        // isim, güzergah ve yaş bilgileri alındı. int index = kullanıcının seçmiş olduğu güzergah numarasıdır.
        // guzergah da aşağıda girilen seçeneği string olarak kullanabilmemiz için oluşturuldu.
        // konsoldaki güzergah numaraları 1den başladığı için guzergahs[index-1].GuzergahAdi yaparak liste indexine denkleştirildi.

        //Guzergah guzerhaglar = guzergahs.Find(x => x.GuzergahAdi == guzergah);

        if (guzergahs[index-1].GuzergahAdi.Contains(guzergah))
        {
            Ticket ticket = new Ticket
            {
                İsim = isim,
                Guzergah = guzergah,
                Yas = yas,
                BiletFiyati = BiletFiyatHesapla()
            };

            double BiletFiyatHesapla() // Yaşı 18den kücük olanlar için %50 indirim uygulandı.
            {
                if (yas <= 18)
                {
                    return guzergahs[index-1].GuzergahFiyati * 0.5;
                }
                return guzergahs[index-1].GuzergahFiyati;
            }


            tickets.Add(ticket); // oluşturulan yeni ticket, tickets listesine eklendi.
            Console.WriteLine("Bilet satisi basarili");
        }
        else
        {
            Console.WriteLine("Böyle bir guzergah yok");
            
        }


    }
    public void BiletIptal()
    {
        Console.Clear();
        Console.WriteLine("Silinecek ismi girin:");
        string isim = Console.ReadLine();
        isim = isim.ToLower();
        isim = isim.Trim();

        List<int> ints = new List<int>(); // boş bir list oluşturuldu

        for (int i = 0; i < tickets.Count; i++) // for döngüsü i'yi 0dan başlatarak tickets listesinin uzunluğuna kadar döndürüldü
        {
            
            if (tickets[i].İsim.Contains(isim)) // kullanıcı tarafından girilen isim, tickets listesinde var mı diye bütün indexlerde kontrol edildi varsa yazdırıldı
            {
                Console.WriteLine($"{i + 1}) İsim: {tickets[i].İsim} Guzergah: {tickets[i].Guzergah} Yas: {tickets[i].Yas} Bilet Fiyatı: {tickets[i].BiletFiyati}");
                ints.Add(1); // Eğer girilen isim listede bulunur ise yeni yaratılan bu listeye 1 eklendi. Burada amaç girilen isim listede var mı yok mu kontrolü yapmak
            }

        }


        if (ints.Count>0) // Eğer isim listede bu yeni listeye eleman eklenmiş olacak ki uzunluğu 0dan büyük olacak ve if içine girecek
        {
            Console.WriteLine("Silinmesini istediginiz bilet numarasini giriniz:");
            int index = int.Parse(Console.ReadLine());   // silinmesi istenen numara girilecek. 
            if (index <= tickets.Count)
            {
                tickets.RemoveAt(index - 1); // ekrandaki sayilar 1den başladığı için liste indexine göre işlem yapılacağı için index-1 yazildi.
                Console.WriteLine("bilet silindi");
                ints.Clear();
               // Console.WriteLine(ints.Count);
            }
            else //eğer ekrandaki numaralar harici bir değer girilirse burası çalışacak
            {
                Console.WriteLine("Gecerli bir numara girin.");
            }
        }
        else // eğer yukarıdaki for döngüsünde eşleşen isim yoksa ints listesi boş kalacağı için else çalışak ve bu isimde satılan bilet yoktur yazilacak
        {
            Console.WriteLine("Bu isimde satilmis bir bilet yoktur.");
        
        }


    }
}

