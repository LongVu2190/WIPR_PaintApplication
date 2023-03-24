using System.Drawing.Drawing2D;
using System.Drawing;

namespace Paint_Midterm
{
    public class MyPolygon : MyMultiPoint
    {
        public MyPolygon()
        {
            this.Name = "Polygon";
        }
        public MyPolygon(float Size, Color ShapeColor, DashStyle ShapeDashStyle, bool IsFill, Color ShapeFillColor)
        {
            this.Size = Size;
            this.ShapeColor = ShapeColor;
            this.ShapeDashStyle = ShapeDashStyle;
            this.IsFill = IsFill;
            this.ShapeFillColor = ShapeFillColor;
            this.Name = "Polygon";
        }
        public override GraphicsPath GetPath
        {
            get
            {
                GraphicsPath path = new GraphicsPath();
                if (Points.Count < 3)
                {
                    path.AddLine(Points[0], Points[1]);
                }
                else
                {
                    path.AddPolygon(Points.ToArray());
                }

                return path;
            }
        }
        public override bool IsHit(PointF Point)
        {
            bool result = false;
            using (GraphicsPath path = this.GetPath)
            {
                if (!IsFill)
                {
                    using (Pen pen = new Pen(this.ShapeColor, this.Size + 3))
                    {
                        result = path.IsOutlineVisible(Point, pen);
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
            using (GraphicsPath path = this.GetPath)
            {
                using (Pen pen = new Pen(this.ShapeColor, this.Size) { DashStyle = this.ShapeDashStyle })
                {
                    graphics.DrawPath(pen, path);
                }

                if (this.IsFill)
                {
                    using (Brush brush = new SolidBrush(this.ShapeFillColor))
                    {
                        graphics.FillPath(brush, path);
                    }
                }
            }
        }
        public override void Move(PointF Dis)
        {
            P1 = new PointF(P1.X + Dis.X, P1.Y + Dis.Y);
            P2 = new PointF(P2.X + Dis.X, P2.Y + Dis.Y);
            for (int i = 0; i < Points.Count; i++)
            {
                Points[i] = new PointF(Points[i].X + Dis.X, Points[i].Y + Dis.Y);
            }
        }
    }
}
