using System.Drawing;
using System.Drawing.Drawing2D;

namespace Paint_Midterm
{
    public class C_Line : A_Shape
    {
        public C_Line()
        {
            this.Name = "Line";
        }
        public C_Line(PointF P1, PointF P2, float Width, Color ShapeColor, DashStyle ShapeDashStyle) : base(P1, P2, Width, ShapeColor, ShapeDashStyle)
        {
            this.Name = "Line";
        }
        protected override GraphicsPath GetPath
        {
            get
            {
                GraphicsPath GPath = new GraphicsPath();
                GPath.AddLine(P1, P2);
                return GPath;
            }
        }
        public override void Draw(Graphics Gra)
        {
            Pen myPen = new Pen(ShapeColor, Width) { DashStyle = ShapeDashStyle };
            Gra.DrawPath(myPen, GetPath);
        }
        public override void Move(PointF Dis)
        {
            P1 = new PointF(P1.X + Dis.X, P1.Y + Dis.Y);
            P2 = new PointF(P2.X + Dis.X, P2.Y + Dis.Y);
        }
        public override bool IsHit(PointF Point)
        {
            Pen MyPen = new Pen(ShapeColor, Width + 5);
            return GetPath.IsOutlineVisible(Point, MyPen);
        }
    }
}
