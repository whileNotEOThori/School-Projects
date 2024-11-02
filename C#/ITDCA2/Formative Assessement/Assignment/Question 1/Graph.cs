using System.Runtime.InteropServices.Marshalling;

namespace Question_1;

public class Graph<T>
{
    // In your implementation, graphs are not directional, but they are weighted. 
    private bool isDirected = false;
    private bool isWeighted = true;
    private List<Node<T>> nodes = new List<Node<T>>();
    private int nodeCount = 0;

    //Constructor 
    public Graph() //default values for this implementation
    {

    }

    public Edge<T> this[int sourceIndex, int destinationIndex]
    {
        get
        {
            Node<T> sourceNode = nodes[sourceIndex];
            Node<T> destinationNode = Nodes[destinationIndex];
            int i = sourceNode.Adjacencies.IndexOf(destinationNode);
            if (i >= 0)
            {
                Edge<T> edge = new Edge<T>();
                edge.SourceNode = sourceNode;
                edge.DestinationNode = destinationNode;
                edge.Weight = edge.SourceNode.Weights[i];
                return edge;
            }

            return null;  //if edge does not exist
        }
    }

    // Value based AddNode
    public void/* Node<T>*/ AddNode(T nodeValue)
    {
        Node<T> node = new Node<T>(); //create a new node
        node.Data = nodeValue; //set the data in the node
        nodes.Add(node); //adds node to the graph adjacency list
        UpdateIndices();
        nodeCount++;
        // return node;
    }

    //optional possibly remove
    //Node based AddNode Overload
    /*public Node<T> AddNode(Node<T> nodeToAdd)
    {
        nodes.Add(nodeToAdd); //adds node to the graph adjacency list
        UpdateIndices();
        return nodeToAdd;
    }*/

    public void RemoveNode(Node<T> nodeToRemove)
    {
        nodes.Remove(nodeToRemove);
        UpdateIndices();
        foreach (var node in nodes)
            RemoveEdge(node, nodeToRemove);
        nodeCount--;
    }

    public void AddEdge(Node<T> sourceNode, Node<T> destinationNode, int weight = 0)
    {
        sourceNode.Adjacencies.Add(destinationNode);
        sourceNode.Weights.Add(weight);
        destinationNode.Adjacencies.Add(sourceNode);
        destinationNode.Weights.Add(weight);
    }

    public void RemoveEdge(Node<T> sourceNode, Node<T> destinationNode)
    {
        int i = sourceNode.Adjacencies.IndexOf(destinationNode);

        if (i >= 0)
        {
            sourceNode.Adjacencies.RemoveAt(i);
            sourceNode.Weights.RemoveAt(i);
        }
    }

    public List<Edge<T>> GetEdges()
    {
        List<Edge<T>> edges = new List<Edge<T>>();
        Console.WriteLine("In GetEdges method");

        foreach (Node<T> node in this.Nodes)  //iterate through nodes
        {
            // Console.WriteLine($"loop: {node.ToString()}");
            Console.WriteLine(node.Adjacencies.Count);
            for (int i = 0; i < node.Adjacencies.Count; i++)  //iternate through each nodes adjacency list
            {
                Edge<T> edge = new Edge<T>();
                edge.SourceNode = node;  //assign edge source node
                edge.DestinationNode = edge.SourceNode.Adjacencies[i];  //assign edge's source destination(s)
                edge.Weight = edge.SourceNode.Weights[i]; //assign edge's source destination(s)' weight
                edges.Add(edge);
            }
        }
        return edges;
    }

    private void UpdateIndices()
    {
        int i = 0;
        foreach (Node<T> node in nodes)
        {
            node.Index = i;
            i++;
        }
    }

    public List<Node<T>> Nodes
    {
        get { return nodes; }
        set { nodes = value; }
    }

    public int NodeCount
    {
        get { return nodeCount; }
    }
}
