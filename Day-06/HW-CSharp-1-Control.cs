using System;

namespace UnderstandingTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Q1
            showTypes();

            // Q2
            showCenturies();
            
            
        }

        static void showTypes()
        {
            Console.WriteLine(String.Format("{0,-10} | {1,-10} | {2,-40} | {3, -10}", "Type", "Size", "MIN", "MAX"));
            Console.WriteLine(String.Format("{0,-10} | {1,-10} | {2,-40} | {3, -10}", "sbyte", sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue));
            Console.WriteLine(String.Format("{0,-10} | {1,-10} | {2,-40} | {3, -10}", "byte", sizeof(byte), byte.MinValue, byte.MaxValue));
            Console.WriteLine(String.Format("{0,-10} | {1,-10} | {2,-40} | {3, -10}", "short", sizeof(short), short.MinValue, short.MaxValue));
            Console.WriteLine(String.Format("{0,-10} | {1,-10} | {2,-40} | {3, -10}", "ushort", sizeof(ushort), ushort.MinValue, ushort.MaxValue));
            Console.WriteLine(String.Format("{0,-10} | {1,-10} | {2,-40} | {3, -10}", "int", sizeof(int), int.MinValue, int.MaxValue));
            Console.WriteLine(String.Format("{0,-10} | {1,-10} | {2,-40} | {3, -10}", "uint", sizeof(uint), uint.MinValue, uint.MaxValue));
            Console.WriteLine(String.Format("{0,-10} | {1,-10} | {2,-40} | {3, -10}", "long", sizeof(long), long.MinValue, long.MaxValue));
            Console.WriteLine(String.Format("{0,-10} | {1,-10} | {2,-40} | {3, -10}", "ulong", sizeof(ulong), ulong.MinValue, ulong.MaxValue));
            Console.WriteLine(String.Format("{0,-10} | {1,-10} | {2,-40} | {3, -10}", "float", sizeof(float), float.MinValue, float.MaxValue));
            Console.WriteLine(String.Format("{0,-10} | {1,-10} | {2,-40} | {3, -10}", "double", sizeof(double), double.MinValue, double.MaxValue));
            Console.WriteLine(String.Format("{0,-10} | {1,-10} | {2,-40} | {3, -10}", "decimal", sizeof(decimal), decimal.MinValue, decimal.MaxValue));
        }

        static void showCenturies()
        {
            ushort yearInCent = (ushort)100;
            float dayInYear = (float)365.24;
            ushort hourInDay = (ushort)24;
            ushort minInHour = (ushort)60;
            ushort secInMin = (ushort)60;
            ushort millInSec = (ushort)1000;
            uint nanoInMill = (uint)1000000;

            Console.WriteLine("Please enther an interger");
            ushort centurary = ushort.Parse(Console.ReadLine());
            // ushort centurary = (ushort) 1;
            ushort years = (ushort) (centurary * yearInCent);
            uint days = (uint) (years * dayInYear);
            uint hours = (uint) (days * hourInDay);
            uint minutes = (uint) (hours * minInHour);
            ulong seconds = (ulong) (minutes * secInMin);
            ulong milliseconds = (ulong) (seconds * millInSec);
            ulong nanoseconds = (ulong) (milliseconds * nanoInMill);

            // uint days = 365 * years;
            Console.WriteLine($"{centurary} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {nanoseconds} nanoseconds");
        }
    }
}
