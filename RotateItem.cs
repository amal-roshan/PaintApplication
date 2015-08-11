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
    class RotateItem
    {
        public PictureBox RotateClockwise(PictureBox pic)
        {
            if (pic.Image != null)
            {
                pic.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
                pic.Image = pic.Image;
            }
            return pic;
        }
        public PictureBox RotateAntiClockwise(PictureBox pic)
        {
            if (pic.Image != null)
            {
               pic.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
               pic.Image = pic.Image;
            }
            return pic;
        }
    }
}
