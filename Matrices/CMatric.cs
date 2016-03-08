using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrices
{
    class CMatric
    {
        //Properties and Fields
        private float[,] elements;
        private int rows;
        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        private int cols;

        public int Cols
        {
            get { return cols; }
            set { cols = value; }
        }

        //Constructor
        public CMatric(int r, int c)
        {
            this.Rows = r;
            this.Cols = c;
            elements = new float[Rows, Cols];
        }

        //Get Method
        public float Get(int row, int col)
        {
            float r;
            r = elements[row, col];
            return r;
        }

        //Set Method
        public void Set(int row, int col, float value)
        {
            elements[row, col] = value;
        }

        public void Randomise()
        {
            Random rnd = new Random();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    elements[i, j] = rnd.Next(0, 9);
                }
            }
        }

        //Identity Matrix Method
        public CMatric Identity()
        {
            CMatric identity = new CMatric(Rows, Cols);
            int marker = 0;

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if (j == marker)
                    {
                        identity.Set(i, j, 1);
                    }
                    else
                    {
                        identity.Set(i, j, 0);
                    }
                }
                marker++;
            }
            return identity;
        }

        public void display()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write(elements[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }


        //Operator overloaded * operator that multiplies two matrices
        public static CMatric operator *(CMatric ma, CMatric mb)
        {
            CMatric mc = new CMatric(ma.Rows, mb.Cols);
            if (ma.Cols != mb.Rows)
            {
                Console.WriteLine("Unable to multiply Matrices");
                return mc;
            }
            else
            {
                for (int i = 0; i < mc.Rows; i++)
                {
                    for (int j = 0; j < mc.Cols; j++)
                    {
                        mc.elements[i, j] = 0;
                        for (int k = 0; k < ma.Cols; k++)
                        {
                            mc.elements[i, j] += ma.elements[i, k] * mb.elements[k, j];
                        }
                    }
                }
                return mc;
            }
        }
    }
}
