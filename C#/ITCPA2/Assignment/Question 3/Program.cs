namespace Question_3;
internal class Program
{
    private static void Main(string[] args)
    {
        // Console.WriteLine($"Hello, World! {args[0]}");

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
                    System.Console.Write($"Enter patient's name to discharge: ");
                    name = Console.ReadLine();

                    carstenhof.dischargePatient(name);
                    break;
                case 4:
                    System.Console.Write($"Enter ward number to display: ");
                    ward = Convert.ToInt32(Console.ReadLine());

                    carstenhof.displayWardInformation(ward);
                    System.Console.WriteLine();
                    break;
                case 5:
                    System.Console.Write($"Enter patient's name to search: ");
                    name = Console.ReadLine();

                    carstenhof.searchPatient(name);
                    break;
                case 6:
                    System.Console.WriteLine("Exiting program...");
                    break;
                default:
                    System.Console.WriteLine("Invalid input. Try again.\n");
                    break;

            }
        } while (option != 6);

        System.Console.WriteLine("=== Code Execution Successful ===");
    }
    static int Menu()
    {
        int num;

        System.Console.WriteLine("Hospital Management System");
        System.Console.WriteLine("1.\tAdd a Patient");
        System.Console.WriteLine("2.\tDisplay Patients");
        System.Console.WriteLine("3.\tDischarge a Patient");
        System.Console.WriteLine("4.\tDisplay Ward Information");
        System.Console.WriteLine("5.\tSearch for a Patient");
        System.Console.WriteLine("6.\tExit");
        System.Console.Write("Enter your choice: ");
        num = Convert.ToInt32(Console.ReadLine());

        return num;
    }
}
