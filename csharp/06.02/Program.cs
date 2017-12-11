using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _06._02
{
	class Program
	{
		static void Main()
		{
			var banks =
				File.ReadAllText("input.txt")
				.Split("\t", StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			var seen = new Dictionary<string, int>();

			int cycles = 0;
			int result;
			
			while (true)
			{
				var next = banks
					.Select((v, i) => new { v, i })
					.OrderByDescending(n => n.v)
					.ThenBy(n => n.i).First();

				banks[next.i] = 0;

				for (int i = 1; i < next.v + 1; i++)
					banks[(next.i + i) % banks.Length]++;

				cycles++;

				var stringified = string.Join(" ", banks.Select(b => b.ToString()));

				if (seen.ContainsKey(stringified))
				{
					result = cycles - seen[stringified];
					break;
				}

				seen.Add(stringified, cycles);
			}

			Console.WriteLine(result);
			Console.ReadKey();
		}
	}
}
