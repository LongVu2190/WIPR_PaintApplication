using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Paint_Midterm
{
    public class C_Rec : A_Shape
    {
        public C_Rec()
        {
            this.Name = "Rectangle";
        }
        public C_Rec(PointF P1, PointF P2, float Width, Color ShapeColor, DashStyle ShapeDashStyle, bool IsFill, Color ShapeFillColor) : base(P1, P2, Width, ShapeColor, ShapeDashStyle)
        {
            this.Name = "Rectangle";
            this.IsFill = IsFill;
            this.ShapeFillColor = ShapeFillColor;
        }
        protected override GraphicsPath GetPath
        {
            get
            {                
                GraphicsPath path = new GraphicsPath();
                RectangleF r = new RectangleF(Math.Min(P1.X, P2.X),
                                              Math.Min(P1.Y, P2.Y),
                                              Math.Abs(P2.X - P1.X),
                                              Math.Abs(P2.Y - P1.Y));
                path.AddRectangle(r);
                return path;
            }
        }
        public override bool IsHit(PointF Point)
        {
            CheckPoints();
            GraphicsPath path = GetPath;
            if (!IsFill)
            {
                Pen MyPen = new Pen(ShapeColor, Width + 5);
                return path.IsOutlineVisible(Point, MyPen);
            }
            else
            {
                return path.IsVisible(Point);
            }
        }
        public override void Draw(Graphics Gra)
        {
            Pen myPen = new Pen(ShapeColor, Width) { DashStyle = ShapeDashStyle };
            Gra.DrawPath(myPen, GetPath);

            if (IsFill)
            {
                Brush myBrush = new SolidBrush(ShapeFillColor);
                Gra.FillPath(myBrush, GetPath);
            }
        }
        public override void Move(PointF Dis)
        {
            P1 = new PointF(P1.X + Dis.X, P1.Y + Dis.Y);
            P2 = new PointF(P2.X + Dis.X, P2.Y + Dis.Y);
        }
        // Kiểm tra các hình vẽ từ phải qua trái, dưới lên trên -> trái trên qua phải dưới
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
