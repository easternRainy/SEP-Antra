using System;
using System.Collections;

namespace StringDemos
{
    class Program
    {
        static void Main(String[] args)
        {
            // CopyArray();
            // int[] primes = FindPrimesInRange(2, 100);
            //ManageList();
            // ReverseStr("sample");

            // ProtocolParse("https://www.apple.com/iphone");
            // ProtocolParse("ftp://www.example.com/employee");
            // ProtocolParse("ftp://www.example.com/employee");
            // ProtocolParse("www.apple.com");
            // ExtractPalin("Hi,exe? ABBA! Hog fully a string: ExE. Bob");

            ReverseSen("The quick brown fox jumps over the lazy dog /Yes! Really!!!/.");


        }

        // Q1
        static void ReverseStr(String str)
        {
            char[] arr = str.ToCharArray();
            
            for (int i=arr.Length-1; i>=0; i--)
            {
                System.Console.WriteLine(arr[i]);
            }

            Array.Reverse(arr);

            System.Console.WriteLine(String.Join("", arr));
        }
        

        // Q2
        static void ReverseSen(String sentence)
        {
            
            char[] delims = {' ', '.', ',', ':', ';', '=', '(', ')', '&', '[', ']', '\"', '\'', '\\', '/', '!', '?'};
            String[] splits = sentence.Split(delims);
            System.Console.WriteLine(String.Join("----", splits));
            
        }

        // Q3
        static void ExtractPalin(String str)
        {
            ArrayList palindromes = new ArrayList();
            Stack stack = new Stack();
            
            foreach(char c in str)
            {
                if (Char.IsLetter(c))
                {
                    if (stack.Count == 0)
                    {
                        stack.Push(c);
                        displayStack(stack);
                    }
                    else
                    {
                        char topChar = (char)stack.Pop();


                    }
                    
                }
                else
                {
                    stack.Clear();
                }
                
            }
        }

        static void displayStack(Stack stack)
        {
            foreach (Object o in stack)
            {
                System.Console.Write((char)o);
            }
            System.Console.WriteLine();
        }

        
    
        // Q4
        static void ProtocolParse(String url)
        {
            String protocol = "";
            String server = url;
            String resource = "";

            if (url.Contains("://")) 
            {
                String[] tmp = url.Split("://");
                protocol = tmp[0];
                server = tmp[1];
            }

            if (server.Contains("/")) 
            {
                String[] tmp = server.Split("/");
                server = tmp[0];
                resource = tmp[1];
            }

            System.Console.WriteLine(url);
            System.Console.WriteLine($"[protocol] = {protocol}");
            System.Console.WriteLine($"[server] = {server}");
            System.Console.WriteLine($"[resource] = {resource}");

        }

    }
}