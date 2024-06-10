using System.Runtime.InteropServices;

internal partial class Fines
{
    private static void Main(string[] args)
    {
        int numBooks, daysOverdue;

        System.Console.Write("Enter the number of books checked out: ");
        numBooks = Convert.ToInt32(Console.ReadLine());

        System.Console.Write("Enter the number of days overdue: ");
        daysOverdue = Convert.ToInt32(Console.ReadLine());

        CalcFines(numBooks, daysOverdue);



    }

    static void CalcFines(int books, int days)
    {
        int fines = 0;

        if (days <= 7)
        {
            fines = (days * 5) * books;
        }
        else
        {
            fines = (7 * 5 + (days - 7) * 2) * books;
        }

        System.Console.WriteLine($"The library fine is {fines.ToString("C")}");
    }
}