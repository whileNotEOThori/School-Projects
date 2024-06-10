internal partial class Add
{
    private static void Main(string[] args)
    {
        int num1, num2;

        System.Console.WriteLine("Add two numbers");

        System.Console.Write("Enter number 1: ");
        num1 = Convert.ToInt32(Console.ReadLine());

        System.Console.Write("Enter number 2: ");
        num2 = Convert.ToInt32(Console.ReadLine());


        System.Console.WriteLine($"The sum of {num1} and {num2} is {add(num1, num2)}");
    }

    static int add(int num1, int num2)
    {
        return num1 + num2;
    }
}