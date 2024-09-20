using System;
using System.Diagnostics;
using Microsoft.VisualBasic;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {

            // Be användaren ange sorteringsordning om ej angett vid start
            if (args.Length == 0)
            {
                Console.WriteLine("Ange _0 för att sortera stigande eller _1 för att sortera fallande");
                return;
            }

            //Variabler som lagrar lägsta och högsta tal som får finnas i arrayen
            int Min = 1;
            int Max = 1500;

            //Array som lagrar 100 integers
            int[] arrayOfNumbers = new int[100];

            //Metod som fyller arrayen med slumpmässiga tal
            Random randomNum = new Random();
            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                arrayOfNumbers[i] = randomNum.Next(Min, Max);
            }

            //Skriv ut den osorterade arrayen till konsolen
            Console.WriteLine("Osorterad array:");
            foreach (int number in arrayOfNumbers)
            {
                Console.Write(number + " ");
            }

            //Skapa radbrytning i konsolen
            Console.WriteLine();
            Console.WriteLine();

            string sortOrder = args[0];

            //Tidtagning för sortering med stopwatch
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            if (sortOrder == "_0")
            {
                //Sortera i stigande ordning
                BubbleSort(arrayOfNumbers, true);
                Console.WriteLine("Array sorterad med BubbleSort i stigande ordning: ");
            }
            else if (sortOrder == "_1")
            {
                //Sortera i fallande ordning
                BubbleSort(arrayOfNumbers, false);
                Console.WriteLine("Array sorterad med BubbleSort i fallande ordning: ");
            }
            else
            {
                Console.WriteLine("Något har gått fel. Använd -0 eller -1 som argument för att sortera");
                return;
            }

            stopwatch.Stop(); //Stoppa tidtagning

            //Skriv ut den sorterade arrayen och hur lång tid sorteringen tog
            foreach (int number in arrayOfNumbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Det tog {stopwatch.ElapsedTicks} mikrosekunder att utföra sorteringen med BubbleSort.");
            Console.WriteLine();
            Console.WriteLine();

            // Klona den osorterade arrayen och lagra i en variabel
            int[] clonedArray = (int[])arrayOfNumbers.Clone();

            //Sortera och mät tid för sortering med inbyggda metoden Array.Sort
            stopwatch.Reset();
            stopwatch.Start();

                    if (sortOrder == "_0")
            {
                //Sortera i stigande ordning
                Array.Sort(clonedArray);
                Console.WriteLine("Array sorterad med Array.Sort i stigande ordning: ");
            }
            else if (sortOrder == "_1")
            {
                //Sortera i fallande ordning
                Array.Sort(clonedArray, (x, y) => y.CompareTo(x));
                Console.WriteLine("Array sorterad med Array.Sort i fallande ordning: ");
            }

            stopwatch.Stop(); //Stoppa tidtagning

            //Skriv ut den sorterade arrayen och hur lång tid sorteringen tog
            foreach (int number in clonedArray)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Det tog {stopwatch.ElapsedTicks} mikrosekunder att utföra sorteringen med Array.Sort.");



        }

        //Skapa metod för BubbleSort
        static void BubbleSort(int[] data, bool _0)
        {
            bool needsSorting = true;

            //Loop för att sortera arrayen
            for (int numbers = 0; numbers < data.Length - 1 && needsSorting; numbers++)
            {
                needsSorting = false; //Anta att arrayeb ör sorterad tillsvidare

                //Gå igenom osorterade tal och byt plats om det behövs
                for (int unsortedNumbers = 0; unsortedNumbers < data.Length - 1 - numbers; unsortedNumbers++)
                {
                    bool swapCondition;

                    if(_0)
                    {
                        //Byt plats om det föregående talet är större än nästa (stigande ordning)
                        swapCondition = data[unsortedNumbers] > data[unsortedNumbers + 1];
                    }
                    else
                    {
                        //Byt plats om det föregående talet är lägre än nästa (Fallande ordning)
                        swapCondition = data[unsortedNumbers] < data[unsortedNumbers + 1];
                    }

                    if (swapCondition)
                    {
                        //Byt plats på talen
                        int temp = data[unsortedNumbers];
                        data[unsortedNumbers] = data[unsortedNumbers + 1];
                        data[unsortedNumbers + 1] = temp;

                        //Om en omkastning sker behövs ytterligare sortering
                        needsSorting = true;

                    }
                }
            }
        }
    }
}
