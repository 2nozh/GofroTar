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
        GraphicsPath gp3 = new GraphicsPath();
        GraphicsPath gp2 = new GraphicsPath();




        GraphicsPath plane = new GraphicsPath();
        GraphicsPath busySpace = new GraphicsPath();
        GraphicsPath boxGP = new GraphicsPath();
        Canvas canvas;
        Point startPoint = new Point(10,10);

        int step = 1;
        int scale = 20;
        Boolean ready = false;
        public Graphic(Canvas canvas)
        {
            this.canvas = canvas;
            InitializeComponent();
        }

        private void Graphic_Load(object sender, EventArgs e)
        {
                plane.AddRectangle(new Rectangle(9, 9, (canvas.width + 2) * scale, (canvas.length + 2) * scale));
            g = CreateGraphics();/*
            plane.AddRectangle(new Rectangle(9, 9, 501, 501));

           
            gp.AddRectangle(new Rectangle(10, 10, 100, 200));
            gp3 = DrawNext();*/
            
        }

        private void Graphic_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawPath(new Pen(Color.Coral), plane);
            e.Graphics.DrawPath(new Pen(Color.Black), busySpace);         
            //e.Graphics.DrawPath(new Pen(Color.AliceBlue), boxGP);
        }

        private Point FindPoint(Point testPoint,BoxMapped box, GraphicsPath busySpace)
        {
            if (testPoint.X == canvas.width*scale)
            {
                return new Point(0, 0);
            }
            boxGP.AddRectangle(new Rectangle(testPoint, new Size(box.width*scale+1, box.length*scale+1)));
            Region boxRegion = new Region(boxGP);
            Region busyRegion = new Region(busySpace);
            boxRegion.Intersect(busyRegion);
            if (!boxRegion.IsEmpty(g))
            {
                textBox1.Text = "included";
                return FindPoint(new Point(testPoint.X + step*scale, testPoint.Y),box,plane);               
            }
            else
            {
                textBox1.Text = "awesome";
                startPoint.X++;
                return testPoint;
            }

            
        }


        public bool TryFitting(BoxMapped box)
        {

            g = CreateGraphics();
            startPoint = FindPoint(startPoint, box, busySpace);
            if (startPoint.X == 0)
            {
                return false;
            }
            else
            {
                busySpace.AddRectangle(new Rectangle(startPoint, new Size(box.width*scale, box.length*scale)));
                return true;
            }


            
        }



    }
}
