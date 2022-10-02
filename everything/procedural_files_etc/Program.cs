/*
** Procedural programming is making calls to functions/routines/subroutines
** TODO:	Vector math class
** 			Transofmration class (scaling, translation, rotation)
** A-B:		Create a GUI with the implementation
** 			Add code and interactive with inputs (readkey?)
**			Read it from a file?
**
** A-B = above and beyond
*/


using System.IO;

namespace procedural_files_etc
{
	public class Program
	{
		static int add(int x, int y)
		{
			Console.Write("Result: ");
			return x + y;
		}
		public static void Main(string[] args)
		{
			Console.WriteLine(add(5,5));
		}
	}
}
