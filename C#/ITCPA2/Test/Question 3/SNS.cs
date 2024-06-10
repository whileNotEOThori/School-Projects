internal partial class SNS
{
    private static void Main(string[] args)
    {
        string message;

        System.Console.Write("Enter your message post: ");
        message = Console.ReadLine();

        Bua(message);
    }

    static void Bua(string text)
    {
        if (text.Length > 140)
        {
            System.Console.WriteLine("The length of the entered message is too long. It cannot be more than 140 characters.");
        }
        else
        {
            System.Console.WriteLine("The length is of the entered message is fine. It is less than 140 characters.");
        }
    }
}