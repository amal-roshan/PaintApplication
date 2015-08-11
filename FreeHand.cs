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

namespace Paint3
{
    class FreeHand:Shape
    {
        Brush myBrush;
        public void GetBrush(Brush brush)
        {
            myBrush = brush;
        }
        public override PictureBox DrawShape(PictureBox pic, Point point)
        {
            Graphics g = Graphics.FromImage(pic.Image);
            g.FillRectangle(myBrush, point.X, point.Y, 5, 5);
            pic.Image = pic.Image;
            return pic;
        }
    }
}
