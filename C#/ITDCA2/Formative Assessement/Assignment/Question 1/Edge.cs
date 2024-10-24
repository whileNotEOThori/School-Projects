namespace Question_1;

public class Edge<T>
{
    private Node<T> sourceNode;
    private Node<T> destinationNode;
    private int weight;

    public override string ToString()
    {
        return $"Edge: {sourceNode.Data} ->	{destinationNode.Data}, weight: {Weight}";
    }

    public Node<T> SourceNode
    {
        get { return sourceNode; }
        set { sourceNode = value; }
    }
    public Node<T> DestinationNode
    {
        get { return destinationNode; }
        set { destinationNode = value; }
    }
    public int Weight
    {
        get { return weight; }
        set { weight = value; }
    }
}
