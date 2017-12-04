using System;

namespace _03._02
{
	class Program
	{
		static void Main(string[] args)
		{
			void RenderGrid(int count)
			{
				int dimensionSize = (int)Math.Sqrt(count);
			}

			var result = 0;

			RenderGrid(100);

			Console.WriteLine(result);
			Console.ReadKey();
		}

		
	}
}
