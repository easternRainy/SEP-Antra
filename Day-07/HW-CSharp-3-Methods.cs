using System;

namespace WorkingWithMethods
{
	static class Program
	{
		public static void Main(String[] args)
		{
			// ReverseArr();
			LoopFibonacci();
		}

		// Q1
		public static void ReverseArr()
		{
			int[] numbers = GenerateNumbers();
			Reverse(numbers);
			PrintNumbers(numbers);
		}

		private static int[] GenerateNumbers()
		{
			int N = new Random().Next(100);

			int[] arr = new int[N];
			for (int i=0; i<N; i++)
			{
				int newRan = new Random().Next(100);
				Console.WriteLine(newRan);
				arr[i] = newRan;
			}

			return arr;
		}

		private static void Reverse(int[] arr)
		{
			int N = arr.Length;
			int left = 0;
			int right = N - 1;

			while (left < right)
			{
				int tmp = arr[left];
				arr[left] = arr[right];
				arr[right] = tmp;

				left += 1;
				right -= 1;
			}
		}

		private static void PrintNumbers(int[] arr)
		{
			int N = arr.Length;

			for (int i=0; i<N; i++)
			{
				if (i == N-1)
				{
					Console.WriteLine(arr[i]);
					continue;
				}
				Console.Write($"{arr[i]}, ");
			}
		}


		// Q2
		public static void LoopFibonacci()
		{
			for(int i=1; i<=10; i++)
			{
				Console.WriteLine(Fibonacci(i));
			}
		}

		public static int Fibonacci(int n)
		{
			if (n == 1 || n == 2)
			{
				return 1;
			}
			else
			{
				return Fibonacci(n-1) + Fibonacci(n-2);
			}
		}
	}

}