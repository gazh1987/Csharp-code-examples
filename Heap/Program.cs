
// Heap.cs
// Simple array based implementation of a Heap;

using System;
using System.Collections.Generic;

class Heap
{
    private int[] a;
    private int N;

    private static int hmax = 100;

    public Heap()
    {
        a = new int[hmax + 1];
        N = 0;
    }

    public Heap(int _hmax)
    {
        a = new int[_hmax + 1];
        N = 0;
    }


    public void insert(int x)
    {
        a[++N] = x;
        siftUp(N);
    }


    public void siftUp(int k)
    {
        int value = a[k];

        a[0] = int.MaxValue;
        while (value > a[k / 2])
        {
            a[k] = a[k / 2];
            //a[k/2] = value;
            k = k / 2;
        }
        a[k] = value;
    }

    
    public int remove()
    {
        int value = a[1];
        a[1] = a[N];
        a[N] = value;
        N--;
        siftDown(1);
        return value;
    }

    public void siftDown(int k)
    {
        int value = a[k];
        int j;
        while ((2*k) <= N)
        {
            j = 2 * k;

            //go right
            if (a[j] <= a[j + 1])
            {
                if (j + 1 != N+1)
                {
                    value = a[j + 1];
                    a[j + 1] = a[k];
                    a[k] = value;
                }
                k = j + 1;
            }
            //go Left
            else //if (a[j] > a[j+1])
            {
                if (j != N+1)
                {
                    value = a[j];
                    a[j] = a[k];
                    a[k] = value;
                }
                k = j;
            }
        }
    }

    public void display()
    {
        Console.WriteLine("{0}", a[1]);

        for (int i = 1; i <= N / 2; i = i * 2)
        {
            for (int j = 2 * i; j < 4 * i && j <= N; ++j)
                Console.Write("{0}  ", a[j]);
            Console.Write("\n");
        }
    }

}

class HeapTest
{
    static void Main(string[] args)
    {
        Heap h = new Heap();

        Random r = new Random();

        int i, x;
        for (i = 1; i < 20; ++i)
        {
            x = r.Next(99);
            Console.WriteLine("\nInserting {0} ", x);
            h.insert(x);
            h.display();
        }

        for (i = 1; i < 20; i++)
        {
            x = h.remove();
            Console.WriteLine("\nRemoving {0} ", x);
            h.display();
        }
        Console.WriteLine();
     

        Console.ReadKey();

    }
}