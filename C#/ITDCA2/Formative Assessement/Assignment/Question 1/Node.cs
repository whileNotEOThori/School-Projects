﻿namespace Question_1;

public class Node
{
    private int data;
    private int index;
    private List<Node> neighbors;

    ///////////////////////////////////default constructor/////////////////////////////////////////
    public Node()
    {
        neighbors = new List<Node>();
    }

    ///////////////////////////////////value based constructor/////////////////////////////////////////
    public Node(int value)
    {
        data = value;
        neighbors = new List<Node>();
    }

    ///////////////////////////////////node based AKA copy constructor//////////////////////////////////////
    public Node(Node node)
    {
        data = node.Data;
        index = node.Index;

        neighbors = new List<Node>();
        foreach (var neighbor in node.Neighbors)
        {
            this.neighbors.Add(neighbor);
        }
    }

    //////////////////////////////////////////ADD NEIGHBOR/////////////////////////////////////////////
    public void AddNeighbor(Node node)
    {
        if (isNeighbor(node))
            Console.WriteLine("Node is already a neighbor.");
        else
        {
            neighbors.Add(node);
            Console.WriteLine("Node added as a neighbor.");
        }
    }

    ////////////////////////////////////////REMOVE NEIGHBOR////////////////////////////////////////////
    public void RemoveNeighbor(Node node)
    {
        if (isNeighbor(node))
        {
            neighbors.Remove(node);
            Console.WriteLine("Node removed as a neighbor.");
        }
        else
            Console.WriteLine("Node is not a neighbor.");
    }

    ////////////////////////////////////////REMOVE ALL NEIGHBORS////////////////////////////////////////////
    public void RemoveAllNeighbors()
    {
        int neighborCount = neighbors.Count;

        if (neighborCount == 0)
            Console.WriteLine("No neighbors to remove.");
        else
        {
            for (int i = neighborCount - 1; i >= 0; i--)
                neighbors.Remove(neighbors[i]);

            Console.WriteLine("All neighbors removed.");
        }
    }

    ////////////////////////////////////////isNEIGHBORS////////////////////////////////////////////
    public bool isNeighbor(Node node)
    {
        return neighbors.Contains(node);
    }

    /////////////////////////////////////ToString Override////////////////////////////////////////
    public override string ToString()
    {
        int neighborCount = neighbors.Count;

        string result = $"Index: {index}\nData: {data}\nNeighbor Count: {neighborCount}\n";

        if (neighborCount <= 0)
            result += $"\tNo neighbors\n";
        else
        {
            result += $"Neighbors:\n";
            foreach (var neighbor in neighbors)
            {
                result += $"\t{neighbor.Data}\n";
            }
        }
        return result;
    }

    //////////////////////////////////////Getters and Setters/////////////////////////////////////////
    public int Data
    {
        get { return data; }
        set { data = value; }
    }
    public int Index
    {
        get { return index; }
        set { index = value; }
    }
    public List<Node> Neighbors
    {
        get { return neighbors; }
    }
}
