// See https://aka.ms/new-console-template for more information 
public class kodeBuah
{
    public enum kode_buah
    {
        Apel,
        Aprikot,
        Alpukat,
        Pisang,
        Paprika,
        Blackberry,
        ceri,
        Kelapa,
        Jagung,
        Kurma,
        Durian,
        Anggur,
        Melon,
        Semangka,

    }
    public static string getKodeBuah(kode_buah buah)
    {
        string[] kode = {"A00","B00","C00","D00","E00","F00","H00","I00","J00","K00","L00","M00","N00","O00"};
        return kode[(int)buah];
    }
    public static void Main(string[] args)
    {
        kode_buah kodeBuah = kode_buah.Aprikot;
        Console.WriteLine($"{kodeBuah} = {getKodeBuah(kodeBuah)}");
    }
}
