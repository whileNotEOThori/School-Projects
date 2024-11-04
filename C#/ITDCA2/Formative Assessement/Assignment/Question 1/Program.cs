using Question_1;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(@"///////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////Main/////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////");
        // Console.WriteLine();
        // Node_UnitTest();

        // Console.WriteLine();
        // Edge_UnitTest();

        Graph_UnitTest();
        Console.WriteLine();
    }

    ///////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////NODE TESTING/////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////
    static void Node_UnitTest()
    {
        Console.WriteLine(@"///////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////NODE UNIT TESTING/////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////");
        Console.WriteLine();

        //constructor test
        Console.WriteLine("///////////////////////////////////constructor test///////////////////////////////////");
        Node a = new Node();
        Node b = new Node(2);
        Node c = new Node(b);

        //getter and setter test
        Console.WriteLine("///////////////////////////////////getter and setter test///////////////////////////////////");
        Console.WriteLine($"node a:");
        Console.WriteLine($"\t data: {a.Data}");
        Console.WriteLine($"\t index: {a.Index}");
        Console.WriteLine($"\t neighbor count: {a.Neighbors.Count}");

        Console.WriteLine($"node b:");
        Console.WriteLine($"\t data: {b.Data}");
        Console.WriteLine($"\t index: {b.Index}");
        Console.WriteLine($"\t neighbor count: {b.Neighbors.Count}");

        Console.WriteLine($"node c:");
        Console.WriteLine($"\t data: {c.Data}");
        Console.WriteLine($"\t index: {c.Index}");
        c.Data = 3;
        c.Index = 2;
        Console.WriteLine($"\t data: {c.Data}");
        Console.WriteLine($"\t index: {c.Index}");
        Console.WriteLine($"\t neighbor count: {c.Neighbors.Count}");

        //AddNeighbor and RemoveNeighbor test
        Console.WriteLine("///////////////////////////////////AddNeighbor and RemoveNeighbor test///////////////////////////////////");
        a.AddNeighbor(b);
        a.AddNeighbor(c);
        c.RemoveNeighbor(c);
        b.AddNeighbor(c);
        b.RemoveNeighbor(c);

        //ToString test
        Console.WriteLine("///////////////////////////////////ToString test///////////////////////////////////");
        Console.WriteLine(a.ToString());
        Console.WriteLine(b.ToString());
        Console.WriteLine(c.ToString());

        //RemoveAllNeighbors test
        Console.WriteLine("///////////////////////////////////RemoveAllNeighbors test///////////////////////////////////");
        b.RemoveAllNeighbors();
        // Console.WriteLine(b.ToString());
        a.RemoveAllNeighbors();
        // Console.WriteLine(a.ToString());
    }

    ///////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////NODE TESTING/////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////
    static void Edge_UnitTest()
    {
        Console.WriteLine(@"///////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////EDGE UNIT TESTING/////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////");
        Console.WriteLine();

        Node a = new Node();
        Node b = new Node(2);
        Node c = new Node(b);

        //constructor test
        Console.WriteLine("///////////////////////////////////constructor test///////////////////////////////////");
        Edge x = new Edge(a, b, 4);
        Edge y = new Edge(a, c, 2);


        Console.WriteLine("///////////////////////////////////getters and setters test///////////////////////////////////");
        List<Edge> edges = new List<Edge>();
        edges.Add(x);
        edges.Add(y);

        foreach (var edge in edges)
        {
            Console.WriteLine($"Source:");
            Console.WriteLine(edge.SourceNode.ToString());
            Console.WriteLine($"Destination:");
            Console.WriteLine(edge.DestinationNode.ToString());
            Console.Write($"Weight:");
            Console.WriteLine(edge.Weight);

        }

        Console.WriteLine("///////////////////////////////////ToString test///////////////////////////////////");
        foreach (var edge in edges)
        {
            Console.WriteLine(edge.ToString());
        }
    }

    static void Graph_UnitTest()
    {
        Console.WriteLine(@"///////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////Graph UNIT TESTING/////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////");
        Console.WriteLine();

        Console.WriteLine("///////////////////////////////////constructor test///////////////////////////////////");
        Graph g = new Graph();

        Console.WriteLine();

        Console.WriteLine("///////////////////////////////////getters and setters test///////////////////////////////////");
        Console.WriteLine($"Node count: {g.Nodes.Count}");
        Console.WriteLine($"Node count: {g.Edges.Count}");

        Console.WriteLine();

        Console.WriteLine("///////////////////////////////////AddNode test///////////////////////////////////");
        Node a = new Node(1);
        Node b = new Node(2);
        Node c = new Node(3);

        g.AddNode(a);
        g.AddNode(b);
        g.AddNode(c);
        g.AddNode(a);

        Console.WriteLine($"Node count: {g.NodeCount}");

        Console.WriteLine();

        Console.WriteLine("///////////////////////////////////RemoveNode test///////////////////////////////////");
        g.RemoveNode(c);
        Console.WriteLine($"Node count: {g.NodeCount}");

        Console.WriteLine();

        Console.WriteLine("///////////////////////////////////RemoveAllNode test///////////////////////////////////");
        g.RemoveAllNodes();
        Console.WriteLine($"Node count: {g.NodeCount}");

        Console.WriteLine();

        Node d = new Node(4);
        Node e = new Node(5);
        Node f = new Node(6);
        g.AddNode(a);
        g.AddNode(b);
        g.AddNode(c);
        // g.AddNode(d);
        // g.AddNode(e);
        // g.AddNode(f);
        Console.WriteLine($"Node count: {g.NodeCount}");
        // a.AddNeighbor(b);
        // a.AddNeighbor(c);

        Console.WriteLine("///////////////////////////////////AddEdge test///////////////////////////////////");
        Console.WriteLine("a,b");
        g.AddEdge(a, b, 2);
        Console.WriteLine("a,c");
        g.AddEdge(a, c, 2);//
        Console.WriteLine("b,c");
        g.AddEdge(b, c, 2);
        Console.WriteLine("c,b");
        g.AddEdge(c, b, 2);
        Console.WriteLine("e,f");
        g.AddEdge(e, f, 2);
        Console.WriteLine("a,f");
        g.AddEdge(a, f, 2);
        Console.WriteLine("f,b");
        g.AddEdge(f, b, 2);
        Console.WriteLine("a,b again---check if edge exists");
        g.AddEdge(a, b, 2);
        Console.WriteLine();

        Console.WriteLine($"{g.EdgeCount}.");


        foreach (var edge in g.Edges)
        {
            Console.WriteLine(edge.ToString());
        }

        Console.WriteLine("///////////////////////////////////RemoveEdge test///////////////////////////////////");
        g.RemoveEdge(b, c);
        g.RemoveEdge(c, b);

        Console.WriteLine($"{g.EdgeCount}.");
        foreach (var edge in g.Edges)
        {
            Console.WriteLine(edge.ToString());
        }

        Console.WriteLine("///////////////////////////////////RemoveAllEdge test///////////////////////////////////");
        g.RemoveAllEdges();

        g.getNodes();
        g.getEdges();

        // Console.WriteLine($"{g.EdgeCount}.");
        // foreach (var edge in g.Edges)
        // {
        //     Console.WriteLine(edge.ToString());
        // }
    }
}