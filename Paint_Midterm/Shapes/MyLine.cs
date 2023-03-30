using System.Drawing;
using System.Drawing.Drawing2D;

namespace Paint_Midterm
{
    public class MyLine : MyShape
    {
        public MyLine() 
        {
            this.Name = "Line";
        }
        public MyLine(PointF P1, PointF P2, float Width, Color ShapeColor, DashStyle ShapeDashStyle) : base(P1, P2, Width, ShapeColor, ShapeDashStyle)
        {
            this.Name = "Line";
        }
        public override GraphicsPath GetPath
        {
            get
            {
                GraphicsPath GPath = new GraphicsPath();
                GPath.AddLine(P1, P2);
                return GPath;
            }
        }
        public override bool IsHit(PointF Point)
        {
            bool result = false;
            using (GraphicsPath path = GetPath)
            {
                using (Pen MyPen = new Pen(ShapeColor, Width + 2))
                {
                    result = path.IsOutlineVisible(Point, MyPen);
                }
            }
            return result;
        }       
        public override void Draw(Graphics Gra)
        {
            using (GraphicsPath path = GetPath)
            {
                using (Pen myPen = new Pen(ShapeColor, Width))
                {
                    myPen.DashStyle = ShapeDashStyle;
                    Gra.DrawPath(myPen, path);
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
