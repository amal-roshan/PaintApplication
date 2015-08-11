using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Paint3;

namespace Paint3
{
    class CropImage
    {
        Point firstLocation;
        Point lastLocation;
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
        public Image CropBitmap(PictureBox pic, int cropX, int cropY, int cropWidth, int cropHeight)
        {
            Bitmap bmp = new Bitmap(pic.Width, pic.Height);
            bmp = (Bitmap)pic.Image;
            Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
            Bitmap cropped = bmp.Clone(rect, bmp.PixelFormat);
            pic.Image = (Image)cropped;
            return pic.Image;
        }
    }
}
