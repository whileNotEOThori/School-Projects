namespace Question_1;

public class Node<T>
{
    private int index { get; set; }
    private T data { get; set; }
    private List<Node<T>> adjacencies = new List<Node<T>>();
    private List<int> weights = new List<int>();

    public override string ToString()
    {
        return $"Node with index {index}: {data}, neighbors: {adjacencies.Count}";
    }

    public int Index
    {
        get { return index; }
        set { index = value; }
    }

    private T Data
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
