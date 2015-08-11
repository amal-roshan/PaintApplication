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
    public static class SaveFile
    {
        public static void SaveImageCapture(System.Drawing.Image image)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.FileName = "Image";
            s.DefaultExt = ".Jpg";
            s.Filter = "Image (.jpg)|*.jpg|Bitmap files (*.bmp)|*.bmp|GIF files (*.gif)|*.gif|All files (*.*)|*.*";
            s.InitialDirectory = (@"C:\Users\Amal\Desktop");
            s.RestoreDirectory = true;
            if (s.ShowDialog() == DialogResult.OK)
            {
                string filename = s.FileName;
                using (System.IO.FileStream fstream = new System.IO.FileStream(filename, System.IO.FileMode.Create))
                {
                    image.Save(fstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    fstream.Close();
                }
            }
        }
    }
}
