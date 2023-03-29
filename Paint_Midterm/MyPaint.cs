﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint_Midterm
{
    public partial class MyPaint : Form
    {
        Color MyColor, MyFillColor;
        float MyWidth;
        List<MyShape> Shapes = new List<MyShape>(); // Chứa các hình sẽ vẽ

        PaintType Mode = PaintType.Line; // Chế độ vẽ

        bool Moving, IsFill = false, IsStart = false, IsCircle = false, PolygonStatus;

        MyRec rec = new MyRec(); // Dành cho không vẽ hình (Mode: Group)
        bool isControlKeyPress; // Dành cho group shapes (Mode: Group)
        List<MyShape> MySelectedShapes = new List<MyShape>(); // Biến tạm thời lưu các hình để group

        // Dành cho di chuyển shape (Mode: Mode)
        PointF PreviousPoint = Point.Empty;
        MyShape SelectedShape; // Lưu shape di chuyển
        MyShape LastSelectedShape; // Xóa hoặc zoom in zoom out shape vừa di chuyển

        // Vẽ ra khung xung quanh khi di chuyển hình
        Brush MovingBrush = new SolidBrush(Color.FromArgb(0, 30, 81));
        Brush MovingShadow = new SolidBrush(Color.White);
        Pen MovingFrame = new Pen(Color.FromArgb(0, 30, 81), 1.5f)
        {
            DashPattern = new float[] { 3, 3, 3, 3 },
        };
        Pen MovingFrameShadow = new Pen(Color.White, 2f)
        {
            DashPattern = new float[] { 3.25f, 3.25f, 3.25f, 3.25f },
        };

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public MyPaint()
        {
            InitializeComponent();
        }
        private void MyPaint_Load(object sender, EventArgs e)
        {
            //AllocConsole();
            MyColor = Color.Black;
            MyFillColor = Color.Black;
            MyWidth = 5;
            DashStyle.SelectedIndex = 0;
            Mode = PaintType.Group;
            Fill_Color_btn.Visible = false;
        }

        // Vẽ
        private void Main_Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (Mode == PaintType.Group && isControlKeyPress)
            {
                for (int i = 0; i < Shapes.Count; i++)
                {
                    if (Shapes[i].IsHit(e.Location))
                    {
                        Shapes[i].IsSelected = !Shapes[i].IsSelected;
                        Shapes[i].PreviousPoint = e.Location;

                        if (Shapes[i].IsSelected == true)
                        {
                            MySelectedShapes.Add(Shapes[i]);
                        }
                        else
                        {
                            MySelectedShapes.Remove(Shapes[i]);
                        }
                        Shape_txb.Text = Shapes[i].Name;
                        Main_PBox.Invalidate();
                        break;
                    }
                }
            }
            else if (Mode == PaintType.Move)
            {
                for (var i = Shapes.Count - 1; i >= 0; i--)
                {
                    if (Shapes[i].IsHit(e.Location))
                    {
                        SelectedShape = Shapes[i];
                        Shape_txb.Text = Shapes[i].Name;
                        PreviousPoint = e.Location;
                        Moving = true;
                        break;
                    }
                }
            }

            base.OnMouseDown(e);
            switch (Mode)
            {
                case PaintType.Group:
                    IsStart = true;
                    rec = new MyRec(e.Location, e.Location, 2, Color.Black, System.Drawing.Drawing2D.DashStyle.Dash, false, Color.Black);
                    Main_PBox.Invalidate();
                    break;
                case PaintType.Line:
                    IsStart = true;
                    MyLine myLine = new MyLine(e.Location, e.Location, MyWidth, MyColor, MyDashStyle.GetDashStyle(Convert.ToInt32(DashStyle.Text)));
                    Shapes.Add(myLine);
                    Main_PBox.Invalidate();
                    break;
                case PaintType.Rec:
                    IsStart = true;
                    MyRec myRec = new MyRec(e.Location, e.Location, MyWidth, MyColor, MyDashStyle.GetDashStyle(Convert.ToInt32(DashStyle.Text)), IsFill, MyFillColor);
                    Shapes.Add(myRec);
                    Main_PBox.Invalidate();
                    break;
                case PaintType.Ellipse:
                    IsStart = true;
                    MyEllipse myEllipse = new MyEllipse(e.Location, e.Location, MyWidth, MyColor, MyDashStyle.GetDashStyle(Convert.ToInt32(DashStyle.Text)), IsFill, MyFillColor, IsCircle);
                    Shapes.Add(myEllipse);
                    Main_PBox.Invalidate();
                    break;
                case PaintType.Polygon:
                    if (!PolygonStatus)
                    {
                        MyPolygon polygon = new MyPolygon(MyWidth, MyColor, MyDashStyle.GetDashStyle(Convert.ToInt32(DashStyle.Text)), IsFill, MyFillColor);
                        polygon.Points.Add(e.Location);
                        polygon.Points.Add(e.Location);

                        Shapes.Add(polygon);
                        PolygonStatus = true;
                    }
                    else
                    {
                        MyPolygon polygon = Shapes[Shapes.Count - 1] as MyPolygon;
                        polygon.Points[polygon.Points.Count - 1] = e.Location;
                        polygon.Points.Add(e.Location);
                    }
                    IsStart = true;
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
                if (SelectedShape != null)
                {
                    var d = new PointF(e.X - PreviousPoint.X, e.Y - PreviousPoint.Y);
                    SelectedShape.Move(d);
                    PreviousPoint = e.Location;
                    Main_PBox.Invalidate();
                }
            }

            base.OnMouseMove(e);
            if (!IsStart) return;

            switch (Mode)
            {
                case PaintType.Group:
                    rec.P2 = e.Location;
                    Main_PBox.Refresh();
                    break;
                case PaintType.Move:
                    break;
                case PaintType.Polygon:
                    if (PolygonStatus)
                    {
                        MyPolygon polygon = Shapes[Shapes.Count - 1] as MyPolygon;
                        polygon.Points[polygon.Points.Count - 1] = e.Location;

                        Main_PBox.Refresh();
                    }
                    break;
                default:
                    Shapes[Shapes.Count - 1].P2 = e.Location;
                    Main_PBox.Refresh();
                    break;
            }
        }
        private void Main_Panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (Moving && isControlKeyPress == false)
            {
                LastSelectedShape = SelectedShape;
                SelectedShape = null;
                Moving = false;
            }

            // Xóa khung hình chữ nhật sau khi thả chuột
            if (Mode == PaintType.Group && !isControlKeyPress)
            {
                for (int i = 0; i < Shapes.Count; i++)
                {
                    Shapes[i].IsSelected = false;

                    if (Shapes[i] is MyPolygon polygon)
                    {
                        if (polygon.IsGroupHit(rec.P1, rec.P2))
                        {
                            Shapes[i].IsSelected = true;
                            MySelectedShapes.Add(Shapes[i]);
                        }
                    }
                    else if (Shapes[i].P1.X >= rec.P1.X &&
                        Shapes[i].P2.X <= rec.P2.X + (rec.P2.X - rec.P1.X) &&
                        Shapes[i].P1.Y >= rec.P1.Y &&
                        Shapes[i].P2.Y <= rec.P2.Y + (rec.P2.Y - rec.P1.Y))
                    {
                        Shapes[i].IsSelected = true;
                        MySelectedShapes.Add(Shapes[i]);
                    }
                }
                PointF p = new PointF(0, 0);
                rec.P1 = p;
                rec.P2 = p;
                Main_PBox.Invalidate();
                Shape_txb.Text = "Group";
            }

            base.OnMouseUp(e);
            if (Mode != PaintType.Polygon)
                IsStart = false;
        }
        private void Main_Panel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (rec != null)
                rec.Draw(e.Graphics);
            foreach (var shape in Shapes)
            {
                shape.Draw(e.Graphics);
                //if (Mode == PaintType.Group && isControlKeyPress)
                if (Mode == PaintType.Group)
                {
                    if (shape.IsSelected == true)
                    {
                        if (!(shape is MyLine))
                        {
                            ShapeFrame.DrawSelectFrame(e.Graphics, MovingFrame, MovingFrameShadow,
                                new RectangleF(shape.P1.X,
                                shape.P1.Y,
                                shape.P2.X - shape.P1.X,
                                shape.P2.Y - shape.P1.Y));
                        }
                        if (shape is MyLine)
                        {
                            ShapeFrame.DrawSelectPoints(e.Graphics, MovingBrush, MovingShadow, shape.P1, shape.P2);
                        }
                        else if (shape is MyRec || shape is MyEllipse)
                        {
                            ShapeFrame.DrawSelectPoints(e.Graphics, MovingBrush, MovingShadow,
                                                        shape.P1,
                                                        shape.P2);
                        }
                        else if (shape is MyPolygon polygon)
                        {
                            ShapeFrame.DrawSelectPoints(e.Graphics, MovingBrush, MovingShadow, polygon.Points);
                        }
                        if (shape is MyLine)
                            shape.Draw(e.Graphics);
                    }
                    else
                    {
                        shape.Draw(e.Graphics);
                    }

                }
                else if (Moving)
                {
                    // Vẽ dash cho khung chọn hình ngoại trừ đường thẳng
                    if (!(SelectedShape is MyLine))
                    {
                        ShapeFrame.DrawSelectFrame(e.Graphics, MovingFrame, MovingFrameShadow,
                            new RectangleF(SelectedShape.P1.X,
                            SelectedShape.P1.Y,
                            SelectedShape.P2.X - SelectedShape.P1.X,
                            SelectedShape.P2.Y - SelectedShape.P1.Y));
                    }
                    // Vẽ hai điểm đầu cho đường thẳng
                    if (SelectedShape is MyLine)
                    {
                        ShapeFrame.DrawSelectPoints(e.Graphics, MovingBrush, MovingShadow, SelectedShape.P1, SelectedShape.P2);
                    }
                    // Vẽ hai điểm đầu cho hình chữ nhật
                    else if (SelectedShape is MyRec || SelectedShape is MyEllipse)
                    {
                        ShapeFrame.DrawSelectPoints(e.Graphics, MovingBrush, MovingShadow,
                                                    SelectedShape.P1,
                                                    SelectedShape.P2);
                    }
                    else if (shape is MyPolygon polygon)
                    {
                        ShapeFrame.DrawSelectPoints(e.Graphics, MovingBrush, MovingShadow, polygon.Points);
                    }
                    // Vẽ đường thẳng trong chế độ di chuyển
                    if (SelectedShape != shape || SelectedShape is MyLine)
                        shape.Draw(e.Graphics);
                }
                // Vẽ lại các hình
                else
                    shape.Draw(e.Graphics);
            }
        }

        private void PenSize_ValueChanged(object sender, EventArgs e)
        {
            MyWidth = (float)PenWidth.Value;
        }

        // Chức năng
        private void Color_btn_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                MyColor = dlg.Color;
                Color_btn.BackColor = dlg.Color;
            }
        }
        private void Fill_Color_btn_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                MyFillColor = dlg.Color;
                Fill_Color_btn.BackColor = dlg.Color;
            }
        }
        private void Delete_btn_Click(object sender, EventArgs e)
        {
            DeleteShapes();
        }
        private void Clear_btn_Click(object sender, EventArgs e)
        {
            Shapes.Clear();
            Shape_txb.Text = "NULL";
            Main_PBox.Invalidate();
        }
        private void Select_btn_Click(object sender, EventArgs e)
        {
            Mode = PaintType.Move;
            Mode_tb.Text = "MODE: SELECT & MOVE";
            Main_PBox.Invalidate();
        }
        private void Group_btn_Click(object sender, EventArgs e)
        {
            Mode = PaintType.Group;          
            Mode_tb.Text = "MODE: GROUP";
            Main_PBox.Invalidate();
        }
        private void Ungroup_btn_Click(object sender, EventArgs e)
        {
            if (LastSelectedShape is null || LastSelectedShape.Name != "Group")
            {
                MessageBox.Show("Please choose a group shape", "Notification");
                return;
            }
            MyGroup group = new MyGroup();
            group = LastSelectedShape as MyGroup;

            group.UnGroup(Shapes);
            Shapes.Remove(group);
            Main_PBox.Invalidate();
            LastSelectedShape = null;
            Mode = PaintType.Move;
            MessageBox.Show("Ungrouped", "Notification");
        }
        private void Fill_btn_Click(object sender, EventArgs e)
        {
            IsFill = (IsFill == true) ? false : true;
            if (IsFill == true)
            {
                Fill_Color_btn.Visible = true;
                Fill_btn.Text = "Fill: On";
            }                
            else
            {
                Fill_Color_btn.Visible = false;
                Fill_btn.Text = "Fill: Off";
            }
                
        }
        private void ZoomIn_btn_Click(object sender, EventArgs e)
        {
            if (LastSelectedShape != null)
            {
                LastSelectedShape.Width += 5;
                Main_PBox.Invalidate();
            }
            else
                MessageBox.Show("Please select a shape", "Notification");
        }
        private void ZoomOut_btn_Click(object sender, EventArgs e)
        {
            if (LastSelectedShape != null)
            {
                if (LastSelectedShape.Width > 5)
                    LastSelectedShape.Width -= 5;
                Main_PBox.Invalidate();
            }
            else
                MessageBox.Show("Please select a shape", "Notification");
        }

        // Nhấn ctrl và delete
        private void MyPaint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                isControlKeyPress = true;
                if (Mode == PaintType.Polygon)
                {
                    isControlKeyPress = false;
                    MessageBox.Show("Drew a Polygon", "Notification");
                    Mode_tb.Text = "MODE: SELECT & MOVE";
                    IsStart = false;
                    PolygonStatus = true;
                    Mode = PaintType.Move;
                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                DeleteShapes();
            }
        }
        private void MyPaint_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                isControlKeyPress = e.Control;

                if (MySelectedShapes.Count > 1 && Mode == PaintType.Group)
                {
                    DialogResult dlr = MessageBox.Show("Group these shapes?", "Grouping", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        MyGroup group = new MyGroup();
                        foreach (var shape in MySelectedShapes)
                        {
                            group.AddSingleShape(shape);
                            Shapes.Remove(shape);
                        }
                        group.LinkShapes();
                        Shapes.Add(group);
                        group.IsSelected = false;
                        MySelectedShapes.Clear();
                    }
                    else
                    {
                        foreach (var shape in MySelectedShapes)
                        {
                            shape.IsSelected = false;
                        }
                        MySelectedShapes.Clear();
                    }
                    Mode = PaintType.Move;
                    Main_PBox.Invalidate();
                }
                else
                {
                    foreach (var shape in MySelectedShapes)
                    {
                        shape.IsSelected = false;
                    }
                    Mode = PaintType.Move;
                    Main_PBox.Invalidate();
                }
                Mode_tb.Text = "MODE: SELECT & MOVE";
            }
        }

        private void DeleteShapes()
        {
            Shapes.Remove(LastSelectedShape);
            foreach (var shape in MySelectedShapes)
            {
                Shapes.Remove(shape);
            }
            Main_PBox.Invalidate();
            LastSelectedShape = null;
            Shape_txb.Text = "NULL";
            Main_PBox.Invalidate();
        }
        private void DashStyle_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index != -1)
            {
                e.Graphics.DrawImage(DashList.Images[e.Index], e.Bounds.Left, e.Bounds.Top);
            }
            e.DrawFocusRectangle();
        }

        // Chọn Mode vẽ
        private void Line_btn_Click(object sender, EventArgs e)
        {
            Mode = PaintType.Line;
            Mode_tb.Text = "MODE: DRAW LINE";
        }
        private void Rec_btn_Click(object sender, EventArgs e)
        {
            Mode = PaintType.Rec;
            Mode_tb.Text = "MODE: DRAW RECTANGLE";
        }
        private void Ellipse_btn_Click(object sender, EventArgs e)
        {
            Mode = PaintType.Ellipse;
            IsCircle = false;
            Mode_tb.Text = "MODE: DRAW ELLIPSE";
        }
        private void Circle_btn_Click(object sender, EventArgs e)
        {
            Mode = PaintType.Ellipse;
            IsCircle = true;
            Mode_tb.Text = "MODE: DRAW CIRCLE";
        }
        private void Polygon_btn_Click(object sender, EventArgs e)
        {
            Mode = PaintType.Polygon;
            PolygonStatus = false;
            Mode_tb.Text = "MODE: DRAW POLYGON";
        }
        private void Arc_btn_Click(object sender, EventArgs e)
        {
            Mode_tb.Text = "MODE: DRAW ARC";
        }
    }
}
