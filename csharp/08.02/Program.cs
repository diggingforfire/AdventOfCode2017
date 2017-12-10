using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace _08._02
{
	class Program
	{
		static void Main()
		{
			var input =
				File.ReadAllLines("input.txt")
					.Select(n => n.Split(' ', StringSplitOptions.RemoveEmptyEntries))
					.ToArray();

			var registers = new Dictionary<string, int>(input.Select(n => n[0]).Distinct().Select(n => new KeyValuePair<string, int>(n, 0)));

			var table = new DataTable();
			table.Columns.Add(new DataColumn("0", typeof(bool), string.Empty));
			table.Columns.Add(new DataColumn("1", typeof(int), string.Empty));
			table.Rows.Add(0);

			int highest = 0;
			input
				.ToList()
				.ForEach(tokens =>
				{
					table.Columns[0].Expression = $"{registers[tokens[4]]} {tokens[5].Replace("==", "=").Replace("!=", "<>")} {tokens[6]}";
					table.Columns[1].Expression = $"{tokens[1].Replace("inc", "+").Replace("dec", "-")}{int.Parse(tokens[2])}";
					registers[tokens[0]] += (int)table.Rows[0]["1"] * Convert.ToInt32(table.Rows[0]["0"]);
					highest = Math.Max(highest, registers[tokens[0]]);
				});

			Console.WriteLine(highest);
			Console.ReadKey();
		}
	}
}
