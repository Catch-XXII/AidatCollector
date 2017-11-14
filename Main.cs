using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AidatCollector
{
    public partial class Main : Form
    {
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }


        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Today.ToShortDateString();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Income().Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Expense().Show();
        }
    }
}
