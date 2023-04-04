using System.Drawing;
using System.Drawing.Drawing2D;

namespace Paint_Midterm
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
        }
        public PointF PreviousPoint = Point.Empty;
        public string Name { get; set; }
        public PointF P1;
        public PointF P2;
        public float Width { get; set; }
        public bool IsFill { get; set; } = false;
        public Color ShapeFillColor { get; set; }
        public bool IsChosen { get; set; } = false;
        public Color ShapeColor { get; set; }
        public DashStyle ShapeDashStyle { get; set; }
        protected abstract GraphicsPath GetPath { get; }

        public abstract void Draw(Graphics Gra); // Vẽ hình
        public abstract void Move(PointF Dis); // Di chuyển hình
        public abstract bool IsHit(PointF Point); // Kiểm tra xem click chuột có chạm hình không
        public abstract void ZoomIn();
        public abstract void ZoomOut();
    }
}
