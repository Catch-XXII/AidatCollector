using AidatCollector.Sınıflar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AidatCollector
{
    public partial class Income : Form
    {
        // esc key press event 
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        public Income()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // empty record control
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Zorunlu alanları doldurun");
                return;
            }

            UserIncome i1 = new UserIncome()
            {
                AdSoyad = textBox1.Text,
                DaireNo = textBox3.Text,
                Tutar = textBox2.Text,
                Tarih = dateTimePicker1.Value
            };
            string path = "income.txt";
            StringBuilder sb = new StringBuilder();
            sb.Append(i1.AdSoyad);
            sb.Append(", ");
            sb.Append(i1.DaireNo);
            sb.Append(", ");
            sb.Append(i1.Tutar);
            sb.Append(", ");
            sb.Append(i1.Tarih);
            sb.Append(Environment.NewLine);

            if (File.Exists(path))
            {
                File.AppendAllText(path, sb.ToString());
            }
            else
            {
                // .Close() method to avoid having file access problem
                File.Create(path).Close();
                File.AppendAllText(path, sb.ToString());
            }
            label6.Text = "Kaydedildi.";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label6.Text = "Gösteriliyor";

            if (!File.Exists("income.txt"))
            {
                MessageBox.Show("Herhangi bir kayıt bulunamadı. Önce bir kayıt oluşturun");
                return;
            }

            // avoid each time same record problem.
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            string[] satirlar = File.ReadAllLines("income.txt");

            foreach (string satir in satirlar)
            {
                string[] bolunmus = satir.Split(',');
                string s1 = bolunmus[0];
                string s2 = bolunmus[1];
                string s3 = bolunmus[2];
                string s4 = bolunmus[3];
                listBox1.Items.Add(s1);
                listBox2.Items.Add(s2);
                listBox3.Items.Add(s3);
                listBox4.Items.Add(s4);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            label6.Text = "Temizlendi";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.SelectedIndex = listBox1.SelectedIndex;
            listBox3.SelectedIndex = listBox1.SelectedIndex;
            listBox4.SelectedIndex = listBox1.SelectedIndex;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = listBox2.SelectedIndex;
            listBox3.SelectedIndex = listBox2.SelectedIndex;
            listBox4.SelectedIndex = listBox2.SelectedIndex;
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.SelectedIndex = listBox3.SelectedIndex;
            listBox1.SelectedIndex = listBox3.SelectedIndex;
            listBox4.SelectedIndex = listBox3.SelectedIndex;
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.SelectedIndex = listBox4.SelectedIndex;
            listBox3.SelectedIndex = listBox4.SelectedIndex;
            listBox1.SelectedIndex = listBox4.SelectedIndex;
        }
    }
}
