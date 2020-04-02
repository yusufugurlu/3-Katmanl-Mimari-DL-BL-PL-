using KatmanliMimariCSharp.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KatmanliMimariCSharp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
                pnlPopup.Visible = false;
                pnplHider.Visible = false;
       
        }

        int iDonenDeger;
        clsMusteriIslemleri islem;
        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            //Dictionary ile procedure içinde parametre alıyorsa bunları dictionary ile gönderiyorum
            Dictionary<object, object> parametreler = new Dictionary<object, object>();
            parametreler.Add("@Email",txtEmail.Text);
            parametreler.Add("@Sifre", txtSifre.Text);

            islem = new clsMusteriIslemleri(parametreler, "sp_MusteriLogin");
            //Burada procedureden gelen tek değişkenli degeri değişkene atadım
             iDonenDeger= Convert.ToInt32(islem.TekScalarDeger().ToString());
            //0 ise email veya şifre yanlış
            if (iDonenDeger==0)
            {
                lblDurum.Text = "Email veya sifre yanlış Lütfen tekrar deneyiniz";

            }
            //0dan farklı degerse musterinin veritabanındaki unique Id değerini aldım
            else
            {
               
                lblDurum.Text = "Islem basarili.";
                //Dictionary ile procedure içinde parametre alıyorsa bunları dictionary ile gönderiyorum
                Dictionary<object, object> parametrelerMusteriGetir = new Dictionary<object, object>();
               //Yukkarıdaki Id procedure göndererek kişinin bilgilerini table şeklinde alıyorum.
                parametrelerMusteriGetir.Add("@MusteriID", iDonenDeger);
                islem = new clsMusteriIslemleri(parametrelerMusteriGetir,"sp_MusteriGetir");
                //Datatable atadım. 
                DataTable dataTable= islem.BlogSayfasiniGoruntule();
                //Datatabledaki verileri ekrana yazdırıyorum.
                //Bir tane veri geleceğinden 0 row ve adi ise BlogSayfasiniGoruntule methodunda satırların isimlerini tanımladık ona gore 
                //adlarını yazıyorum.
                lblKullaniciAdi.Text = dataTable.Rows[0]["Adi"].ToString() + " " + dataTable.Rows[0]["Soyadi"].ToString() + "Tekradam Hoşgeldiniz.";
                lblEmail.Text = dataTable.Rows[0]["Adi"].ToString();
                pnlPopup.Visible = true;
                pnplHider.Visible = true;
            }
        }

        protected void btnKapat_Click(object sender, EventArgs e)
        {
            pnlPopup.Visible = false;
            pnplHider.Visible = false;
        }
    }
}