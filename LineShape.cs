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
    class LineShape:Shape
    {
        Point startPosition;
        Point lastPosition;
        public override PictureBox DrawShape(PictureBox pic, Point point)
        {
            return pic;
        }
    }
}
