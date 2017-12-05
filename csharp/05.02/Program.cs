using System;
using System.IO;
using System.Linq;

namespace _05._02
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
				for (int index = 0; ; result++)
				{
					int oldIndex = index;
					index += input[index];
					input[oldIndex] += index - oldIndex >= 3 ? -1 : 1;
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
