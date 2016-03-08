﻿// Simple weighted graph representation 
// Uses an Adjacency Linked Lists, suitable for sparse graphs

using System;
using System.IO;

class Graph
{
    class Stack
    {
        private int[] data;
        public int[] Data
        {
            get { return data; }
            set { data = value; }
        }

        public Stack()
        {
            this.data = new int[10];
        }

        public void display(Stack s)
        {
            Console.Write("\nStack Contents: ");
            for (int i = 0; i < s.data.Length; i++)
            {
                Console.Write(" " + s.data[i]);
            }
        }

        public int push(int x, Stack s, int top)
        {

            s.data[top] = x;
            top++;
            return top;
        }

        public int pop(Stack s, int top)
        {
            top--;
            return s.data[top];
        }
        public int pop(int top)
        {
            top--;
            return top;
        }
    }
    // class for linked list nodes needed, do yourself
    class Node
    {
        //class attributes.
        public int vert; //what data the node contains.
        public int wgt; // where the Node points to next.
        public Node next;
        public Node prev;
    }

    // Declare te following
    // V = number of vertices
    // E = number of edges
    // adj[] is the adjacency lists array
    private int V, E;
    private Node[] adj;

    // missing declaration here
    private Node z;

    // used for traversing graph
    private int[] visited;
    private int id;

    // default constructor, some code missing
    public Graph(string graphFile)
    {
        int u, v;
        int e, wgt;
        Node t;

        StreamReader reader = new StreamReader(graphFile);

        char[] splits = new char[] { ' ', ',', '\t' };
        string line = reader.ReadLine();
        string[] parts = line.Split(splits, StringSplitOptions.RemoveEmptyEntries);

        // find out number of vertices and edges
        V = int.Parse(parts[0]);
        E = int.Parse(parts[1]);

        // create sentinel node
        z = new Node();
        z.next = z;
        z.vert = int.MaxValue;

        // Create adjacency lists, initialised to sentinel node z
        // Dynamically allocate array 
        adj = new Node[V + 1];
        for (v = 1; v <= V; ++v)
        {
            adj[v] = new Node();
            adj[v].vert = v;
            adj[v].next = z;
        }
        Console.WriteLine("Reading edges from text file");
        for (e = 1; e <= E; ++e)
        {
            line = reader.ReadLine();
            parts = line.Split(splits, StringSplitOptions.RemoveEmptyEntries);
            u = int.Parse(parts[0]);
            v = int.Parse(parts[1]);
            wgt = int.Parse(parts[2]);

            Console.WriteLine("Edge {0}--({1})--{2}", toChar(u), wgt, toChar(v));
            // write code to put edge into adjacency lists     
            // do yourself
            t = new Node();
            t.vert = v;
            t.wgt = wgt;
            t.prev = adj[u];
            t.next = adj[u].next;
            adj[u].next = t;

            t = new Node();
            t.vert = u;
            t.wgt = wgt;
            t.prev = adj[v];
            t.next = adj[v].next;
            adj[v].next = t;
        }
    }

    // convert vertex into char for pretty printing
    private char toChar(int u)
    {
        return (char)(u + 64);
    }

    // method to display the graph representation
    public void display()
    {
        int v;
        Node n;

        for (v = 1; v <= V; ++v)
        {
            Console.Write("\nadj[{0}] ->", toChar(v));
            for (n = adj[v]; n != z; n = n.next)
            {
                Console.Write(" |{0} | {1}| ->", toChar(n.vert), n.wgt);
            }
            Console.WriteLine(" z");
        }
    }

    public void DF(int s, int top)
    {
        Stack stack = new Stack();

        int u, v;
        id = 0;
        visited = new int[V + 1];

        //Initialise all elements to be unvisited
        for (int i = 1; i < visited.Length; i++)
        {
            visited[i] = 0;
        }
        top = stack.push(s, stack, top);
        while (stack.Data.Length != 0)
        {
            v = stack.pop(stack, top);
            u = adj[v].next.vert;

            while (adj[v] != z)
            {
                if (visited[u] == 0)
                {
                    visited[v] = ++id;
                    stack.push(u, stack, top);
                    top++;
                    Console.Write("\nVisited Vertex " + toChar(u) + " along edge " + toChar(v) + "-" + toChar(u));
                    break;
                }
                else
                { 
                    u = adj[v].next.vert;
                    adj[v] = adj[v].next;
                    //top = stack.pop(top);
                }
             }
               

            /*
            else
            {
                //adj[v] = adj[v].next;
                top = stack.pop(top);
            }*/
       }
    }

    public static void Main()
    {
        int s = 4, top = 0;
        string fname = "wGraph3.txt";
        Graph g = new Graph(fname);

        g.display();

        g.DF(s, top);
    }

}

