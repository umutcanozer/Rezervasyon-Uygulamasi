using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelRezervasyonUygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox12.Enabled = false;
            comboBox7.Items.Add("1000"); 
            comboBox7.Items.Add("1200");  
            comboBox7.Items.Add("1800");  
            comboBox7.Items.Add("2000");
            comboBox7.Enabled = false;
            dateTimePicker1.MaxDate = DateTime.Today.AddYears(2);
            dateTimePicker2.MaxDate = DateTime.Today.AddYears(2);
            textBox6.Enabled = false;
            numericUpDown1.Enabled = false;
            comboBox1.Enabled = false;
            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;
            listView1.Columns.Add("Kişi",100);
            listView1.Columns.Add("Cinsiyet",100);
            listView1.Columns.Add("Adres",100);
            listView1.Columns.Add("Telefon",100);
            listView1.Columns.Add("Oda No",100);
            listView1.Columns.Add("Giriş Tarihi",100);
            listView1.Columns.Add("Çıkış Tarihi",100);
            listView1.Columns.Add("K.Gün",100);
            listView1.Columns.Add("Ücret",100);
            listView1.Columns.Add("Ödeme Türü", 100);
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string Kisi = "", Cinsiyet = "", Adres = "", Telefon = "", OdaNo = "", GirisTarihi = "", CıkısTarihi = "", KGun = "", Ucret = "", OdemeTuru = "";
            Kisi = textBox1.Text + textBox2.Text;
            if (radioButton1.Checked == true)
                Cinsiyet = radioButton1.Text;
            else if (radioButton2.Checked == true)
                Cinsiyet = radioButton2.Text;
            Adres = textBox3.Text;
            Telefon = maskedTextBox1.Text;
            OdaNo = numericUpDown1.Value.ToString();
            GirisTarihi = dateTimePicker1.Text;
            CıkısTarihi = dateTimePicker2.Text;
            KGun = textBox6.Text;
            Ucret = textBox12.Text;
            OdemeTuru = comboBox2.Text;
            string[] bilgiler = { Kisi, Cinsiyet, Adres, Telefon, OdaNo, GirisTarihi, CıkısTarihi, KGun, Ucret, OdemeTuru };
            bool odakontrol = false;
            for(int i = 0;i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[4].Text == numericUpDown1.Value.ToString())
                {
                    odakontrol = true;
                    MessageBox.Show(numericUpDown1.Value.ToString() + ". Oda dolu. Lütfen başka bir oda seçiniz.");
                }
            }
            if (odakontrol == false)
            {
                ListViewItem lst = new ListViewItem(bilgiler);
                if (Kisi != "" && Cinsiyet != "" && Adres != "" && Telefon != "" && OdaNo != "" && GirisTarihi != "" && CıkısTarihi != "" && KGun != "" && Ucret != "" && OdemeTuru != "")
                {
                    listView1.Items.Add(lst);
                }
                else
                    MessageBox.Show("Kayıt bilgilerinde eksiklik var.");
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedPersonCount = Convert.ToInt32(comboBox3.SelectedItem);         
            comboBox1.Enabled = false;
            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;

            
            if (selectedPersonCount == 4)
            {
                comboBox1.Enabled = true;
            }
            else if (selectedPersonCount == 3)
            {
                comboBox4.Enabled = true;
            }
            else if (selectedPersonCount == 2)
            {
                comboBox5.Enabled = true;
            }
            else if (selectedPersonCount == 1)
            {
                comboBox6.Enabled = true;
            }
            
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRoom = comboBox1.SelectedItem.ToString();
            int roomNumber;
            if (int.TryParse(selectedRoom, out roomNumber))
            {
                numericUpDown1.Value = roomNumber;
                comboBox7.SelectedIndex = 0;
            }
            
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRoom = comboBox4.SelectedItem.ToString();
            int roomNumber;
            if(int.TryParse(selectedRoom, out roomNumber))
            {
                numericUpDown1.Value = roomNumber;
                comboBox7.SelectedIndex = 1;
            }
            
            
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRoom = comboBox5.SelectedItem.ToString();
            int roomNumber;
            if (int.TryParse(selectedRoom, out roomNumber))
            {
                numericUpDown1.Value = roomNumber;
                comboBox7.SelectedIndex = 2; 
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRoom = comboBox6.SelectedItem.ToString();
            int roomNumber;
            if (int.TryParse(selectedRoom, out roomNumber))
            {
                numericUpDown1.Value = roomNumber;
                comboBox7.SelectedIndex = 3; 
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

            TimeSpan difference = endDate - startDate;
            int dayDifference = difference.Days;

            textBox6.Text = dayDifference.ToString();

            int selectedValue = Convert.ToInt32(comboBox7.SelectedItem);
            int result = dayDifference * selectedValue;

            textBox12.Text = result.ToString();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedRow = listView1.SelectedItems[0];
                listView1.Items.Remove(selectedRow); 
            }
        }
    }
}
