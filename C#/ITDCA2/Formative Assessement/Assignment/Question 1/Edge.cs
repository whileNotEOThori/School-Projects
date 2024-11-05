namespace Question_1;

public class Edge
{
    private Node sourceNode;
    private Node destinationNode;
    private int weight;

    ////////////////////////////////////////constructor//////////////////////////////////////////////
    public Edge(Node source, Node destination, int w = 1) //1 default weight
    {
        sourceNode = source;
        destinationNode = destination;
        weight = w;
    }

    /////////////////////////////////////ToString Override////////////////////////////////////////
    public override string ToString()
    {
        string result = $"Source Node: {sourceNode.Data} -> Destination Node: {destinationNode.Data}, weight {weight}";
        return result;
    }

    //////////////////////////////////////Getters and Setters/////////////////////////////////////////
    public Node SourceNode
    {
        get { return sourceNode; }
    }
    public Node DestinationNode
    {
        get { return destinationNode; }
    }
    public int Weight
    {
        get { return weight; }
        set { weight = value; }
    }
}
