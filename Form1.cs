using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace otomasyon
{
    public partial class Form1 : Form
    {
        public static string hasta;
        public static string tcno;

        //config isminde IFirebaseConfig anahtarı oluşturduk ve bunların içine Veritabanımızın anahtarını ve adresini tanımladık
        IFirebaseConfig config = new FirebaseConfig
        {
            //Veritabanı anahtarımız
            AuthSecret = "5jaCdGRw9SdOoDLSTAZ2vWJBZawUu0v0kO8VUFCs",
            //Veritabanı adresimiz
            BasePath = "https://hastaneproje-585a9.firebaseio.com/"
        };
        //client isminde IFirebaseClient anahtarı oluşturuyoruz
        IFirebaseClient client;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox1.ForeColor = Color.Black;
        }

    

      

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Kullanıcı Adınız";
                textBox1.ForeColor = Color.Gray;
            }
        }

     

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        public static string doktoradi;

        private async void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                //textbox1'deki değer ile Veritabanımızın Personeller klasörünü kontrol ettiriyoruz
                FirebaseResponse personelresponse = await client.GetTaskAsync("Personeller/" + textBox1.Text);
                personeller personeldegerler = personelresponse.ResultAs<personeller>();
                string sifre = personeldegerler.sifre;//şifre karşılaştırması için şifreyi önce veritabanından çekiyoruz
                string girilensifre = textBox2.Text;//textbox2'deki girdiğimiz şifreyi girilensifre değişkenine kaydediyoruz
                doktoradi = personeldegerler.doktorad;
                if (textBox1.Text == "Kullanıcı Adınız" || textBox2.Text == "Şifreniz")
                {
                    MessageBox.Show("Lütfen Bilgilerinizi Giriniz", "SİSTEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (textBox2.Text == "" || textBox2.Text == "Şifre")
                {
                    MessageBox.Show("lütfen şifrenizi giriniz", "SİSTEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (girilensifre != sifre)
                {
                    MessageBox.Show("Şifreniz yanlış", "SİSTEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    PersonelForm personelform = new PersonelForm();
                    personelform.Show();
                    this.Hide();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata ile karşılaşıldı.Kullanıcı adınız veri tabanında bulunamadı.", "SİSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            textBox4.Text = "";
        }

        private void textBox4_MouseLeave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "TC NO";
                textBox4.ForeColor = Color.Gray;
            }
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Şifreniz";
                textBox2.ForeColor = Color.Gray;
            }
        }
        public static string kullanici;
        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //textbox4 ile kullanıcılar klasörüne ulaşıyoruz
                FirebaseResponse response = await client.GetTaskAsync("Kullanicilar/" + textBox4.Text);
                kullanicilar degerler = response.ResultAs<kullanicilar>();
                string sifre = degerler.sifre;//şifre karşılaştırması için şifreyi önce veritabanından çekiyoruz
                string girilensifre = textBox3.Text;//textbox3 teki textini girilensifre değişkenine kaydediyoruz
                if (textBox4.Text == "" || textBox4.Text == "TC NO")
                {
                    MessageBox.Show("Lütfen TC Kimlik Numaranızı Giriniz", "SİSTEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (textBox4.TextLength < 11)
                {
                    MessageBox.Show("TC Kimlik Numaranızı Eksiksiz Giriniz", "SİSTEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (textBox3.Text == "" || textBox3.Text == "Şifre")
                {
                    MessageBox.Show("lütfen şifrenizi giriniz", "SİSTEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (girilensifre != sifre)
                {
                    MessageBox.Show("Şifreniz yanlış", "SİSTEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    /*Olası bir durumda kullanıcı TCNO'sunu yanlış girmesi durumunda programın çökmesini önlemek için
                    try catch bloğunu kullanıyoruz*/
                    try
                    {
                        FirebaseResponse response1 = await client.GetTaskAsync("Kullanicilar/" + textBox4.Text);
                        kullanicilar degerler1 = response.ResultAs<kullanicilar>();
                        kullanici = degerler1.adi + " " + degerler1.soyadi;//Hasta randevu alacağı form'da ismi gözükmesi için kullanici public stringini düzenliyoruz
                        tcno = textBox4.Text; //textbox4'deki değeri tcno'ya atıyoruz
                        RandevuProgramForm randevu = new RandevuProgramForm();
                        randevu.Show();
                        this.Hide();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Hata ile karşılaşıldı.Kullanıcı adınız veri tabanında bulunamadı.", "SİSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Hata ile karşılaşıldı.Kullanıcı adınız veri tabanında bulunamadı.", "SİSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox2.ForeColor = Color.Black;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox4.ForeColor = Color.Black;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
               
            }
        }

       
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_MouseLeave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Şifreniz";
                textBox3.ForeColor = Color.Gray;
            }
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox3.Text = "";
            textBox3.ForeColor = Color.Black;
        }
      

        private void button4_Click(object sender, EventArgs e)
        {
            Kayıt grs = new Kayıt();
            this.Hide();
            grs.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (label5.Text == "Göster")
            {
                textBox2.PasswordChar = '\0';
                label5.Text = "Gizle";
            }
            else if (label5.Text == "Gizle")
            {
                textBox2.PasswordChar = '*';
                label5.Text = "Göster";

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (label6.Text == "Göster")
            {
                textBox3.PasswordChar = '\0';
                label6.Text = "Gizle";
            }
            else if (label6.Text == "Gizle")
            {
                textBox3.PasswordChar = '*';
                label6.Text = "Göster";

            }
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Kullanıcı Adınız";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            
        }
        
    }
}
