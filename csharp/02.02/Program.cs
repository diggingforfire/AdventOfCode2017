using System;
using System.IO;
using System.Linq;

namespace _02._02
{
	class Program
	{
		static void Main()
		{
			var result = File.ReadAllLines("input.txt")
				.Select(row => row.Split('\t', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse).ToArray())
				.Sum(n => n.SelectMany(p => n.Where(o => p % o == 0 && p != o).Select(o => p / o)).First());

			Console.WriteLine(result);
			Console.ReadKey();
		}
	}
}
