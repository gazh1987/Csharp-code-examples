using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericStack
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Stack<int> stack = new Stack<int>(10);

                stack.Push(10);
                stack.Push(16);
                stack.Push(24);

                Console.WriteLine(stack.Pop());
                Console.WriteLine(stack.Pop());
                Console.WriteLine(stack.Pop());
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.StackTrace);
            }

            try
            {
                Stack<string> stack = new Stack<string>(10);

                stack.Push("Gary");
                stack.Push("Stefan");
                stack.Push("Frank");

                Console.WriteLine(stack.Pop());
                Console.WriteLine(stack.Pop());
                Console.WriteLine(stack.Pop());
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}