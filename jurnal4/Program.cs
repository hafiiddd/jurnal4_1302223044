// See https://aka.ms/new-console-template for more information 
using System;
/*public class kodeBuah
{
    //membuar var enum berisi nama buah
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
    //membuat fungsi untuk mengembalikan index berdasarkan kodepos dan nama buah 
    public static string getKodeBuah(kode_buah buah)
    {
        string[] kode = { "A00", "B00", "C00", "D00", "E00", "F00", "H00", "I00", "J00", "K00", "L00", "M00", "N00", "O00" };
        return kode[(int)buah];
    }
    //menampilkan nilai kodepos yang sama dengan parameter nama buah yang di inputkan
    public static void Main(string[] args)
    {
        kode_buah kodeBuah = kode_buah.Aprikot;
        Console.WriteLine($"{kodeBuah} = {getKodeBuah(kodeBuah)}");
    }
}*/
public class posisiKarakterGame
{
    public enum stateKarakter { BERDIRI, JONGKOK, TERBANG, TENGKURAP };
    public enum Trigger { TOMBOL_S, TOMBOL_W, TOMBOL_X };

    public stateKarakter currentStateKarakter = stateKarakter.BERDIRI;

    public class Transition
    {
        public stateKarakter stateAwal;
        public stateKarakter stateAkhir;
        public Trigger trigger;
        public Transition(stateKarakter stateAwal, stateKarakter stateAkhir, Trigger trigger)
        {
            this.stateAwal = stateAwal;
            this.stateAkhir = stateAkhir;
            this.trigger = trigger;
        }
    }
    Transition[] Transisi =
    {
        new Transition(stateKarakter.BERDIRI, stateKarakter.JONGKOK , Trigger.TOMBOL_S),
        new Transition(stateKarakter.BERDIRI, stateKarakter.TERBANG , Trigger.TOMBOL_W),
        new Transition(stateKarakter.TERBANG, stateKarakter.BERDIRI , Trigger.TOMBOL_S),
        new Transition(stateKarakter.TERBANG, stateKarakter.JONGKOK , Trigger.TOMBOL_X),
        new Transition(stateKarakter.JONGKOK, stateKarakter.BERDIRI , Trigger.TOMBOL_W),
        new Transition(stateKarakter.JONGKOK, stateKarakter.TENGKURAP , Trigger.TOMBOL_S),
        new Transition(stateKarakter.TENGKURAP, stateKarakter.JONGKOK , Trigger.TOMBOL_W),

    };
    public stateKarakter getNextKarakter(stateKarakter stateAwal, Trigger trigger)
    {
        stateKarakter stateAkhir = stateAwal;
        for (int i = 0; i < Transisi.Length; i++)
        {
            Transition ubah = Transisi[i];
            if (stateAwal == ubah.stateAwal && trigger == ubah.trigger)
            {
                stateAkhir = ubah.stateAkhir;
                
            }
        }
        currentStateKarakter = stateAkhir;
        return stateAkhir;
    }
    public static void Main(string[] args)
    {
        posisiKarakterGame state = new posisiKarakterGame();
        Console.WriteLine(state.currentStateKarakter);

        Console.WriteLine($"state sekarang : {state.getNextKarakter(state.currentStateKarakter, posisiKarakterGame.Trigger.TOMBOL_S)}");
        Console.WriteLine(state.currentStateKarakter);

        if (state.currentStateKarakter == stateKarakter.BERDIRI)
        {
            Console.WriteLine("posisi stanby");
        }
        else if (state.currentStateKarakter == stateKarakter.TENGKURAP)
        {
            Console.WriteLine("posisi istirahat");
        }

    }
}

