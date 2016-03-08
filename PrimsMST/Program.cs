// Prim's MST Algorithm on Adjacency Lists representation 
// Uses an Adjacency Linked Lists, suitable for sparse graphs
// PrimSparse.cs

using System;
using System.IO;

 //Heap code to be adapted for Prim's algorithm
 //on adjacency lists graph
class Heap
{
    public int[] h;	   // heap array
    private int[] hPos;	   // hPos[h[k]] == k
    private int[] dist;// dist[v] = priority of v
    private int[] parent;

    private int N; // heap size

    // The heap constructor gets passed from the Graph:
    //    1. maximum heap size
    //    2. reference to the dist[] array
    //    3. reference to the hPos[] array
    public Heap(int maxSize, int[] _dist, int[] _hPos)
    {
        N = 0; //Makes the size of the heap 0
        h = new int[maxSize + 1]; //makes the max size of the heap 8
        dist = _dist; //passes in the dist array, all elements initialised to int.maxvalue
        hPos = _hPos; //passes in the hpos array, all elements initialised to 0
    }

    public void display()
    {
        Console.WriteLine("{0}", h[1]);

        for (int i = 1; i <= N / 2; i = i * 2)
        {
            for (int j = 2 * i; j < 4 * i && j <= N; ++j)
                Console.Write("{0}  ", h[j]);
            Console.Write("\n");
        }
    }

    public bool isEmpty()
    {
        return N == 0;
    }


    public void siftUp(int k) 
    {
        int v = h[k];

        h[0] = 0;  // put dummy vertex before top of heap
        dist[0] = int.MinValue; //and dist array

        while (dist[v] < dist[h[k / 2]])  //while v is greater than the element in pos h[k / 2]
        {
            h[k] = h[k / 2]; //place element at pos h[k/2] into h[k]
            hPos[h[k]] = k; //update the hpos array
            k = k / 2; //divide k by 2
        }
        h[k] = v; //put v into the h array at value k
        hPos[v] = k; //update the hpos array to show what position in the heap we are at
    }

    public void siftDown(int k)
    {
        int value = h[k]; //sift down value at the top of the heap
        int j;
        while ((2 * k) <= N) //while the value is < = N
        {
            j = 2 * k;

            if ((j < N && (dist [h[j + 1]] < dist[h[j]])))
            {
                ++j;
            }
            if (dist[value] <= dist[h[j]])
            {
                break;
            }
            h[k] = h[j];
            hPos[h[k]] = k;
            k = j;
        }
        h[k] = value;
        hPos[value] = k;
    }

    public void insert(int x)
    {
        h[++N] = x; //place x in the h array in pos ++N
        siftUp(N); //sift up at this position
    }

    public int remove()
    {
        int value = h[1]; //value == top of the heap
        h[1] = h[N]; 
        h[N] = value; //Swap the top of the heap and the last element in the heap 
        N--; // Decrement N so last element is gone
        siftDown(1); //Sift down from element 1
        return value;
    }
}  // end of Heap class


// Graph code to support Prim's MSt Alg
class Graph
{
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

     //Prim's algorithm to compute MST
     //Code most of this yourself
    int[] MST_Prim(int s)
    {
        int v, u;
        int wgt_sum = 0;
        int[] dist, parent, hPos; 
        Boolean isin = false;

        dist = new int[V + 1];
        parent = new int[V + 1];
        hPos = new int[V + 1];

        for (v = 0; v < V + 1; v ++)
        {
            dist[v] = int.MaxValue; //initialise all dist array to be the max value of an int
            parent[v] = 0; //initialise all parent array to 0
            hPos[v] = 0; //initialise all hpos array to 0
        }

        Heap h = new Heap(V, dist, hPos); //initialise the heap
        h.insert(s); //insert the first vertex on the heap
        dist[s] = 0;//make the distance to the first stop in our traversal == 0 (eg, there is no distance between A and A)

        while (!h.isEmpty()) //While h is not empty
        {
            v = h.remove(); //remove the element at the top of the heap and place in v
            dist[v] = -dist[v];
            while (adj[v].next != z) //Examine all the neighbours of v
            {
                u = adj[v].next.vert; //u is the name of the next vertex
                if (weight(v, u) < dist[u]) //if the distance between this vertex and the next is less than the element stored in the dist array at element u
                {
                    dist[u] = weight(v, u); //make the element at the dist array u be the distance between the vertexes
                    parent[u] = v; //and make the parent array at element u correspond to the number of the vertex this one is connected to
                    for (int i = 0; i < h.h.Length; i++)
                    {
                        if (u == h.h[i]) //if vertex u is in the heap
                        {
                            isin = true; //set the isin flag
                        }   
                    }
                    if (isin == false) //if the is in flag is not set
                    {
                        h.insert(u); //place u in the heap
                    }
                    else
                    {
                        //Else sift up from hpos[u]
                        h.siftUp(hPos[u]);
                        //reset the flag
                        isin = false;
                    }
                }
                adj[v] = adj[v].next;
            }

            Console.Write("\nAdding to MST edge {0}--({1})--{2}", toChar(parent[v]), dist[v], toChar(v));
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine("====");
            //Console.WriteLine("Heap");
            //Console.WriteLine("====");
            //h.display();
            wgt_sum += -dist[v];
        }
        Console.Write("\n\nWeight of MST = {0}\n", wgt_sum);

        return parent;
    }


    public void showMST(int[] mst)
    {
        Console.Write("\n\nMinimum Spanning tree parent array is:\n");
        for (int v = 1; v <= V; ++v)
            Console.Write("{0} -> {1}\n", toChar(v), toChar(mst[v]));
        Console.WriteLine("");
    }

    //Find the weight of the next Vertex
    public int weight(int curr, int next)
    {
        int wgt = adj[curr].next.wgt;
        return wgt;
    }

    public static void Main()
    {
        int s = 3;
        int[] mst;
        string fname = "wGraph3.txt";

        Graph g = new Graph(fname);

        g.display();

        mst = g.MST_Prim(s);

        g.showMST(mst);
    }

} // end of Graph class


