using System.Collections.Generic;
using Question_1;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        /*Node<string> a = new Node<string>();
        Console.WriteLine(a.ToString());
        Console.WriteLine();

        a.Data = "Thoriso";
        Console.WriteLine(a.ToString());
        Console.WriteLine();

        Node<string> b = new Node<string>();
        b.Data = "Reneilwe";
        Console.WriteLine(b.ToString());
        Console.WriteLine();*/

        Graph<Node<string>> g = new Graph<Node<string>>();
        // g.AddNode(a);
        // g.AddNode(b);
        g.AddNode(new Node<string>());
        g.AddNode(new Node<string>());
        foreach (var node in g.Nodes)
        // for (int i = 0, j = g.Count; i < j; i++)
        {
            Console.WriteLine(node.ToString());
        }
        Console.WriteLine();

        Console.WriteLine($"{g.NodeCount}");
        Console.WriteLine();

        Console.WriteLine($"{g.Nodes[1].Data}");
        Console.WriteLine();

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