// Thoriso Dibatana EDUV4841116
// ITCPA2-22 Formative Assessment
// Question 2 - Patient Class
namespace Question_2;

public class Patient
{
    private string name;
    private string condition;
    private int age;

    public Patient(string n, string c, int a)
    {
        name = n;
        condition = c;
        age = a;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Condition
    {
        get { return condition; }
        set { condition = value; }
    }
    public int Age
    {
        get { return age; }
        set { age = value; }
    }
}
