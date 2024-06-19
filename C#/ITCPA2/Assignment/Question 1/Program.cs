// Thoriso Dibatana EDUV4841116
// ITCPA2-22 Formative Assessment
// Question 1
// See https://aka.ms/new-console-template for more information

using System.Globalization;

internal class Program
{
    //Global formatting constant for degree symbol
    const string degreesCelsius = "\u00B0C"; //unicode for Degree character

    private static void Main(string[] args)
    {
        //Prompt user for data
        uint numSections = GetNumSections();
        uint readingsPerSection = GetNumReadings();

        // Local variable declarations
        double[,] temperatures = new double[numSections, readingsPerSection];
        double avgTemp = 0.00;
        double[] sectionAvgTemp = new double[numSections];
        double[] sectionMaxTemp = new double[numSections];
        double[] sectionMinTemp = new double[numSections];

        InputData(ref temperatures, numSections, readingsPerSection);

        DisplayData(temperatures, numSections, readingsPerSection);

        PerformAnalysis(temperatures, ref avgTemp, ref sectionAvgTemp, ref sectionMaxTemp, ref sectionMinTemp, numSections, readingsPerSection);

        DisplayAnalysis(avgTemp, sectionAvgTemp, sectionMaxTemp, sectionMinTemp, numSections);

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
                sec = GetSec();
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
                readings = GetReadings();
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
    static void InputData(ref double[,] temp, uint sec, uint readings)
    {

        for (int i = 0; i < sec; i++)
        {
            Console.WriteLine($"Enter the temperature readings for section {i + 1}: ");
            for (int j = 0; j < readings; j++)
            {
                try
                {
                    temp[i, j] = EnterTemp(j);
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
                            temp[i, j] = EnterTemp(j);
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
    static void DisplayData(double[,] temp, uint sec, uint readings)
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
    static void PerformAnalysis(double[,] temp, ref double avgTemp, ref double[] sectionAvgTemp, ref double[] sectionMaxTemp, ref double[] sectionMinTemp, uint sec, uint readings)
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
    static void DisplayAnalysis(double avgTemp, double[] sectionAvgTemp, double[] sectionMaxTemp, double[] sectionMinTemp, uint sec)
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

    //helper function
    static double EnterTemp(int j)
    {
        double temperature;

        Console.Write($"\tTemperature reading {j + 1}: ");
        temperature = Convert.ToDouble(Console.ReadLine());

        return temperature;
    }
    static uint GetSec()
    {
        uint temp;

        Console.Write("Enter number of sections: ");
        temp = Convert.ToUInt32(Console.ReadLine());

        return temp;
    }

    static uint GetReadings()
    {
        uint readings;

        Console.Write("Enter number of readings per sections: ");
        readings = Convert.ToUInt32(Console.ReadLine());

        return readings;
    }
}
