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
        public static void DrawPolygonPoints(Graphics graphics, List<PointF> Points)
        {
            for (int i = 0; i < Points.Count; i++)
            {
                graphics.FillEllipse(MovingBrush, new RectangleF(Points[i].X - 5, Points[i].Y - 5, 10, 10));
                graphics.FillEllipse(MovingShadow, new RectangleF(Points[i].X - 4, Points[i].Y - 4, 8, 8));
            }
        }
        public static void DrawRectangleFrame(Graphics graphics, RectangleF rec)
        {
            graphics.DrawRectangle(MovingFrameShadow, rec.X, rec.Y, rec.Width, rec.Height);
            graphics.DrawRectangle(MovingFrame, rec.X, rec.Y, rec.Width, rec.Height);
        }
    }
}
