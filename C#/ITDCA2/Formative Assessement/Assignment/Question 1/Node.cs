namespace Question_1;

public class Node<T>
{
    private int index; //index variable for easy node access. Nodes are labelled with integers
    private T data; //data storage variable
    private List<Node<T>> adjacencies = new List<Node<T>>(); //adjacency list
    private List<int> weights = new List<int>();

    public override string ToString()
    {
        return $"Node index: {index}\nNode data: {data}\nNode adjacencies: {adjacencies.Count}";
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
