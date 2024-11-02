namespace Test;

public class Stack
{
    private int[] array;
    private int top;

    public Stack()
    {
        this.array = new int[20];
        this.top = -1;
    }

    public void Push(int data)
    {
        if (top >= array.Length)
        {
            int[] temp = new int[array.Length];

            for (int i = 0, length = array.Length; i < length; i++)
            {
                temp[i] = array[i];
            }

            array = new int[array.Length * 2];

            for (int i = 0, length = temp.Length; i < length; i++)
            {
                array[i] = temp[i];
            }
        }

        top++;
        array[top] = data;

        Console.WriteLine($"{data} added to the stack");
    }

    public void Pop()
    {
        if (top == -1)
        {
            Console.WriteLine("Stack has no data");
        }
        else
        {
            // array[top];
            top--;
        }
    }

    public void Peek()
    {
        if (top == -1)
        {
            Console.WriteLine("Stack has no data");
        }
        else
        {
            // array[top]
            top--;
        }
    }
}
