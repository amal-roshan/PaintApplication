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
    class ColorPickerTool
    {
        public Color GetPixelColor(PictureBox pic, Point position)
        {
            Bitmap myBitmap = new Bitmap(pic.Image);
            Color pixelColor = myBitmap.GetPixel(position.X, position.Y);
            return pixelColor;
        }
    }
}
