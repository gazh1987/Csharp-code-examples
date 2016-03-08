using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericStack
{
    public class Stack<T>
    {
        T[] data;
        int capacity;
        int top = 0;

        public Stack(int capacity)
        {
            this.capacity = capacity;
            data = new T[capacity];
        }

        public void Push(T value)
        {
            if (top < capacity)
            {
                data[top++] = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Too many elements on the stack");
            }
        }

        public T Pop()
        {
            if (top > 0)
            {
                return data[--top];
            }
            else
            {
                throw new IndexOutOfRangeException("No elements on the stack");
            }
        }

        public T Top()
        {
            return data[top - 1];
        }
    }
}
