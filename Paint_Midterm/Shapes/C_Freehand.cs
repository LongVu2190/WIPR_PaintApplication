using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System;
using System.Windows.Forms;

namespace Paint_Midterm.Shapes
{
    public class C_Freehand : A_Shape
    {
        public C_Freehand()
        {
            Name = "Freehand";
        }
        public C_Freehand(float Width, Color ShapeColor, DashStyle ShapeDashStyle)
        {
            this.Width = Width;
            this.ShapeColor = ShapeColor;
            this.ShapeDashStyle = ShapeDashStyle;
            this.Name = "Freehand";
        }
        public List<PointF> Points { get; set; } = new List<PointF>();
        protected override GraphicsPath GetPath
        {
            get
            {
                GraphicsPath path = new GraphicsPath();
                for (int i = 0; i < Points.Count - 1; i++)
                {
                    path.AddLine(Points[i], Points[i + 1]);
                }
                return path;
            }
        }
        public override void Draw(Graphics Gra)
        {
            Pen myPen = new Pen(ShapeColor, Width) { DashStyle = ShapeDashStyle };
            myPen.StartCap = myPen.EndCap = LineCap.Round;
            Gra.DrawPath(myPen, GetPath);
        }
        public override bool IsHit(PointF Point)
        {
            Pen myPen = new Pen(ShapeColor, Width + 3);
            return GetPath.IsOutlineVisible(Point, myPen);
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
            Width = Width + 2;
        }
        public override void ZoomOut()
        {
            if (Width > 3)
            {
                Width -= 2;
            }
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
    }
}
