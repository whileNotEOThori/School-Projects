using Question_1;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Node_UnitTest();
    }

    ///////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////NODE TESTING/////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////
    static void Node_UnitTest()
    {
        //constructor test
        Node a = new Node();
        Node b = new Node(2);
        Node c = new Node(b);

        //getter and setter test
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
        Console.WriteLine($"\t neighbor count: {c.Neighbors.Count}");
        Console.WriteLine($"\t weight count: {c.Weights.Count}");

        //AddNeighbor and RemoveNeighbor test
        a.AddNeighbor(b);
        a.AddNeighbor(c);
        c.RemoveNeighbor(c);
        b.AddNeighbor(c);
        b.RemoveNeighbor(c);

        Console.WriteLine(a.ToString());
        Console.WriteLine(b.ToString());
        Console.WriteLine(c.ToString());

    }
}

