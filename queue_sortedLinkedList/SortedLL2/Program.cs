// Sorted linked list with a sentinel node
// Skeleton code
using System;

class SortedLL
{
    class Node
    {
        public int data;
        public Node next;
    }

    //private Node z;
    private Node head;

    public SortedLL()
    {
        head = new Node();
        head.next = head;
    }

    // this is the crucial method
    public void insert(int x)
    {
        Node prev, curr, temp;

        temp = new Node();

        prev = head;
        curr = head;
        temp.data = x;

        //If list is empty
        if (head == head.next)
        {
            head = temp;
            temp.next = head; //temp
            return;
        }

        //If belongs in first pos.
        if (temp.data < curr.data)
        {
            temp.next = curr;
            head = temp;
            return;
        }
        while (temp.data > curr.data)
        {
            prev = curr;
            curr = curr.next;
        }

        temp.next = curr;
        prev.next = temp;


    }

    public void display()
    {
        Node t = head;
        Console.Write("\nHead -> ");
        while (t != t.next)
        {
            Console.Write("{0} -> ", t.data);
            t = t.next;
        }
        Console.Write("Z\n");
    }

    public static void Main()
    {
        SortedLL list = new SortedLL();
        list.display();

        int i, x;
        Random r = new Random();

        for (i = 0; i < 10; ++i)
        {
            x = r.Next(20); //pick rndm variable
            list.insert(x); //insert it into the list
            Console.Write("\nInserting {0}", x);
            list.display();
        }
        Console.ReadKey();
    }
}