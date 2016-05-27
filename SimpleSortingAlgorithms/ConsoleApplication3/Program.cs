using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[10000];

            PopulateWithRandomNumbers(numbers);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Quicksort(numbers, 0, numbers.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Quicksort has taken " + stopwatch.ElapsedMilliseconds + " milliseconds to complete.");

            stopwatch.Reset();

            PopulateWithRandomNumbers(numbers);

            stopwatch.Start();
            BubbleSort(numbers);
            stopwatch.Stop();
            Console.WriteLine("Bubble Sort taken " + stopwatch.ElapsedMilliseconds + " milliseconds to complete");

            Console.ReadLine();
        }

        private static void PopulateWithRandomNumbers(int[] arrayToPopulate)
        {
            Random randomGenerator = new Random();
            for (int i = 0; i < arrayToPopulate.Length; i++)
            {
                arrayToPopulate[i] = randomGenerator.Next(1, 100000);
            }
        }

        private static int[] BubbleSort(int[] numbersToSort)
        {
            bool elementsLeftToSort = true;

            // While ever we think there are elements that are out of order, continue to loop through all elements
            for (int i = 1; (i < numbersToSort.Length) && elementsLeftToSort; i++)
            {
                // Assume we're in order unless we find otherwise - this breaks the array if no changes are required
                elementsLeftToSort = false;
                // Loop around elements in the array, swapping elements as we go
                for (int j = 0; j < numbersToSort.Length - 1; j++)
                {
                    // Reverse sorting order by changing the operand from < to >
                    if (numbersToSort[j + 1] < numbersToSort[j])
                    {
                        SwapElements(numbersToSort, j, j + 1);
                        elementsLeftToSort = true;
                    }
                }
            }
            return numbersToSort;
        }

        private static void Quicksort(int[] numbersToSort, int lowestIndex, int highestIndex)
        {
            // If the lowest index is less than the highest index, the section of the array is sorted, and we break the recursion
            if (lowestIndex < highestIndex)
            {
                // Find the location of the pivot element and sort it into position
                int pivotLocation = PartitionArray(numbersToSort, lowestIndex, highestIndex);
                // The array is then split into two sections based around the pivot, and each of these sections is sorted recursively
                // in the same way
                Quicksort(numbersToSort, lowestIndex, pivotLocation - 1);
                Quicksort(numbersToSort, pivotLocation + 1, highestIndex);
            }
        }

        private static int PartitionArray(int[] numbersToSort, int lowestIndex, int highestIndex)
        {
            // Gets the value from the array to use as the pivot
            int pivot = numbersToSort[highestIndex];
            int i = lowestIndex - 1;

            // Sort elements in this section of the array correctly around the pivot value
            // So that only elements less than the pivot are lower, and elements greater than are higher
            for (int j = lowestIndex; j < highestIndex; j++)
            {
                if (numbersToSort[j] <= pivot)
                {
                    i++;
                    SwapElements(numbersToSort, i, j);
                }
            }
            SwapElements(numbersToSort, i + 1, highestIndex);
            return i + 1;
        }

        // Simple method to swap elements in an array - stops us rpeating the same code several times
        private static void SwapElements(int[] array, int elementOne, int elementTwo)
        {
            var temp = array[elementOne];
            array[elementOne] = array[elementTwo];
            array[elementTwo] = temp;
        }
    }
}
