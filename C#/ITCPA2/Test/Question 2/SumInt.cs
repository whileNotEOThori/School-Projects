internal partial class SumInt
{
    private static void Main(string[] args)
    {
        SumInts();
    }

    static void SumInts()
    {
        int num, sum = 0;
        System.Console.WriteLine("Enter an integer to sum. Enter 30 to terminate ");
        do
        {
            System.Console.Write("Number: ");
            num = Convert.ToInt32(Console.ReadLine());
            sum += num;
        } while (num != 30);

        System.Console.WriteLine($"The sum of the entered integers is: {sum - 30}");
    }
}