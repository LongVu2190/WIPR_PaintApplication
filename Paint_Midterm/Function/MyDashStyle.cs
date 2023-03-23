using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint_Midterm
{
    public static class MyDashStyle
    {
        public static float[] GetDashStyle(float n)
        {
            switch (n)
            {

                case 1:
                    {
                        float[] dashValues = { 1 };
                        return dashValues;
                    }
                case 2:
                    {
                        float[] dashValues = { 1, 1, 1, 1 };
                        return dashValues;
                    }
                case 3:
                    {
                        float[] dashValues = { 1, 1, 3 };                       
                        return dashValues;
                    }
                case 4:
                    {
                        float[] dashValues = { 1, 5, 1, 5 };
                        return dashValues;
                    }
                case 5:
                    {
                        float[] dashValues = { 6, 4, 7, 2 };
                        return dashValues;
                    }
                default:
                    {
                        float[] dashValues = { 1 };
                        return dashValues;
                    }

            }
        }
    }
}
