using AidatCollector.Sınıflar;
using System;
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
    public partial class Expense : Form
    {
        protected override bool ProcessDialogKey(Keys keyData)
        {
            // esc key press event 
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        public Expense()
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

            UserExpense e1 = new UserExpense()
            {
                AdSoyad = textBox1.Text,
                GiderTipi = textBox3.Text,
                Tutar = textBox2.Text,
                Tarih = dateTimePicker1.Value
            };

            string path1 = "expense.txt";
            StringBuilder sb1 = new StringBuilder();
            sb1.Append(e1.AdSoyad);
            sb1.Append(", ");
            sb1.Append(e1.GiderTipi);
            sb1.Append(", ");
            sb1.Append(e1.Tutar);
            sb1.Append(", ");
            sb1.Append(e1.Tarih);
            sb1.Append(Environment.NewLine);

            if (File.Exists(path1))
            {
                File.AppendAllText(path1, sb1.ToString());
            }
            else
            {
                // .Close() method to avoid having file access problem
                File.Create(path1).Close();
                File.AppendAllText(path1, sb1.ToString());
            }
            label6.Text = "Kaydedildi.";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            listBox7.Items.Clear();
            listBox8.Items.Clear();
            label6.Text = "Temizlendi";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label6.Text = "Gösteriliyor";

            if (!File.Exists("expense.txt"))
            {
                MessageBox.Show("Herhangi bir kayıt bulunamadı. Önce bir kayıt oluşturun");
                return;
            }
            // avoid showing same record problem.
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            listBox7.Items.Clear();
            listBox8.Items.Clear();

            string[] satirlar = File.ReadAllLines("expense.txt");
            foreach (string satir in satirlar)
            {
                string[] bolunmus = satir.Split(',');
                string s1 = bolunmus[0];
                string s2 = bolunmus[1];
                string s3 = bolunmus[2];
                string s4 = bolunmus[3];
                listBox5.Items.Add(s1);
                listBox6.Items.Add(s2);
                listBox7.Items.Add(s3);
                listBox8.Items.Add(s4);

            }
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox6.SelectedIndex = listBox5.SelectedIndex;
            listBox7.SelectedIndex = listBox5.SelectedIndex;
            listBox8.SelectedIndex = listBox5.SelectedIndex;
        }

        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox5.SelectedIndex = listBox6.SelectedIndex;
            listBox7.SelectedIndex = listBox6.SelectedIndex;
            listBox8.SelectedIndex = listBox6.SelectedIndex;
        }

        private void listBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox6.SelectedIndex = listBox7.SelectedIndex;
            listBox5.SelectedIndex = listBox7.SelectedIndex;
            listBox8.SelectedIndex = listBox7.SelectedIndex;
        }

        private void listBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox6.SelectedIndex = listBox8.SelectedIndex;
            listBox7.SelectedIndex = listBox8.SelectedIndex;
            listBox5.SelectedIndex = listBox8.SelectedIndex;
        }
    }
}
