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

namespace Paint3
{
    class ZoomItem
    {
        public PictureBox ZoomIn(PictureBox pic)
        {
            if (pic != null)
            {
                Graphics g = Graphics.FromImage(pic.Image);
                int zoom = 50;
                int newwidth = Convert.ToInt32(pic.Width + zoom);
                int newheight = Convert.ToInt32(pic.Height + zoom);
                //Rectangle r = new Rectangle(this.AutoScrollPosition.X, this.AutoScrollPosition.Y, newwidth, newheight);
                Rectangle r = new Rectangle(4, 10, newwidth, newheight);
                //myCanvas.Invalidate();
                pic.Refresh();
                g.DrawImage(pic.Image, r);
                pic.Image = pic.Image;
            }
            return pic;
        }

        public PictureBox ZoomOut(PictureBox pic)
        {
            if (pic != null)
            {
                Graphics g = Graphics.FromImage(pic.Image);
                int zoom = 50;
                int newwidth = Convert.ToInt32(pic.Width - zoom);
                int newheight = Convert.ToInt32(pic.Height-+ zoom);
                //Rectangle r = new Rectangle(this.AutoScrollPosition.X, this.AutoScrollPosition.Y, newwidth, newheight);
                Rectangle r = new Rectangle(4, 10, newwidth, newheight);
                //myCanvas.Invalidate();
                pic.Refresh();
                g.DrawImage(pic.Image, r);
                pic.Image = pic.Image;
            }
            return pic;
        }
    }
}
