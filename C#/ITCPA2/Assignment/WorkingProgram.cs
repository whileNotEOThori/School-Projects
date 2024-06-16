// Thoriso Dibatana EDUV4841116
// ITCPA2-22 Formative Assessment
// Question 1
// See https://aka.ms/new-console-template for more information

using System.Globalization;

internal class WorkingProgram
{
    //Global formatting constant for degree symbol
    const string degreesCelsius = "\u00B0C";

    private static void Main(string[] args)
    {
        //Prompt user for data
        int numSections = getNumSections();
        int readingsPerSection = getNumReadings();

        // Local variable declarations
        double[,] temperatures = new double[numSections, readingsPerSection];
        double avgTemp = 0.00;
        double[] sectionAvgTemp = new double[numSections];
        double[] sectionMaxTemp = new double[numSections];
        double[] sectionMinTemp = new double[numSections];

        inputData(ref temperatures, numSections, readingsPerSection);

        displayData(temperatures, numSections, readingsPerSection);

        performAnalysis(temperatures, ref avgTemp, ref sectionAvgTemp, ref sectionMaxTemp, ref sectionMinTemp, numSections, readingsPerSection);

        displayAnalysis(avgTemp, sectionAvgTemp, sectionMaxTemp, sectionMinTemp, numSections);
    }

    //Prompt the user to enter the number of sections 
    static int getNumSections()
    {
        int num;

        try
        {

            Console.Write("Enter number of sections: ");
            num = Convert.ToInt32(Console.ReadLine());

            return num;
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    // Prompt the user to enter the number of readings per section
    static int getNumReadings()
    {
        int num;

        try
        {

            Console.Write("Enter number of readings per sections: ");
            num = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            return num;

        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    // Input temperature readings for each section
    static void inputData(ref double[,] temp, int sec, int readings)
    {
        try
        {
            for (int i = 0; i < sec; i++)
            {
                Console.WriteLine($"Enter the temperature readings for section {i + 1}: ");
                for (int j = 0; j < readings; j++)
                {
                    Console.Write($"\tTemperature reading {j + 1}: ");
                    temp[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }
            Console.WriteLine();
        }
        catch (FormatException e)
        {
            Console.WriteLine($"{e.Message}");
            throw;
        }
        catch (IndexOutOfRangeException e)
        {
            System.Console.WriteLine(e.Message);
        }
        catch (StackOverflowException e)
        {
            System.Console.WriteLine(e.Message);
        }
    }

    // Display the entered sensor data
    static void displayData(double[,] temp, int sec, int readings)
    {
        for (int i = 0; i < sec; i++)
        {
            Console.WriteLine($"The temperature readings for section {i + 1}: ");
            for (int j = 0; j < readings; j++)
            {
                Console.WriteLine($"\t Temperature reading {j + 1}: {temp[i, j]}{degreesCelsius}");
            }
        }
        Console.WriteLine();
    }

    //Stats calculations on temperatures
    static void performAnalysis(double[,] temp, ref double avgTemp, ref double[] sectionAvgTemp, ref double[] sectionMaxTemp, ref double[] sectionMinTemp, int sec, int readings)
    {
        for (int i = 0; i < sec; i++)
        {
            sectionAvgTemp[i] = 0.00;
            sectionMaxTemp[i] = temp[i, 0];
            sectionMinTemp[i] = temp[i, 0];
            for (int j = 0; j < readings; j++)
            {
                avgTemp += temp[i, j];//calculate universal avg temp
                sectionAvgTemp[i] += temp[i, j]; // calculate section avg temp

                //determine section max temp
                if (sectionMaxTemp[i] < temp[i, j])
                {
                    sectionMaxTemp[i] = temp[i, j];
                }

                //determine section min temp
                if (sectionMinTemp[i] > temp[i, j])
                {
                    sectionMinTemp[i] = temp[i, j];
                }
            }
            try
            {
                sectionAvgTemp[i] = sectionAvgTemp[i] / readings; //calculate section avg temp
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        try
        {
            avgTemp = avgTemp / (sec * readings);//calculate universal avg temp
        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    //display all stats
    static void displayAnalysis(double avgTemp, double[] sectionAvgTemp, double[] sectionMaxTemp, double[] sectionMinTemp, int sec)
    {
        // display the average temperature for all readings across all sections of the greenhouse
        Console.WriteLine($"The average temperature for all readings across all sections of the greenhouse is : {avgTemp:F2}{degreesCelsius}\n");

        // display the stats for all readings in each section of the greenhouse
        Console.WriteLine($"The temperature statistics for all readings in each section of the greenhouse is :");
        for (int i = 0; i < sec; i++)
        {
            Console.WriteLine($"Section {i + 1}:");
            Console.WriteLine($"\tAverage temperature: {sectionAvgTemp[i]:F2}{degreesCelsius}");
            Console.WriteLine($"\tMax temperature: {sectionMaxTemp[i]:F2}{degreesCelsius}");
            Console.WriteLine($"\tMin temperature: {sectionMinTemp[i]:F2}{degreesCelsius}");
        }
    }

}

// \u00B0 - unicode for Degree character