using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Paint_Midterm
{
    public class MyGroup : MyShape
    {
        public List<MyShape> Shapes = new List<MyShape>();
        public int Count => Shapes.Count;
        public MyGroup()
        {
            this.Name = "Group";
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
        private GraphicsPath[] GetPaths
        {
            get
            {
                GraphicsPath[] paths = new GraphicsPath[Shapes.Count];

                for (int i = 0; i < Shapes.Count; i++)
                {
                    GraphicsPath path = new GraphicsPath();

                    if (Shapes[i] is MyLine line)
                    {
                        path.AddLine(line.P1, line.P2);
                    }
                    else if (Shapes[i] is MyPolygon polygon)
                    {
                        path.AddPolygon(polygon.Points.ToArray());
                    }
                    else if (Shapes[i] is MyRec rect)
                    {
                        path.AddRectangle(new RectangleF(rect.P1.X, rect.P1.Y, rect.P2.X - rect.P1.X, rect.P2.Y - rect.P1.Y));
                    }
                    else if (Shapes[i] is MyEllipse ellip)
                    {
                        if (ellip.IsCircle == true)
                        {
                            float r = ((ellip.P2.X - ellip.P1.X) + (ellip.P2.Y - ellip.P1.Y)) / 2;
                            path.AddEllipse(new RectangleF(ellip.P1.X, ellip.P1.Y, r, r));
                        }
                        else
                        {
                            path.AddEllipse(new RectangleF(ellip.P1.X, ellip.P1.Y, ellip.P2.X - ellip.P1.X, ellip.P2.Y - ellip.P1.Y));
                        }
                    }
                    paths[i] = path;
                }
                return paths;
            }
        }
        public void Add(MyShape shape) { Shapes.Add(shape); }
        public override void Draw(Graphics Gra)
        {
            GraphicsPath[] paths = this.GetPaths;
            for (int i = 0; i < paths.Length; i++)
            {
                using (GraphicsPath path = paths[i])
                {
                    if (Shapes[i].IsFill == true)
                    {
                        using (Brush brush = new SolidBrush(Shapes[i].ShapeFillColor))
                        {
                            Gra.FillPath(brush, path);
                        }
                        using (Pen pen = new Pen(Shapes[i].ShapeColor, Shapes[i].Width))
                        {
                            Gra.DrawPath(pen, path);
                        }
                    }
                    else if (Shapes[i] is MyGroup group)
                    {
                        group.Draw(Gra);
                    }
                    else
                    {
                        using (Pen pen = new Pen(Shapes[i].ShapeColor, Shapes[i].Width) { DashStyle = Shapes[i].ShapeDashStyle })
                        {
                            Gra.DrawPath(pen, path);
                        }
                    }

                }
            }
        }
        public override bool IsHit(PointF point)
        {
            GraphicsPath[] paths = GetPaths;
            for (int i = 0; i < paths.Length; i++)
            {
                using (GraphicsPath path = paths[i])
                {

                    if (Shapes[i].IsFill)
                    {
                        using (Brush brush = new SolidBrush(Shapes[i].ShapeColor))
                        {
                            if (path.IsVisible(point)) { return true; }
                        }
                    }
                    else
                    {
                        using (Pen pen = new Pen(Shapes[i].ShapeColor, Shapes[i].Width + 3))
                        {
                            if (path.IsOutlineVisible(point, pen)) { return true; }
                        }
                    }

                    if (!(Shapes[i] is MyGroup))
                    {
                        using (Pen pen = new Pen(Shapes[i].ShapeColor, Shapes[i].Width + 3))
                        {
                            if (path.IsOutlineVisible(point, pen)) { return true; }
                        }
                    }
                    else if (Shapes[i] is MyGroup group) { return group.IsHit(point); }
                }
            }

            return false;
        }
        public override void Move(PointF Dis)
        {
            for (int i = 0; i < Shapes.Count; i++)
            {
                Shapes[i].Move(Dis);
            }
            P1 = new PointF(P1.X + Dis.X, P1.Y + Dis.Y);
            P2 = new PointF(P2.X + Dis.X, P2.Y + Dis.Y);
        }
        public void FindRegion()
        {
            float minX = float.MaxValue;
            float minY = float.MaxValue;
            float maxX = float.MinValue;
            float maxY = float.MinValue;

            for (int i = 0; i < this.Shapes.Count; i++)
            {
                MyShape shape = Shapes[i];

                if (shape is MyPolygon polygon)
                {
                    polygon.FindRegion();
                }
                if (shape.P1.X < minX)
                {
                    minX = shape.P1.X;
                }
                if (shape.P2.X < minX)
                {
                    minX = shape.P2.X;
                }

                if (shape.P1.Y < minY)
                {
                    minY = shape.P1.Y;
                }
                if (shape.P2.Y < minY)
                {
                    minY = shape.P2.Y;
                }

                if (shape.P1.X > maxX)
                {
                    maxX = shape.P1.X;
                }
                if (shape.P2.X > maxX)
                {
                    maxX = shape.P2.X;
                }

                if (shape.P1.Y > maxY)
                {
                    maxY = shape.P1.Y;
                }
                if (shape.P2.Y > maxY)
                {
                    maxY = shape.P2.Y;
                }
            }

            this.P1 = new PointF(minX, minY);
            this.P2 = new PointF(maxX, maxY);
        }
        public void UnGroup(List<MyShape> shapes)
        {
            foreach (var shape in Shapes)
            {
                shape.IsSelected = false;
                shapes.Add(shape);
            }
        }
    }
}
