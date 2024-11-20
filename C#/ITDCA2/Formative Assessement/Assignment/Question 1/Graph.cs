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
        if (findNode(node) >= 0)
            Console.WriteLine($"Node already exists in the graph.");
        else
        {
            nodes.Add(node);
            updateIndices();
            Console.WriteLine($"Node added to the graph.");
        }
    }

    //////////////////////////////////////////REMOVE NODE/////////////////////////////////////////////
    public void RemoveNode(Node node)
    {
        if (findNode(node) >= 0)
        {
            nodes.Remove(node);
            updateIndices();
            for (int i = 0, length = NodeCount; i < length; i++)
                RemoveEdge(nodes[i], node);
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
        if (findNode(source) == -1 && findNode(destination) == -1)
        {
            Console.WriteLine($"Both nodes do not exist in the graph.");
            return;
        }
        else if (findNode(source) >= 0 && findNode(destination) == -1)
        {
            Console.WriteLine($"Destination node does not exist in the graph.");
            return;
        }
        else if (findNode(source) == -1 && findNode(destination) >= 0)
        {
            Console.WriteLine($"Source node does not exist in the graph.");
            return;
        }

        //create edge object
        Edge edge = new Edge(source, destination, weight);

        //check if edge exists
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
        if (findNode(source) == -1 && findNode(destination) == -1)
        {
            Console.WriteLine($"Both nodes do not exist in the graph.");
            return;
        }
        else if (findNode(source) >= 0 && findNode(destination) == -1)
        {
            Console.WriteLine($"Destination node does not exist in the graph.");
            return;
        }
        else if (findNode(source) == -1 && findNode(destination) >= 0)
        {
            Console.WriteLine($"Source node does not exist in the graph.");
            return;
        }

        //create edge object
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

    //////////////////////////////////////////REMOVE ALL EDGES/////////////////////////////////////////////
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
    public void PrintNodes()
    {
        Console.WriteLine($"{NodeCount}.");
        foreach (var node in nodes)
            Console.WriteLine(node.ToString());
    }

    //////////////////////////////////////////GET EDGES/////////////////////////////////////////////
    public void PrintEdges()
    {
        Console.WriteLine($"{EdgeCount}.");
        foreach (var edge in Edges)
            Console.WriteLine(edge.ToString());
    }

    //////////////////////////////////////////UPDATE INDICES/////////////////////////////////////////////
    private void updateIndices()
    {
        int i = 0;
        foreach (var node in nodes)
        {
            node.Index = i;
            i++;
        }
    }

    //////////////////////////////////////////findNODE/////////////////////////////////////////////
    private int findNode(Node node)
    {
        for (int i = 0, length = NodeCount; i < length; i++)//iterate through node list to check if node exists
            if (nodes[i].Data == node.Data)//compares node's attributes to each of the attributes of each node in the node list
                return i;
        return -1;//return index in node list or -1
    }

    //////////////////////////////////////////findEDGE/////////////////////////////////////////////
    private int findEdge(Edge edge)
    {
        for (int i = 0, length = EdgeCount; i < length; i++)//iterate through edge list to check if edge exists
            //compares edge's attributes to each of the attributes of each edge in the edge list
            if ((edges[i].SourceNode == edge.SourceNode) && (edges[i].DestinationNode == edge.DestinationNode))
                return i;
        return -1;//return index in edge list or -1
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

    ///////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////QUESTION 2 START/////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////
    #region QUESTION 2
    ////////////////////////////////////////DEPTH FIRST SEARCH///////////////////////////////////////////
    public void ReadFile(string filename)
    {
        string[] lines = File.ReadAllLines(filename);

        //extract number of nodes and number fo edges from the first 2 lines of the text file
        int NodeCount = Convert.ToInt32(lines[0]);
        int EdgeCount = Convert.ToInt32(lines[1]);

        //string array to store extracted source node , destination node and weight from line each line
        string[] line;

        for (int i = 2, length = lines.Length; i < length; i++)
        {
            line = lines[i].Split(' ');//extract data from line
            Node sourceNode = new Node(Convert.ToInt32(line[0]));
            Node destinationNode = new Node(Convert.ToInt32(line[1]));
            int weight = Convert.ToInt32(line[2]);

            this.AddNode(sourceNode);
            this.AddNode(destinationNode);
            this.AddEdge(sourceNode, destinationNode, weight);
        }
    }

    public List<Node> DFS()
    {
        bool[] isVisited = new bool[NodeCount];
        List<Node> result = new List<Node>();

        DFS_Helper(isVisited, nodes[0], result);

        return result;

        //expected output
        //DFS Visit Order: 1, 11, 18, 7, 12, 29, 39, 20, 40, 33, 35, 48, 44, 43, 45, 6, 36, 41, 49, 50, 10, 24, 37, 4, 17, 42, 46, 47, 3, 22, 25, 27, 34, 5, 14, 13, 9
        // DFS Order starting from node 1: 1, 11, 18, 2, 20, 12, 14, 37, 48, 8, 15, 31, 12, 7, 39, 41, 49, 50, 16, 24, 45, 36, 47, 50, 6, 43, 44, 18, 19, 27, 3, 22, 35, 16, 25, 13, 40, 30, 34, 45, 29, 32, 26, 9, 23, 17, 42
    }

    private void DFS_Helper(bool[] isVisited, Node node, List<Node> result)
    {
        if (!isVisited[node.Index])
        {
            result.Add(node);
            isVisited[node.Index] = true;
        }

        if (node.Neighbors.Count != 0)
            foreach (Node neighbor in node.Neighbors)
                if (!isVisited[neighbor.Index])
                    DFS_Helper(isVisited, neighbor, result);

        if (node.Index + 1 < NodeCount)
            DFS_Helper(isVisited, nodes[node.Index + 1], result);
    }

    ////////////////////////////////////////BREADTH FIRST SEARCH///////////////////////////////////////////
    public List<Node> BFS()
    {
        return BFS_Helper(nodes[0]);

        //expected output
        //BFS Visit Order: 1, 11, 18, 7, 12, 29, 39, 20, 40, 33, 35, 48, 44, 43, 45, 6, 36, 41, 49, 50, 10, 24, 37, 4, 17, 42, 46, 47, 3, 22, 25, 27, 34, 5, 14, 13, 9
        // BFS Order starting from node 1: 1, 11, 18, 20, 12, 5, 34, 25, 22, 6, 14, 27, 30, 10, 23, 17, 9, 47, 49, 43, 45, 38, 41, 36, 18, 39, 32, 29, 15, 48, 44, 33, 37, 28, 16, 26, 24, 21, 50, 46, 19, 31, 13, 40, 35, 42
    }

    private List<Node> BFS_Helper(Node node)
    {
        bool[] isVisited = new bool[NodeCount];
        isVisited[node.Index] = true;

        List<Node> result = new List<Node>();
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(node);
        while (queue.Count > 0)
        {
            Node next = queue.Dequeue();
            result.Add(next);

            foreach (Node neighbor in next.Neighbors)
            {
                if (!isVisited[neighbor.Index])
                {
                    isVisited[neighbor.Index] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }

        return result;
    }
    #endregion QUESTION 2
    ///////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////QUESTION 2 END/////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////

    ///////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////QUESTION 3 START/////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////
    #region QUESTION 3
    public List<Edge> MST_Kruskal()
    {
        edges.Sort((a, b) => a.Weight.CompareTo(b.Weight));
        Queue<Edge> queue = new Queue<Edge>(edges);

        Subset[] subsets = new Subset[NodeCount];

        for (int i = 0; i < NodeCount; i++)
            subsets[i] = new Subset() { Parent = Nodes[i] };

        List<Edge> result = new List<Edge>();

        while (result.Count < NodeCount - 1)
        {
            Edge edge = queue.Dequeue();
            Node sourceNode = GetRoot(subsets, edge.SourceNode);
            Node destinationNode = GetRoot(subsets, edge.DestinationNode);
            if (sourceNode != destinationNode)
            {
                result.Add(edge);
                Union(subsets, sourceNode, destinationNode);
            }
        }

        return result;
    }

    private Node GetRoot(Subset[] subsets, Node node)
    {
        if (subsets[node.Index].Parent != node)
            subsets[node.Index].Parent = GetRoot(subsets, subsets[node.Index].Parent);

        return subsets[node.Index].Parent;
    }

    private void Union(Subset[] subsets, Node a, Node b)
    {
        if (subsets[a.Index].Rank > subsets[b.Index].Rank)
            subsets[b.Index].Parent = a;
        else if (subsets[a.Index].Rank < subsets[b.Index].Rank)
            subsets[a.Index].Parent = b;
        else
        {
            subsets[b.Index].Parent = a;
            subsets[a.Index].Rank++;
        }
    }

    public class Subset
    {
        public Node Parent { get; set; }
        public int Rank { get; set; }
        public override string ToString()
        {
            return $"Subset	with rank {Rank}, parent: {Parent.Data} (index: {Parent.Index})";
        }
    }
    #endregion QUESTION 3
    ///////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////QUESTION 3 END/////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////

    ///////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////QUESTION 4 START/////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////
    #region  QUESTION 4
    public List<Edge> MST_Prim()
    {
        int[] previous = new int[NodeCount];
        previous[0] = -1;

        int[] minWeight = new int[NodeCount];
        Fill(minWeight, int.MaxValue);
        minWeight[0] = 0;

        bool[] isInMST = new bool[NodeCount];
        Fill(isInMST, false);

        for (int i = 0; i < NodeCount - 1; i++)
        {
            int minWeightIndex = GetMinimumWeightIndex(minWeight, isInMST);
            isInMST[minWeightIndex] = true;

            for (int j = 0; j < NodeCount; j++)
            {
                Edge edge = this[minWeightIndex, j];

                int weight;
                if (edge != null)
                    weight = edge.Weight;
                else
                    weight = -1;
                if (edge != null && !isInMST[j] && weight < minWeight[j])
                {
                    previous[j] = minWeightIndex;
                    minWeight[j] = weight;
                }
            }
        }

        List<Edge> result = new List<Edge>();
        for (int i = 1; i < NodeCount; i++)
        {
            Edge edge = this[previous[i], i];
            result.Add(edge);
        }
        return result;
    }

    private int GetMinimumWeightIndex(int[] weights, bool[] isInMST)
    {
        int minValue = int.MaxValue;
        int minIndex = 0;

        for (int i = 0; i < NodeCount; i++)
        {
            if (!isInMST[i] && weights[i] < minValue)
            {
                minValue = weights[i];
                minIndex = i;
            }
        }

        return minIndex;
    }

    private void Fill<Q>(Q[] array, Q value)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = value;
        }
    }

    #endregion QUESTION 4
    ///////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////QUESTION 4 END/////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////
}