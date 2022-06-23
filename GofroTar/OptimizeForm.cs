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
    public partial class OptimizeForm : MaterialForm
    {
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        public OptimizeForm()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Indigo500, MaterialSkin.Primary.Indigo700, MaterialSkin.Primary.Indigo100, MaterialSkin.Accent.Pink200, MaterialSkin.TextShade.WHITE);

        }

        private void OptimizeForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = DBConnection.orders.Count.ToString();
            textBox3.Text = "";
            foreach (Order order in DBConnection.orders)
            {
                int count=0;
                foreach(int boxCount in order.count)
                {
                    count = count + boxCount;
                }
                dataGridView1.Rows.Add(true, order.number,count);
            }
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            DBConnection.getPlan();
            List<Order> orders =new List<Order>();   
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                if ((bool)dataGridView1[0, i].Value)
                {
                    foreach (Order o in DBConnection.orders)
                    {
                        if (o.number == dataGridView1[1, i].Value.ToString())
                        {
                            orders.Add(o);
                            break;
                        }
                    }

                } 
            }

            PlanResult pr = Optimize.DoSimplex(orders);
            ResultsForm res = new ResultsForm(pr);
            res.Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void materialTabSelector1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            List<Order> orders = new List<Order>();
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                if ((bool)dataGridView1[0, i].Value)
                {
                    foreach (Order o in DBConnection.orders)
                    {
                        if (o.number == dataGridView1[1, i].Value.ToString())
                        {
                            orders.Add(o);
                            break;
                        }
                    }

                }
            }
            textBox1.Text = orders.Count.ToString();
        }
    }
}
