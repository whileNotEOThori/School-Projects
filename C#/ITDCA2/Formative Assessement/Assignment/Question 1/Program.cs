using Question_1;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(@"///////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////Main/////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////");
        Console.WriteLine();
        Node_UnitTest();

        Console.WriteLine();
        Edge_UnitTest();

        Graph_UnitTest();
        Console.WriteLine();

        Question_2();
        Console.WriteLine();

        Question_3();
        Console.WriteLine();

        Question_4();
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
    //////////////////////////////////////Edge TESTING/////////////////////////////////////////
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

    ///////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////Graph TESTING/////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////
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

        g.PrintNodes();
        g.PrintEdges();

        // Console.WriteLine($"{g.EdgeCount}.");
        // foreach (var edge in g.Edges)
        // {
        //     Console.WriteLine(edge.ToString());
        // }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////Question 2 TESTING/////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////
    static void Question_2()
    {

        Graph graph = new Graph();

        // string filename = getFileName();
        string filename = "graph.txt";

        // read all lines from text file
        graph.ReadFile(filename);

        List<Node> dfs = graph.DFS();
        List<Node> bfs = graph.BFS();

        Console.WriteLine(dfs.Count);
        Console.WriteLine(bfs.Count);

        foreach (var item in dfs)
            Console.WriteLine(item.Data);

        Console.WriteLine(dfs.Count);

        foreach (var item in bfs)
            Console.WriteLine(item.ToString());

        Console.WriteLine(bfs.Count);
    }

    static void Question_3()
    {
        Graph graph = new Graph();
        List<Edge> MST_Kruskal = new List<Edge>();

        string filename = getFileName();
        graph.ReadFile(filename);

        const int NUM_TIME_READINGS = 10;
        DateTime[] execution_times = new DateTime[NUM_TIME_READINGS];
        DateTime execution_start_time, execution_end_time;
        TimeSpan execution_time;
        string[] temp = new string[NUM_TIME_READINGS];


        for (int i = 0; i < NUM_TIME_READINGS; i++)
        {
            execution_start_time = DateTime.Now;

            MST_Kruskal = graph.MST_Kruskal();

            execution_end_time = DateTime.Now;
            execution_time = execution_end_time.Subtract(execution_start_time);//calculate execution time

            execution_times[i] = Convert.ToDateTime(execution_time);
            temp[i] = Convert.ToString(execution_time);


            //display MST
            foreach (var edge in MST_Kruskal)
            {
                Console.WriteLine(edge.ToString());
            }
        }

        File.WriteAllLines("kruskal.txt", temp);
    }

    static void Question_4()
    {
        Graph graph = new Graph();
        List<Edge> MST_Prim = new List<Edge>();

        string filename = getFileName();
        graph.ReadFile(filename);

        const int NUM_TIME_READINGS = 10;
        DateTime[] execution_times = new DateTime[NUM_TIME_READINGS];
        DateTime execution_start_time, execution_end_time;
        TimeSpan execution_time;
        string[] temp = new string[NUM_TIME_READINGS];


        for (int i = 0; i < NUM_TIME_READINGS; i++)
        {
            execution_start_time = DateTime.Now;

            MST_Prim = graph.MST_Prim();

            execution_end_time = DateTime.Now;
            execution_time = execution_end_time.Subtract(execution_start_time);//calculate execution time

            execution_times[i] = Convert.ToDateTime(execution_time);
            temp[i] = Convert.ToString(execution_time);


            //display MST
            foreach (var edge in MST_Prim)
            {
                Console.WriteLine(edge.ToString());
            }
        }

        File.WriteAllLines("prim.txt", temp);
    }

    static string getFileName()
    {
        Console.WriteLine("Enter file name with .txt extension");
        Console.Write("File name: ");
        string filename = Console.ReadLine();

        return filename;
    }
}