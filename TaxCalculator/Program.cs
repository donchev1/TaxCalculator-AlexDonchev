using System;

namespace TaxCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool goAgain = true;
            decimal netSalary = 0;
            bool validCountryInput = false;
            bool validGrossSalaryInput = false;

            while (goAgain)
            {
                decimal grossSalary = 0;
                Console.WriteLine("You just started tax calculator.");
                Console.WriteLine("Simple console application for calculating net salary.");
                while (!validGrossSalaryInput)
                {
                    Console.WriteLine("What is your gross salary amount?");
                    validGrossSalaryInput = decimal.TryParse(Console.ReadLine(), out grossSalary);

                    if (!validGrossSalaryInput)
                    {
                        Console.WriteLine("Wrong decimal format. Please try again.");
                    }
                }

                while (!validCountryInput)
                {
                    Console.WriteLine("Please input the name of your country.");
                    string countryName = Console.ReadLine();

                    switch (countryName.ToLower())
                    {
                        case "imaginaria":
                            validCountryInput = true;
                            ICountry country = new Imaginaria() { GrossSalaryAmount = grossSalary };
                            NetSalaryCalculator imaginariaTaxCalculator = new NetSalaryCalculator(country);
                            netSalary = imaginariaTaxCalculator.NetSalary;
                            break;
                        default:
                            Console.WriteLine($"{countryName} is not a valid country. Please try again.");
                            break;
                    }
                }

                Console.WriteLine("The net salary is: " + netSalary.ToString());
                Console.WriteLine("Would you like to calculate net salary again?");
                Console.WriteLine("Just type 'yes' if you want to go again.");
                goAgain = Console.ReadLine().ToLower() == "yes";

                if (goAgain)
                {
                    validGrossSalaryInput = false;
                    validCountryInput = false;
                }
            }

        }
    }
}
