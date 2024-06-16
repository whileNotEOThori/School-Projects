// Thoriso Dibatana EDUV4841116
// ITCPA2-22 Formative Assessment
// Question 2 - Main
namespace Question_2;
internal class Program
{
    private static void Main(string[] args)
    {
        Hospital carstenhof = new Hospital();
        int option, ward;
        string name;

        do
        {
            option = Menu();
            switch (option)
            {
                case 1:
                    carstenhof.AddPatient();
                    break;
                case 2:
                    carstenhof.DisplayPatients();
                    break;
                case 3:
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Invalid input. Try again.\n");
                    break;

            }
        } while (option != 3);

        Console.WriteLine("=== Code Execution Successful ===");
    }

    static int Menu()
    {
        int num;

        Console.WriteLine("Hospital Management System");
        Console.WriteLine("1.\tAdd a Patient");
        Console.WriteLine("2.\tDisplay Patients");
        Console.WriteLine("3.\tExit");
        Console.Write("Enter your choice: ");
        num = Convert.ToInt32(Console.ReadLine());

        return num;
    }
}