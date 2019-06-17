using System;
using System.Collections.Generic;
using System.Text;

namespace Log
{
    public class Record
    {
        public Guid ID { get; set; }
        public DateTime TarihSaat { get; set; }
        public KayitTip Tip { get; set; }
        public string Namespace { get; set; }
        public string Class { get; set; }
        public string Metot { get; set; }
        public object Parametreler { get; set; }
        public Exception Ex { get; set; }
        public string Ex_Aciklama { get; set; }
        public KayitDurum Durum { get; set; }
        public string DurumAciklama { get; set; }
    }

    public enum KayitTip
    {
        Debug, Bilgilendirme, Hata
    }

    public enum KayitDurum
    {
        YeniKayit, Islemde, Duzenlendi, IptalEdildi
    }
}
