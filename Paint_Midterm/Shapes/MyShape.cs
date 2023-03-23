using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint_Midterm
{
    public abstract class MyShape
    {
        public MyShape() 
        {
            this.Name = "Shape ";
        }
        public MyShape(PointF P1, float Size, Color ShapeColor, float[] ShapeDashStyle)
        {
            this.P1 = P1;
            this.Size = Size;
            this.ShapeColor = ShapeColor;
            this.ShapeDashStyle = ShapeDashStyle;
        }
        public string Name { get; set; }
        public PointF P1 { get; set; }
        public PointF P2 { get; set; }
        public float Size { get; set; }
        public Color ShapeColor { get; set; }
        public float[] ShapeDashStyle { get; set; }
        public bool IsSelected { get; set; } = false;
        public bool IsHidden { get; set; } = false;
        public abstract GraphicsPath GetPath { get; }

        public abstract void Draw(Graphics Gra);
        public abstract void Move(PointF Dis);
        public abstract bool IsHit(PointF Point);
    }
}
