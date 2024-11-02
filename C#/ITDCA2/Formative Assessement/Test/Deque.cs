using System.Collections.Generic;
namespace Test;

public class Deque
{
    LinkedList<int> list;
    public Deque()
    {
        list = new LinkedList<int>();
    }

    public void EnqueueFront(int data)
    {
        list.AddFirst(data);
    }

    public void EnqueueBack(int data)
    {
        list.AddLast(data);
    }

    public int DequeueFront()
    {
        if (list.Count > 0)
            return -1;

        int result = list.First();
        list.RemoveFirst();
        return result;
    }

    public int DequeueBack()
    {
        if (list.Count > 0)
            return -1;

        int result = list.Last();
        list.RemoveLast();
        return result;
    }

    public int PeekFront()
    {
        if (list.Count > 0)
            return -1;

        int result = list.First();
        return result;
    }

    public int PeekBack()
    {
        if (list.Count > 0)
            return -1;

        int result = list.Last();
        return result;
    }
}


