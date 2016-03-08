using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minimum_Edit_Distance
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "ImagineCup";
            string b = "IXXXineCup";
            float c = 0;

            c = EditDistance.MinimumEditDistance(a, b);
        }
    }
}
