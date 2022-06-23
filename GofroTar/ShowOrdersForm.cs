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
    public partial class ShowOrdersForm : MaterialForm
    {
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        public ShowOrdersForm()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Indigo500, MaterialSkin.Primary.Indigo700, MaterialSkin.Primary.Indigo100, MaterialSkin.Accent.Pink200, MaterialSkin.TextShade.WHITE);

        }

        private void ShowOrdersForm_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add("12", DateTime.Now, DateTime.Now, "dkhg\ndjndfjl\n");
            dataGridView1.Rows.Add("13", DateTime.Now, DateTime.Now, "dkhg\ndjndfjl\n");
            foreach(Order order in DBConnection.orders)
            {
                string content = "";
                for (int i = 0; i < order.boxes.Count; i++)
                {
                    content = content + "тип тары:" +order.boxes[i].name + ", \n";
                    content = content + "количество:" + order.count[i].ToString() + "; \n";
                }
                dataGridView1.Rows.Add(order.number,order.dateCreated, order.endDate, content);
            }
            
        }
    }
}
