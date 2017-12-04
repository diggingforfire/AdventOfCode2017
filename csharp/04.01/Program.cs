using System;
using System.IO;
using System.Linq;

namespace _04._01
{
	class Program
	{
		static void Main()
		{
			var result =
				File.ReadAllLines("input.txt")
				.Select(n => n.Split(' ', StringSplitOptions.RemoveEmptyEntries))
				.Count(n => n.Distinct().Count() == n.Length);

			Console.WriteLine(result);
			Console.ReadKey();
		}
	}
}
