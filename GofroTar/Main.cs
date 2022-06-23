using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GofroTar
{
    public partial class Main : MaterialForm
    {
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        public Main()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Indigo500, MaterialSkin.Primary.Indigo700, MaterialSkin.Primary.Indigo100, MaterialSkin.Accent.Pink200,MaterialSkin.TextShade.WHITE);


        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm();
            orderForm.Show();
        }

        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            OptimizeForm optimizeForm = new OptimizeForm();
            optimizeForm.Show();
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            ShowOrdersForm show = new ShowOrdersForm();
            show.Show();
        }
    }
}
