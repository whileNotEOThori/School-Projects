namespace Question_1;

public class Graph
{
    private List<Node> nodes;
    private List<Edge> edges;

    ///////////////////////////////////default constructor/////////////////////////////////////////
    public Graph()
    {
        nodes = new List<Node>();
        edges = new List<Edge>();
    }



    //////////////////////////////////////Getters and Setters/////////////////////////////////////////
    public List<Node> Nodes
    {
        get { return nodes; }
    }
    public List<Edge> Edges
    {
        get { return edges; }
    }
}
