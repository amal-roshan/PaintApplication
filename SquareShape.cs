using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing.Drawing2D;
using System.Windows.Shapes;

namespace Paint3
{
    class SquareShape : Shape
    {
        Point firstLocation;
        Point lastLocation;
        Pen myPen;
        public Point FirstLocation
        {
            get
            {
                return firstLocation;
            }
            set
            {
                firstLocation = value;
            }
        }

        public Point LastLocation
        {
            get
            {
                return lastLocation;
            }
            set
            {
                lastLocation = value;
            }
        }
        public void GetPen(Pen pen)
        {
            myPen = pen;
        }
        public override PictureBox DrawShape(PictureBox pic, Point point)
        {
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(Math.Min(point.X, firstLocation.X), Math.Min(point.Y, firstLocation.Y), Math.Abs(point.X - firstLocation.X), Math.Abs(point.X - firstLocation.X));
            Graphics g = Graphics.FromImage(pic.Image);
            //g.DrawRectangle(myPen, firstLocation.X,firstLocation.Y, Math.Abs(point.X - firstLocation.X),Math.Abs(point.Y - firstLocation.Y));
            g = pic.CreateGraphics();
            g.DrawRectangle(myPen, rect);
            pic.Image = pic.Image;
            return pic;
        }
    }
}
