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
}

