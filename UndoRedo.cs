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
    class UndoRedo
    {
        Stack<PictureBox> undoStack = new Stack<PictureBox>();
        Stack<PictureBox> redoStack = new Stack<PictureBox>();
        //int maxStackSize = 1;
        public void PushInStack(PictureBox pic)
        {
            undoStack.Push(pic);
        }
        public PictureBox DoUndo(PictureBox pic)
        {
            if (undoStack.Count > 0)
            {
                PictureBox pic1 = undoStack.Pop();
                Graphics g = Graphics.FromImage(pic1.Image);
                //g.Clear(Color.White);
                //PictureBox pic1 = undoStack.Pop();
                redoStack.Push(pic1);
                pic.Image = pic1.Image;
                g.Save();
            }

            
           // pic.Image = pic.Image;
            
            pic.Refresh();
            return pic;
        }

    }
}
