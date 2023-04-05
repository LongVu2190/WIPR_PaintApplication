using System.Collections.Generic;
using System.Drawing;

namespace Paint_Midterm.Custom
{
    public static class ShapeFrame
    {
        static Brush MovingBrush = new SolidBrush(Color.FromArgb(13, 49, 110));
        static Brush MovingShadow = new SolidBrush(Color.White);
        static Pen MovingFrame = new Pen(Color.FromArgb(13, 49, 110), 1.5f)
        {
            DashPattern = new float[] { 2, 2, 2, 2 },
        };
        static Pen MovingFrameShadow = new Pen(Color.White, 2f)
        {
            DashPattern = new float[] { 2, 2, 2, 2 },
        };
        public static void DrawStartEndPoints(Graphics graphics, PointF P1, PointF P2)
        {
            graphics.FillEllipse(MovingBrush, new RectangleF(P1.X - 5, P1.Y - 5, 10, 10));
            graphics.FillEllipse(MovingBrush, new RectangleF(P2.X - 5, P2.Y - 5, 10, 10));
        }
        public static void DrawRectanglePoints(Graphics graphics, PointF P1, PointF P2)
        {
            graphics.FillEllipse(MovingShadow, new RectangleF(P1.X - 5, P1.Y - 5, 12, 12));
            graphics.FillEllipse(MovingShadow, new RectangleF(P2.X - 5, P2.Y - 5, 12, 12));
            graphics.FillEllipse(MovingBrush, new RectangleF(P1.X - 5, P1.Y - 5, 10, 10));
            graphics.FillEllipse(MovingBrush, new RectangleF(P2.X - 5, P2.Y - 5, 10, 10));
        }
        public static void DrawPolygonPoints(Graphics graphics, List<PointF> points)
        {
            for (int i = 0; i < points.Count; i++)
            {
                graphics.FillEllipse(MovingBrush, new RectangleF(points[i].X - 5, points[i].Y - 5, 10, 10));
                graphics.FillEllipse(MovingShadow, new RectangleF(points[i].X - 4, points[i].Y - 4, 8, 8));
            }
        }
        public static void DrawRectangleFrame(Graphics graphics, RectangleF zone)
        {
            graphics.DrawRectangle(MovingFrameShadow, zone.X, zone.Y, zone.Width, zone.Height);
            graphics.DrawRectangle(MovingFrame, zone.X, zone.Y, zone.Width, zone.Height);
        }
    }
}
