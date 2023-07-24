
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A14
{
    internal class Program
    {
        public static int[] generate(int size,int min,int max)
        {
            Random r=new Random();
            int[] arr=new int[size];
            for(int i = 0; i < size; i++)
            {
                arr[i]=r.Next(min,max+1);
            }
            return arr;

        }
        public static void bubblesort(int[] arr)
        {
            int n = arr.Length;
            bool swapped;

            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;

                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // Swap elements arr[j] and arr[j+1]
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;

                        swapped = true;
                    }
                }

                // If no two elements were swapped in the inner loop, the array is already sorted
                if (!swapped)
                    break;
            }
        
    }
        public static void print(int[] arr)
        {
            foreach (int i in arr)
            {
                Console.Write(i+" ");
            }
            Console.WriteLine("\n");
        }
        public static bool check(int[] arr)
        {
            for(int i=0; i<arr.Length-1; i++)
            {
                if (arr[i] > arr[i+1])
                    return false;
            }
            return true;
        }
        public static void insertion(int[] arr)
        {
            int n = arr.Length;

            for (int i = 1; i < n; i++)
            {
                int currentElement = arr[i];
                int j = i - 1;

                // Move elements that are greater than the currentElement to the right
                while (j >= 0 && arr[j] > currentElement)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                // Insert the currentElement in its correct position
                arr[j + 1] = currentElement;
            }
        }
        public static void selection(int[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;

                // Find the minimum element's index in the remaining unsorted part of the array
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[minIndex])
                        minIndex = j;
                }

                // Swap the minimum element with the first element in the unsorted part
                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }
        }
        static void Main(string[] args)
        {
            int s,min,max;
            Stopwatch sw1 = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();
            Stopwatch sw3 = new Stopwatch();
            Console.WriteLine("Enter the size of array you want to generate");
            s=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the minimum value you want in array");
            min =int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the maximum value you want in array");
            max =int.Parse(Console.ReadLine());
            int[] a1 = generate(s, min, max);
            int[] a2, a3;
            a2 = a1;
            a3 = a1;
            Console.WriteLine("Before sorting");
            print(a1);
            
            sw1.Start(); 
            bubblesort(a1);
            sw1.Stop();

            sw2.Start();
            selection(a2);
            sw2.Stop();

            sw3.Start();
            insertion(a3);
            sw3.Stop();

            

            Console.WriteLine("After sorting using bubble sort ");
            print(a1);
            if (check(a1))
            {
                Console.WriteLine("Array is sorted correctly");
            }
            else
            {
                Console.WriteLine("Array is not sorted correctly");
            }
            Console.WriteLine($"Time taken to perform bubblesort is {sw1.Elapsed.TotalMilliseconds} milliseconds");
            Console.WriteLine($"Time taken to perform selection sort is {sw2.Elapsed.TotalMilliseconds} milliseconds");
            Console.WriteLine($"Time taken to perform insertion sort is {sw3.Elapsed.TotalMilliseconds} milliseconds");

            Console.ReadKey();
        }
    }
}
