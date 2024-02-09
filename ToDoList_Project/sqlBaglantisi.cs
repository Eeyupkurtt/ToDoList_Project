using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ToDoList_Project
{
    internal class sqlBaglantisi
    {
        /*Sql Veri Tabanında Veri Çekeceğimiz için işimizi kolaylaştıracak bir sql baglanti sınıfı oluşturma.
        Küçük projelerde önemli olmayabilir ama
        birçok bağlantı yapmamız gereken uygulamalarda kolaylık sağlar
        -sqlBaglantisi bgl = new sqlBaglantisi();-->Bu şekilde baglanti sınıfını çağırabiliriz.*/
        public SqlConnection baglanti()
        {    
            SqlConnection baglan = new SqlConnection("");//Tırnak içerisine olşturduğunuz veri tabanının linkini koyacaksınız.
            baglan.Open();                               //orn; ("Data Source=.......;......;......;")
            return baglan;
        }
    }
}
