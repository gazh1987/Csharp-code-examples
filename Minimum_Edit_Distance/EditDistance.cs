using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minimum_Edit_Distance
{
    class EditDistance
    {
        public static float Min3(float a, float b, float c)
        {
            float temp;
            if (a < b)
            {
                temp = a;
            }
            else
            {
                temp = b;
            }

            if (temp < c)
            {
                return temp;
            }
            else
            {
                return c;
            }
        }

        public static float MinimumEditDistance(String a, String b)
        {
            CMatric matrix = new CMatric(a.Length + 1, b.Length + 1);
            float temp, t1, t2, t3, value = 0;

            for (int i = 0; i < matrix.Rows; i++)
            {
                matrix.Set(i, 0, i);
            }
            for (int i = 0; i < matrix.Cols; i++)
            {
                matrix.Set(0, i, i);
            }

            matrix.display();

            for (int i = 1; i < matrix.Rows; i++)
            {
                for (int j = 1; j < matrix.Cols; j++)
                {
                    if (b[j - 1] == a[i - 1])
                    {
                        temp = matrix.Get(i - 1, j - 1);
                        matrix.Set(i, j, temp);
                    }
                    else
                    {
                        t1 = matrix.Get(i - 1, j);
                        t2 = matrix.Get(i, j - 1);
                        t3 = matrix.Get(i - 1, j - 1);
                        value = Min3(t1, t2, t3);
                        matrix.Set(i, j, value + 1);
                    }
                }
            }
            Console.WriteLine();
            matrix.display();
            return matrix.Get(matrix.Rows - 1, matrix.Cols - 1);

        }


    }
}
