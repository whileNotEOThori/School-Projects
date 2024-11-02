
namespace Question_1;

public class Node<T>
{
    private int index; //index variable for easy node access. Nodes are labelled with integersN
    private T data; //data storage variable
    private List<Node<T>> adjacencies; //adjacency list
    private List<int> weights;

    //default constructor
    public Node()
    {
        adjacencies = new List<Node<T>>();
        weights = new List<int>();
    }

    //value based constructor
    public Node(T dataValue)
    {
        data = dataValue;
        adjacencies = new List<Node<T>>();
        weights = new List<int>();
    }

    public override string ToString()
    {
        // {Convert.ToString(this.data)} insert in data line
        // this.
        return $"Node index: {this.index}\nNode data: {Convert.ToString(this.N)}\nNumber of node adjacencies: {this.adjacencies.Count}";
        // return Convert.ToString(data);
    }

    public int Index
    {
        get { return index; }
        set { index = value; }
    }

    public T Data
    {
        get { return data; }
        set { data = value; }
    }

    public List<Node<T>> Adjacencies
    {
        get { return adjacencies; }
        set { adjacencies = value; }
    }

    public List<int> Weights
    {
        get { return weights; }
        set { weights = value; }
    }

}
