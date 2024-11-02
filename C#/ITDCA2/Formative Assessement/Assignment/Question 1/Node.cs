namespace Question_1;

public class Node
{
    private int data;
    private int index;
    private List<Node> neighbors;
    private List<int> weights;

    //default constructor
    public Node()
    {
        neighbors = new List<Node>();
        weights = new List<int>();
    }

    //value based constructor
    public Node(int value)
    {
        data = value;
        neighbors = new List<Node>();
        weights = new List<int>();
    }

    //node based copy constructor
    public Node(Node node)
    {
        data = node.Data;
        index = node.Index;
        neighbors = new List<Node>();
        weights = new List<int>();
    }

    public int Data
    {
        get { return data; }
        set { data = value; }
    }
    public int Index
    {
        get { return index; }
        set { index = value; }
    }

}
