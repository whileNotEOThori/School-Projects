﻿// Thoriso Dibatana EDUV4841116
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
        this.name = n;
        this.condition = c;
        this.age = a;
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public string Condition
    {
        get { return this.condition; }
        set { this.condition = value; }
    }
    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }
}
