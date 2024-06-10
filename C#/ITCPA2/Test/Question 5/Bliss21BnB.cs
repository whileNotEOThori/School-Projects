internal partial class Bliss21BnB
{
    private static void Main(string[] args)
    {
        int[] prices = { 400, 350, 300, 250 };

        int days, nights, totalPrice;
        string price;

        System.Console.Write("Enter the number of days for our stay: ");
        days = Convert.ToInt32(Console.ReadLine());

        nights = days - 1;

        if (nights >= 1 && nights <= 2)
        {
            totalPrice = nights * prices[0];
            price = $"Price per night: {prices[0].ToString("C")}";
        }
        else if (nights >= 3 && nights <= 4)
        {
            totalPrice = nights * prices[1];
            price = $"Price per night: {prices[1].ToString("C")}";
        }
        else if (nights >= 5 && nights <= 7)
        {
            totalPrice = nights * prices[2];
            price = $"Price per night: {prices[2].ToString("C")}";
        }
        else if (nights <= 8)
        {
            totalPrice = nights * prices[3];
            price = $"Price per night: {prices[3].ToString("C")}";
        }
        else
        {
            totalPrice = 0;
            price = $"Price per night: {0.ToString("C")}";
        }

        System.Console.WriteLine(price);

        System.Console.WriteLine($"Total price for {days} days: {totalPrice.ToString("C")} ");

    }
}