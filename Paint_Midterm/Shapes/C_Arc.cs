using System;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Paint_Midterm
{
    public class C_Arc : A_Shape
    {
        public C_Arc()
        {
            this.Name = "Arc";
        }
        public C_Arc(PointF P1, PointF P2, float Width, Color ShapeColor, DashStyle ShapeDashStyle) : base(P1, P2, Width, ShapeColor, ShapeDashStyle)
        {
            this.Name = "Arc";
        }
        public int SweepAngle { get; set; }
        private bool IsChecked { get; set; } = false;
        protected override GraphicsPath GetPath
        {
            get
            {
                GraphicsPath path = new GraphicsPath();
                if (IsChecked == false)
                {
                    SweepAngle = -180;
                    if (P1.Y >= P2.Y)
                    {
                        SweepAngle = 180;
                    }
                    if (Math.Abs(P2.Y - P1.Y) == 0 && Math.Abs(P2.X - P1.X) == 0)
                    {
                        RectangleF r = new RectangleF(
                         Math.Min(P1.X, P2.X),
                         Math.Min(P1.Y, P2.Y),
                         Math.Abs(P2.X - P1.X + 10),
                         Math.Abs(P2.Y - P1.Y + 10));
                        path.AddArc(r, 0, SweepAngle);
                    }
                    else if (Math.Abs(P2.Y - P1.Y) == 0)
                    {
                        RectangleF r = new RectangleF(
                         Math.Min(P1.X, P2.X),
                         Math.Min(P1.Y, P2.Y),
                         Math.Abs(P2.X - P1.X),
                         Math.Abs(P2.Y - P1.Y + 10));
                        path.AddArc(r, 0, SweepAngle);
                    }
                    else if (Math.Abs(P2.X - P1.X) == 0)
                    {
                        RectangleF r = new RectangleF(
                        Math.Min(P1.X, P2.X),
                        Math.Min(P1.Y, P2.Y),
                        Math.Abs(P2.X - P1.X + 10),
                        Math.Abs(P2.Y - P1.Y));
                        path.AddArc(r, 0, SweepAngle);
                    }
                    else
                    {
                        RectangleF r = new RectangleF(
                          Math.Min(P1.X, P2.X),
                          Math.Min(P1.Y, P2.Y),
                          Math.Abs(P2.X - P1.X),
                          Math.Abs(P2.Y - P1.Y));
                        path.AddArc(r, 0, SweepAngle);
                    }
                }              
                else
                {
                    RectangleF r = new RectangleF(
                          Math.Min(P1.X, P2.X),
                          Math.Min(P1.Y, P2.Y),
                          Math.Abs(P2.X - P1.X),
                          Math.Abs(P2.Y - P1.Y));
                    if (r.Width == 0 || r.Height == 0) // Trường hợp vẽ arc chỉ chấm 1 điểm
                    {
                        r.Width = 10;
                        r.Height = 10;
                    }
                    path.AddArc(r, 0, SweepAngle);
                }
                return path;
            }
        }
        public override bool IsHit(PointF Point)
        {
            if (IsChecked == false)
            {
                CheckPoints();
            }
            Pen myPen = new Pen(ShapeColor, Width + 5);
            return GetPath.IsOutlineVisible(Point, myPen);
        }
        public override void Draw(Graphics Gra)
        {
            Pen myPen = new Pen(ShapeColor, Width) { DashStyle = ShapeDashStyle };
            Gra.DrawPath(myPen, GetPath);
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
                SweepAngle = 180;
                P1_Temp.X = P1.X;
                P1_Temp.Y = P2.Y;

                P2_Temp.X = P2.X;
                P2_Temp.Y = P1.Y;
            }
            else if (P1.X > P2.X && P1.Y > P2.Y)
            {
                SweepAngle = 180;
                P1_Temp = P2;
                P2_Temp = P1;
            }
            else if (P1.X > P2.X && P2.Y > P1.Y)
            {
                SweepAngle = -180;
                P1_Temp.X = P2.X;
                P1_Temp.Y = P1.Y;

                P2_Temp.X = P1.X;
                P2_Temp.Y = P2.Y;
            }
            else
            {
                SweepAngle = -180;
                P1_Temp = P1;
                P2_Temp = P2;
            }
            IsChecked = true;
            //Console.WriteLine("P1 After: " + P1.ToString());
            //Console.WriteLine("P2 After: " + P2.ToString());
            P1 = P1_Temp;
            P2 = P2_Temp;
            //Console.WriteLine("P1: " + P1.ToString());
            //Console.WriteLine("P2: " + P2.ToString());
        }
    }
}
