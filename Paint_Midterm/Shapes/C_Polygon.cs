using System.Drawing.Drawing2D;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;

namespace Paint_Midterm
{
    public class C_Polygon : A_Shape
    {
        public C_Polygon()
        {
            Name = "Polygon";
        }
        public C_Polygon(float Width, Color ShapeColor, DashStyle ShapeDashStyle, bool IsFill, Color ShapeFillColor)
        {
            this.Width = Width;
            this.ShapeColor = ShapeColor;
            this.ShapeDashStyle = ShapeDashStyle;
            this.IsFill = IsFill;
            this.ShapeFillColor = ShapeFillColor;
            this.Name = "Polygon";
        }
        public List<PointF> Points { get; set; } = new List<PointF>();
        protected override GraphicsPath GetPath
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
            if (!IsFill)
            {
               Pen myPen = new Pen(ShapeColor, Width + 5);

                    return GetPath.IsOutlineVisible(Point, myPen);
            }
            else
            {
                return GetPath.IsVisible(Point);
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
            for (int i = 0; i < Points.Count; i++)
            {
                Points[i] = new PointF(Points[i].X + Dis.X, Points[i].Y + Dis.Y);
            }
        }
        public override void ZoomIn()
        {
            List<PointF> tmp = new List<PointF>();
            tmp.Add(Points[0]);
            if (Points.Count() > 2)
            {
                for (int i = 1; i < Points.Count(); i++)
                {
                    float Dx1 = (float)(-Points[0].Y + Points[i].Y) / (Points[0].X - Points[i].X);
                    if (i == 1)
                    {
                        PointF p2 = new PointF(Points[i].X + 3, Points[i].Y - (3 * Dx1));
                        tmp.Add(p2);
                    }
                    else
                    {
                        float Dx2 = (float)(-Points[i - 1].Y + Points[i].Y) / (Points[i - 1].X - Points[i].X);
                        float x = Dx2 * (-tmp[i - 1].X) - tmp[i - 1].Y + Dx1 * (Points[0].X) + Points[0].Y;
                        x /= (Dx1 - Dx2);
                        float y = -Dx1 * (x - Points[0].X) + Points[0].Y;
                        PointF p2 = new PointF(x, y);
                        tmp.Add(p2);                    }
                }
                for (int i = 0; i < Points.Count(); i++)
                    Points[i] = tmp[i];
            }
            else
            {
                float Dx = (float)(-Points[0].Y + Points[1].Y) / (Points[0].X - Points[1].X);
                PointF p2 = new PointF(Points[1].X + 3, Points[1].Y - (3 * Dx));
                Points[1] = p2;
            }
            Width += 1;
        }
        public override void ZoomOut()
        {
            if (Width <= 2) return;
            bool flag = true;
            List<PointF> tmp = new List<PointF>();
            tmp.Add(Points[0]);
            if (Points.Count() > 2)
            {
                for (int i = 1; i < Points.Count(); i++)
                {
                    float Dx1 = (float)(-Points[0].Y + Points[i].Y) / (Points[0].X - Points[i].X);
                    if (i == 1)
                    {
                        PointF p2 = new PointF(Points[i].X - 3, Points[i].Y + (3 * Dx1));
                        float check = Points[i].X - 3 - Points[0].X;
                        if (check > 5)
                        {
                            tmp.Add(p2);
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                            break;
                        }
                    }
                    else
                    {
                        float Dx2 = (float)(-Points[i - 1].Y + Points[i].Y) / (Points[i - 1].X - Points[i].X);
                        float x = Dx2 * (-tmp[i - 1].X) - tmp[i - 1].Y + Dx1 * (Points[0].X) + Points[0].Y;
                        x /= (Dx1 - Dx2);
                        float y = -Dx1 * (x - Points[0].X) + Points[0].Y;
                        PointF p2 = new PointF(x, y);
                        tmp.Add(p2);
                    }
                }
                if (flag == true)
                    for (int i = 0; i < Points.Count(); i++)
                        Points[i] = tmp[i];
            }
            else
            {
                if (Points[1].X - 10 - Points[0].X > 5)
                {
                    float Dx1 = (float)(-Points[0].Y + Points[1].Y) / (Points[0].X - Points[1].X);
                    PointF p2 = new PointF(this.Points[1].X - 3, this.Points[1].Y + (3 * Dx1));
                    Points[1] = p2;
                }
            }
            Width -= 1;
        }
        public void LinkPoints()
        {
            float minX = float.MaxValue;
            float minY = float.MaxValue;
            float maxX = float.MinValue;
            float maxY = float.MinValue;

            Points.ForEach(p =>
            {
                if (minX > p.X) { minX = p.X; }
                if (minY > p.Y) { minY = p.Y; }
                if (maxX < p.X) { maxX = p.X; }
                if (maxY < p.Y) { maxY = p.Y; }
            });
            P1 = new PointF(minX, minY);
            P2 = new PointF(maxX, maxY);
        }
        public bool IsGroupHit(PointF p1, PointF p2)
        {
            for (int i = 0; i < Points.Count; i++)
            {
                if (Points[i].X < Math.Max(p2.X, p1.X)
                        && Points[i].X > Math.Min(p2.X, p1.X)
                        && Points[i].Y < Math.Max(p2.Y, p1.Y)
                        && Points[i].Y > Math.Min(p2.Y, p1.Y))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
