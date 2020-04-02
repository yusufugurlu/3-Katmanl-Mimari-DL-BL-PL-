using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using KatmanliMimariCSharp.Entity;

namespace KatmanliMimariCSharp.DL
{
    public class clsVeritabani
    {
        Dictionary<object, object> _Parametreler;


        //Parametreleri almak için   Dictionary<object, object> get-set oluşturduk(Property)
        public Dictionary<object, object> Parametreler
        {
            get { return _Parametreler; }
            set { _Parametreler = value; }
        }



    

        string _sSorgu;
        //Procedure adını almak için  _sSorgu  get-set oluşturduk(Property)

        public string SSorgu
        {
            get { return _sSorgu; }
            set { _sSorgu = value; }
        }

        //procedure Parametresiz  olan constracture
        public clsVeritabani(string sSorgu)
        {

            this.SSorgu = sSorgu;
        }
        // procedure Parametreli olan  constracture
        public clsVeritabani(Dictionary<object, object> parametreler, string sSorgu)
        {
            this.Parametreler = parametreler;
            this.SSorgu = sSorgu;
        }

        clsBaglanti clsBaglanti = new clsBaglanti();
     
        //Burada entity de bulunan classların hepsi (enumlar hariç) objext nesnesinden tureyecek Onemli !!!
        //Ona gore burada veritabanında tutacağımız tek list ile butun classları tutabliriz.
        List<object> musteriler;

        //Burada ise Dictionary<object, object> Parametreler gelen sqlcommand aktarma islemi yapılır tabi parametreli ise.
        void ParametreleriDoldur()
        {

            if (Parametreler == null)
            {
                return;
            }
            if (Parametreler.Count > 0)
            {
                foreach (var item in Parametreler)
                {

                    clsBaglanti.sqlKomut.Parameters.AddWithValue(item.Key.ToString(), item.Value.ToString());

                }
            }


        }

        //Verileri liste şeklinde buradan alıyoruz. Burada parametre olarak enum seçerek ona göre hangi tablodan okuyacağımız,
        //hangi classına ait olduğu ona ekleme işlemi yapılır.
        public List<object> VerileriListeSeklindeGetir(EnumTabloAdlari enumTablo)
        {
            musteriler = new List<object>();
            clsBaglanti.sqlSunucuBaglan.Open();
            clsBaglanti.sqlKomut.CommandText = SSorgu;
            clsBaglanti.sqlKomut.CommandType = CommandType.StoredProcedure;
            ParametreleriDoldur();
            clsBaglanti.sqlKomut.Connection = clsBaglanti.sqlSunucuBaglan;
            SqlDataReader rd = clsBaglanti.sqlKomut.ExecuteReader();

            while (rd.Read())
            {
                //Burada enuma gore switch yapısına giderek veriler okunur.
                switch (enumTablo)
                {
                    case EnumTabloAdlari.tblMusteriler:
                        clsMusteriler musteri = new clsMusteriler();
                        musteri.Adi = rd["Adi"].ToString();
                        musteri.Soyadi = rd["Soyadi"].ToString();
                        musteri.Email = rd["Email"].ToString();
                        musteriler.Add(musteri);
                        break;
                    default:
                        break;
                }



            }

            clsBaglanti.sqlSunucuBaglan.Close();

            return musteriler;




        }

        //Burada tek değer toplam musteri sayisi tek değer alıcaksa bu method kullanıllır.
        //Bu method ise object değeri alması önemli
        //string,int,bool... gibi
        public object TekDegerSkaler()
        {
            object nesne;
            clsBaglanti.sqlSunucuBaglan.Open();
            clsBaglanti.sqlKomut.Connection = clsBaglanti.sqlSunucuBaglan;
            ParametreleriDoldur();
            clsBaglanti.sqlKomut.CommandText = SSorgu;
            clsBaglanti.sqlKomut.CommandType = CommandType.StoredProcedure;
            nesne = clsBaglanti.sqlKomut.ExecuteScalar();
            clsBaglanti.sqlSunucuBaglan.Close();

            return nesne;
        }
    }
}