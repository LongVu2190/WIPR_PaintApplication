using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint_Midterm
{
    public class MyLine : MyShape
    {
        public MyLine() 
        {
            this.Name = "Line";
        }
        public MyLine(PointF P1, float Size, Color ShapeColor, DashStyle ShapeDashStyle) : base(P1, Size, ShapeColor, ShapeDashStyle)
        {

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
                using (Pen MyPen = new Pen(ShapeColor, Size + 2))
                {
                    result = path.IsOutlineVisible(Point, MyPen);
                }
            }
            return result;
        }
        
        public override void Draw(Graphics graphics)
        {
            using (GraphicsPath path = GetPath)
            {
                using (Pen myPen = new Pen(ShapeColor, Size))
                {
                    myPen.DashStyle = ShapeDashStyle;
                    graphics.DrawPath(myPen, path);
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
