using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Paint_Midterm
{
    public static class ShapeFrame
    {
        static Brush MovingBrush = new SolidBrush(Color.FromArgb(0, 30, 81));
        static Brush MovingShadow = new SolidBrush(Color.White);
        static Pen MovingFrame = new Pen(Color.FromArgb(0, 30, 81), 1.5f)
        {
            DashPattern = new float[] { 3, 3, 3, 3 },
        };
        static Pen MovingFrameShadow = new Pen(Color.White, 2f)
        {
            DashPattern = new float[] { 3.25f, 3.25f, 3.25f, 3.25f },
        };
        public static void DrawStartEndPoints(Graphics graphics, PointF point0, PointF point1)
        {
            graphics.FillEllipse(MovingBrush, new RectangleF(point0.X - 5, point0.Y - 5, 10, 10));
            graphics.FillEllipse(MovingBrush, new RectangleF(point1.X - 5, point1.Y - 5, 10, 10));
        }
        public static void DrawRectanglePoints(Graphics graphics, PointF point0, PointF point1)
        {
            graphics.FillEllipse(MovingShadow, new RectangleF(point0.X - 5, point0.Y - 5, 12, 12));
            graphics.FillEllipse(MovingShadow, new RectangleF(point1.X - 5, point1.Y - 5, 12, 12));
            graphics.FillEllipse(MovingBrush, new RectangleF(point0.X - 5, point0.Y - 5, 10, 10));
            graphics.FillEllipse(MovingBrush, new RectangleF(point1.X - 5, point1.Y - 5, 10, 10));
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
