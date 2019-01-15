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
    public partial class Kayıt : Form
    {
        //config isminde IFirebaseConfig anahtarı oluşturduk ve bunların içine Veritabanımızın anahtarını ve adresini tanımladık
        IFirebaseConfig config = new FirebaseConfig
        {
            //Veritabanı anahtarımız
            AuthSecret = "5jaCdGRw9SdOoDLSTAZ2vWJBZawUu0v0kO8VUFCs",
            //Veritabanı adresimiz
            BasePath = "https://hastaneproje-585a9.firebaseio.com/"
        };
        IFirebaseClient client;
        public Kayıt()
        {
            InitializeComponent();
        }
        private void Kayıt_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text=="" || textBox3.Text=="" || comboBox1.Text == "" || comboBox2.Text == "")
            {
                DialogResult hata = new DialogResult();
                hata = MessageBox.Show("Kullanıcı Bilgilerini Eksiksiz Giriniz !", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox4.Text != textBox5.Text)
            {
                DialogResult hata = new DialogResult();
                hata = MessageBox.Show("Girdiğiniz şifreler uyuşmuyor", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //kullanicilar sınıfını ve içindeki elementleri tanımlıyoruz
                var kullanici = new kullanicilar
                {
                    adi = textBox1.Text,
                    soyadi = textBox2.Text,
                    tcno = textBox3.Text,
                    cinsiyet = comboBox2.SelectedItem.ToString(),
                    sifre = textBox4.Text,
                    sigorta = comboBox1.SelectedItem.ToString(),
                    tarih = dateTimePicker1.Text
                };
                //textbox3'teki text ile sisteme kayıt açıyoruz
                SetResponse response = await client.SetTaskAsync("Kullanicilar/" + textBox3.Text, kullanici);
                hastaverileri result = response.ResultAs<hastaverileri>();
                DialogResult mesaj = new DialogResult();
                mesaj = MessageBox.Show("Başarıyla kayıt oldunuz!", "SİSTEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
                    if(mesaj==DialogResult.OK)
                    {
                        Form1 prsl = new Form1();
                        this.Hide();
                        prsl.Show();
                    }
                      
                
            }
            
            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 giris = new Form1();
            giris.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            if (label9.Text == "Göster")
            {
                textBox4.PasswordChar = '\0';
                label9.Text = "Gizle";
            }
            else if (label9.Text == "Gizle")
            {
                textBox4.PasswordChar = '*';
                label9.Text = "Göster";

            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            if (label10.Text == "Göster")
            {
                textBox5.PasswordChar = '\0';
                label10.Text = "Gizle";
            }
            else if (label10.Text == "Gizle")
            {
                textBox5.PasswordChar = '*';
                label10.Text = "Göster";

            }
        }

    }
}
