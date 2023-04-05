using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Paint_Midterm.Shapes
{
    public class C_Line : A_Shape
    {
        public C_Line()
        {
            this.Name = "Line";
        }
        public C_Line(PointF P1, PointF P2, float Width, Color ShapeColor, DashStyle ShapeDashStyle) : base(P1, P2, Width, ShapeColor, ShapeDashStyle)
        {
            this.Name = "Line";
        }
        protected override GraphicsPath GetPath
        {
            get
            {
                GraphicsPath GPath = new GraphicsPath();
                GPath.AddLine(P1, P2);
                return GPath;
            }
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
        public override bool IsHit(PointF Point)
        {
            Pen MyPen = new Pen(ShapeColor, Width + 5);
            return GetPath.IsOutlineVisible(Point, MyPen);
        }
        public override void ZoomIn()
        {
            float Dx = (float)(-P1.Y + P2.Y) / (P1.X - P2.X);
            if (Dx == 0)
            {
                Dx = (float)(-P1.Y + P2.Y) / (P1.X - P2.X);
            }

            if (P2.X > P1.X)
            {
                P2 = new PointF(P2.X + 3, P2.Y - (3 * Dx));
            }
            else
            {
                P1 = new PointF(P1.X + 3, P1.Y - (3 * Dx));
            }
            Width += 1;
        }
        public override void ZoomOut()
        {
            if (Width <= 2) return;

            float Dx = (float)(-P1.Y + P2.Y) / (P1.X - P2.X);

            if (P2.X > P1.X && P2.X - P1.X > 8)
            {
                P2 = new PointF(P2.X - 3, P2.Y + (3 * Dx));
            }
            else if (P1.X - P2.X > 8)
            {
                P1 = new PointF(P1.X - 3, P1.Y + (3 * Dx));
            }
            Width -= 1;
        }
    }
}
