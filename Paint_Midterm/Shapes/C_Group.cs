using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Reflection;
using System;

namespace Paint_Midterm
{
    public class C_Group : A_Shape
    {
        public List<A_Shape> Shapes = new List<A_Shape>();
        public C_Group()
        {
            Name = "Group";
        }
        protected override GraphicsPath GetPath
        {
            get
            {
                GraphicsPath path = new GraphicsPath();
                path.AddLine(P1, P2);
                return path;
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
                    if (Shapes[i] is C_Line line)
                    {
                        path.AddLine(line.P1, line.P2);
                    }
                    else if (Shapes[i] is C_Polygon polygon)
                    {
                        path.AddPolygon(polygon.Points.ToArray());
                    }
                    else if (Shapes[i] is C_Rec rec)
                    {
                        path.AddRectangle(new RectangleF(rec.P1.X, rec.P1.Y, rec.P2.X - rec.P1.X, rec.P2.Y - rec.P1.Y));
                    }
                    else if (Shapes[i] is C_Freehand freehand)
                    {
                        for (int j = 0; j < freehand.Points.Count - 1; j++)
                        {
                            path.AddLine(freehand.Points[j], freehand.Points[j + 1]);
                        }
                    }
                    else if (Shapes[i] is C_Ellipse ellip)
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
                    else if (Shapes[i] is C_Arc arc)
                    {
                        if (Math.Abs(arc.P2.Y - arc.P1.Y) == 0 && Math.Abs(arc.P2.X - arc.P1.X) == 0)
                        {
                            RectangleF r = new RectangleF(
                             Math.Min(arc.P1.X, arc.P2.X),
                             Math.Min(arc.P1.Y, arc.P2.Y),
                             Math.Abs(arc.P2.X - arc.P1.X + 10),
                             Math.Abs(arc.P2.Y - arc.P1.Y + 10));
                            path.AddArc(r, 0, arc.SweepAngle);
                        }
                        else if (Math.Abs(arc.P2.Y - arc.P1.Y) == 0)
                        {
                            RectangleF r = new RectangleF(
                             Math.Min(arc.P1.X, arc.P2.X),
                             Math.Min(arc.P1.Y, arc.P2.Y),
                             Math.Abs(arc.P2.X - arc.P1.X),
                             Math.Abs(arc.P2.Y - arc.P1.Y + 10));
                            path.AddArc(r, 0, arc.SweepAngle);
                        }
                        else if (Math.Abs(arc.P2.X - arc.P1.X) == 0)
                        {
                            RectangleF r = new RectangleF(
                            Math.Min(arc.P1.X, arc.P2.X),
                            Math.Min(arc.P1.Y, arc.P2.Y),
                            Math.Abs(arc.P2.X - arc.P1.X + 10),
                            Math.Abs(arc.P2.Y - arc.P1.Y));
                            path.AddArc(r, 0, arc.SweepAngle);
                        }
                        else
                        {
                            RectangleF r = new RectangleF(
                              Math.Min(arc.P1.X, arc.P2.X),
                              Math.Min(arc.P1.Y, arc.P2.Y),
                              Math.Abs(arc.P2.X - arc.P1.X),
                              Math.Abs(arc.P2.Y - arc.P1.Y));
                            path.AddArc(r, 0, arc.SweepAngle);
                        }
                    }
                    paths[i] = path;
                }
                return paths;
            }
        }
        public override void Draw(Graphics Gra)
        {
            GraphicsPath[] paths = GetPaths;
            for (int i = 0; i < paths.Length; i++)

            {
                if (Shapes[i] is C_Group group)
                {
                    group.Draw(Gra);
                }
                else if (Shapes[i].IsFill == true)
                {
                    Brush myBrush = new SolidBrush(Shapes[i].ShapeFillColor);
                    Gra.FillPath(myBrush, paths[i]);
                    Pen myPen = new Pen(Shapes[i].ShapeColor, Shapes[i].Width);
                    Gra.DrawPath(myPen, paths[i]);
                }
                else
                {
                    Pen myPen = new Pen(Shapes[i].ShapeColor, Shapes[i].Width) { DashStyle = Shapes[i].ShapeDashStyle };
                    Gra.DrawPath(myPen, paths[i]);
                }
            }
        }
        public override bool IsHit(PointF point)
        {
            GraphicsPath[] paths = GetPaths;
            for (int i = 0; i < paths.Length; i++)
            {
                if (Shapes[i].IsFill)
                {
                    if (paths[i].IsVisible(point))
                        return true;
                }
                else
                {
                    Pen myPen = new Pen(Shapes[i].ShapeColor, Shapes[i].Width + 3);
                    if (paths[i].IsOutlineVisible(point, myPen))
                        return true;
                }
                if (!(Shapes[i] is C_Group))
                {
                    Pen myPen = new Pen(Shapes[i].ShapeColor, Shapes[i].Width + 3);
                    if (paths[i].IsOutlineVisible(point, myPen))
                        return true;
                }
                else if (Shapes[i] is C_Group group)
                    return group.IsHit(point);

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
        public void AddSingleShape(A_Shape shape)
        {
            Shapes.Add(shape);
        }
        public void LinkShapes()
        {
            float minX = float.MaxValue;
            float minY = float.MaxValue;
            float maxX = float.MinValue;
            float maxY = float.MinValue;

            for (int i = 0; i < this.Shapes.Count; i++)
            {
                A_Shape shape = Shapes[i];

                if (shape is C_Polygon polygon)
                {
                    polygon.LinkPoints();
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

            P1 = new PointF(minX, minY);
            P2 = new PointF(maxX, maxY);
        }
        public void UnGroup(List<A_Shape> shapes)
        {
            foreach (var shape in Shapes)
            {
                shape.IsChosen = false;
                shapes.Add(shape);
            }
        }
    }
}
