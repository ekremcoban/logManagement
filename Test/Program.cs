using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Transactions transactions = new Log.Transactions("PROJECT");
            transactions.NewRecord(new Log.Record()
            {
                ID = Guid.NewGuid(),
                TarihSaat = DateTime.Now,
                Namespace = "UDEMY.TEST",
                Class = "Program",
                Metot = "Main",
                Tip = Log.KayitTip.Debug,
                Durum = Log.KayitDurum.YeniKayit
            });
        }
    }
}
