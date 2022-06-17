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
            richTextBox1.Text = Optimize.DoOptimize();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = Optimize.DoOptimize();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
