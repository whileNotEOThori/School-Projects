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
    public void AddEdge(Node source, Node destination, int weight)
    {
        // check if nodes exist in graph
        if (nodes.Contains(source) == false && nodes.Contains(destination) == false)
        {
            Console.WriteLine($"Both nodes do not exist in the graph.");
            return;
        }
        else if (nodes.Contains(source) == true && nodes.Contains(destination) == false)
        {
            Console.WriteLine($"Destination node does not exist in the graph.");
            return;
        }
        else if (nodes.Contains(source) == false && nodes.Contains(destination) == true)
        {
            Console.WriteLine($"Source node does not exist in the graph.");
            return;
        }

        //create edge object
        Edge edge = new Edge(source, destination, weight);

        //iterate through edge list to check if edge exists
        // foreach (var temp in edges)
        // {
        //     //check if edge exists
        //     // if (temp.Equals(edge))
        //     if ((temp.SourceNode == edge.SourceNode) && (temp.DestinationNode == edge.DestinationNode) && (temp.Weight == edge.Weight))
        //     {
        //         Console.WriteLine($"An edge between the nodes already exist in the graph.");
        //         return;
        //     }
        // }

        //check if edge exists
        // if (edges.Contains(edge))
        // if (edges.IndexOf(edge) >= 0)
        if (findEdge(edge) >= 0)
        {
            Console.WriteLine($"An edge between the nodes already exist in the graph.");
            return;
        }

        source.AddNeighbor(destination);
        destination.AddNeighbor(source);
        edges.Add(edge);
        Console.WriteLine($"Edge created in the in the graph.");
    }

    //////////////////////////////////////////REMOVE EDGE/////////////////////////////////////////////
    public void RemoveEdge(Node source, Node destination)
    {
        // check if nodes exist in graph
        if (nodes.Contains(source) == false && nodes.Contains(destination) == false)
        {
            Console.WriteLine($"Both nodes do not exist in the graph.");
            return;
        }
        else if (nodes.Contains(source) == true && nodes.Contains(destination) == false)
        {
            Console.WriteLine($"Destination node does not exist in the graph.");
            return;
        }
        else if (nodes.Contains(source) == false && nodes.Contains(destination) == true)
        {
            Console.WriteLine($"Source node does not exist in the graph.");
            return;
        }

        //create edge object
        // Edge edge = new Edge(source, destination);
        int edgeIndex = findEdge(new Edge(source, destination));

        //check if edge exist
        if (edgeIndex == -1)
        {
            Console.WriteLine($"An edge between the nodes does not exist in the graph.");
            return;
        }

        edges.RemoveAt(edgeIndex);
        source.RemoveNeighbor(destination);
        destination.RemoveNeighbor(source);
        Console.WriteLine($"Edge removed from the graph.");
    }

    //////////////////////////////////////////REOMVE ALL EDGES/////////////////////////////////////////////
    public void RemoveAllEdges()
    {
        if (EdgeCount == 0)
            Console.WriteLine("Graph has no edges to remove.");
        else
        {
            for (int i = EdgeCount - 1; i >= 0; i--)
                edges.Remove(edges[i]);

            Console.WriteLine("All edges removed from the graph.");
        }
    }

    //////////////////////////////////////////GET NODES/////////////////////////////////////////////

    //////////////////////////////////////////GET EDGES/////////////////////////////////////////////

    //////////////////////////////////////////UPDATE INDICES/////////////////////////////////////////////

    //////////////////////////////////////////findEDGE/////////////////////////////////////////////
    public int findEdge(Edge edge)
    {//return index in edge list or -1
        //iterate through edge list to check if edge exists
        for (int i = 0, length = edges.Count; i < length; i++)
            //compares edge's attributes to each of the attributes of each edge in the edge list
            if ((edges[i].SourceNode == edge.SourceNode) && (edges[i].DestinationNode == edge.DestinationNode) /*&& (edges[i].Weight == edge.Weight)*/)
                return i;
        return -1;
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

    public int NodeCount
    {
        get { return nodes.Count; }
    }

    public int EdgeCount
    {
        get { return edges.Count; }
    }
}
