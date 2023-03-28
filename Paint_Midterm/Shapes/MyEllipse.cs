using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint_Midterm
{
    internal class MyEllipse : MyShape
    {
        
        public MyEllipse()
        {
            this.Name = "Ellipse";
        }
        public MyEllipse(PointF P1, PointF P2, float Width, Color ShapeColor, DashStyle ShapeDashStyle, bool IsFill, Color ShapeFillColor, bool IsCircle) : base(P1, P2, Width, ShapeColor, ShapeDashStyle)
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
        public float Diameter { get; set; } = 0f;
        public override GraphicsPath GetPath
        {
            get
            {
                GraphicsPath path = new GraphicsPath();
                if (IsCircle)
                {

                    Diameter = ((P2.X - P1.X) + (P2.Y - P1.Y)) / 2;
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
            bool result = false;
            using (GraphicsPath path = GetPath)
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
        public override void Draw(Graphics Gra)
        {
            using (GraphicsPath path = GetPath)
            {
                using (Pen pen = new Pen(this.ShapeColor, this.Width) { DashStyle = ShapeDashStyle })
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
        }
    }
}
