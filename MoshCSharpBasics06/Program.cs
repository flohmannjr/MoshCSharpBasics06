using System;
using System.Collections.Generic;
using System.Linq;

namespace MoshCSharpBasics06
{
    class Program
    {
        const int Names = 1;
        const int ReverseName = 2;
        const int FiveNumbers = 3;
        const int UniqueNumbers = 4;
        const int SmallestNumbers = 5;

        static void Main(string[] args)
        {
            Console.Write("1 - Names\n2 - Reverse Name\n3 - Five Numbers\n4 - Unique Numbers\n5 - Smallest Numbers\n\nChoose an exercise: ");

            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case Names:
                    var names = new List<string>();
                    var name = "";

                    while (true)
                    {
                        Console.Write("Enter a name (or blank to exit): ");
                        name = Console.ReadLine();

                        if(!String.IsNullOrEmpty(name))
                        {
                            names.Add(name);
                        }
                        else
                        {
                            var namesCount = names.Count;

                            if(namesCount > 0 && namesCount <= 2)
                            {
                                Console.WriteLine(String.Join(" and ", names));
                            }
                            else if (namesCount > 2)
                            {
                                Console.WriteLine("{0}, {1} and {2} others", names[0], names[1], namesCount - 2);
                            }

                            break;
                        }
                    }

                    break;

                case ReverseName:
                    Console.Write("Enter your name: ");
                    var yourName = Console.ReadLine();
                    var reversed = yourName.ToArray();
                    Array.Reverse(reversed);
                    Console.WriteLine("Reversed: " + String.Join("", reversed));
                    break;

                case FiveNumbers:
                    var number = 0;
                    var numberCount = 0;
                    var numbers = new List<int>();

                    Console.WriteLine("Enter five numbers: ");

                    while (numberCount < 5)
                    {
                        Console.Write("Enter number {0}: ", numberCount + 1);
                        number = Convert.ToInt32(Console.ReadLine());

                        if(numbers.IndexOf(number) < 0)
                        {
                            numbers.Add(number);
                            numberCount++;
                        }
                        else
                        {
                            Console.WriteLine("Number {0} already exists. Please enter a new number.", number);
                        }
                    }

                    numbers.Sort();
                    Console.WriteLine("Numbers: " + String.Join(", ", numbers));

                    break;

                case UniqueNumbers:
                    var notUniques = new List<int>();
                    var input = "";

                    while (true)
                    {
                        Console.Write("Enter a number (or 'quit' to exit): ");
                        input = Console.ReadLine();

                        if (input != "quit")
                        {
                            notUniques.Add(Convert.ToInt32(input));
                        }
                        else
                        {
                            var uniques = new List<int>();

                            foreach(var nu in notUniques)
                                if (!uniques.Contains(nu))
                                    uniques.Add(nu);

                            uniques.Sort();
                            Console.WriteLine("Unique numbers: " + String.Join(", ", uniques));
                            break;
                        }
                    }

                    break;

                case SmallestNumbers:
                    while(true)
                    {
                        Console.Write("Enter a list of 5 or more comma separated numbers: ");
                        var newNumbers = Console.ReadLine().Split(',', ' ');

                        if (newNumbers.Length < 5)
                        {
                            Console.WriteLine("Invalid list.");
                        }
                        else
                        {
                            var moreNumbers = Array.ConvertAll(newNumbers, int.Parse);
                            Array.Sort(moreNumbers);
                            var smallest = new int[3];
                            Array.Copy(moreNumbers, smallest, 3);
                            Console.WriteLine("3 smallest numbers: " + String.Join(", ", smallest));
                            break;
                        }
                    }

                    break;

                default:
                    Console.WriteLine("Invalid exercise.");
                    break;
            }
        }
    }
}
