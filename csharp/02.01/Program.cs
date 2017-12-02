using System;
using System.IO;
using System.Linq;

namespace _02._01
{
	class Program
	{
		static void Main()
		{
			var result = File.ReadAllLines("input.txt")
				.Select(row => row.Split('\t', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse).ToArray())
				.Sum(n => n.Max() - n.Min());

			Console.WriteLine(result);
			Console.ReadKey();
		}
	}
}
