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
        Console.WriteLine($"\t weight count: {a.Weights.Count}");

        Console.WriteLine($"node b:");
        Console.WriteLine($"\t data: {b.Data}");
        Console.WriteLine($"\t index: {b.Index}");
        Console.WriteLine($"\t neighbor count: {b.Neighbors.Count}");
        Console.WriteLine($"\t weight count: {b.Weights.Count}");


        Console.WriteLine($"node c:");
        Console.WriteLine($"\t data: {c.Data}");
        Console.WriteLine($"\t index: {c.Index}");
        c.Data = 3;
        c.Index = 2;
        Console.WriteLine($"\t data: {c.Data}");
        Console.WriteLine($"\t index: {c.Index}");
        Console.WriteLine($"\t neighbor count: {c.Neighbors.Count}");
        Console.WriteLine($"\t weight count: {c.Weights.Count}");

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
        Node a = new Node();
        Node b = new Node(2);
        Node c = new Node(b);

        g.AddNode(a);
        g.AddNode(b);
        g.AddNode(c);

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

    }
}