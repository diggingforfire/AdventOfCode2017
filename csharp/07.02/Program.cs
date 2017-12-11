using System;
using System.IO;
using System.Linq;

namespace _07._02
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
						SubTowers = n.Skip(1).FirstOrDefault()?.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(t => t.Trim()).ToArray()
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

			var lowestTower = towers.Single(t => t.Name == GetParentTower(towers[0].Name));

			int GetWeightOfChildren(string towerName, string[] subtowerNames)
			{
				var tower = towers.Single(t => t.Name == towerName);

				if (subtowerNames == null)
					return tower.Weight;

				var subtowers = subtowerNames.Select(st => towers.Single(t => t.Name == st)).ToArray();

				if (towerName == lowestTower.Name)
				{
					return 0;
				}

				return tower.Weight + subtowers.Sum(st => GetWeightOfChildren(st.Name, st.SubTowers));
			}

			var twrs = lowestTower.SubTowers.Select(st => new
				{
					Tower = st,
					WeightOfChildren = GetWeightOfChildren(st, towers.Single(t => t.Name == st).SubTowers)
				});
			var towersGroupedByWeightOfChildren = twrs
				.GroupBy(t => t.WeightOfChildren)
				.Select(grp => new
				{
					Count = grp.Count(),
					Tower = grp.First()
				})
				.OrderBy(g => g.Count).ToList();

			var diff = Math.Abs(towersGroupedByWeightOfChildren.First().Tower.WeightOfChildren - towersGroupedByWeightOfChildren.Skip(1).First().Tower.WeightOfChildren);
			var weight = towers.Single(t => t.Name == towersGroupedByWeightOfChildren.First().Tower.Tower).Weight;

			var test = lowestTower.SubTowers.Select(st => towers.Single(t => t.Name == st)).ToList();

			var result = weight - diff;

			Console.WriteLine(result);

			Console.ReadKey();
		}
	}
}
