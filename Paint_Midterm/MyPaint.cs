using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint_Midterm
{
    public partial class MyPaint : Form
    {
        Pen MyPen;
        Color MyColor, TempColor;
        Brush MyBrush;
        float MySize;

        List<MyShape> Shapes = new List<MyShape>();
        float[] TempDashStyle;

        MyShape SelectedShape;
        MyShape LastSelectedShape;

        PointF PreviousPoint = Point.Empty;
        PaintType Mode = PaintType.Line;

        bool Moving, IsFill = false, IsStart = false;

        Brush brush = new SolidBrush(Color.FromArgb(0, 30, 81));
        Brush brushShadow = new SolidBrush(Color.White);
        Pen framePen = new Pen(Color.FromArgb(0, 30, 81), 1.5f)
        {
            DashPattern = new float[] { 3, 3, 3, 3 },
        };

        Pen framePenShadow = new Pen(Color.White, 2f)
        {
            DashPattern = new float[] { 3.25f, 3.25f, 3.25f, 3.25f },
        };
        public MyPaint()
        {
            InitializeComponent();
        }

        private void MyPaint_Load(object sender, EventArgs e)
        {
            MyColor = Color.Black;
            MyBrush = Brushes.Black;
            MySize = 5;
            MyPen = new Pen(MyColor, MySize);
            for (float i = 1; i <= 5; i++)
            {
                DashStyle.Items.Add(i.ToString());
            }
        }
        private void Main_Panel_MouseDown(object sender, MouseEventArgs e)
        {
            for (var i = Shapes.Count - 1; i >= 0; i--)
            {
                if (Shapes[i].IsHit(e.Location))
                {
                    SelectedShape = Shapes[i];
                    Shape_txb.Text = SelectedShape.Name + i.ToString();
                    break;
                }
            }
            if (SelectedShape != null)
            {
                Moving = true;
                PreviousPoint = e.Location;
            }
            base.OnMouseDown(e);
            switch (Mode)
            {
                case PaintType.NoPaint:
                    break;
                case PaintType.Line:
                    IsStart = true;
                    MyLine myLine = new MyLine();
                    myLine.P1 = e.Location;
                    myLine.P2 = e.Location;
                    myLine.ShapeColor = MyColor;
                    myLine.Size = MySize;
                    myLine.ShapeDashStyle = MyDashStyle.GetDashStyle(Convert.ToInt32(DashStyle.Text));
                    Shapes.Add(myLine);
                    Main_PBox.Invalidate();
                    break;
                case PaintType.Rec:
                    IsStart = true;
                    MyRec myRec = new MyRec();
                    myRec.P1 = e.Location;
                    myRec.P2 = e.Location;
                    myRec.ShapeColor = MyColor;
                    myRec.Size = MySize;
                    myRec.ShapeDashStyle = MyDashStyle.GetDashStyle(Convert.ToInt32(DashStyle.Text));
                    myRec.IsFill = IsFill;
                    Shapes.Add(myRec);
                    Main_PBox.Invalidate();
                    break;
                default:
                    break;
            }
        }
        private void Main_Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (Moving && Mode == PaintType.Move)
            {
                var d = new PointF(e.X - PreviousPoint.X, e.Y - PreviousPoint.Y);
                SelectedShape.Move(d);
                PreviousPoint = e.Location;
                Main_PBox.Invalidate();
            }
            base.OnMouseMove(e);
            if (!IsStart) return;

            switch (Mode)
            {
                case PaintType.Move:
                    break;
                case PaintType.Line:
                    Shapes[Shapes.Count - 1].P2 = e.Location;
                    Main_PBox.Refresh();
                    break;
                case PaintType.Rec:
                    Shapes[Shapes.Count - 1].P2 = e.Location;
                    Main_PBox.Refresh();
                    break;
            }
        }
        private void Main_Panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (Moving)
            {
                LastSelectedShape = SelectedShape;
                SelectedShape = null;
                Moving = false;
            }
            Main_PBox.Invalidate();
            base.OnMouseUp(e);
            IsStart = false;
        }
        private void Main_Panel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (var shape in Shapes)
            {
                if (Moving)
                {                   
                    if (!(SelectedShape.Name == "Line"))
                    {
                        ShapeFrame.DrawSelectFrame(e.Graphics, framePen, framePenShadow,
                            new RectangleF(SelectedShape.P1.X,
                            SelectedShape.P1.Y,
                            SelectedShape.P2.X - SelectedShape.P1.X,
                            SelectedShape.P2.Y - SelectedShape.P1.Y));                        
                    }                      
                    if (SelectedShape.Name == "Line")
                    {
                        ShapeFrame.DrawSelectPoints(e.Graphics, brush, brushShadow, SelectedShape.P1, SelectedShape.P2);
                    }
                    else if (SelectedShape.Name == "Rectangle")
                    {
                        ShapeFrame.DrawSelectPoints(e.Graphics, brush, brushShadow,
                                                    SelectedShape.P1,
                                                    SelectedShape.P2);
                    }
                    if (SelectedShape != shape || SelectedShape is MyLine)
                        shape.Draw(e.Graphics);
                }
                else
                    shape.Draw(e.Graphics);
            }
        }
        private void ZoomIn_btn_Click(object sender, EventArgs e)
        {
            if (LastSelectedShape != null)
            {
                LastSelectedShape.Size += 5;
                Main_PBox.Invalidate();
            }
        }
        private void ZoomOut_btn_Click(object sender, EventArgs e)
        {
            if (LastSelectedShape != null)
            {
                if (LastSelectedShape.Size > 5)
                    LastSelectedShape.Size -= 5;
                Main_PBox.Invalidate();
            }
        }

        private void PenSize_ValueChanged(object sender, EventArgs e)
        {
            MySize = (float)PenSize.Value;
        }

        private void Color_btn_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                MyColor = dlg.Color;
                MyBrush = new SolidBrush(MyColor);
                Color_btn.BackColor = dlg.Color;
            }
        }
        private void Delete_btn_Click(object sender, EventArgs e)
        {
            Shapes.Remove(LastSelectedShape);
            Main_PBox.Invalidate();
            LastSelectedShape = null;
            Shape_txb.Text = "NULL";
        }
        private void Clear_btn_Click(object sender, EventArgs e)
        {
            Shapes.Clear();
            Main_PBox.Invalidate();
        }
        private void Select_btn_Click(object sender, EventArgs e)
        {
            Mode = PaintType.Move;
        }
        private void Line_btn_Click(object sender, EventArgs e)
        {
            Mode = PaintType.Line;
        }
        private void Rec_btn_Click(object sender, EventArgs e)
        {
            Mode = PaintType.Rec;
        }
        private void Fill_btn_Click(object sender, EventArgs e)
        {
            IsFill = (IsFill == true) ? false : true;
            check.Text = IsFill.ToString();
        }       
    }
}
