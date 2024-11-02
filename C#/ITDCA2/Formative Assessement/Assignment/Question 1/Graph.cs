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

    //////////////////////////////////////////ADD NODE/////////////////////////////////////////////
    public void AddNode(Node node)
    {
        if (nodes.Contains(node))
            Console.WriteLine($"Node already exists in the graph.");
        else
        {
            nodes.Add(node);
            Console.WriteLine($"Node added to the graph.");
        }
    }

    //////////////////////////////////////////REMOVE NODE/////////////////////////////////////////////
    public void RemoveNode(Node node)
    {
        if (nodes.Contains(node))
        {
            nodes.Remove(node);
            Console.WriteLine($"Node removed from the graph.");
        }
        else
            Console.WriteLine($"Node does not exists in the graph.");
    }

    //////////////////////////////////////////REMOVE ALL NODES/////////////////////////////////////////////
    public void RemoveAllNodes()
    {
        if (NodeCount == 0)
            Console.WriteLine("Graph has no nodes to remove.");
        else
        {
            for (int i = NodeCount - 1; i >= 0; i--)
                nodes.Remove(nodes[i]);

            Console.WriteLine("All nodes removed from the graph.");
        }
    }

    //////////////////////////////////////////ADD EDGE/////////////////////////////////////////////

    //////////////////////////////////////////REMOVE EDGE/////////////////////////////////////////////

    //////////////////////////////////////////REOMVE EDGES/////////////////////////////////////////////

    //////////////////////////////////////////GET NODES/////////////////////////////////////////////

    //////////////////////////////////////////GET EDGES/////////////////////////////////////////////

    //////////////////////////////////////////UPDATE INDICES/////////////////////////////////////////////

    //////////////////////////////////////Getters and Setters/////////////////////////////////////////
    public List<Node> Nodes
    {
        get { return nodes; }
    }

    public List<Edge> Edges
    {
        get { return edges; }
    }

    public int NodeCount
    {
        get { return nodes.Count; }
    }

    public int EdgeCount
    {
        get { return edges.Count; }
    }
}
