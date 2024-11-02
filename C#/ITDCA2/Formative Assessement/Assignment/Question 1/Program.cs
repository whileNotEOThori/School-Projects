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
        //default constructor test
        Node a = new Node();
        Node b = new Node(2);
        Node c = new Node(b);

        Console.WriteLine($"node a:");
        Console.WriteLine($"\t data: {a.Data}");
        Console.WriteLine($"\t index: {a.Index}");


        Console.WriteLine($"node b:");
        Console.WriteLine($"\t data: {b.Data}");
        Console.WriteLine($"\t index: {b.Index}");

        Console.WriteLine($"node c:");
        Console.WriteLine($"\t data: {c.Data}");
        Console.WriteLine($"\t index: {c.Index}");
    }
}

