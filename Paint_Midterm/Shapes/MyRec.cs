using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint_Midterm
{
    public class MyRec : MyShape
    {
        public MyRec()
        {
            this.Name = "Rectangle";
        }
        public MyRec(PointF P1, PointF P2, float Width, Color ShapeColor, DashStyle ShapeDashStyle, bool IsFill, Color ShapeFillColor) : base(P1, P2, Width, ShapeColor, ShapeDashStyle)
        {
            this.Name = "Rectangle";
            this.IsFill = IsFill;
            this.ShapeFillColor = ShapeFillColor;
        }
        public override GraphicsPath GetPath
        {
            get
            {
                GraphicsPath GPath = new GraphicsPath();
                RectangleF r = new RectangleF(Math.Min(P1.X, P2.X),
                            Math.Min(P1.Y, P2.Y),
                            Math.Abs(P2.X - P1.X),
                            Math.Abs(P2.Y - P1.Y));
                GPath.AddRectangle(r);
                return GPath;
            }
        }
        public override bool IsHit(PointF Point)
        {
            bool result = false;
            using (GraphicsPath path = GetPath)
            {
                if (!IsFill)
                {
                    using (Pen MyPen = new Pen(ShapeColor, Width + 2))
                    {
                        result = path.IsOutlineVisible(Point, MyPen);
                    }
                }
                else
                {
                    result = path.IsVisible(Point);
                }
            }
            return result;
        }
        public override void Draw(Graphics Gra)
        {
            using (GraphicsPath path = GetPath)
            {
                using (Pen myPen = new Pen(ShapeColor, Width))
                {
                    myPen.DashStyle = ShapeDashStyle;
                    Gra.DrawPath(myPen, path);
                }
                if (IsFill)
                {
                    using (Brush myBrush = new SolidBrush(ShapeFillColor))
                    {
                        Gra.FillPath(myBrush, path);
                    }
                }
            }
        }
        public override void Move(PointF Dis)
        {
            P1 = new PointF(P1.X + Dis.X, P1.Y + Dis.Y);
            P2 = new PointF(P2.X + Dis.X, P2.Y + Dis.Y);
        }
    }
}
