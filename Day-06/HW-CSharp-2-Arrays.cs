using System;
using System.Collections;

namespace ArrayDemo
{
    class Program
    {
        static void Main(String[] args)
        {
            // CopyArray();
            // int[] primes = FindPrimesInRange(2, 100);
            //ManageList();

            int[] arr = {7,7,7,0,2,2,2,0,10,10,10};
            int max_num = MostFreqNum(arr);
            System.Console.WriteLine(max_num);
        }

        // Q1
        static void CopyArray()
        {
            int[] initArr = {1,2,3,4,5,6,7,8,9,10};
            int n = initArr.Length;
            int[] newArr = new int[n];

            for (int i = 0; i < n; i++)
            {
                newArr[i] = initArr[i];
            }

            for (int i = 0; i < n; i++)
            {
                System.Console.WriteLine(newArr[i]);
            }
        }
    
        
        // Q2
        static void ManageList()
        {
            ArrayList arr = new ArrayList();

            while (true)
            {
                Console.WriteLine("Enter command (+ item, - item, or -- to clear, 0 to exit)):");
                String item = Console.ReadLine();

                if (item  == "0")
                {
                    break;
                    
                }

                if (item == "--")
                {
                    arr.Clear();
                    Console.WriteLine(String.Join(", ", arr.ToArray(typeof(String)) as String[]));
                    continue;
                }

                if (item.StartsWith("+"))
                {
                    arr.Add(item.Split(" ")[1]);
                    Console.WriteLine(String.Join(", ", arr.ToArray(typeof(String)) as String[]));
                    continue;
                }

                if (item.StartsWith("-"))
                {
                    arr.Remove(item.Split(" ")[1]);
                    Console.WriteLine(String.Join(", ", arr.ToArray(typeof(String)) as String[]));
                    continue;
                }

            }
        }

        // Q3
        static int[] FindPrimesInRange(int startNum, int endNum)
        {
            ArrayList primes = new ArrayList();
            for (int i = startNum; i <= endNum; i++) 
            {
                if (isPrime(i))
                {
                    primes.Add(i);
                    System.Console.WriteLine(i);
                }
            }

            return primes.ToArray(typeof(int)) as int[];

        }

        static bool isPrime(int num)
        {
            if (num <= 2)
            {
                return num == 2;
            }

            int p = 2;
            while (p * p <= num)
            {
                if (num % p == 0)
                {
                    return false;
                }

                p += 1;
            }

            return true;
        }


        // Q4
        static void RotateArray()
        {

        }

        // Q5


        // Q7
        static int MostFreqNum(int[] arr)
        {
            Hashtable table = new Hashtable();

            for (int i=0; i<arr.Length; i++)
            {
                if ( table.ContainsKey(arr[i]) )
                {
                    table[arr[i]] = (int)table[arr[i]] + 1;
                }
                else
                {
                    table.Add(arr[i], 1);
                }
            }

            int max_freq = 0;
            int max_num = int.MinValue;
            foreach (DictionaryEntry de in table)
            {
                if ((int)de.Value > max_freq)
                {
                    max_freq = (int)de.Value;
                    max_num = (int)de.Key;
                }
            }

            return max_num;
        }
    
    }
}