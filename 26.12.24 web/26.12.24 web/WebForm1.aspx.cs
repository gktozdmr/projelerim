using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // Eğer sayfa ilk kez yükleniyorsa (postback değilse)
            if (!IsPostBack)
            {
                // Veritabanı bağlantısını oluşturuyoruz
                SqlConnection veri_baglanti = new SqlConnection("Data Source=LAPTOP-GKK4AA8V;Initial Catalog=gkt;Integrated Security=True" );

                try
                {


                    // Verileri almak için DataAdapter kullanıyoruz
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM ogr", veri_baglanti);

                    // Sorgudan gelen verileri tutacak bir DataTable oluşturuyoruz
                    DataTable dt = new DataTable();

                    // Verileri DataTable'a dolduruyoruz
                    da.Fill(dt);

                    // Eğer veri varsa, DataTable'ı GridView'a bağlıyoruz
                    if (dt.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt;
                        GridView1.DataBind(); // GridView veriyi bağlamak için DataBind() metodu çağrılmalı
                    }
                    else
                    {
                        // Veri yoksa kullanıcıya mesaj gösterebiliriz
                        Response.Write("Veritabanında hiç veri yok.");
                    }

                    // Bağlantıyı açıyoruz
                    veri_baglanti.Open();
                    // Bağlantıyı kapatıyoruz
                    veri_baglanti.Close();
                }
                catch (Exception ex) // Hata durumunda daha fazla bilgi verebiliriz
                {
                    // Hata mesajını yazdırıyoruz
                    Response.Write("Veritabanıyla bağlantı kurulamadı: " + ex.Message);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection veri_baglanti = new SqlConnection("Provider=Microsoft.ACE.OLEDB.12.0; DATA Source=" + Server.MapPath("App_Data//deneme1.mdb"));
            try
            {
                // Kullanıcıdan alınan veriler
                string kimlik = TextBox1.Text;
                string ad = TextBox2.Text;
                string soyad = TextBox3.Text;
                string adres = TextBox4.Text;
                string telefon = TextBox5.Text;

                // Veritabanına yeni kayıt eklemek için sorgu
                string sorgu = "INSERT INTO ogr (Kimlik, Ad, Soyad, Adres, Telefon) VALUES (?, ?, ?, ?, ?)";

                SqlCommand komut = new SqlCommand(sorgu, veri_baglanti);
                komut.Parameters.AddWithValue("?", kimlik);
                komut.Parameters.AddWithValue("?", ad);
                komut.Parameters.AddWithValue("?", soyad);
                komut.Parameters.AddWithValue("?", adres);
                komut.Parameters.AddWithValue("?", telefon);

                // Bağlantıyı açıyoruz
                veri_baglanti.Open();

                // Kayıt ekliyoruz
                komut.ExecuteNonQuery();

                // Kullanıcıya başarılı mesajı gösterilebilir
                Response.Write("Yeni kayıt başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya mesaj gösteriyoruz
                Response.Write("Hata: " + ex.Message);
            }
            finally
            {
                veri_baglanti.Close();
              
            }
        }
    }
}