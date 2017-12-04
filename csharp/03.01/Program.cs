using System;
using System.Drawing;
using Console = Colorful.Console;

namespace _03._01
{
	class Program
	{
		static void Main()
		{
			int input = 49;

			int dimensionSize = (int)Math.Sqrt(input);

			int center = (dimensionSize - 1) / 2;

			int[,] grid = new int[dimensionSize, dimensionSize];

			grid[center, center] = 1;

			int x, y;
			x = y = center;
			int offset = 1;

			for (int i = 1; i < input; i++)
			{
				
			}

			void RenderGrid()
			{
				for (int i = 0; i < dimensionSize; i++)
				{
					for (int j = 0; j < dimensionSize; j++)
						Console.Write(grid[i,j] + "\t", i == center && j == center ? Color.Red : Color.White);

					Console.WriteLine();
					Console.WriteLine();
					Console.WriteLine();
					Console.WriteLine();
				}

			}

			var result = 0;

			RenderGrid();

			Console.ReadKey();
		}
	}
}
