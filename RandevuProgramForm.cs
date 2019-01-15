using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Firebase Elementler
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace otomasyon
{
    public partial class RandevuProgramForm : Form
    {
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
        public RandevuProgramForm()
        {
            InitializeComponent();
        }

        private void RandevuProgramForm_Load(object sender, EventArgs e)
        {
            label7.Text = Form1.tcno;
            label9.Text = "Sayın "+Form1.kullanici;
            //yukarıda oluşturduğumuz client'i config'e bağlıyoruz
            client = new FireSharp.FirebaseClient(config);
            //Bu döngüyle de veritabanımız ile bağlantı kuruluyor mu onu kontrol ediyoruz
            if (client != null)
            {
                DialogResult mesaj = new DialogResult();
                mesaj = MessageBox.Show("Başarıyla Giriş Yapıldı!", "Veritabanı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            timer1.Start();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "İstanbul")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Sarıyer");
                comboBox2.Items.Add("Eyüp");
                comboBox2.Items.Add("Üsküdar");
                
            }
            else if (comboBox1.Text == "Ankara")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Güdül");
                comboBox2.Items.Add("Nallıhan");
                comboBox2.Items.Add("Çankaya");
            }
            else if (comboBox1.Text == "İzmir")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Bayındır");
                comboBox2.Items.Add("Buca");
                comboBox2.Items.Add("Çeşme");
            }
            
                     
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Sarıyer")
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add("İstinye Devlet Hastanesi");
            }
            else if (comboBox2.Text == "Eyüp")
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add("Eyüp Devlet Hastanesi");
            }
            else if (comboBox2.Text == "Üsküdar")
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add("Üsküdar Devlet Hastanesi");
            }
            else if (comboBox2.Text == "Güdül")
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add("Güdül Devlet Hastanesi");
            }
            else if (comboBox2.Text == "Nallıhan")
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add("Nallıhan Devlet Hastanesi");
            }
            else if (comboBox2.Text == "Çankaya")
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add("29 Mayıs Devlet Hastanesi");
            }
            else if (comboBox2.Text == "Bayındır")
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add("Bayındır Devlet Hastanesi");
            }
            else if (comboBox2.Text == "Buca")
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add("Seyfi Demirsoy Devlet Hastanesi");
            }
            else if (comboBox2.Text == "Çeşme")
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add("Alper Çizgenakat Devlet Hastanesi");
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "İstinye Devlet Hastanesi")
            {
                comboBox5.Items.Clear();
                comboBox5.Items.Add("İç Hastalıkları");
                comboBox5.Items.Add("Beyin ve Sinir Cerrahisi");
                comboBox5.Items.Add("Çocuk Sağlığı ve Hastalıkları");
            }
            else if (comboBox3.Text == "Eyüp Devlet Hastanesi")
            {
                comboBox5.Items.Clear();
                comboBox5.Items.Add("Üroloji");
                comboBox5.Items.Add("Göz Hastalıkları");
                comboBox5.Items.Add("Kalp ve Damar Cerrahisi");
            }
            else if (comboBox3.Text == "Üsküdar Devlet Hastanesi")
            {
                comboBox5.Items.Clear();
                comboBox5.Items.Add("Kadın Hastalıkları ve Doğum");
                comboBox5.Items.Add("Ruh Sağlığı ve Hastalıkları");
                comboBox5.Items.Add("İç Hastalıkları (Üsküdar)");
            }
            else if (comboBox3.Text == "Güdül Devlet Hastanesi")
            {
                comboBox5.Items.Clear();
                comboBox5.Items.Add("Genel Cerrahi");
                comboBox5.Items.Add("Aile Hekimliği");
                comboBox5.Items.Add("İç Hastalıkları (Güdül)");
            }
            else if (comboBox3.Text == "Nallıhan Devlet Hastanesi")
            {
                comboBox5.Items.Clear();
                comboBox5.Items.Add("Ortopedi ve Travmatoloji");
                comboBox5.Items.Add("Kulak Burun Boğaz");
                comboBox5.Items.Add("Diş Hastalıkları");
            }
            else if (comboBox3.Text == "29 Mayıs Devlet Hastanesi")
            {
                comboBox5.Items.Clear();
                comboBox5.Items.Add("Deri ve Zührevi Hastalıklar");
                comboBox5.Items.Add("Enfeksiyon Hastalıkları");
                comboBox5.Items.Add("Anestezi ve Reaminasyon");
            }
            else if (comboBox3.Text == "Bayındır Devlet Hastanesi")
            {
                comboBox5.Items.Clear();
                comboBox5.Items.Add("Kulak Burun Boğaz (Bayındır)");
                comboBox5.Items.Add("Ağız ve Diş Sağlığı (Bayındır)");
                comboBox5.Items.Add("Ortopedi ve Travmatoloji (Bayındır)");
            }
            else if (comboBox3.Text == "Seyfi Demirsoy Devlet Hastanesi")
            {
                comboBox5.Items.Clear();
                comboBox5.Items.Add("Aile Hekimliği (Buca)");
                comboBox5.Items.Add("Beyin Cerrahi");
                comboBox5.Items.Add("Dermatoloji");
            }
            else if (comboBox3.Text == "Alper Çizgenakat Devlet Hastanesi")
            {
                comboBox5.Items.Clear();
                comboBox5.Items.Add("Üroloji (Çeşme)");
                comboBox5.Items.Add("Göz Hastalıkları (Çeşme)");
                comboBox5.Items.Add("Nöroloji");
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.Text == "İç Hastalıkları")
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("Aynur ARSLAN");
            }
            else if (comboBox5.Text == "Beyin ve Sinir Cerrahisi")
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("Murat KARAKUŞ");
            }
            else if (comboBox5.Text == "Çocuk Sağlığı ve Hastalıkları")
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("Tülin YÜKSEKGÖNÜL");
            }
            else if (comboBox5.Text == "Üroloji")
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("Mustafa Gökhan KÖSE");
            }
            else if (comboBox5.Text == "Göz Hastalıkları")
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("Muzaffer ATEŞ");
            }
            else if (comboBox5.Text == "Kalp ve Damar Cerrahisi")
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("Fikret KOCAMAZ");
            }
            else if (comboBox5.Text == "Kadın Hastalıkları ve Doğum")
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("Mehmet Emin ULUĞ");
            }
            else if (comboBox5.Text == "Ruh Sağlığı ve Hastalıkları")
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("Semiha TUFAN");
            }
            else if (comboBox5.Text == "İç Hastalıkları (Üsküdar)")
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("Hatice Selcen BİÇER");
            }
            else if (comboBox5.Text == "Genel Cerrahi")
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("Hüseyin Murat Merci MAHMUTOĞLU");
            }
            else if (comboBox5.Text == "Aile Hekimliği")
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("Esra ERDOĞAN");
            }
            else if (comboBox5.Text == "İç Hastalıkları (Güdül)")
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("Ömer Özgür CEYLAN");
            }
            else if (comboBox5.Text == "Ortopedi ve Travmatoloji")
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("Mehmet AYDEMİR");
            }
            else if (comboBox5.Text == "Kulak Burun Boğaz")
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("Habib HAŞEMİ");
            }
            else if (comboBox5.Text == "Diş Hastalıkları")
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("Burak ALKAN");
            }
            else if (comboBox5.Text == "Deri ve Zührevi Hastalıklar")
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("Selda ÖCAL ÜNAL");
            }
            else if (comboBox5.Text == "Enfeksiyon Hastalıkları")
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("Gülçin TELLİ DİZMAN");
            }
            else if (comboBox5.Text == "Anestezi ve Reaminasyon")
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("Elif ŞENSES");
            }
            else if (comboBox5.Text == "Kulak Burun Boğaz (Bayındır)")
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("Yusuf HIDIR");
            }
            else if (comboBox5.Text == "Ağız ve Diş Sağlığı (Bayındır)")
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("Tahir ÖZAKTAN");
            }
            else if (comboBox5.Text == "Ortopedi ve Travmatoloji (Bayındır)")
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("Semih Gürkan TORLAK");
            }
            else if (comboBox5.Text == "Aile Hekimliği (Buca)")
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("Süleyman Ozan VİCİR");
            }
            else if (comboBox5.Text == "Beyin Cerrahi")
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("Berkant ATAY");
            }
            else if (comboBox5.Text == "Dermatoloji")
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("Berna Ülgen ATALAY");
            }
            else if (comboBox5.Text == "Üroloji (Çeşme)")
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("Eyüp ERDOĞAN");
            }
            else if (comboBox5.Text == "Göz Hastalıkları (Çeşme)")
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("Cafer Ferheng AZEROĞLU");
            }
            else if (comboBox5.Text == "Nöroloji")
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("Bezayim Can CANDAN");
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //butonların tıklanıp tıklanmadığı kontrol ediliyor
                if (button3.BackColor != Color.Red && button4.BackColor != Color.Red && button5.BackColor != Color.Red && button6.BackColor != Color.Red && button7.BackColor != Color.Red && button8.BackColor != Color.Red && button9.BackColor != Color.Red && button10.BackColor != Color.Red && button11.BackColor != Color.Red && button12.BackColor != Color.Red && button13.BackColor != Color.Red && button14.BackColor != Color.Red && button15.BackColor != Color.Red && button16.BackColor != Color.Red && button17.BackColor != Color.Red && button18.BackColor != Color.Red && button19.BackColor != Color.Red && button20.BackColor != Color.Red)
                {
                    DialogResult hata = new DialogResult();
                    hata = MessageBox.Show("Randevu Saatinizi Seçiniz", "SİSTEM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //hastaneverileri.cs dosyamızı buraya tanımlıyoruz ve içindeki değerlerin neye eşit olacağını belirtiyoruz
                    var veri = new hastaverileri
                    {
                        isim = Form1.kullanici,
                        sehir = comboBox1.SelectedItem.ToString(),
                        ilce = comboBox2.SelectedItem.ToString(),
                        hastane = comboBox3.SelectedItem.ToString(),
                        klinik = comboBox5.SelectedItem.ToString(),
                        doktor = comboBox6.SelectedItem.ToString(),
                        tarih = dateTimePicker1.Text,
                        saat = saat
                    };
                    //element değerlerini stringe tanımlıyoruz böylece rows.add komudumuz fazla uzun sürmüyor
                    string sehir = comboBox1.SelectedItem.ToString();
                    string ilce = comboBox2.SelectedItem.ToString();
                    string hastane = comboBox3.SelectedItem.ToString();
                    string klinik = comboBox5.SelectedItem.ToString();
                    string doktor = comboBox6.SelectedItem.ToString();
                    string tarih = dateTimePicker1.Text;
                    string zaman = saat;
                    dataGridView1.Rows.Add(Form1.kullanici, sehir, ilce, hastane, klinik, doktor, tarih, zaman);
                    //datagridview'a randevumuz eklendikten sonra giriş esnasında aldığımız tcno üzerinden randevu açıyoruz
                    SetResponse response = await client.SetTaskAsync("Randevular/" + label7.Text, veri);
                    hastaverileri result = response.ResultAs<hastaverileri>();
                    DialogResult mesaj = new DialogResult();
                    mesaj = MessageBox.Show("Randevu Başarıyla Alındı", "SİSTEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    comboBox3.Text = "";
                    comboBox5.Text = "";
                    comboBox6.Text = "";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Kutucuklarda boşluk bıraktınız veya verilerde hata var.");
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            label10.Text = "Saat: " + DateTime.Now.ToLongTimeString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
           
        }


        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (button4.BackColor == Color.LimeGreen)
            {
                saat = button4.Text;
                button4.BackColor = Color.Red;
                button3.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button14.Enabled = false;
                button15.Enabled = false;
                button16.Enabled = false;
                button17.Enabled = false;
                button18.Enabled = false;
                button19.Enabled = false;
                button20.Enabled = false;
            }
            else if (button4.BackColor == Color.Red)
            {
                saat = "";
                button4.BackColor = Color.LimeGreen;
                button3.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button14.Enabled = true;
                button15.Enabled = true;
                button16.Enabled = true;
                button17.Enabled = true;
                button18.Enabled = true;
                button19.Enabled = true;
                button20.Enabled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.BackColor == Color.LimeGreen)
            {
                saat = button5.Text;
                button5.BackColor = Color.Red;
                button3.Enabled = false;
                button4.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button14.Enabled = false;
                button15.Enabled = false;
                button16.Enabled = false;
                button17.Enabled = false;
                button18.Enabled = false;
                button19.Enabled = false;
                button20.Enabled = false;
            }
            else if (button5.BackColor == Color.Red)
            {
                saat = "";
                button5.BackColor = Color.LimeGreen;
                button4.Enabled = true;
                button3.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button14.Enabled = true;
                button15.Enabled = true;
                button16.Enabled = true;
                button17.Enabled = true;
                button18.Enabled = true;
                button19.Enabled = true;
                button20.Enabled = true;
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (button6.BackColor == Color.LimeGreen)
            {
                saat = button6.Text;
                button6.BackColor = Color.Red;
                button4.Enabled = false;
                button5.Enabled = false;
                button3.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button14.Enabled = false;
                button15.Enabled = false;
                button16.Enabled = false;
                button17.Enabled = false;
                button18.Enabled = false;
                button19.Enabled = false;
                button20.Enabled = false;
            }
            else if (button6.BackColor == Color.Red)
            {
                saat = "";
                button6.BackColor = Color.LimeGreen;
                button4.Enabled = true;
                button5.Enabled = true;
                button3.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button14.Enabled = true;
                button15.Enabled = true;
                button16.Enabled = true;
                button17.Enabled = true;
                button18.Enabled = true;
                button19.Enabled = true;
                button20.Enabled = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.BackColor == Color.LimeGreen)
            {
                saat = button7.Text;
                button7.BackColor = Color.Red;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button3.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button14.Enabled = false;
                button15.Enabled = false;
                button16.Enabled = false;
                button17.Enabled = false;
                button18.Enabled = false;
                button19.Enabled = false;
                button20.Enabled = false;
            }
            else if (button7.BackColor == Color.Red)
            {
                saat = "";
                button7.BackColor = Color.LimeGreen;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button3.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button14.Enabled = true;
                button15.Enabled = true;
                button16.Enabled = true;
                button17.Enabled = true;
                button18.Enabled = true;
                button19.Enabled = true;
                button20.Enabled = true;
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            if (button8.BackColor == Color.LimeGreen)
            {
                saat = button8.Text;
                button8.BackColor = Color.Red;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button3.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button14.Enabled = false;
                button15.Enabled = false;
                button16.Enabled = false;
                button17.Enabled = false;
                button18.Enabled = false;
                button19.Enabled = false;
                button20.Enabled = false;
            }
            else if (button8.BackColor == Color.Red)
            {
                saat = "";
                button8.BackColor = Color.LimeGreen;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button3.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button14.Enabled = true;
                button15.Enabled = true;
                button16.Enabled = true;
                button17.Enabled = true;
                button18.Enabled = true;
                button19.Enabled = true;
                button20.Enabled = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.BackColor == Color.LimeGreen)
            {
                saat = button9.Text;
                button9.BackColor = Color.Red;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button3.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button14.Enabled = false;
                button15.Enabled = false;
                button16.Enabled = false;
                button17.Enabled = false;
                button18.Enabled = false;
                button19.Enabled = false;
                button20.Enabled = false;
            }
            else if (button9.BackColor == Color.Red)
            {
                saat = "";
                button9.BackColor = Color.LimeGreen;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button3.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button14.Enabled = true;
                button15.Enabled = true;
                button16.Enabled = true;
                button17.Enabled = true;
                button18.Enabled = true;
                button19.Enabled = true;
                button20.Enabled = true;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (button10.BackColor == Color.LimeGreen)
            {
                saat = button10.Text;
                button10.BackColor = Color.Red;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button3.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button14.Enabled = false;
                button15.Enabled = false;
                button16.Enabled = false;
                button17.Enabled = false;
                button18.Enabled = false;
                button19.Enabled = false;
                button20.Enabled = false;
            }
            else if (button10.BackColor == Color.Red)
            {
                saat = "";
                button10.BackColor = Color.LimeGreen;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button3.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button14.Enabled = true;
                button15.Enabled = true;
                button16.Enabled = true;
                button17.Enabled = true;
                button18.Enabled = true;
                button19.Enabled = true;
                button20.Enabled = true;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (button11.BackColor == Color.LimeGreen)
            {
                saat = button11.Text;
                button11.BackColor = Color.Red;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
                button3.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button14.Enabled = false;
                button15.Enabled = false;
                button16.Enabled = false;
                button17.Enabled = false;
                button18.Enabled = false;
                button19.Enabled = false;
                button20.Enabled = false;
            }
            else if (button11.BackColor == Color.Red)
            {
                saat = "";
                button11.BackColor = Color.LimeGreen;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button3.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button14.Enabled = true;
                button15.Enabled = true;
                button16.Enabled = true;
                button17.Enabled = true;
                button18.Enabled = true;
                button19.Enabled = true;
                button20.Enabled = true;
            }
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            if (button12.BackColor == Color.LimeGreen)
            {
                saat = button12.Text;
                button12.BackColor = Color.Red;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;
                button3.Enabled = false;
                button13.Enabled = false;
                button14.Enabled = false;
                button15.Enabled = false;
                button16.Enabled = false;
                button17.Enabled = false;
                button18.Enabled = false;
                button19.Enabled = false;
                button20.Enabled = false;
            }
            else if (button12.BackColor == Color.Red)
            {
                saat = "";
                button12.BackColor = Color.LimeGreen;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button3.Enabled = true;
                button13.Enabled = true;
                button14.Enabled = true;
                button15.Enabled = true;
                button16.Enabled = true;
                button17.Enabled = true;
                button18.Enabled = true;
                button19.Enabled = true;
                button20.Enabled = true;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (button13.BackColor == Color.LimeGreen)
            {
                saat = button13.Text;
                button13.BackColor = Color.Red;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button3.Enabled = false;
                button14.Enabled = false;
                button15.Enabled = false;
                button16.Enabled = false;
                button17.Enabled = false;
                button18.Enabled = false;
                button19.Enabled = false;
                button20.Enabled = false;
            }
            else if (button13.BackColor == Color.Red)
            {
                saat = "";
                button13.BackColor = Color.LimeGreen;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button3.Enabled = true;
                button14.Enabled = true;
                button15.Enabled = true;
                button16.Enabled = true;
                button17.Enabled = true;
                button18.Enabled = true;
                button19.Enabled = true;
                button20.Enabled = true;
            }
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            if (button14.BackColor == Color.LimeGreen)
            {
                saat = button14.Text;
                button14.BackColor = Color.Red;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button3.Enabled = false;
                button15.Enabled = false;
                button16.Enabled = false;
                button17.Enabled = false;
                button18.Enabled = false;
                button19.Enabled = false;
                button20.Enabled = false;
            }
            else if (button14.BackColor == Color.Red)
            {
                saat = "";
                button14.BackColor = Color.LimeGreen;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button3.Enabled = true;
                button15.Enabled = true;
                button16.Enabled = true;
                button17.Enabled = true;
                button18.Enabled = true;
                button19.Enabled = true;
                button20.Enabled = true;
            }
        }

        public static string saat;

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.LimeGreen)
            {
                saat = button3.Text;
                button3.BackColor = Color.Red;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button14.Enabled = false;
                button15.Enabled = false;
                button16.Enabled = false;
                button17.Enabled = false;
                button18.Enabled = false;
                button19.Enabled = false;
                button20.Enabled = false;
            }
            else if (button3.BackColor == Color.Red)
            {
                saat = "";
                button3.BackColor = Color.LimeGreen;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button14.Enabled = true;
                button15.Enabled = true;
                button16.Enabled = true;
                button17.Enabled = true;
                button18.Enabled = true;
                button19.Enabled = true;
                button20.Enabled = true;
            }
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            if (button15.BackColor == Color.LimeGreen)
            {
                saat = button15.Text;
                button15.BackColor = Color.Red;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button14.Enabled = false;
                button3.Enabled = false;
                button16.Enabled = false;
                button17.Enabled = false;
                button18.Enabled = false;
                button19.Enabled = false;
                button20.Enabled = false;
            }
            else if (button15.BackColor == Color.Red)
            {
                saat = "";
                button15.BackColor = Color.LimeGreen;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button14.Enabled = true;
                button3.Enabled = true;
                button16.Enabled = true;
                button17.Enabled = true;
                button18.Enabled = true;
                button19.Enabled = true;
                button20.Enabled = true;
            }
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            if (button16.BackColor == Color.LimeGreen)
            {
                saat = button16.Text;
                button16.BackColor = Color.Red;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button14.Enabled = false;
                button15.Enabled = false;
                button3.Enabled = false;
                button17.Enabled = false;
                button18.Enabled = false;
                button19.Enabled = false;
                button20.Enabled = false;
            }
            else if (button16.BackColor == Color.Red)
            {
                saat = "";
                button16.BackColor = Color.LimeGreen;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button14.Enabled = true;
                button15.Enabled = true;
                button3.Enabled = true;
                button17.Enabled = true;
                button18.Enabled = true;
                button19.Enabled = true;
                button20.Enabled = true;
            }
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            if (button17.BackColor == Color.LimeGreen)
            {
                saat = button17.Text;
                button17.BackColor = Color.Red;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button14.Enabled = false;
                button15.Enabled = false;
                button16.Enabled = false;
                button3.Enabled = false;
                button18.Enabled = false;
                button19.Enabled = false;
                button20.Enabled = false;
            }
            else if (button17.BackColor == Color.Red)
            {
                saat = "";
                button17.BackColor = Color.LimeGreen;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button14.Enabled = true;
                button15.Enabled = true;
                button16.Enabled = true;
                button3.Enabled = true;
                button18.Enabled = true;
                button19.Enabled = true;
                button20.Enabled = true;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (button18.BackColor == Color.LimeGreen)
            {
                saat = button18.Text;
                button18.BackColor = Color.Red;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button14.Enabled = false;
                button15.Enabled = false;
                button16.Enabled = false;
                button3.Enabled = false;
                button17.Enabled = false;
                button19.Enabled = false;
                button20.Enabled = false;
            }
            else if (button18.BackColor == Color.Red)
            {
                saat = "";
                button18.BackColor = Color.LimeGreen;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button14.Enabled = true;
                button15.Enabled = true;
                button16.Enabled = true;
                button3.Enabled = true;
                button17.Enabled = true;
                button19.Enabled = true;
                button20.Enabled = true;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (button19.BackColor == Color.LimeGreen)
            {
                saat = button19.Text;
                button19.BackColor = Color.Red;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button14.Enabled = false;
                button15.Enabled = false;
                button16.Enabled = false;
                button3.Enabled = false;
                button18.Enabled = false;
                button17.Enabled = false;
                button20.Enabled = false;
            }
            else if (button19.BackColor == Color.Red)
            {
                saat = "";
                button19.BackColor = Color.LimeGreen;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button14.Enabled = true;
                button15.Enabled = true;
                button16.Enabled = true;
                button3.Enabled = true;
                button18.Enabled = true;
                button17.Enabled = true;
                button20.Enabled = true;
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (button20.BackColor == Color.LimeGreen)
            {
                saat = button20.Text;
                button20.BackColor = Color.Red;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button14.Enabled = false;
                button15.Enabled = false;
                button16.Enabled = false;
                button3.Enabled = false;
                button18.Enabled = false;
                button19.Enabled = false;
                button17.Enabled = false;
            }
            else if (button20.BackColor == Color.Red)
            {
                saat = "";
                button20.BackColor = Color.LimeGreen;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button14.Enabled = true;
                button15.Enabled = true;
                button16.Enabled = true;
                button3.Enabled = true;
                button18.Enabled = true;
                button19.Enabled = true;
                button17.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult mesaj = new DialogResult();
            mesaj = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "SİSTEM", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (mesaj == DialogResult.Yes)
            {
                Form1 giris = new Form1();
                giris.Show();
                this.Hide();
            }
        }
    }
}
