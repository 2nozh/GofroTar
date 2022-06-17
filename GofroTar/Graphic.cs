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
        GraphicsPath plane = new GraphicsPath();
        GraphicsPath gp = new GraphicsPath();
        GraphicsPath gp3 = new GraphicsPath();
        int step = 10;
        Boolean ready = false;
        public Graphic()
        {
            InitializeComponent();
        }

        private void Graphic_Load(object sender, EventArgs e)
        {

            g = CreateGraphics();

            plane.AddRectangle(new Rectangle(9, 9, 501, 501));
            gp.AddRectangle(new Rectangle(10, 10, 100, 200));
            gp3 = DrawNext();
            
        }

        private void Graphic_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawPath(new Pen(Color.Coral), plane);
            e.Graphics.DrawPath(new Pen(Color.Black), gp);
            e.Graphics.DrawPath(new Pen(Color.BlueViolet), gp3);



            
        }

        private GraphicsPath DrawNext(int a = 50,int b = 100)
        {
            GraphicsPath gp2 = new GraphicsPath();
            gp2.AddRectangle(new Rectangle(FindPoint(new Point(10,10)), new Size(50,100)));
            return gp2;
        }

        private Point FindPoint(Point testPoint)
        {
            Region r1 = new Region(gp);
            GraphicsPath testgp = new GraphicsPath();
            testgp.AddRectangle(new Rectangle(testPoint, new Size(50, 100)));
            Region r2 = new Region(testgp);
            r1.Intersect(r2);
            if (!r1.IsEmpty(g))
            {
                textBox1.Text = "included";
                return FindPoint(new Point(testPoint.X + step, testPoint.Y));               
            }
            else
            {
                textBox1.Text = "awesome";
                return testPoint;
       
            }

            
        }



    }
}
