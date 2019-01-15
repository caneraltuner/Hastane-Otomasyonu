using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Firebase Elementleri
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace otomasyon
{
    public partial class PersonelForm : Form
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

        public PersonelForm()
        {
            InitializeComponent();
        }

        private void PersonelForm_Load(object sender, EventArgs e)
        {
            label9.Text = Form1.doktoradi;
            //yukarıda oluşturduğumuz client'i config'e bağlıyoruz
            client = new FireSharp.FirebaseClient(config);
            //Bu döngüyle de veritabanımız ile bağlantı kuruluyor mu onu kontrol ediyoruz
            if (client != null)
            {
                DialogResult mesaj = new DialogResult();
                mesaj = MessageBox.Show("Başarıyla Giriş Yapıldı!", "Veritabanı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "" || textBox5.Text != "" || comboBox2.Text != "")
            {
                //Projemizde oluşturduğumuz Data.cs dosyasını buraya tanımlıyoruz çünkü buradaki değişkenlere kutularımızdan değer atayacağız
                var data = new Data
                {
                    doktorad = label9.Text, //doktorad değişkenimizin değerini combobox1'in seçilen değerini atayacağız
                    hastaad = textBox2.Text, //hastaad değişkenimizin değerini textbox2'den alıyoruz
                    hastatcno = textBox3.Text, //hastatcno değişkenimizin değerini textbox3'den alıyoruz
                    hastaligi = comboBox2.SelectedItem.ToString(), //hastaligi değişkenimizin değerini combobox2'nin seçilen değerinden alıyoruz
                    ilaclar = textBox5.Text, //ilaclar değişkenimizin değerini textbox5'ten alıyoruz
                    eknot = textBox1.Text, //eknot değişkenimizin değerini textbox1'den alıyoruz
                    tarih = dateTimePicker1.Text //datetimepicker'ın text'i alınıyor
                };
                //Bu değerleri Firebase'e eklemeden önce datagridview'a da ekliyoruz
                dataGridView1.Rows.Add(label9.Text, textBox2.Text, textBox3.Text, comboBox2.SelectedItem.ToString(), textBox5.Text, textBox1.Text, dateTimePicker1.Text);


                SetResponse response = await client.SetTaskAsync("Hastalar/" + textBox3.Text, data);
                Data result = response.ResultAs<Data>();
                //Veriler eklendikten sonra kutularımızdaki değerleri sıfırlıyoruz
                comboBox2.Text = "";
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox5.Clear();
                //Mesajımızı personele gösteriyoruz
                MessageBox.Show("Hasta Eklendi: " + result.hastatcno, "SİSTEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen boş değer bırakmayınız!", "SİSTEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //textbox4 boş değil ise işlemlerimizi yapıyoruz
                if (textBox4.Text != "")
                {
                    //Yeni bir response yaratıyoruz buna Hastalar içindeki TCNO'yu textbox4'ten alacağını tanımlıyoruz
                    FirebaseResponse response = await client.GetTaskAsync("Hastalar/" + textBox4.Text);
                    //Data.cs'yi obj adında değişkene tanımlıyoruz
                    Data obj = response.ResultAs<Data>();
                    //obj değişkenine bağlı değerleri dataGridView'a ekliyoruz
                    dataGridView1.Rows.Add(obj.doktorad, obj.hastaad, obj.hastatcno, obj.hastaligi, obj.ilaclar, obj.eknot, obj.tarih);
                }
                else
                {
                    MessageBox.Show("Lütfen bir TCNO giriniz", "SİSTEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Girdiğiniz TCNO ya hatalı ya da veri tabanında bulunmuyor", "SİSTEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)       
        {
            DialogResult tmzle=new DialogResult();
            tmzle = MessageBox.Show("Hasta kayıtlarını silmek istediğinizden emin misiniz", "SİSTEM", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tmzle == DialogResult.Yes)
            {
                //datagridview'daki satırları temizliyoruz
                dataGridView1.Rows.Clear();
                //daha sonra da datagridview'ımızı yeniliyoruz
                dataGridView1.Refresh();
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            try //try catch ile uygulamanın çökmesini engelliyoruz
            {
                //Textbox boş değilse ve textbox'taki veri 11 haneye eşitse verimizi siliyor
                if (textBox4.Text != "" && textBox4.TextLength == 11 && dataGridView1.SelectedRows.Count > 0)
                {
                    /*DeleteTaskAsync fonksiyonunu kullanmak için response yaratıyoruz daha sonra veri tabanımız içinde açtığımız
                    hastalar klasörünü tanımlıyoruz textBox4.Text dememizin sebebi ise Hastalar klasörünün içindeki tcno yu textbox4'e tanımlamamız*/
                    FirebaseResponse response = await client.DeleteTaskAsync("Hastalar/" + textBox4.Text);
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        dataGridView1.Rows.RemoveAt(row.Index);
                    }
                    //Silinen verimizi personele gösteriyoruz
                    MessageBox.Show("Şu TCNO'ya sahip veri silindi: " + textBox4.Text, "SİSTEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("lütfen tablodan veri seçiniz", "SİSTEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else //Bu şartlar sağlanamıyorsa hata mesajı gösteriyor
                {
                    MessageBox.Show("TCNO'da hata var", "SİSTEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("TCNO'da hata var yada sistemde böyle bir TCNO yok...", "SİSTEM", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            DialogResult cks = new DialogResult();
            cks = MessageBox.Show("Çıkış Yapmak İstediğinizden Emin Misiniz?", "SİSTEM", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cks == DialogResult.Yes)
            {
                Form1 giris = new Form1();
                this.Hide();
                giris.Show();
            }
        }
    }
}
