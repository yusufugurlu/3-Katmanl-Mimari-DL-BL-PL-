using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KatmanliMimariCSharp.Entity
{
    //Burada onemli nokta entity classlarının object nesnesinden kalıtım sağlıyor olmasıdır.!!!
    public class clsMusteriler:Object
    {
        //Veritabanındaki tablonuzdaki sutun adları yazılır.
        //Sonra bu classı list şeklinde alarak aslında bunu ramde tutarak hızdan tasaruf sağlanır.
        //Ama ram şişebilir dezavantaj olarak.
        public int ID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Email { get; set; }
    }
}