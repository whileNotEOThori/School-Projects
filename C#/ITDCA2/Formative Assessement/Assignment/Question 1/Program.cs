using System.Collections;
using System.Collections.Generic;
using Question_1;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine
        (@"############################################################
#########################Program#######################
############################################################");

        Console.WriteLine();

        Node<int> a = new Node<int>();
        a.Data = 1;
        Console.WriteLine(a.ToString());
        Console.WriteLine();
        // Graph<Node<int>> g = new Graph<Node<int>>();


        // Node_UnitTest();
        // Console.WriteLine();

        Graph_UnitTest();
        Console.WriteLine();






        /*string fileName = getFileName();
        string[] lines = readFile(fileName);

        int numNodes = Convert.ToInt32(lines[0]);
        int numEdges = Convert.ToInt32(lines[1]);
        string[] line;


        for (int i = 2, length = lines.Length; i < length; i++)
        {
            line = lines[i].Split(' ');



        }*/


    }

    static void Node_UnitTest()
    {
        Console.WriteLine
        (@"############################################################
#########################Node Unit Test#######################
############################################################");
        Node<string> a = new Node<string>();
        Console.WriteLine(a.ToString());
        Console.WriteLine();

        a.Data = "Thoriso";
        Console.WriteLine(a.ToString());
        Console.WriteLine();

        Node<string> b = new Node<string>();
        b.Data = "Reneilwe";
        Console.WriteLine(b.ToString());
        Console.WriteLine();

        a.Adjacencies.Add(b);
        Console.WriteLine(a.ToString());
        Console.WriteLine();

        a.Adjacencies.Remove(b);
        Console.WriteLine(a.ToString());
        Console.WriteLine();
    }

    static void Edge_UnitTest()
    {
        Console.WriteLine
        (@"############################################################
        #########################Edge Unit Test#######################
        ############################################################");
    }

    static void Graph_UnitTest()
    {
        Console.WriteLine
        (@"############################################################
#########################Graph Unit Test#######################
############################################################");

        Graph<Node<int>> g = new Graph<Node<int>>();
        // g.AddNode(a);
        // g.AddNode(b);
        // g.AddNode(new Node<int>());
        // g.AddNode(new Node<int>());

        Node<int> a = new Node<int>();
        a.Data = 1;
        // Console.WriteLine(a.ToString());
        // Console.WriteLine();

        Node<int> b = new Node<int>();
        b.Data = 2;
        // Console.WriteLine(b.ToString());
        // Console.WriteLine();

        Node<int> c = new Node<int>();
        c.Data = 3;
        // Console.WriteLine(c.ToString());
        // Console.WriteLine();

        Node<int> d = new Node<int>();
        d.Data = 4;
        // Console.WriteLine(d.ToString());
        // Console.WriteLine();

        Node<int> e = new Node<int>();
        e.Data = 5;
        // Console.WriteLine(e.ToString());
        // Console.WriteLine();

        Node<int> f = new Node<int>();
        f.Data = 6;
        // Console.WriteLine(f.ToString());
        // Console.WriteLine();

        a.Adjacencies.Add(b);
        a.Weights.Add(5);
        a.Adjacencies.Add(c);
        a.Weights.Add(5);

        b.Adjacencies.Add(a);
        b.Weights.Add(5);

        c.Adjacencies.Add(a);
        c.Weights.Add(5);
        c.Adjacencies.Add(d);
        c.Weights.Add(7);

        d.Adjacencies.Add(c);
        d.Weights.Add(7);
        d.Adjacencies.Add(e);
        d.Weights.Add(8);
        d.Adjacencies.Add(f);
        d.Weights.Add(2);

        e.Adjacencies.Add(d);
        e.Weights.Add(8);
        e.Adjacencies.Add(f);
        e.Weights.Add(3);

        f.Adjacencies.Add(d);
        f.Weights.Add(2);
        f.Adjacencies.Add(e);
        f.Weights.Add(3);

        g.AddNode(a);
        g.AddNode(b);
        g.AddNode(c);
        g.AddNode(d);
        g.AddNode(e);
        g.AddNode(f);

        // foreach (var node in g.Nodes)
        for (int i = 0, j = g.NodeCount; i < j; i++)
        {
            // Console.WriteLine(node.ToString());
            // g.Nodes[i].Data = Convert.ToString(i);
            Console.WriteLine(g.Nodes[i].ToString());
            Console.WriteLine();
        }
        Console.WriteLine();

        Console.WriteLine($"{g.NodeCount}");
        Console.WriteLine();

        List<Edge<Node<int>>> edges = g.GetEdges();

        Console.WriteLine(edges.Count);

        for (int i = 0, count = edges.Count; i < count; i++)
        {
            // Console.WriteLine(edge.ToString());
            Console.WriteLine(i);
        }

        // g.AddEdge(a, b, 5);

        // Console.WriteLine($"{g.Nodes[1].Data}");
        // Console.WriteLine();
    }

    static string getFileName()
    {
        string file;
        Console.WriteLine("Enter the name of the text file with  the extension (.txt) you would like to read from.");
        Console.Write("Enter file: ");
        file = Console.ReadLine();

        return file;

    }

    static string[] readFile(string fileName)
    {
        if (File.Exists(fileName))
            return File.ReadAllLines(fileName);
        else
            return null;
    }
}

/*Write a graph implementation in C#. 
Remember that graphs also require a Node and Edge class, which you must implement as well. 
In your implementation, graphs are not directional, but they are weighted. 
Nodes are labelled with integers.*/

//DFS + BFS 
// https://www.simplilearn.com/tutorials/c-sharp-tutorial/what-is-graphs-in-c-sharp
// https://masterdotnet.com/csharp/ds/graphincsharp/
// https://medium.com/@konduruharish/graphs-in-typescript-and-c-7cce9ea72476