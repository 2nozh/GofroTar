using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace GofroTar
{
    public partial class Graphic : Form
    {
        Graphics g; 
        GraphicsPath gp = new GraphicsPath();
        GraphicsPath gp1 = new GraphicsPath();

        public Graphic()
        {
            InitializeComponent();
        }

        private void Graphic_Load(object sender, EventArgs e)
        {
            
            g = CreateGraphics();
           
            gp.AddRectangle(new Rectangle(10, 10, 30, 50));
            gp.AddRectangle(new Rectangle(100, 10, 50, 70));
            gp1.AddRectangle(new Rectangle(50, 10, 10, 70));
            


        }

        private void Graphic_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawPath(new Pen(Color.Black), gp);
            e.Graphics.DrawPath(new Pen(Color.Blue), gp1);

            foreach(PointF p in gp1.PathData.Points)
            {
                if (gp.IsVisible(p)) textBox1.Text = "included";
            }
        }
    }
}
