// Sorted linked list with a sentinel node
// Skeleton code
using System;

class SortedLL
{
    class Node //declare class Node.
    {
        //class attributes.
        public int data; //what data the node contains.
        public Node next; // where the Node points to next.
    }

    private Node z; //The sentinal node.
    private Node head; //the head node.

    //Constructor: called once at the beginning of the program. 
    public SortedLL()
    {
        z = new Node(); //initialise an instance of the node
        z.next = z; //make it point to itself to indicate there is only one node in the liat
        head = z; //make that node the head node
        z.data = int.MaxValue; //set the data inside it to be the largest value possible, so as no other node can be bigger than it. 
    }

    // this is the crucial method
    public void insert(int x)
    {
        Node prev, curr, temp; //initialise 3 nodes

        temp = new Node(); //make the temp node a new node.

        prev = head; //make the prev node a copy of the head node
        curr = head; // and the curr node a copy of the head node
        temp.data = x; //make the data for the temp node be the value inported into this method

        //If list is empty
        if (head == head.next) //if the head node points to itself there must be only one value in the list
        {
            head = temp; //make the temp node the head node
            temp.next = z; // have the head node point to the sentinal node z
            return; 
        }

        //If belongs in first pos.
        if (temp.data <= curr.data) //if the temp data is lower or the same as the curr dasta (curr is a copy of the head node so this means the temp data is the lowest value in the list)
        {
            temp.next = curr; //make temp point to curr
            head = temp; // and make the newly inserted temp node the head
            return;
        }

        //if the node belongs anywhere else in the list
        while (temp.data > curr.data) //while the temp data is greater than the node it is ponting too
        {
            //here is where we iterate the list
            prev = curr; //make the current node the prev node. This increments the prev node in the list.
            curr = curr.next; //make the curr node the node after curr. This increments the curr node in the list.
        } //keep iterating through the list until temp.data is < curr.data. When this statement is through this is where we put the temp node.

        //Placing the temp node in the list
        temp.next = curr; //make temp.next point to the curr node (ie the curr node is the node that was bigger than temp.
        prev.next = temp; //And then make the prev.next node point to the temp. 


    }

    public void display()
    {
        Node t = head;
        Console.Write("\nHead -> ");
        while (t != z)
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