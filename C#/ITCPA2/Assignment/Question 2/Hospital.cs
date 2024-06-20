// Thoriso Dibatana EDUV4841116
// ITCPA2-22 Formative Assessment
// Question 2 - Hospital Class
namespace Question_2;

public class Hospital
{
    const int maxWards = 3;
    const int maxPatients = 4;
    private Patient[,] patients;

    public Hospital()
    {
        patients = new Patient[maxWards, maxPatients];

        for (int i = 0; i < maxWards; i++)
        {

            for (int j = 0; j < maxPatients; j++)
            {
                patients[i, j] = null;
            }
        }
    }
    public void AddPatient()
    {
        string name, condition;
        int age, ward;

        System.Console.Write("Enter patient's name: ");
        name = Console.ReadLine();

        System.Console.Write("Enter patient's age: ");
        age = Convert.ToInt32(Console.ReadLine());

        System.Console.Write("Enter patient's condition: ");
        condition = Console.ReadLine();

        System.Console.Write("Enter ward number: ");
        ward = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < maxPatients; i++)
        {
            if (patients[ward, i] == null)
            {
                patients[ward, i] = new Patient(name, condition, age);
                System.Console.WriteLine($"Patient {name} added to Ward {ward} successfully.\n");
                return;
            }
        }

        System.Console.WriteLine($"Patient {name} could not be added because Ward {ward} is currently full.\n");
    }
    public void DisplayPatients()
    {
        System.Console.WriteLine("List of Patients:");
        for (int i = 0; i < maxWards; i++)
        {
            System.Console.WriteLine($"Ward {i}:");
            for (int j = 0; j < maxPatients; j++)
            {
                if (patients[i, j] != null)
                {
                    System.Console.WriteLine($"\tName: {patients[i, j].Name}, Age: {patients[i, j].Age}, Condition: {patients[i, j].Condition}");
                }
            }

        }
        System.Console.WriteLine();
    }
}