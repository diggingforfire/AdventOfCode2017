using System;
using System.Drawing;
using Console = Colorful.Console;

namespace _03._01
{
	class Program
	{
		static void Main()
		{
			var input = 48;
			var sqrt = Math.Sqrt(input);
			var roundedUp = (int)Math.Round(sqrt, MidpointRounding.AwayFromZero);


			var squared = Math.Pow(roundedUp, 2);


			var tmp = (roundedUp - 1) / 2;

			var tmp2 = tmp + (squared - tmp);
 
			
			 

			/*		37	36	35	34	33	32	31
			 *		38  17  16  15  14  13	30
			 *		39	18   5   4   3  12	29
			 *		40	19   6   1   2  11	28
			 *		41	20   7   8   9  10	27
			 *		42	21  22  23	24	25	26
			 *		43	44	45	46	47	48	49 
			 */            //4 //3 //4 //5 //6

			Console.ReadKey();
		}
	}
}
