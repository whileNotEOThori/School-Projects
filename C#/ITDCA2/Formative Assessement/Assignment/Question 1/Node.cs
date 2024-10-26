namespace Question_1;

public class Node<T>
{
    private int index; //index variable for easy node access. Nodes are labelled with integers
    private T data; //data storage variable
    private List<Node<T>> adjacencies = new List<Node<T>>(); //adjacency list
    private List<int> weights = new List<int>();

    //default constructor
    /*public Node()
    {
    }

    //value based constructor
    public Node(T dataValue)
    {
        data = dataValue;
    }*/

    public override string ToString()
    {
        return $"Node index: {index}\nNode data: {Convert.ToString(this.data)}\nNumber of node adjacencies: {adjacencies.Count}";
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
