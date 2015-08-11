using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Controls;
using Paint3;

namespace Paint3
{
    public partial class PaintApp : Form
    {
        bool paint = false;
        bool isErase = false;
        bool drawRectangleActive = false;
        bool drawRectangle = false;
        bool drawCircleActive = false;
        bool drawCircle = false;
        bool drawSquare = false;
        bool drawSquareActive = false;
        bool drawLines = false;
        bool drawLineActive = false;
        bool isColorPickerActive = false;
        bool isCropActive = false;
        bool crop = false;
        bool clearScreen = false;
        bool undoClicked = false;
        bool writeText = false;
        bool writeTextActive = false;
        Color myColor = Color.Black;
        int penSize = 3;
        string msg;
        Point txtBoxLocation;
        FreeHand freeHand = new FreeHand();
        EraseItem eraseItem = new EraseItem();
        RectangleShape rectangle = new RectangleShape();
        CircleShape circle = new CircleShape();
        SquareShape square = new SquareShape();
        RotateItem rotater = new RotateItem();
        OpenFile open = new OpenFile();
        ZoomItem zoomItem = new ZoomItem(); 
        ColorPickerTool colorPickerTool = new ColorPickerTool();
        UndoRedo undoRedo = new UndoRedo();
        CropImage cropImage = new CropImage();
        Line line = new Line();
        TextTool textTool = new TextTool();
        public PaintApp()
        {
            InitializeComponent();
            myCanvas.Image = new Bitmap(myCanvas.Width, myCanvas.Height);
            this.textBox.Visible = false;
            Graphics g = Graphics.FromImage(myCanvas.Image);
            g.Clear(Color.White);
        }

        private void myCanvas_MouseDown(object sender, MouseEventArgs e)
        {  
            if (isErase || drawRectangleActive || drawCircleActive || isColorPickerActive || drawSquareActive ||
                isCropActive || drawLineActive || writeTextActive)
                paint = false;
            else
                paint = true;
            if (drawRectangleActive)
            {
                drawRectangle = true;
                rectangle.FirstLocation = e.Location;
            }
            if (drawCircleActive)
            {
                drawCircle = true;
                circle.FirstLocation = e.Location;
            }
            if (isColorPickerActive)
            {
                myColor = colorPickerTool.GetPixelColor(myCanvas, e.Location);
            }
            if (drawSquareActive)
            {
                drawSquare = true;
                square.FirstLocation = e.Location;
            }
            if (isCropActive)
            {
                crop = true;
                cropImage.FirstLocation = e.Location;
            }
            if (drawLineActive)
            {
                drawLines = true;
                line.FirstLocation = e.Location;
            }
            if (writeTextActive && !writeText)
            {
                writeText = true;
                this.textBox.Visible = true;
                this.textBox.Enabled = true;
                txtBoxLocation = e.Location;
            }
            if (writeText)
            {
                this.textBox.Enabled = false;
                this.textBox.Visible = false;
                myCanvas = textTool.AddText(myCanvas, txtBoxLocation, msg, myColor);
                writeText = false;
                writeTextActive = false;
                this.textBox.Clear();
            }
            undoRedo.PushInStack(myCanvas);
        }

        private void myCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (paint)
            {
                Brush myBrush = new SolidBrush(myColor);
                freeHand.GetBrush(myBrush);
                myCanvas = freeHand.DrawShape(myCanvas, e.Location);
            }
            if (isErase && e.Button == MouseButtons.Left)
            {
                myCanvas = eraseItem.DrawShape(myCanvas, e.Location);
            }
            if(drawRectangle)
            {
                this.Refresh();
                Pen myPen = new Pen(myColor, penSize);
                rectangle.GetPen(myPen);
                rectangle.LastLocation = e.Location;
                myCanvas = rectangle.DrawShape(myCanvas, e.Location);
            }
            if (drawCircle)
            {
                this.Refresh();
                Pen myPen = new Pen(myColor, penSize);
                circle.GetPen(myPen);
                circle.LastLocation = e.Location;
                myCanvas = circle.DrawShape(myCanvas, e.Location);
            }
            if (drawSquare)
            {
                this.Refresh();
                Pen myPen = new Pen(myColor, penSize);
                square.GetPen(myPen);
                square.LastLocation = e.Location;
                myCanvas = square.DrawShape(myCanvas, e.Location);
            }
            if (crop)
            {
                this.Refresh();
                float[] dashValues = { 4, 2 };
                Pen myPen1 = new Pen(myColor, penSize);
                myPen1.DashPattern = dashValues;
                rectangle.GetPen(myPen1);
                rectangle.FirstLocation = cropImage.FirstLocation;
                rectangle.LastLocation = e.Location;
                myCanvas = rectangle.DrawShape(myCanvas, e.Location);
            }
            if (writeTextActive && !writeText)
            {
                this.textBox.Location = txtBoxLocation;
                this.textBox.Enabled = true;
                this.textBox.Visible = true;
                msg = this.textBox.Text;
            }
            if (drawLines)
            {
                this.Refresh();
                Pen myPen = new Pen(myColor, penSize);
                line.GetPen(myPen);
                line.LastLocation = e.Location;
                myCanvas = line.DrawShape(myCanvas, e.Location);
            }
            string str = "X, Y = " + e.Location.X.ToString() + " , " + e.Location.Y.ToString();
            toolStripStatusLabel1.Text = str;

        }

        private void myCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;
            if (drawRectangle)
            {
                Pen myPen = new Pen(myColor, penSize);
                Graphics g = Graphics.FromImage(myCanvas.Image);
                g.DrawRectangle(myPen, rectangle.FirstLocation.X,rectangle.FirstLocation.Y,
                    Math.Abs(rectangle.FirstLocation.X - e.X),Math.Abs(rectangle.FirstLocation.Y- e.Y));
                myCanvas.Image = myCanvas.Image;
                drawRectangle = false;
                drawRectangleActive = false;
                this.Cursor = Cursors.Arrow;
                
            }
            if (drawCircle)
            {
                Pen myPen = new Pen(myColor, penSize);
                circle.LastLocation = e.Location;
                Graphics g = Graphics.FromImage(myCanvas.Image);
                g.DrawEllipse(myPen, circle.FirstLocation.X, circle.FirstLocation.Y,
                    Math.Abs(circle.FirstLocation.X - e.X), Math.Abs(circle.FirstLocation.Y - e.Y));
                myCanvas.Image = myCanvas.Image;
                drawCircle = false;
                drawCircleActive = false;
                this.Cursor = Cursors.Arrow;
            }
            if (isColorPickerActive)
            {
                isColorPickerActive = false;
            }
            if (drawSquare)
            {
                Pen myPen = new Pen(myColor, penSize);
                Graphics g = Graphics.FromImage(myCanvas.Image);
                g.DrawRectangle(myPen, square.FirstLocation.X, square.FirstLocation.Y,
                    Math.Abs(square.FirstLocation.X - e.X), Math.Abs(square.FirstLocation.X - e.X));
                myCanvas.Image = myCanvas.Image;
                drawSquare = false;
                drawSquareActive = false;
                this.Cursor = Cursors.Arrow;
            }
            if (crop)
            {
                float[] dashValues = { 2, 2 };
                Pen myPen1 = new Pen(myColor, penSize);
                myPen1.DashPattern = dashValues;
                cropImage.LastLocation = e.Location;
                myCanvas.Image = cropImage.CropBitmap(myCanvas, cropImage.FirstLocation.X, cropImage.FirstLocation.Y,
                    Math.Abs(cropImage.FirstLocation.X - e.X), Math.Abs(cropImage.FirstLocation.Y - e.Y));
                myCanvas.Size = new Size(500, 500);
                crop = false;
                isCropActive = false;
                this.Cursor = Cursors.Arrow;
            }
            if (drawLines)
            {
                this.Refresh();
                Pen myPen = new Pen(myColor, penSize);
                line.GetPen(myPen);
                line.LastLocation = e.Location;
                Graphics g = Graphics.FromImage(myCanvas.Image);
                g.DrawLine(myPen, line.FirstLocation, e.Location);
                myCanvas.Image = myCanvas.Image;
                drawLines = false;
                drawLineActive = false;
            }
        }

        private void drawPencilTool_Click(object sender, EventArgs e)
        { 
            isErase = false;
        }

        private void eraseTool_Click(object sender, EventArgs e)
        {
            paint = false;
            isErase = true;
        }

        private void changePenColorTool_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.ShowDialog();
            colorDlg.AllowFullOpen = false;
            colorDlg.AnyColor = true;
            colorDlg.SolidColorOnly = false;
            myColor = colorDlg.Color;
        }

        private void drawRectangleTool_Click(object sender, EventArgs e)
        {
            drawRectangleActive = true;
            this.Cursor = Cursors.Cross;
            paint = false;
            isErase = false;
        }

        private void rotateAntiTool_Click(object sender, EventArgs e)
        {
            myCanvas = rotater.RotateAntiClockwise(myCanvas);
        }

        private void rotateClockwiseTool_Click(object sender, EventArgs e)
        {
            myCanvas = rotater.RotateClockwise(myCanvas);
        }

        private void saveFileTool_Click(object sender, EventArgs e)
        {
            SaveFile.SaveImageCapture(myCanvas.Image);
        }

        private void OpenFileTool_Click(object sender, EventArgs e)
        {
            myCanvas = open.OpenNewFile(myCanvas);
        }

        private void zoomIn_Click(object sender, EventArgs e)
        {
            myCanvas = zoomItem.ZoomIn(myCanvas);
        }

        private void drawCircleTool_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Cross;
            drawCircleActive = true;
            paint = false;
            isErase = false;
        }

        private void zoomOut_Click(object sender, EventArgs e)
        {
            myCanvas = zoomItem.ZoomOut(myCanvas);
        }

        private void colorPicker_Click(object sender, EventArgs e)
        {
            isColorPickerActive = true;
        }

        private void drawSquareTool_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Cross;
            drawSquareActive = true;
            paint = false;
            isErase = false;
        }

        private void undo_Click(object sender, EventArgs e)
        {
            //myCanvas = undoRedo.DoUndo(myCanvas);
            undoClicked = true;

            this.Refresh();
        }

        private void redo_Click(object sender, EventArgs e)
        {

        }

        private void cropImageTool_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Cross;
            paint = false;
            isCropActive = true;
        }

        private void clearPicturebox_Click(object sender, EventArgs e)
        {
            clearScreen = true;
        }

        private void myCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (clearScreen)
            {
                Graphics g = Graphics.FromImage(myCanvas.Image);
                g.Clear(Color.White);
            }
            clearScreen = false;
        }

        private void chngBgColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.ShowDialog();
            colorDlg.AllowFullOpen = false;
            colorDlg.AnyColor = true;
            colorDlg.SolidColorOnly = false;
            myCanvas.BackColor = colorDlg.Color;
        }

        private void drawLine_Click(object sender, EventArgs e)
        {
            drawLineActive = true;
        }

        private void addTextTool_Click(object sender, EventArgs e)
        {
            writeTextActive = true;
        }
    }
}
