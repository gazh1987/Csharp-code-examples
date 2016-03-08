using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generic_Class_Example
{
    class Test <T>
    {
        T value;

        public Test(T t)
        {
            this.value = t;
        }

        //Formats the String
        public override string ToString()
        {
            return  value+"";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Test<int> test1 = new Test<int>(5);
            Console.WriteLine(test1);

            Test<string> test2 = new Test<string>("hello");
            Console.WriteLine(test2);
        }
    }
}
