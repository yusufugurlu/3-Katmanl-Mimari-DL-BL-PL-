using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KatmanliMimariCSharp.DL
{
    public class clsBaglanti
    {
        //Burada sqlconection,sqlcommand nesnelerinin oluşturmakla ilgilidir.

        SqlConnection _sqlSunucuBaglan = new SqlConnection("Buraya Database yolu yazılır");

        //sqlSunucuBaglan nesne yok ise oluştur get-seti
        public SqlConnection sqlSunucuBaglan
        {
            get
            {
                if (_sqlSunucuBaglan == null)
                {
                    _sqlSunucuBaglan = new SqlConnection("Buraya Database yolu yazılır");

                }
                return _sqlSunucuBaglan;
            }

        }

        SqlCommand _sqlKomut = new SqlCommand();
        //sqlKomut nesne yok ise oluştur get-seti
        public SqlCommand sqlKomut
        {
            get
            {
                if (_sqlKomut == null)
                {
                    _sqlKomut = new SqlCommand();


                }
                return _sqlKomut;
            }

        }


        SqlDataReader _sqlOku;

       



    }
}