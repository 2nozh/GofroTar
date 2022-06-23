using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GofroTar
{
    public partial class OrderForm : MaterialForm
    {
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        public OrderForm()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Indigo500, MaterialSkin.Primary.Indigo700, MaterialSkin.Primary.Indigo100, MaterialSkin.Accent.Pink200, MaterialSkin.TextShade.WHITE);

        }

        private void OrderForm_Load(object sender, EventArgs e)
        {

        }

        private void materialTabSelector1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            DBConnection.AddOrder(textBox1.Text, Convert.ToDateTime(dateTimePicker1.Text), Convert.ToDateTime(dateTimePicker2.Text));
            List<BoxMapped> boxes = new List<BoxMapped>();
            List<int> count = new List<int>();
            boxes.Add(new BoxMapped("f1"));
            count.Add(((int)numericUpDown1.Value));
            boxes.Add(new BoxMapped("f2"));
            count.Add(((int)numericUpDown3.Value));
            boxes.Add(new BoxMapped("f3"));
            count.Add(((int)numericUpDown5.Value));

            DBConnection.fillOrder(textBox1.Text, boxes,count);
            MessageBox.Show("Успешно","Уведомление",MessageBoxButtons.OK);
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            flowLayoutPanel1.Controls.Add(vScrollBar1);
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
