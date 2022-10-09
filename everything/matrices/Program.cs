/*
** Addidng Matrices: https://www.c-sharpcorner.com/article/add-2d-arraymatric-in-c-sharp/
** 
*/

using System;
namespace Vectors_Matrices
{	
	public class Matrices
	{
		public int x;
		public int y;
		public int z;
		public Matrices()
		{
			Console.WriteLine("Matrices constructor created...");
		}
		public Matrices(int value)
		{
			this.x = value;
			this.y = value;
			this.z = value;
		}
		public Matrices(int x, int y)
		{
			int[,] array2D = new int[x, y];
			Console.WriteLine("2D Created with [{0}, {1}] dimensions", x, y);
			for (int i = 0; i < x; i++)
			{
				for (int j = 0; j < y; j++)
				{
					Console.Write("Array Index [{0}, {1}]: ", i, j);
					array2D[i, j] = Convert.ToInt32(Console.ReadLine());
				}
			}

			for (int i = 0; i < x; i++)
			{
				for (int j = 0; j < y; j++)
				{
					if (j == 0)
						Console.Write(array2D[i, j]);
					else
						Console.Write(" " + array2D[i, j]);
				}
				Console.WriteLine();
			}
		}
		public Matrices(int x, int y, int z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			int [,,] array3D = new int[x, y, z];
			Console.WriteLine("3D Created with [{0}, {1}, {2}] dimensions", x, y, z);
		}
	}
	public class Program
	{
		public static void Main(string[] args)
		{
			Console.Write("Insert your x value for the 2D matrix: ");
			int x = Convert.ToInt32(Console.ReadLine());
			Console.Write("Insert your y value for the 2D matrix: ");
			int y = Convert.ToInt32(Console.ReadLine());

			Matrices myMatrix = new Matrices();
			Matrices my2DMatrix = new Matrices(x, y);
		}
	}
}
