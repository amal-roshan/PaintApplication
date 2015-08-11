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
    class TextTool
    {
        public PictureBox AddText(PictureBox pic, Point point, string msg,Color myColor)
        {
            Graphics g = Graphics.FromImage(pic.Image);
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(myColor);
            g.DrawString(msg, drawFont, drawBrush, point);
            pic.Image = pic.Image;
            return pic;
        }
    }
}
