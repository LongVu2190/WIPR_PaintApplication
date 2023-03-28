using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Paint_Midterm
{
    public class MyMultiPoint : MyShape
    {
        public List<PointF> Points { get; set; } = new List<PointF>();
        protected MyMultiPoint() { }
        protected MyMultiPoint(float Width, Color ShapeColor, DashStyle ShapeDashStyle) : base()
        {

        }

        public override GraphicsPath GetPath => throw new NotImplementedException();

        public override void Draw(Graphics graphics) { throw new NotImplementedException(); }

        public override bool IsHit(PointF point) { throw new NotImplementedException(); }

        public override void Move(PointF distance)
        {
            P1 = new PointF(P1.X + distance.X, P1.Y + distance.Y);
            P2 = new PointF(P2.X + distance.X, P2.Y + distance.Y);
            for (int i = 0; i < Points.Count; i++)
            {
                Points[i] = new PointF(Points[i].X + distance.X, Points[i].Y + distance.Y);
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
