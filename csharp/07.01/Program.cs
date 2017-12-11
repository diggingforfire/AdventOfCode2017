using System;
using System.IO;
using System.Linq;

namespace _07._01
{
	class Program
	{
		static void Main()
		{
			var towers =
				File.ReadAllLines("input.txt")
					.Select(n => n.Replace('(', ' ').Replace(')', ' ').Split("->", StringSplitOptions.RemoveEmptyEntries))
					.Select(n => new
					{
						Name = n[0].Split(' ', StringSplitOptions.RemoveEmptyEntries)[0],
						Weight = int.Parse(n[0].Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]),
						SubTowers = n.Skip(1).FirstOrDefault()?.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(t => t.Trim())
					})
					.ToList();

			string GetParentTower(string name)
			{
				var tower = towers.Single(t => t.Name == name);
				var parent = towers.FirstOrDefault(t => t.SubTowers != null && t.SubTowers.Contains(tower.Name));
				if (parent == null)
					return tower.Name;
				return GetParentTower(parent.Name);
			}

			var result = GetParentTower(towers[0].Name);

			Console.WriteLine(result);
			Console.ReadKey();
		}
	}
}
