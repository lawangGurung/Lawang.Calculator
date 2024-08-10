using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using CalculatorLibrary;

class Program
{
    static void Main(string[] args)
    {
        string? userInput;
        do
        {
            bool endApp = false;
            int calUsed = 0;
            Console.Clear();
            Console.WriteLine("---\tMenu\t---");
            Console.WriteLine("-------------------");
            Console.WriteLine("Press '1' for Calculation.");
            Console.WriteLine("Press '2' for viewing calculation records.");
            Console.WriteLine("Press '3' for deleting calculation record.");
            Console.WriteLine("Press '4' for exiting the Program.");
            userInput = Console.ReadLine();

            while (userInput == null || !Regex.IsMatch(userInput, "[1-4]"))
            {
                Console.WriteLine("Please enter the value from 1 to 3");
                userInput = Console.ReadLine();
            }

            Calculator calculator = new Calculator();

            switch (userInput)
            {
                case "1":
                    while (!endApp)
                    {
                        Console.Clear();
                        Console.WriteLine("Console Calculator in C#\r");
                        Console.WriteLine("------------------------\n");

                        string? numInput1 = "";
                        string? numInput2 = "";
                        double result = 0;

                        Console.Write("Type a number, and then press Enter: ");
                        numInput1 = Console.ReadLine();

                        double cleanNum1 = 0;

                        while (!double.TryParse(numInput1, out cleanNum1))
                        {
                            Console.Write("This is not valid input. Please enter a numeric value: ");
                            numInput1 = Console.ReadLine();
                        }

                        Console.Write("Type another number, and then press Enter: ");
                        numInput2 = Console.ReadLine();

                        double cleanNum2 = 0;

                        while (!double.TryParse(numInput2, out cleanNum2))
                        {
                            Console.WriteLine("This is not a valid input. Please enter a numeric value: ");
                            numInput2 = Console.ReadLine();
                        }

                        // Ask the user to choose an operator.
                        Console.WriteLine("Choose an operator from the following list:");
                        Console.WriteLine("\t+ - Add");
                        Console.WriteLine("\t- - Subtract");
                        Console.WriteLine("\t* - Multiply");
                        Console.WriteLine("\t/ - Divide");
                        Console.WriteLine("\ts - Show History");
                        Console.Write("Your option? ");

                        string? op = Console.ReadLine();

                        if (op == null || !Regex.IsMatch(op, @"[\+|\-|\*|/|s]"))
                        {
                            Console.WriteLine("Error: Unrecognized input.");
                        }
                        else
                        {
                            try
                            {
                                result = calculator.DoOperation(cleanNum1, cleanNum2, op);
                                calUsed++;
                                if (double.IsNaN(result))
                                {
                                    Console.WriteLine("This operation will result in a mathematical error.\n");
                                }
                                else
                                {
                                    Console.WriteLine("Your result: {0:0.##}\n", result);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + ex.Message);
                            }
                        }

                        Console.WriteLine("------------------------\n");
                        Console.WriteLine($"Calculator was used {calUsed} times");
                        Console.Write("Press 'n' and Enter to go to menu, or press any other key and Enter to continue: ");

                        if (Console.ReadLine() == "n")
                        {
                            endApp = true;
                        }

                        Console.WriteLine("\n");

                    }
                    calculator.Finish();
                    break;
            }
        }while(userInput != "4");


    }

}