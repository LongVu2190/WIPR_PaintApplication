using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Paint_Midterm
{
    public partial class MyPaint : Form
    {
        Color MyColor, MyFillColor;
        float MyWidth;
        List<A_Shape> Shapes = new List<A_Shape>(); // Chứa các hình sẽ vẽ

        PaintType Mode = PaintType.Line; // Chế độ vẽ

        bool Moving, IsFill = false, IsStart = false, IsCircle = false, PolygonStatus;

        C_Rec rec = new C_Rec(); // Dành cho không vẽ hình (Mode: Group)
        bool isControlKeyPress; // Dành cho group shapes (Mode: Group)
        List<A_Shape> MySelectedShapes = new List<A_Shape>(); // Biến tạm thời lưu các hình để group

        // Dành cho di chuyển shape (Mode: Move)
        PointF PreviousPoint = Point.Empty;
        A_Shape SelectedShape; // Lưu shape di chuyển
        A_Shape LastSelectedShape; // Xóa hoặc zoom in zoom out shape vừa di chuyển

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public MyPaint()
        {
            InitializeComponent();
        }
        private void MyPaint_Load(object sender, EventArgs e)
        {
            AllocConsole(); // Debug
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
                        Shapes[i].IsChosen = !Shapes[i].IsChosen;
                        Shapes[i].PreviousPoint = e.Location;

                        if (Shapes[i].IsChosen == true)
                        {
                            MySelectedShapes.Add(Shapes[i]);
                        }
                        else
                        {
                            MySelectedShapes.Remove(Shapes[i]);
                        }
                        Shape_tb.Text = Shapes[i].Name;
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
                        Shape_tb.Text = Shapes[i].Name;
                        PreviousPoint = e.Location;
                        Moving = true;
                        break;
                    }
                }
            }

            switch (Mode)
            {
                case PaintType.Group:
                    IsStart = true;
                    rec = new C_Rec(e.Location, e.Location, 2, Color.Black, System.Drawing.Drawing2D.DashStyle.Dash, false, Color.Black);
                    Main_PBox.Invalidate();
                    break;
                case PaintType.Line:
                    IsStart = true;
                    C_Line Line = new C_Line(e.Location, e.Location, MyWidth, MyColor, MyDashStyle.GetDashStyle(Convert.ToInt32(DashStyle.Text)));
                    Shapes.Add(Line);
                    Main_PBox.Invalidate();
                    break;
                case PaintType.Rec:
                    IsStart = true;
                    C_Rec Rec = new C_Rec(e.Location, e.Location, MyWidth, MyColor, MyDashStyle.GetDashStyle(Convert.ToInt32(DashStyle.Text)), IsFill, MyFillColor);
                    Shapes.Add(Rec);
                    Main_PBox.Invalidate();
                    break;
                case PaintType.Ellipse:
                    IsStart = true;
                    C_Ellipse Ellipse = new C_Ellipse(e.Location, e.Location, MyWidth, MyColor, MyDashStyle.GetDashStyle(Convert.ToInt32(DashStyle.Text)), IsFill, MyFillColor, IsCircle);
                    Shapes.Add(Ellipse);
                    Main_PBox.Invalidate();
                    break;
                case PaintType.Polygon:
                    if (!PolygonStatus)
                    {
                        C_Polygon Polygon = new C_Polygon(MyWidth, MyColor, MyDashStyle.GetDashStyle(Convert.ToInt32(DashStyle.Text)), IsFill, MyFillColor);
                        Polygon.Points.Add(e.Location);
                        Polygon.Points.Add(e.Location);

                        Shapes.Add(Polygon);
                        PolygonStatus = true;
                    }
                    else
                    {
                        C_Polygon Polygon = Shapes[Shapes.Count - 1] as C_Polygon;
                        Polygon.Points[Polygon.Points.Count - 1] = e.Location;
                        Polygon.Points.Add(e.Location);
                    }
                    IsStart = true;
                    Main_PBox.Invalidate();
                    break;
                case PaintType.Freehand:
                    C_Freehand Freehand = new C_Freehand(MyWidth, MyColor, MyDashStyle.GetDashStyle(Convert.ToInt32(DashStyle.Text)));
                    Freehand.P1 = e.Location;
                    Freehand.Points.Add(e.Location);
                    Shapes.Add(Freehand);
                    PolygonStatus = true;
                    IsStart = true;
                    Main_PBox.Invalidate();
                    break;
                case PaintType.Arc:
                    IsStart = true;
                    C_Arc Arc = new C_Arc(e.Location, e.Location, MyWidth, MyColor, MyDashStyle.GetDashStyle(Convert.ToInt32(DashStyle.Text)));
                    Shapes.Add(Arc);
                    Main_PBox.Invalidate();
                    break;
                default:
                    break;
            }

            // Nhấn chuột phải để kết thúc vẽ polygon
            if (e.Button == MouseButtons.Right && Mode == PaintType.Polygon)
            {
                isControlKeyPress = false;
                MessageBox.Show("Drew a Polygon", "Notification");
                ChangeTextBox("MODE: SELECT & MOVE", "NOTE: ");
                IsStart = false;
                PolygonStatus = true;
                Mode = PaintType.Move;
            }
        }
        private void Main_Panel_MouseMove(object sender, MouseEventArgs e)
        {
            // Thay đổi con trỏ chuột khi di chuyển đến hình
            Main_PBox.Cursor = Cursors.Default;
            if (Mode == PaintType.Move || isControlKeyPress)
            {
                for (int i = 0; i < Shapes.Count; i++)
                {
                    if (Shapes[i].IsHit(e.Location))
                    {
                        Main_PBox.Cursor = Cursors.SizeAll;
                    }
                }
            }

            // Di chuyển hình trong biến SelectedShape
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
                    C_Polygon polygon = Shapes[Shapes.Count - 1] as C_Polygon;
                    polygon.Points[polygon.Points.Count - 1] = e.Location;
                    Main_PBox.Refresh();
                    break;
                case PaintType.Freehand:
                    C_Freehand freehand = Shapes[Shapes.Count - 1] as C_Freehand;
                    freehand.Points.Add(e.Location);
                    Main_PBox.Refresh();
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

            if (Mode == PaintType.Freehand)
            {
                C_Freehand freehand = Shapes[Shapes.Count - 1] as C_Freehand;
                freehand.P2 = freehand.Points[freehand.Points.Count - 1];
                Main_PBox.Invalidate();
            }

            if (Mode == PaintType.Group && !isControlKeyPress)
            {
                MySelectedShapes.Clear();
                for (int i = 0; i < Shapes.Count; i++)
                {
                    Shapes[i].IsChosen = false;

                    if (Shapes[i] is C_Rec rect)
                    {
                        rect.CheckPoints(); // Đảo lại vị trí P1 và P2
                    }
                    else if (Shapes[i] is C_Ellipse ellipse)
                    {
                        ellipse.CheckPoints(); // Đảo lại vị trí P1 và P2
                    }
                    else if (Shapes[i] is C_Arc arc)
                    {
                        arc.CheckPoints(); // Đảo lại vị trí P1 và P2
                    }
                    else if (Shapes[i] is C_Polygon polygon)
                    {
                        if (polygon.IsGroupHit(rec.P1, rec.P2) == true)
                        {
                            polygon.IsChosen = true;
                            MySelectedShapes.Add(polygon);
                        }
                    }

                    // Kiểm tra xem vùng quét có chạm hình nào không
                    if (Shapes[i].P1.X < Math.Max(rec.P2.X, rec.P1.X)
                        && Shapes[i].P1.X > Math.Min(rec.P2.X, rec.P1.X)
                        && Shapes[i].P1.Y < Math.Max(rec.P2.Y, rec.P1.Y)
                        && Shapes[i].P1.Y > Math.Min(rec.P2.Y, rec.P1.Y))
                    {
                        Shapes[i].IsChosen = true;
                        MySelectedShapes.Add(Shapes[i]);
                    }
                    else if (Shapes[i].P2.X < Math.Max(rec.P2.X, rec.P1.X)
                        && Shapes[i].P2.X > Math.Min(rec.P2.X, rec.P1.X)
                        && Shapes[i].P2.Y < Math.Max(rec.P2.Y, rec.P1.Y)
                        && Shapes[i].P2.Y > Math.Min(rec.P2.Y, rec.P1.Y))
                    {
                        Shapes[i].IsChosen = true;
                        MySelectedShapes.Add(Shapes[i]);
                    }
                }

                // Xóa vùng quét sau khi thả chuột
                PointF p = new PointF(0, 0);
                rec.P1 = p;
                rec.P2 = p;
                Main_PBox.Invalidate();
                Shape_tb.Text = "Group";
                Note_tb.Text = "NOTE: Press Ctrl to group";
            }

            if (Mode != PaintType.Polygon) // Riêng vẽ Polygon
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
                if (Mode == PaintType.Group)
                {
                    if (shape.IsChosen == true) // Vẽ Frame cho những hình được chọn
                    {
                        if (!(shape is C_Line || shape is C_Freehand)) // Vẽ khung hình chữ nhật
                        {
                            ShapeFrame.DrawRectangleFrame(e.Graphics,
                                new RectangleF(shape.P1.X,
                                               shape.P1.Y,
                                               shape.P2.X - shape.P1.X,
                                               shape.P2.Y - shape.P1.Y));
                        }

                        if (shape is C_Line || shape is C_Rec || shape is C_Ellipse || shape is C_Arc)
                        {
                            ShapeFrame.DrawRectanglePoints(e.Graphics, shape.P1, shape.P2);
                            //shape.Draw(e.Graphics);
                        }
                        else if (shape is C_Polygon polygon)
                        {
                            ShapeFrame.DrawPolygonPoints(e.Graphics, polygon.Points);
                        }
                        else if (shape is C_Freehand)
                        {
                            ShapeFrame.DrawStartEndPoints(e.Graphics, shape.P1, shape.P2);
                        }
                    }
                }
                else if (Moving)
                {
                    // Vẽ dash cho khung chọn hình ngoại trừ đường thẳng và freehand
                    if (!(SelectedShape is C_Line || SelectedShape is C_Freehand))
                    {
                        ShapeFrame.DrawRectangleFrame(e.Graphics,
                            new RectangleF(SelectedShape.P1.X,
                            SelectedShape.P1.Y,
                            SelectedShape.P2.X - SelectedShape.P1.X,
                            SelectedShape.P2.Y - SelectedShape.P1.Y));
                    }
                    if (SelectedShape is C_Line || SelectedShape is C_Rec || SelectedShape is C_Ellipse || SelectedShape is C_Arc)
                    {
                        ShapeFrame.DrawRectanglePoints(e.Graphics, SelectedShape.P1, SelectedShape.P2);
                    }
                    else if (SelectedShape is C_Freehand)
                    {
                        ShapeFrame.DrawStartEndPoints(e.Graphics, SelectedShape.P1, SelectedShape.P2);
                    }
                    else if (shape is C_Polygon polygon)
                    {
                        ShapeFrame.DrawPolygonPoints(e.Graphics, polygon.Points);
                    }
                    if (SelectedShape != shape || SelectedShape is C_Line)
                        shape.Draw(e.Graphics);
                }
            }
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
            DialogResult dlr = MessageBox.Show("Do you want to clear panel?", "Notification", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                Shapes.Clear();
                MySelectedShapes.Clear();
                LastSelectedShape = null;
                SelectedShape = null;
                Shape_tb.Text = "NULL";
                Main_PBox.Invalidate();
                MessageBox.Show("Cleared", "Notification");
            }
        }
        private void Select_btn_Click(object sender, EventArgs e)
        {
            Mode = PaintType.Move;
            ChangeTextBox("MODE: SELECT & MOVE", "NOTE: Choose a shape");
            Main_PBox.Invalidate();
        }
        private void Group_btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MySelectedShapes.Count; i++)
            {
                MySelectedShapes[i].IsChosen = false;
            }
            MySelectedShapes.Clear();
            Mode = PaintType.Group;
            ChangeTextBox("MODE: GROUP", "NOTE: Hold Ctrl to select Shapes");
            Main_PBox.Invalidate();
        }
        private void Ungroup_btn_Click(object sender, EventArgs e)
        {
            if (LastSelectedShape is null || LastSelectedShape.Name != "Group")
            {
                MessageBox.Show("Please choose a group shape", "Notification");
                return;
            }
            C_Group group = new C_Group();
            group = LastSelectedShape as C_Group;

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
                Fill_btn.Text = "FILL: ON";
            }
            else
            {
                Fill_Color_btn.Visible = false;
                Fill_btn.Text = "FILL: OFF";
            }

        }
        private void ZoomIn_btn_Click(object sender, EventArgs e)
        {
            if (LastSelectedShape != null)
            {
                LastSelectedShape.ZoomIn();
                Main_PBox.Invalidate();
            }
            else
                MessageBox.Show("Please select a shape", "Notification");
        }
        private void ZoomOut_btn_Click(object sender, EventArgs e)
        {
            if (LastSelectedShape != null)
            {
                LastSelectedShape.ZoomOut();
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
            }
            if (e.KeyCode == Keys.S && isControlKeyPress)
            {
                Save_Picture();
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
                isControlKeyPress = false;

                if (MySelectedShapes.Count > 1 && Mode == PaintType.Group)
                {
                    DialogResult dlr = MessageBox.Show("Group these shapes?", "Notification", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        C_Group group = new C_Group();
                        foreach (var shape in MySelectedShapes)
                        {
                            group.AddSingleShape(shape);
                            Shapes.Remove(shape);
                        }
                        group.LinkShapes();
                        Shapes.Add(group);
                        group.IsChosen = false;
                        MySelectedShapes.Clear();
                    }
                    else
                    {
                        foreach (var shape in MySelectedShapes)
                        {
                            shape.IsChosen = false;
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
                        shape.IsChosen = false;
                    }
                    Mode = PaintType.Move;
                    Main_PBox.Invalidate();
                }
                ChangeTextBox("MODE: SELECT & MOVE", "NOTE: ");
            }
        }

        private void DeleteShapes()
        {
            if (LastSelectedShape == null)
            {
                MessageBox.Show("Please choose a shape to delete", "Notification");
                return;
            }
            Shapes.Remove(LastSelectedShape);
            foreach (var shape in MySelectedShapes)
            {
                Shapes.Remove(shape);
            }
            MySelectedShapes.Clear();
            LastSelectedShape = null;
            Shape_tb.Text = "NULL";
            Main_PBox.Invalidate();
        }
        private void ChangeTextBox(string mode, string note)
        {
            Mode_tb.Text = mode;
            Note_tb.Text = note;
        }
        private void Save_Picture()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.FileName = "MyPaint";
                saveFileDialog.Filter = "PNG | *.png|" +
                                            "JPEG | *.jpg *.jpeg *.jpe *.jfif";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bmp = new Bitmap(Main_PBox.ClientSize.Width, Main_PBox.ClientSize.Height);
                    Main_PBox.DrawToBitmap(bmp, Main_PBox.ClientRectangle);
                    bmp.Save(saveFileDialog.FileName);
                    MessageBox.Show("Saved", "Notification");
                }
            }
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
            ChangeTextBox("MODE: DRAW LINE", "NOTE: ");
        }
        private void Rec_btn_Click(object sender, EventArgs e)
        {
            Mode = PaintType.Rec;
            ChangeTextBox("MODE: DRAW RECTANGLE", "NOTE: ");
        }
        private void Ellipse_btn_Click(object sender, EventArgs e)
        {
            Mode = PaintType.Ellipse;
            IsCircle = false;
            ChangeTextBox("MODE: DRAW ELLIPSE", "NOTE: ");
        }
        private void Circle_btn_Click(object sender, EventArgs e)
        {
            Mode = PaintType.Ellipse;
            IsCircle = true;
            ChangeTextBox("MODE: DRAW CIRCLE", "NOTE: ");
        }
        private void Arc_btn_Click(object sender, EventArgs e)
        {
            Mode = PaintType.Arc;
            ChangeTextBox("MODE: DRAW ARC", "NOTE: ");
        }
        private void Polygon_btn_Click(object sender, EventArgs e)
        {
            Mode = PaintType.Polygon;
            PolygonStatus = false;
            ChangeTextBox("MODE: DRAW POLYGON", "NOTE: Press Ctrl to finish Polygon");
        }
        private void Freehand_btn_Click(object sender, EventArgs e)
        {
            ChangeTextBox("MODE: DRAW FREEHAND", "NOTE:");
            Mode = PaintType.Freehand;
        }

        // Lưu và thoát
        private void Save_btn_Click(object sender, EventArgs e)
        {
            Save_Picture();
        }
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Do you want to save picture before exit?", "Notification", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                Save_Picture();
                Application.Exit();
            }
            if (dlr == DialogResult.No)
            {
                Application.Exit();
            }
        }

        private void PenSize_ValueChanged(object sender, EventArgs e)
        {
            MyWidth = (float)PenWidth.Value;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Shapes: " + Shapes.Count);
            Console.WriteLine("MySelectedShapes: " + MySelectedShapes.Count);
        }
    }
}
