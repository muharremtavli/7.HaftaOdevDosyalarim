using System;
using System.Collections.Generic;

// IYayinci Arayüzü
public interface IYayinci
{
    void AboneEkle(IAbone abone);
    void AboneCikar(IAbone abone);
    void AboneListele();
    void Bildir();
}

// IAbone Arayüzü
public interface IAbone
{
    void BilgiAl(string mesaj);
}

// Yayinci Sınıfı
public class Yayinci : IYayinci
{
    private List<IAbone> aboneler = new List<IAbone>();
    private string haber;

    public void AboneEkle(IAbone abone)
    {
        aboneler.Add(abone);
        Console.WriteLine("Abone eklendi.");
    }

    public void AboneCikar(IAbone abone)
    {
        aboneler.Remove(abone);
        Console.WriteLine("Abone çıkarıldı.");
    }

    public void AboneListele()
    {
        Console.WriteLine($"Toplam Abone Sayısı: {aboneler.Count}");
    }

    public void Bildir()
    {
        foreach (var abone in aboneler)
        {
            abone.BilgiAl(haber);
        }
    }

    public string Haber
    {
        get { return haber; }
        set
        {
            haber = value;
            Console.WriteLine($"Yeni haber: {haber}");
            Bildir();
        }
    }
}

// Abone Sınıfı
public class Abone : IAbone
{
    private string isim;

    public Abone(string isim)
    {
        this.isim = isim;
    }

    public void BilgiAl(string mesaj)
    {
        Console.WriteLine($"{isim} abonesi, yeni haber aldı: {mesaj}");
    }
}

// Ana Program
class Program
{
    static void Main(string[] args)
    {
        // Yayıncı oluştur
        Yayinci yayinci = new Yayinci();

        // Aboneler oluştur
        Abone abone1 = new Abone("Ali");
        Abone abone2 = new Abone("Ayşe");

        // Aboneleri yayıncıya ekle
        yayinci.AboneEkle(abone1);
        yayinci.AboneEkle(abone2);

        // Aboneleri listele
        yayinci.AboneListele();

        // Yayıncı bir haber gönderdiğinde
        yayinci.Haber = "Yeni kitap çıktı!";

        // Bir abone çıkardığında
        yayinci.AboneCikar(abone1);

        // Başka bir haber gönderdiğinde
        yayinci.Haber = "Yaz indirimleri başladı!";
    }
}