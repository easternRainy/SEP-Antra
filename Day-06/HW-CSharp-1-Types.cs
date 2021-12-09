using System;

namespace LoopsAndOp
{
    public class Program
    {
        static void Main(String[] args)
        {
            // FizzBuzz();
            //ByteLoop();
            // GuessNumber();
            // Print24();
            // BirthDateCal(2000, 1, 1);
            // Greets();
            // Print24();
        }

        // Q1
        static void FizzBuzz()
        {
            int max = 100;
            for (int i=1; i<=max; i++)
            {
                if (i % 5 == 0 && i % 3 == 0)
                {
                    Console.WriteLine("fizzbuzz");
                    continue;
                }

                if (i % 3 == 0)
                {
                    Console.WriteLine("fizz");
                    continue;
                }

                if (i % 5 == 0) 
                {
                    Console.WriteLine("buzz");
                    continue;
                }
            }
        }

        // Q2
        static void ByteLoop() 
        {
            // infinitloop
            // byte will always be less than 500
            int max = 500;
            for (byte i = 0; i < max; i++)
            {
                Console.WriteLine(i);
            }

            // What code could you add to warn the problem?
            // I don't know...
            
        }

        // Q3
        static void GuessNumber()
        {
            int correctNumber = new Random().Next(3) + 1;

            Console.WriteLine("Please guess the number");
            int guessedNumber = int.Parse(Console.ReadLine());
            
            if (guessedNumber == correctNumber)
            {
                Console.WriteLine("Correct!");
            } 
            else if (guessedNumber < 1 || guessedNumber > 3)
            {
                Console.WriteLine("Out of range");
            }
            else if (guessedNumber < correctNumber)
            {
                Console.WriteLine("Guess Low");
            }
            else
            {
                Console.WriteLine("Guess High");
            }

        }
 
        // Q4
        static void BirthDateCal(int year, int month, int day)
        {
            DateTime bd = new DateTime(year, month, day);
            DateTime today = DateTime.Now;
            int dayDiff = (today - bd).Days;
            int daysToNextAnniversary = 10000 - (dayDiff % 10000);
            DateTime nextAnni = today.AddDays(daysToNextAnniversary);
            
            Console.WriteLine("This person is " + dayDiff + " days old");
            Console.WriteLine("The next 10000 day anniversary is " + nextAnni);
        }


        // Q5
        static void Greets()
        {
            DateTime now = DateTime.Now;
            if (now.Hour < 12)
            {
                Console.WriteLine("Good Morning!");
            }
            else if (now.Hour < 18)
            {
                Console.WriteLine("Good Afternoon");
            }
            else if (now.Hour < 21)
            {
                Console.WriteLine("Good Evening");
            }
            else
            {
                Console.WriteLine("Good Night");
            }
        }


        // Q6
        static void Print24()
        {
            for(int step = 1; step <= 4; step++)
            {
                for(int i = 0; i <= 24; i += step)
                {
                    if (i < 24) {
                        Console.Write($"{i},");
                        continue;
                    }
                    Console.WriteLine(i);
                    
                }
            }
        }
 
    }
}