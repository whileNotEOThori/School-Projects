// Thoriso Dibatana EDUV4841116
// ITCPA2-22 Formative Assessment
// Question 1
// See https://aka.ms/new-console-template for more information

using System.Globalization;

internal class Program
{
    //Global formatting constant for degree symbol
    const string degreesCelsius = "\u00B0C"; //unicode for Degree character and C

    // Global variable declarations
    static uint numSections, readingsPerSection;
    static double[,] temperatures;
    static double avgTemp = 0.00;
    static double[] sectionAvgTemp;
    static double[] sectionMaxTemp;
    static double[] sectionMinTemp;

    private static void Main(string[] args)
    {
        //Prompt user for data
        numSections = GetNumSections();
        readingsPerSection = GetNumReadings();

        temperatures = new double[numSections, readingsPerSection];
        avgTemp = 0.00;
        sectionAvgTemp = new double[numSections];
        sectionMaxTemp = new double[numSections];
        sectionMinTemp = new double[numSections];

        InputData();

        DisplayData();

        PerformAnalysis();

        DisplayAnalysis();

    }

    //Prompt the user to enter the number of sections 
    static uint GetNumSections()
    {
        uint sec = 0;
        bool flag = false;

        while (!flag)
        {
            try
            {
                Console.Write("Enter number of sections: ");
                sec = Convert.ToUInt32(Console.ReadLine());
                flag = true;
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        return sec;
    }

    // Prompt the user to enter the number of readings per section
    static uint GetNumReadings()
    {
        uint readings = 0;
        bool flag = false;

        while (!flag)
        {
            try
            {
                Console.Write("Enter number of readings per sections: ");
                readings = Convert.ToUInt32(Console.ReadLine());
                flag = true;
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        return readings;
    }

    // Input temperature readings for each section
    static void InputData()
    {

        for (int i = 0; i < numSections; i++)
        {
            Console.WriteLine($"Enter the temperature readings for section {i + 1}: ");
            for (int j = 0; j < readingsPerSection; j++)
            {
                try
                {
                    temperatures[i, j] = EnterTemp(j);
                }
                catch (FormatException e)
                {
                    bool flag = false;

                    Console.WriteLine($"{e.Message} Re-enter Temperature reading {j + 1}:");
                    // j--;//Repeat the current column input without the do while loop(does all of that)
                    do
                    {
                        try
                        {
                            temperatures[i, j] = EnterTemp(j);
                            flag = true;
                        }
                        catch (FormatException f)
                        {
                            System.Console.WriteLine($"{f.Message} Re-enter Temperature reading {j + 1}:");
                        }

                    } while (flag == false);
                }
                catch (StackOverflowException e)
                {
                    System.Console.WriteLine(e.Message);
                    throw;
                }
                catch (IndexOutOfRangeException e)
                {
                    System.Console.WriteLine(e.Message);
                    throw;
                }

            }
        }
        Console.WriteLine();



    }

    // Display the entered sensor data
    static void DisplayData()
    {
        for (int i = 0; i < numSections; i++)
        {
            Console.WriteLine($"The temperature readings for section {i + 1}: ");
            for (int j = 0; j < readingsPerSection; j++)
            {
                Console.WriteLine($"\t Temperature reading {j + 1}: {temperatures[i, j]}{degreesCelsius}");
            }
        }
        Console.WriteLine();
    }

    //Stats calculations on temperatures
    static void PerformAnalysis()
    {
        for (int i = 0; i < numSections; i++)
        {
            sectionAvgTemp[i] = 0.00;
            sectionMaxTemp[i] = temperatures[i, 0];
            sectionMinTemp[i] = temperatures[i, 0];
            for (int j = 0; j < readingsPerSection; j++)
            {
                avgTemp += temperatures[i, j];//calculate universal avg temp
                sectionAvgTemp[i] += temperatures[i, j]; // calculate section avg temp

                //determine section max temp
                if (sectionMaxTemp[i] < temperatures[i, j])
                {
                    sectionMaxTemp[i] = temperatures[i, j];
                }

                //determine section min temp
                if (sectionMinTemp[i] > temperatures[i, j])
                {
                    sectionMinTemp[i] = temperatures[i, j];
                }
            }
            try
            {
                sectionAvgTemp[i] = sectionAvgTemp[i] / readingsPerSection; //calculate section avg temp
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        try
        {
            avgTemp = avgTemp / (numSections * readingsPerSection);//calculate universal avg temp
        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    //display all stats
    static void DisplayAnalysis()
    {
        // display the average temperature for all readings across all sections of the greenhouse
        Console.WriteLine($"The average temperature for all readings across all sections of the greenhouse is : {avgTemp:F2}{degreesCelsius}\n");

        // display the stats for all readings in each section of the greenhouse
        Console.WriteLine($"The temperature statistics for all readings in each section of the greenhouse is :");
        for (int i = 0; i < numSections; i++)
        {
            Console.WriteLine($"Section {i + 1}:");
            Console.WriteLine($"\tAverage temperature: {sectionAvgTemp[i]:F2}{degreesCelsius}");
            Console.WriteLine($"\tMax temperature: {sectionMaxTemp[i]:F2}{degreesCelsius}");
            Console.WriteLine($"\tMin temperature: {sectionMinTemp[i]:F2}{degreesCelsius}");
        }
    }

    //helper function
    static double EnterTemp(int j)
    {
        double temperature;

        Console.Write($"\tTemperature reading {j + 1}: ");
        temperature = Convert.ToDouble(Console.ReadLine());

        return temperature;
    }
}
