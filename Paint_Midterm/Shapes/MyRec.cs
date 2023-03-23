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
        public MyRec(PointF P1, float Size, Color ShapeColor, DashStyle ShapeDashStyle) : base(P1, Size, ShapeColor, ShapeDashStyle)
        {

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
                    using (Pen MyPen = new Pen(ShapeColor, Size + 2))
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

        public override void Draw(Graphics graphics)
        {
            using (GraphicsPath path = GetPath)
            {
                if (!IsFill)
                {
                    using (Pen myPen = new Pen(ShapeColor, Size))
                    {
                        myPen.DashStyle = ShapeDashStyle;
                        graphics.DrawPath(myPen, path);
                    }
                }
                else
                {
                    using (Brush myBrush = new SolidBrush(ShapeColor))
                    {
                        graphics.FillPath(myBrush, path);
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
