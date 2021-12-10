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

            // int[] arr = {7,7,7,0,2,2,2,0,10,10,10};
            // int max_num = MostFreqNum(arr);
            // System.Console.WriteLine(max_num);

            // int[] arr = {2,1,1,2,3,3,2,2,2,1};
            // LongestSubseq(arr);

            int[] arr = {3, 2, 4, -1};
            RotateArray(arr, 2);


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
        static void RotateArray(int[] arr, int k)
        {
            int n = arr.Length;
            int[] sum = new int[n];
            int[] prev = arr;
            int[] rotate;

            for (int i = 0; i < k; i++) 
            {
                rotate = RotateOnce(prev);
                
                Console.WriteLine(String.Join(" ", rotate));

                for (int j = 0; j < n; j++)
                {
                    sum[j] += rotate[j];
                }

                prev = rotate;
            }

            Console.WriteLine(String.Join(" ", sum));
        }

        static int[] RotateOnce(int[] arr) 
        {
            int n = arr.Length;
            int[] newArr = new int[n];

            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    newArr[i] = arr[n-1];
                }
                else
                {
                    newArr[i] = arr[i-1];
                }
            }

            return newArr;
        }

        // Q5
        static void LongestSubseq(int[] arr)
        {
            int currNum = int.MinValue;
            int currFreq = int.MinValue;
            int maxNum = int.MinValue;
            int maxFreq = int.MinValue;

            foreach (int num in arr)
            {
                if (num != currNum) {
                    currNum = num;
                    currFreq = 1;
                }
                else
                {
                    currFreq += 1;
                    if (currFreq > maxFreq)
                    {
                        maxFreq = currFreq;
                        maxNum = num;
                    }
                }
            }

            for (int i = 0; i < maxFreq; i++)
            {
                if ( i != maxFreq - 1)
                {
                    Console.Write(maxNum + " ");
                }
                else
                {
                    Console.WriteLine(maxNum);
                }
                
            }
        }


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