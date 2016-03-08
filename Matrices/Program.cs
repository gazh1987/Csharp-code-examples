using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrices
{
    class Program
    {
        static void Main(string[] args)
        {
            CMatric ma = new CMatric(3, 2);
            CMatric mb = new CMatric(2, 4);

            ma.Randomise();
            mb.Randomise();

            CMatric mc = ma * mb;

            Console.WriteLine("MA");
            ma.display();
            Console.WriteLine();
            Console.WriteLine("MB");
            mb.display();
            Console.WriteLine();
            Console.WriteLine("MC = MA * MB");
            mc.display();
        }
    }
}
