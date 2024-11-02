namespace Question_1;

public class Node
{
    private int data;
    private int index;
    private List<Node> neighbors;
    private List<int> weights;

    ///////////////////////////////////default constructor/////////////////////////////////////////
    public Node()
    {
        neighbors = new List<Node>();
        weights = new List<int>();
    }

    ///////////////////////////////////value based constructor/////////////////////////////////////////
    public Node(int value)
    {
        data = value;
        neighbors = new List<Node>();
        weights = new List<int>();
    }


    ///////////////////////////////////node based copy constructor//////////////////////////////////////
    public Node(Node node)
    {
        data = node.Data;
        index = node.Index;
        neighbors = new List<Node>();
        weights = new List<int>();
    }

    //////////////////////////////////////////ADD NEIGHBOR/////////////////////////////////////////////
    public void AddNeighbor(Node node)
    {
        if (!neighbors.Contains(node))
        {
            neighbors.Add(node);
            Console.WriteLine("Node added as a neighbor.");
            return;
        }

        Console.WriteLine("Node is already a neighbor.");
    }

    ////////////////////////////////////////REMOVE NEIGHBOR////////////////////////////////////////////
    public void RemoveNeighbor(Node node)
    {
        if (neighbors.Contains(node))
        {
            neighbors.Remove(node);
            Console.WriteLine("Node removed as a neighbor.");
            return;
        }

        Console.WriteLine("Node is not a neighbor.");
    }

    //////////////////////////////////////Getters and Setters/////////////////////////////////////////
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

    public List<Node> Neighbors
    {
        get { return neighbors; }
    }
    public List<int> Weights
    {
        get { return weights; }
    }

}
