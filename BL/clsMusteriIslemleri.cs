using KatmanliMimariCSharp.DL;
using KatmanliMimariCSharp.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace KatmanliMimariCSharp.BL
{
    public class clsMusteriIslemleri
    {
        clsVeritabani veritabani;
        public clsMusteriIslemleri(Dictionary<object, object> parametreler, string sorgu)
        {
            //Procedure parametreli ise parametre+ procedure adı olan constructor 
            veritabani = new clsVeritabani(parametreler, sorgu);
        }

        public clsMusteriIslemleri(string sorgu)
        {
            //Procedure parametresiz ise parametre+ procedure adı olan constructor 
            veritabani = new clsVeritabani(sorgu);
        }

        DataTable table;
        public DataTable BlogSayfasiniGoruntule()
        {
            table = new DataTable();

            //Burada veritabanında hangi verileri tanımlayacaksan ona göre kolonların adlarını tanımlıyoruz.
            table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Adi", typeof(string));
            table.Columns.Add("Soyadi", typeof(string));
            table.Columns.Add("Email", typeof(string));
            //Veritabından alınan verileri alıyoruz.
            //EnumTabloları adlı bir enum oluşturdum.Tabloları ona gore switch atarak ona gore okuma işlemi yapıldı.
            List<object> Blog = veritabani.VerileriListeSeklindeGetir(EnumTabloAdlari.tblMusteriler);
            for (int j = 0; j < Blog.Count; j++)
            {
                DataRow Satir = table.NewRow();
                //Verilen Veritabanından verileri datatable aktarıyorum.
                Satir["ID"] = Convert.ToInt32(((clsMusteriler)Blog[j]).ID);
                Satir["Adi"] = ((clsMusteriler)Blog[j]).Adi;
                Satir["Soyadi"] = ((clsMusteriler)Blog[j]).Soyadi;
                Satir["Email"] = ((clsMusteriler)Blog[j]).Email;
                table.Rows.Add(Satir);
            }
            return table;

        }
        public object TekScalarDeger()
        {
            //Burada sadece tek değer almak için kullanılıyor.
            object sonuc = 0;
            sonuc = veritabani.TekDegerSkaler();
            return sonuc;
        }
    }

}