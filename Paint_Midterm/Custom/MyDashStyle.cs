﻿using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint_Midterm
{
    public static class MyDashStyle
    {
        public static DashStyle GetDashStyle(float n)
        {
            switch (n)
            {

                case 1:
                    {
                        return DashStyle.Solid;
                    }
                case 2:
                    {
                        return DashStyle.Dash;
                    }
                case 3:
                    {
                        return DashStyle.Dot;
                    }
                case 4:
                    {
                        return DashStyle.DashDot;
                    }
                case 5:
                    {
                        return DashStyle.DashDotDot;
                    }
                default:
                    {
                        return DashStyle.Solid;
                    }
            }
        }
    }
}