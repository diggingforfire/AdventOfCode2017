using System;
using System.IO;
using System.Linq;

namespace _05._01
{
	class Program
	{
		static void Main()
		{
			var input =
				File.ReadAllLines("input.txt")
				.Select(int.Parse)
				.ToArray();

			int result = 0;

			try
			{
				for (int index = 0;; result++)
				{
					index += input[index]++;
				}
			}
			// Instead of proper bounds checking, just to annoy Teun
			catch (IndexOutOfRangeException)
			{
				Console.WriteLine(result);
				Console.ReadKey();
			}
		}
	}
}
