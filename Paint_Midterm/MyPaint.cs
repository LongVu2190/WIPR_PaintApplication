﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Paint_Midterm
{
    public partial class MyPaint : Form
    {
        Color MyColor, MyFillColor;
        float MySize;

        List<MyShape> Shapes = new List<MyShape>();

        MyShape SelectedShape;
        MyShape LastSelectedShape;
        List<MyShape> mySelectedShapes = new List<MyShape>();

        PointF PreviousPoint = Point.Empty;
        PaintType Mode = PaintType.Line;

        bool Moving, IsFill = false, IsStart = false, IsCircle = false;

        // Dành cho không vẽ hình (NoPaint)
        MyRec rec = new MyRec();

        // Dành cho di chuyển object (Moving)
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
        // Dành cho group shapes
        private bool isControlKeyPress;

        DrawingStage drawingStage;
        public MyPaint()
        {
            InitializeComponent();
        }

        private void MyPaint_Load(object sender, EventArgs e)
        {
            MyColor = Color.Black;
            MyFillColor = Color.Black;
            MySize = 5;
            Mode = PaintType.NoPaint;
            for (float i = 1; i <= 5; i++)
            {
                DashStyle.Items.Add(i.ToString());
            }
        }
        private void Main_Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (isControlKeyPress)
            {
                for (int i = 0; i < Shapes.Count; i++)
                {
                    if (Shapes[i].IsHit(e.Location))
                    {
                        Shapes[i].IsSelected = !Shapes[i].IsSelected;
                        Shapes[i].PreviousPoint = e.Location;

                        if (Shapes[i].IsSelected == true)
                        {
                            mySelectedShapes.Add(Shapes[i]);
                        }
                        else
                        {
                            mySelectedShapes.Remove(Shapes[i]);
                        }
                        Shape_txb.Text = "Shape " + i.ToString() + " (" + Shapes[i].Name + ")";
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
                        Shape_txb.Text = "Shape " + i.ToString() + " (" + Shapes[i].Name + ")";
                        PreviousPoint = e.Location;
                        Moving = true;
                        break;
                    }
                }
            }

            base.OnMouseDown(e);
            switch (Mode)
            {
                case PaintType.NoPaint:
                    IsStart = true;
                    rec = new MyRec(e.Location, e.Location, 2, Color.Black, System.Drawing.Drawing2D.DashStyle.Dash, false, Color.Black);
                    Main_PBox.Invalidate();
                    break;
                case PaintType.Line:
                    IsStart = true;
                    MyLine myLine = new MyLine(e.Location, e.Location, MySize, MyColor, MyDashStyle.GetDashStyle(Convert.ToInt32(DashStyle.Text)));
                    Shapes.Add(myLine);
                    Main_PBox.Invalidate();
                    break;
                case PaintType.Rec:
                    IsStart = true;
                    MyRec myRec = new MyRec(e.Location, e.Location, MySize, MyColor, MyDashStyle.GetDashStyle(Convert.ToInt32(DashStyle.Text)), IsFill, MyFillColor);
                    Shapes.Add(myRec);
                    Main_PBox.Invalidate();
                    break;
                case PaintType.Ellipse:
                    IsStart = true;
                    MyEllipse myEllipse = new MyEllipse(e.Location, e.Location, MySize, MyColor, MyDashStyle.GetDashStyle(Convert.ToInt32(DashStyle.Text)), IsFill, MyFillColor, IsCircle);
                    Shapes.Add(myEllipse);
                    Main_PBox.Invalidate();
                    break;
                case PaintType.Polygon:
                    //IsStart = true;
                    //MyPolygon myPolygon = new MyPolygon(e.Location, e.Location, MySize, MyColor, MyDashStyle.GetDashStyle(Convert.ToInt32(DashStyle.Text)), IsFill, MyFillColor);
                    //Shapes.Add(myPolygon);
                    //Main_PBox.Invalidate();
                    if (drawingStage != DrawingStage.IsDrawPolygon)
                    {
                        MyPolygon polygon = new MyPolygon(MySize, MyColor, MyDashStyle.GetDashStyle(Convert.ToInt32(DashStyle.Text)), IsFill, MyFillColor);
                        polygon.Points.Add(e.Location);
                        polygon.Points.Add(e.Location);

                        Shapes.Add(polygon);
                        drawingStage = DrawingStage.IsDrawPolygon;
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
                if (isControlKeyPress)
                {
                }
                else
                {
                    if (SelectedShape != null)
                    {
                        var d = new PointF(e.X - PreviousPoint.X, e.Y - PreviousPoint.Y);
                        SelectedShape.Move(d);
                        PreviousPoint = e.Location;
                        Main_PBox.Invalidate();

                        int i = Shapes.IndexOf(SelectedShape);
                        if (i >= 0 && DrawnShapes.Items.Count > i)
                            DrawnShapes.SetItemChecked(i, true);
                    }

                }
            }

            base.OnMouseMove(e);
            if (!IsStart) return;

            switch (Mode)
            {
                case PaintType.NoPaint:
                    rec.P2 = e.Location;
                    Main_PBox.Refresh();
                    break;
                case PaintType.Move:
                    break;
                case PaintType.Polygon:
                    if (drawingStage == DrawingStage.IsDrawPolygon)
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
            if (Mode == PaintType.NoPaint)
            {
                PointF p = new PointF(0, 0);
                rec.P1 = p;
                rec.P2 = p;
                Main_PBox.Invalidate();
            }

            base.OnMouseUp(e);
            IsStart = false;

            DrawnShapes.Items.Clear();
            for (int i = 0; i < Shapes.Count; i++)
            {
                DrawnShapes.Items.Add("Shape " + i.ToString() + " " + Shapes[i].IsSelected.ToString());
            }
        }
        private void Main_Panel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (rec != null)
                rec.Draw(e.Graphics);
            foreach (var shape in Shapes)
            {
                shape.Draw(e.Graphics);
                if (isControlKeyPress)
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
                    // Vẽ đường thẳng trong chế độ di chuyển
                    if (SelectedShape != shape || SelectedShape is MyLine)
                        shape.Draw(e.Graphics);
                }
                // Vẽ lại các hình
                else
                {
                    shape.Draw(e.Graphics);
                }

                //if (Mode == PaintType.Polygon)
                //{
                //    ShapeFrame.DrawSelectFrame(e.Graphics, MovingFrame, MovingFrameShadow, SelectedRegion);
                //}

            }
            Main_PBox.Invalidate();
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
            Shapes.Remove(LastSelectedShape);
            Main_PBox.Invalidate();
            LastSelectedShape = null;
            Shape_txb.Text = "NULL";

            DrawnShapes.Items.Clear();
            for (int i = 0; i < Shapes.Count; i++)
            {
                DrawnShapes.Items.Add("Shape " + i.ToString() + " (" + Shapes[i].Name + ")");
            }

            Main_PBox.Invalidate();
        }
        private void Clear_btn_Click(object sender, EventArgs e)
        {
            Shapes.Clear();
            DrawnShapes.Items.Clear();
            Main_PBox.Invalidate();
            Mode = PaintType.NoPaint;
            drawingStage = DrawingStage.None;
        }
        private void Line_btn_Click(object sender, EventArgs e)
        {
            Mode = PaintType.Line;
        }
        private void Select_btn_Click(object sender, EventArgs e)
        {
            Mode = PaintType.Move;
        }
        private void Group_btn_Click(object sender, EventArgs e)
        {
            Mode = PaintType.NoPaint;
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
            MessageBox.Show("Ungrouped", "Notification");
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

        private void Circle_btn_Click(object sender, EventArgs e)
        {
            Mode = PaintType.Ellipse;
            IsCircle = true;
        }

        private void Polygon_btn_Click(object sender, EventArgs e)
        {
            Mode = PaintType.Polygon;
            drawingStage = DrawingStage.None;
        }

        private void DrawnShapes_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Shapes.Count; i++)
            {
                if (DrawnShapes.GetItemChecked(i) == true)
                {
                    Shapes[i].ShapeDashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                }
                else
                {
                    Shapes[i].ShapeDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                }
            }
            Main_PBox.Invalidate();
        }

        private void Ellipse_btn_Click(object sender, EventArgs e)
        {
            Mode = PaintType.Ellipse;
            IsCircle = false;
        }

        private void MyPaint_KeyDown(object sender, KeyEventArgs e)
        {
            isControlKeyPress = e.Control;
            Debug.Text = isControlKeyPress.ToString();
            if (Mode == PaintType.Polygon)
            {
                Mode = PaintType.NoPaint;
                Shapes[Shapes.Count - 1].IsSelected = false;
            }
        }
        private void MyPaint_KeyUp(object sender, KeyEventArgs e)
        {
            isControlKeyPress = e.Control;
            Debug.Text = isControlKeyPress.ToString();

            if (mySelectedShapes.Count > 1 && Mode == PaintType.Move)
            {
                DialogResult dlr = MessageBox.Show("Group these shapes?", "Grouping", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    MyGroup group = new MyGroup();
                    foreach (var shape in mySelectedShapes)
                    {
                        group.Add(shape);
                        Shapes.Remove(shape);
                    }
                    group.FindRegion();
                    Shapes.Add(group);
                    group.IsSelected = false;
                    mySelectedShapes.Clear();
                }
                else
                {
                    foreach (var shape in mySelectedShapes)
                    {
                        shape.IsSelected = false;
                    }
                    mySelectedShapes.Clear();
                }
                Main_PBox.Invalidate();
            }
        }
    }
}
