namespace Question_3;

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
