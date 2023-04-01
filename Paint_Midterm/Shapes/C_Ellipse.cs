using System.Drawing.Drawing2D;
using System.Drawing;
using System.IO;

namespace Paint_Midterm
{
    internal class C_Ellipse : A_Shape
    {
        public C_Ellipse()
        {
            this.Name = "Ellipse";
        }
        public C_Ellipse(PointF P1, PointF P2, float Width, Color ShapeColor, DashStyle ShapeDashStyle, bool IsFill, Color ShapeFillColor, bool IsCircle) : base(P1, P2, Width, ShapeColor, ShapeDashStyle)
        {
            this.IsFill = IsFill;
            this.ShapeFillColor = ShapeFillColor;
            this.IsCircle = IsCircle;

            if (IsCircle == true)
                this.Name = "Circle";
            else
                this.Name = "Ellipse";
        }
        public bool IsCircle { get; set; } = false;
        public override GraphicsPath GetPath
        {
            get
            {
                GraphicsPath path = new GraphicsPath();
                if (IsCircle)
                {

                    float Diameter = ((P2.X - P1.X) + (P2.Y - P1.Y)) / 2;
                    path.AddEllipse(new RectangleF(P1.X, P1.Y, Diameter, Diameter));
                    P2 = new PointF(P1.X + Diameter, P1.Y + Diameter);
                }
                else
                {
                    path.AddEllipse(new RectangleF(P1.X, P1.Y, P2.X - P1.X, P2.Y - P1.Y));
                }
                return path;
            }
        }
        public override bool IsHit(PointF Point)
        {
            CheckPoints();
            if (!IsFill)
            {
                Pen myPen = new Pen(this.ShapeColor, this.Width + 3);
                return GetPath.IsOutlineVisible(Point, myPen);
            }
            else
            {
                return GetPath.IsVisible(Point);
            }

        }
        public override void Draw(Graphics Gra)
        {
            Pen myPen = new Pen(this.ShapeColor, this.Width) { DashStyle = ShapeDashStyle };
            Gra.DrawPath(myPen, GetPath);
            if (this.IsFill)
            {
                Brush myBrush = new SolidBrush(this.ShapeFillColor);
                Gra.FillPath(myBrush, GetPath);
            }
        }
        public override void Move(PointF Dis)
        {
            P1 = new PointF(P1.X + Dis.X, P1.Y + Dis.Y);
            P2 = new PointF(P2.X + Dis.X, P2.Y + Dis.Y);
        }
        public void CheckPoints()
        {
            PointF P1_Temp = new PointF(), P2_Temp = new PointF();
            if (P1.X < P2.X && P1.Y > P2.Y)
            {
                P1_Temp.X = P1.X;
                P1_Temp.Y = P2.Y;

                P2_Temp.X = P2.X;
                P2_Temp.Y = P1.Y;
            }
            else if (P1.X > P2.X && P1.Y > P2.Y)
            {
                P1_Temp = P2;
                P2_Temp = P1;
            }
            else if (P1.X > P2.X && P2.Y > P1.Y)
            {
                P1_Temp.X = P2.X;
                P1_Temp.Y = P1.Y;

                P2_Temp.X = P1.X;
                P2_Temp.Y = P2.Y;
            }
            else
            {
                P1_Temp = P1;
                P2_Temp = P2;

            }
            //Console.WriteLine("P1 After: " + P1.ToString());
            //Console.WriteLine("P2 After: " + P2.ToString());
            P1 = P1_Temp;
            P2 = P2_Temp;
            //Console.WriteLine("P1: " + P1.ToString());
            //Console.WriteLine("P2: " + P2.ToString());
        }
    }
}
