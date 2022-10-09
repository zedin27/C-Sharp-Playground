/*
** Addidng Matrices: https://www.c-sharpcorner.com/article/add-2d-arraymatric-in-c-sharp/
** 
*/

using System;
namespace Vectors_Matrices
{	
	public class Matrix
	{
		public int x;
		public int y;
		public int z;
		private int[,] array2D;
		private int[,,] array3D;
		public Matrix()
		{
			Console.WriteLine("Matrix constructor created...");
		}
		public Matrix(int value)
		{
			this.x = value;
			this.y = value;
			this.z = value;
			this.array2D = new int[x,y];
			this.array3D = new int[x, y, z];
		}
		public Matrix(int x, int y)
		{
			this.x = x;
			this.y = y;
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
		}
		public void ToConsole()
		{
			if (array2D == null || array2D.Length <= 0)
				return ;
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
		public Matrix(int x, int y, int z)
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

			Matrix myMatrix = new Matrix();
			Matrix my2DMatrix = new Matrix(x, y);
			my2DMatrix.ToConsole();
		}
	}
}
