using System;
using System.IO;
using System.Linq;

namespace _04._02
{
	class Program
	{
		static void Main()
		{
			var result =
				File.ReadAllLines("input.txt")
				.Select(n => n.Split(' ', StringSplitOptions.RemoveEmptyEntries))
				.Count(n => !n.Any(p => n.Any(o => !ReferenceEquals(o, p) && p.OrderBy(c => c).SequenceEqual(o.OrderBy(c => c)))));

			Console.WriteLine(result);
			Console.ReadKey();
		}
	}
}
