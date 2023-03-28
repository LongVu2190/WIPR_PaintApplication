using System.Drawing.Drawing2D;
using System.Drawing;
using System.Collections.Generic;

namespace Paint_Midterm
{
    public class MyPolygon : MyShape
    {
        public List<PointF> Points { get; set; } = new List<PointF>();
        public MyPolygon()
        {
            this.Name = "Polygon";
        }
        public MyPolygon(float Width, Color ShapeColor, DashStyle ShapeDashStyle, bool IsFill, Color ShapeFillColor)
        {
            this.Width = Width;
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
                    using (Pen pen = new Pen(this.ShapeColor, this.Width + 3))
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
        public bool IsGroupHit(PointF P1, PointF P2)
        {
            for (int i = 0; i < this.Points.Count; i++) 
            {
                if (Points[i].X >= P1.X &&
                        Points[i].X <= P2.X + (P2.X - P1.X) &&
                        Points[i].Y >= P1.Y &&
                        Points[i].Y <= P2.Y + (P2.Y - P1.Y))
                {
                    return true;
                }                
            }
            return false;
        }

        public override void Draw(Graphics Gra)
        {
            using (GraphicsPath path = this.GetPath)
            {
                using (Pen pen = new Pen(this.ShapeColor, this.Width) { DashStyle = this.ShapeDashStyle })
                {
                    Gra.DrawPath(pen, path);
                }

                if (this.IsFill)
                {
                    using (Brush brush = new SolidBrush(this.ShapeFillColor))
                    {
                        Gra.FillPath(brush, path);
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
        public void FindRegion()
        {
            float minX = float.MaxValue;
            float minY = float.MaxValue;
            float maxX = float.MinValue;
            float maxY = float.MinValue;

            this.Points.ForEach(p =>
            {
                if (minX > p.X) { minX = p.X; }
                if (minY > p.Y) { minY = p.Y; }
                if (maxX < p.X) { maxX = p.X; }
                if (maxY < p.Y) { maxY = p.Y; }
            });
            P1 = new PointF(minX, minY);
            P2 = new PointF(maxX, maxY);
        }
    }
}
