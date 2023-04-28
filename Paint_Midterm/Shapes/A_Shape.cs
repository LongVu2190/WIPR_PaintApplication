using System.Drawing;
using System.Drawing.Drawing2D;

namespace Paint_Midterm.Shapes
{
    public abstract class A_Shape
    {
        public A_Shape() 
        {
        }
        public A_Shape(PointF P1, PointF P2, float Width, Color ShapeColor, DashStyle ShapeDashStyle)
        {
            this.P1 = P1;
            this.P2 = P2;
            this.Width = Width;
            this.ShapeColor = ShapeColor;
            this.ShapeDashStyle = ShapeDashStyle;
            IsFill = false;
            IsChosen = false;
        }
        public PointF PreviousPoint = Point.Empty; // Use to moving the shape
        public string Name { get; set; }
        public PointF P1;
        public PointF P2;
        public float Width { get; set; }
        public bool IsFill { get; set; } // Fill mode or not
        public Color ShapeFillColor { get; set; }
        public bool IsChosen { get; set; } // Check if the shape is selected or not
        public Color ShapeColor { get; set; }
        public DashStyle ShapeDashStyle { get; set; } // DashStyle of the shape
        protected abstract GraphicsPath GetPath { get; } // Store path for drawing

        public abstract void Draw(Graphics Gra); // Draw the shape
        public abstract void Move(PointF Dis); // Move the shape
        public abstract bool IsHit(PointF Point); // Check if the mouse click hit the shape or not
        public abstract void ZoomIn(); // Zoom in the shape
        public abstract void ZoomOut(); // Zoom out the shape
    }
}
