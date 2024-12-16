using System;

class Calisan
{
    public string Ad { get; set; }
    public string Soyad { get; set; }
    public double Maas { get; set; }
    public string Pozisyon { get; set; }

    public Calisan(string ad, string soyad, double maas, string pozisyon)
    {
        Ad = ad;
        Soyad = soyad;
        Maas = maas;
        Pozisyon = pozisyon;
    }

    public virtual string BilgiYazdir()
    {
        return $"Çalışan: {Ad} {Soyad}, Pozisyon: {Pozisyon}, Maaş: {Maas} TL";
    }
}

class Yazilimci : Calisan
{
    public string YazilimDili { get; set; }

    public Yazilimci(string ad, string soyad, double maas, string yazilimDili)
        : base(ad, soyad, maas, "Yazılımcı")
    {
        YazilimDili = yazilimDili;
    }

    public override string BilgiYazdir()
    {
        return base.BilgiYazdir() + $", Yazılım Dili: {YazilimDili}";
    }
}

class Muhasebeci : Calisan
{
    public string MuhasebeYazilimi { get; set; }

    public Muhasebeci(string ad, string soyad, double maas, string muhasebeYazilimi)
        : base(ad, soyad, maas, "Muhasebeci")
    {
        MuhasebeYazilimi = muhasebeYazilimi;
    }

    public override string BilgiYazdir()
    {
        return base.BilgiYazdir() + $", Kullandığı Muhasebe Yazılımı: {MuhasebeYazilimi}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Çalışan türünü seçin: ");
        Console.WriteLine("1. Yazılımcı");
        Console.WriteLine("2. Muhasebeci");

        string secim = Console.ReadLine();
        Calisan calisan = null;

        if (secim == "1")
        {
            Console.Write("Ad: ");
            string ad = Console.ReadLine();
            Console.Write("Soyad: ");
            string soyad = Console.ReadLine();
            Console.Write("Maaş: ");
            double maas = Convert.ToDouble(Console.ReadLine());
            Console.Write("Yazılım Dili: ");
            string yazilimDili = Console.ReadLine();
            calisan = new Yazilimci(ad, soyad, maas, yazilimDili);
        }
        else if (secim == "2")
        {
            Console.Write("Ad: ");
            string ad = Console.ReadLine();
            Console.Write("Soyad: ");
            string soyad = Console.ReadLine();
            Console.Write("Maaş: ");
            double maas = Convert.ToDouble(Console.ReadLine());
            Console.Write("Muhasebe Yazılımı: ");
            string muhasebeYazilimi = Console.ReadLine();
            calisan = new Muhasebeci(ad, soyad, maas, muhasebeYazilimi);
        }
        else
        {
            Console.WriteLine("Geçersiz seçim!");
            return;
        }

        Console.WriteLine(calisan.BilgiYazdir());
        Console.ReadLine();
    }
}