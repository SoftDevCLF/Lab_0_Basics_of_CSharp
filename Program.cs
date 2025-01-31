using static System.Formats.Asn1.AsnWriter;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace Lab_0_Basics_of_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Getting a valid low number
            double validLowNumber = ValidateLowNumber(GetLowNumber());

            //Getting a valid hugh number
            double validHighNumber = ValidateHighNumber(GetHighNumber(), validLowNumber);

            //Getting and printing the difference between low and high numbers
            double differenceLowHighNumbers = validLowNumber - validHighNumber;
            Console.WriteLine("The difference between the low humber and high number is: " + differenceLowHighNumbers);

            //Create a List to store the numbers between low and high number
            List<double> numbers = new List<double>();

            //Loop to add the numbers to the list
            for (double listNumber = validLowNumber + 1; listNumber != validHighNumber; listNumber++)
            {
                numbers.Add(listNumber);
            }

            //Create variable for the file name
            string fileListNumbers = "numbers.txt";

            //Order the numbers in the list from max to min 
            numbers.Reverse();

            //Write file using WriteAllLines to write each strig as a new line
            //Use of lambda to convert every number in numbers to string 
            File.WriteAllLines(fileListNumbers, numbers.Select(number => number.ToString()));

            //.ReadAllLines create an array with the new string values written on the file
            string[] lines = File.ReadAllLines(fileListNumbers);

            //Start the sum with zero
            double sumAllLines = 0;

            //Loop to sum all lines
            foreach (string line in lines)
            {
                sumAllLines += double.Parse(line); //Use of Parse to convert the string into an double

            }
            //printing sum
            Console.WriteLine("The sum of all numbers between the low number and the high number is: " + sumAllLines);

            //Printing Prime Numbers
            Console.WriteLine("The prime numbers between the low number and the high number are: ");
            
            //Loop to find prime numbers in the List numbers
            foreach (double number in numbers)
                if (IsPrimeNumber(number) == true)
                {
                    Console.WriteLine(number);
                }
                
        }

        //Method to get the input for the low number
        static string GetLowNumber()
        {
            //Recovering info from the user as a string
            Console.Write("Please enter a low number: ");
            string inputLowNumber = Console.ReadLine();
            return inputLowNumber;
        }
        
        //Method to validate the low number
        static double ValidateLowNumber(string inputLowNumber)
        {
            double lowNumber; 
            bool isValid = false; //Flag
            do
            {
                //.TryParse() to convert the string into an integer. If succesful it returns true, otherwise, it returns false. It outputs the value into lowNumber.
                //Condition to validate if the number is positive and if it is an integer
                if (double.TryParse(inputLowNumber, out lowNumber) && lowNumber >= 0)
                {
                    //If the condition is true, the loop will stop
                    isValid = true;
                }
                else
                {
                    //The loop will prompt a validation message every time the user inputs an invalid value
                    Console.WriteLine("Invalid input. Please enter a positive low number.");
                    Console.Write("Please enter a low number: ");
                    inputLowNumber = Console.ReadLine();  
                }
            }
            //While the condition is false the loop will continue
            while (!isValid);
            return lowNumber;
        }

        //Method to get the imput for the high number
        static string GetHighNumber()
        {
            //Recovering info from the user as a string
            Console.Write("Please enter a high number: ");
            string inputHighNumber = Console.ReadLine();
            return inputHighNumber;
        }

        //Method to validate the high nunber
        static double ValidateHighNumber(string inputHighNumber, double validLowNumber)
        {
            double highNumber;
            bool isValid = false; //Flag
            do
            {
                //.TryParse() to convert the string into an integer. 
                //Condition to validate if the number is positive and if it is higher than the validLowNumber
                if (double.TryParse(inputHighNumber, out highNumber) && highNumber > validLowNumber)
                {
                    //If the condition is true, the loop will stop
                    isValid = true;
                }
                else
                {
                    //The loop will prompt a validation message every time the user inputs an invalid value
                    Console.WriteLine("Invalid input. Please enter a high number greater than the low number.");
                    Console.Write("Please enter a high number: ");
                    inputHighNumber = Console.ReadLine();
                }
            }
            //While the condition is false the loop will continue
            while (!isValid);
            return highNumber;
        }

        //Method to validate if the number is a prime number
        static bool IsPrimeNumber(double number)
        {
            //if the number is equal to or less than 1 is not a prime number (false)
            if (number <= 1)
            {
                return false;
            }

            //if the number is equal to 2 is a primer number (true)
            if (number == 2)
            {
                return true;
            }

            //loop starts at two, condition: square of the start needs to be less than or equal to the number entered and the star increases one every iteration
            for (double isPrime = 2; isPrime * isPrime <= number; isPrime++)
            {
                if (number % isPrime == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
