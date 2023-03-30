﻿using System.Drawing;
using System.Drawing.Drawing2D;

namespace Paint_Midterm
{
    public abstract class MyShape
    {
        public MyShape() 
        {
        }
        public MyShape(PointF P1, PointF P2, float Width, Color ShapeColor, DashStyle ShapeDashStyle)
        {
            this.P1 = P1;
            this.P2 = P2;
            this.Width = Width;
            this.ShapeColor = ShapeColor;
            this.ShapeDashStyle = ShapeDashStyle;
        }
        public PointF PreviousPoint = Point.Empty;
        public string Name { get; set; }
        public PointF P1 { get; set; }
        public PointF P2 { get; set; }
        public float Width { get; set; }
        public bool IsFill { get; set; } = false;
        public Color ShapeFillColor { get; set; }
        public bool IsSelected { get; set; } = false;
        public Color ShapeColor { get; set; }
        public DashStyle ShapeDashStyle { get; set; }
        public abstract GraphicsPath GetPath { get; }

        public abstract void Draw(Graphics Gra);
        public abstract void Move(PointF Dis);
        public abstract bool IsHit(PointF Point);
    }
}
