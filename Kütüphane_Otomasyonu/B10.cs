using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using Kütüphane_Otomasyonu.Properties;

namespace Kütüphane_Otomasyonu
{
    class B10
    {
        // Veritabanı URL'sini tutan değişken
        public static string urlDatabase = ConnDatabase.HomeUrl;

        // Veritabanı bağlantı dizesi
        static string baglantiYolu = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + urlDatabase;

        // OleDb bağlantısı nesnesi
        static OleDbConnection baglanti = new OleDbConnection(baglantiYolu);

        // Admin kullanıcı girişini doğrulayan metot
        public static bool Admin(string KullaniciAdi, string Sifre)
        {
            // Admin tablosundan kullanıcı adı ve şifre ile eşleşen kaydı sorgular
            string veri = "select * from Admin where KullaniciAdi=@klnc AND Sifre=@sfr";
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = veri;
            komut.Parameters.AddWithValue("@klnc", KullaniciAdi);
            komut.Parameters.AddWithValue("@sfr", Sifre);
            DataSet sonucDS = new DataSet();
            OleDbDataAdapter adaptor = new OleDbDataAdapter(komut);
            baglanti.Open();
            adaptor.Fill(sonucDS);
            baglanti.Close();
            bool sonuc = false;
            if (sonucDS.Tables[0].Rows.Count > 0)
                sonuc = true;
            return sonuc;
        }

        // Kitap ekleyen metot
        public static void KitapEkle(string KitapAdı, int SayfaNo, string Yazar, string BasımEvi)
        {
            baglanti.Open();
            // Kitap tablosuna yeni bir kayıt ekler
            string veri = "insert into Kitap (KitapAdı, SayfaNo, Yazar, BasımEvi) values (@ktpa, @syf, @yzr, @bsmv)";
            OleDbCommand komut = new OleDbCommand(veri, baglanti);
            komut.Parameters.AddWithValue("@ktpa", KitapAdı);
            komut.Parameters.AddWithValue("@syf", SayfaNo);
            komut.Parameters.AddWithValue("@yzr", Yazar);
            komut.Parameters.AddWithValue("@bsmv", BasımEvi);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        // Kitap silen metot
        public static void KitapSil(string KitapAdı)
        {
            baglanti.Open();
            // Kitap tablosundan belirtilen kitabı siler
            string veri = "delete from Kitap where KitapAdı=@ktpa";
            OleDbCommand komut = new OleDbCommand(veri, baglanti);
            komut.Parameters.AddWithValue("@ktpa", KitapAdı);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        // Kitap güncelleyen metot
        public static void KitapGuncelle(string KitapAdı, int SayfaNo, string Yazar, string BasımEvi)
        {
            baglanti.Open();
            // Kitap tablosunda belirtilen kitabın bilgilerini günceller
            string veri = "update Kitap set KitapAdı=@ktpa, SayfaNo=@syf, Yazar=@yzr, BasımEvi=@bsmv where KitapAdı=@ktpa";
            OleDbCommand komut = new OleDbCommand(veri, baglanti);
            komut.Parameters.AddWithValue("@ktpa", KitapAdı);
            komut.Parameters.AddWithValue("@syf", SayfaNo);
            komut.Parameters.AddWithValue("@yzr", Yazar);
            komut.Parameters.AddWithValue("@bsmv", BasımEvi);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        // Emanet kaydı ekleyen metot
        public static void emanetEkle(string KitapAdı, int KitapNo, string ÜyeAdı, int ÜyeNo, string AldığıTarih)
        {
            baglanti.Open();
            // Emanetler tablosuna yeni bir kayıt ekler
            string veri = "insert into Emanetler (KitapAdı, KitapNo, ÜyeAdı, ÜyeNo, AldığıTarih) values (@ktpa, @ktpn, @uye, @uyen, @trh)";
            OleDbCommand komut = new OleDbCommand(veri, baglanti);
            komut.Parameters.AddWithValue("@ktpa", KitapAdı);
            komut.Parameters.AddWithValue("@ktpn", KitapNo);
            komut.Parameters.AddWithValue("@uye", ÜyeAdı);
            komut.Parameters.AddWithValue("@uyen", ÜyeNo);
            komut.Parameters.AddWithValue("@trh", AldığıTarih);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        // Emanet kaydı silen metot
        public static void emanetSil(string KitapAdı)
        {
            baglanti.Open();
            // Emanetler tablosundan belirtilen kitabın emanet kaydını siler
            string veri = "delete from Emanetler where KitapAdı=@ktpa";
            OleDbCommand komut = new OleDbCommand(veri, baglanti);
            komut.Parameters.AddWithValue("@ktpa", KitapAdı);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        // Emanet kaydını güncelleyen metot
        public static void emanetGuncelle(string KitapAdı, int KitapNo, string ÜyeAdı, int ÜyeNo, string AldığıTarih)
        {
            baglanti.Open();
            // Emanetler tablosunda belirtilen kitabın emanet kaydını günceller
            string veri = "update Emanetler set KitapAdı=@ktpa, KitapNo=@ktpn, ÜyeAdı=@uye, ÜyeNo=@uyen, AldığıTarih=@trh where KitapAdı=@ktpa";
            OleDbCommand komut = new OleDbCommand(veri, baglanti);
            komut.Parameters.AddWithValue("@ktpa", KitapAdı);
            komut.Parameters.AddWithValue("@ktpn", KitapNo);
            komut.Parameters.AddWithValue("@uye", ÜyeAdı);
            komut.Parameters.AddWithValue("@uyen", ÜyeNo);
            komut.Parameters.AddWithValue("@trh", AldığıTarih);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        // Üye ekleyen metot
        public static void üyeEkle(string ÜyeAdı, string ÜyeSoyadı, string Meslek, int TelNo)
        {
            baglanti.Open();
            // Üyeler tablosuna yeni bir kayıt ekler
            string veri = "insert into Üyeler (ÜyeAdı, ÜyeSoyadı, Meslek, TelNo) values (@uyea, @uyes, @mslk, @tel)";
            OleDbCommand komut = new OleDbCommand(veri, baglanti);
            komut.Parameters.AddWithValue("@uyea", ÜyeAdı);
            komut.Parameters.AddWithValue("@uyes", ÜyeSoyadı);
            komut.Parameters.AddWithValue("@mslk", Meslek);
            komut.Parameters.AddWithValue("@tel", TelNo);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        // Üye silen metot
        public static void üyeSil(string ÜyeAdı)
        {
            baglanti.Open();
            // Üyeler tablosundan belirtilen üyeyi siler
            string veri = "delete from Üyeler where ÜyeAdı=@uyea";
            OleDbCommand komut = new OleDbCommand(veri, baglanti);
            komut.Parameters.AddWithValue("@uyea", ÜyeAdı);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        // Üye bilgisini güncelleyen metot
        public static void üyeGuncelle(string ÜyeAdı, string ÜyeSoyadı, string Meslek, int TelNo)
        {
            baglanti.Open();
            // Üyeler tablosunda belirtilen üyenin bilgilerini günceller
            string veri = "update Üyeler set ÜyeAdı=@uyea, ÜyeSoyadı=@uyes, Meslek=@mslk, TelNo=@tel where ÜyeAdı=@uyea";
            OleDbCommand komut = new OleDbCommand(veri, baglanti);
            komut.Parameters.AddWithValue("@uyea", ÜyeAdı);
            komut.Parameters.AddWithValue("@uyes", ÜyeSoyadı);
            komut.Parameters.AddWithValue("@mslk", Meslek);
            komut.Parameters.AddWithValue("@tel", TelNo);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}