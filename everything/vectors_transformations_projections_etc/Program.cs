/*
** Enumerables (IEnumerators and IEnumerables): https://www.youtube.com/watch?v=UfT-st9dl8Q&ab_channel=AngelSix
** IEnumerator vs. IEnumerable difference
** TODO:	Vector math class
**			Transofmration class (scaling, translation, rotation)
** A-B:		Create a GUI with the implementation
**			Add code and interactive with inputs (readkey?)
**			Read it from a file?
** Matrix topics:
**				https://www.codeproject.com/Articles/5262037/Csharp-Implementation-of-Basic-Linear-Algebra-Conc
**				
** note -> A-B above and beyond™
*/

using System.Text.Encodings;
using Pastel;

namespace procedural_files_etc
{
	public struct Matrix
	{
		double M11;
		double M12;
		double M13;
		double M14;
		double M21;
		double M22;
		double M23;
		double M24;
		double M31;
		double M32;
		double M33;
		double M34;
		double M41;
		double M42;
		double M43;
		double M44;
		Matrix			(double m11, double m12, double m13, double m14,
						double m21, double m22, double m23, double m24,
						double m31, double m32, double m33, double m34,
						double m41, double m42, double m43, double m44)
		{
			this.M11 = m11;
			this.M12 = m12;
			this.M13 = m13;
			this.M14 = m14;
			this.M21 = m21;
			this.M22 = m22;
			this.M23 = m23;
			this.M24 = m24;
			this.M31 = m31;
			this.M32 = m32;
			this.M33 = m33;
			this.M34 = m34;
			this.M41 = m41;
			this.M42 = m42;
			this.M43 = m43;
			this.M44 = m44;
		}
	}
	public class VectorMaths
	{
		public double x;
		public double y;
		public double z;
		public double w;
		public VectorMaths()
		{

		}
		public VectorMaths(double value)
		{
			this.x = value;
			this.y = value;
			this.z = value;
			this.w = value;
		}
		public VectorMaths(double x, double y)
		{
			this.x = x;
			this.y = y;
		}
		public VectorMaths(double x, double y, double z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
		public VectorMaths(double x, double y, double z, double w)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}
		public static double Magnitude(VectorMaths value1)
		{
			double result;
			result = Math.Sqrt((value1.x * value1.x) + (value1.y * value1.y) + (value1.z * value1.z));
			return result;
		}
		public static VectorMaths Add(VectorMaths value1, VectorMaths value2)
		{
			value1.x += value2.x;
			value1.y += value2.y;
			value1.z += value2.z;
			return value1;
		}
		public static void Add(ref VectorMaths value1, ref VectorMaths value2, out VectorMaths result)
		{
			result = new VectorMaths();
			result.x = value1.x + value2.x;
			result.y = value1.y + value2.y;
			result.z = value1.z + value2.z;
		}
		public static VectorMaths Substraction(VectorMaths value1, VectorMaths value2)
		{
			value1.x -= value2.x;
			value1.y -= value2.y;
			value1.z -= value2.z;
			return value1;
		}
		public static void Substraction(ref VectorMaths value1, ref VectorMaths value2, out VectorMaths result)
		{
			result = new VectorMaths();
			result.x = value1.x - value2.x;
			result.y = value1.y - value2.y;
			result.z = value1.z - value2.z;
		}
		public static VectorMaths Multiply(VectorMaths value1, VectorMaths value2)
		{
			value1.x *= value2.x;
			value1.y *= value2.y;
			value1.z *= value2.z;	
			return value1;
		}
		public static void Multiply(ref VectorMaths value1, ref VectorMaths value2, out VectorMaths result)
		{
			result = new VectorMaths();
			result.x = value1.x * value2.x;
			result.y = value1.y * value2.y;
			result.z = value1.z * value2.z;
		}
			public static VectorMaths Divide(VectorMaths value1, VectorMaths value2)
		{
			value1.x /= value2.x;
			value1.y /= value2.y;
			value1.z /= value2.z;	
			return value1;
		}
		public static void Divide(ref VectorMaths value1, ref VectorMaths value2, out VectorMaths result)
		{
			result = new VectorMaths();
			result.x = value1.x / value2.x;
			result.y = value1.y / value2.y;
			result.z = value1.z / value2.z;
		}
		public static double Dot(VectorMaths value1, VectorMaths value2)
		{
			return (value1.x * value2.x) + (value1.y * value2.y) + (value1.z * value2.z);
		}
		public static void Dot(ref VectorMaths value1, ref VectorMaths value2, out double result)
		{
			result = (value1.x * value2.x) + (value1.y * value2.y) + (value1.z * value2.z);
		}
		public static VectorMaths Cross(VectorMaths value1, VectorMaths value2)
		{
			VectorMaths value3 = new VectorMaths();
			value3.x = (value1.y * value2.z) - (value1.z * value2.y);
			value3.y = (value1.z * value2.x) - (value1.x * value2.z);
			value3.z = (value1.x * value2.y) - (value1.y * value2.x);
			return value3;
		}
		// public static VectorMaths Reflect(VectorMaths value1, VectorMaths normal) //This is for 3D matrices though
		// {
		// 	VectorMaths reflectedVector = new VectorMaths();
		// 	double dotProduct;
			
		// 	dotProduct = Dot(value1, normal);
		// 	reflectedVector.x = value1.x - (2.0f * normal.x) * dotProduct;
		// 	reflectedVector.y = value1.y - (2.0f * normal.y) * dotProduct;
		// 	reflectedVector.z = value1.z - (2.0f * normal.z) * dotProduct;
		// 	return reflectedVector;
		// }
		// public static void Reflect(ref VectorMaths value1, VectorMaths normal, out VectorMaths result)
		// {
		// 	result = new VectorMaths();
		// 	double dotProduct;

		// 	dotProduct = ((value1.x * normal.x) + (value1.y * normal.y) + (value1.z * normal.z));
		// 	result.x = value1.x - (2.0f * normal.x) * dotProduct;
		// 	result.y = value1.y - (2.0f * normal.y) * dotProduct;
		// 	result.z = value1.z - (2.0f * normal.z) * dotProduct;

		// }
		public void finish()
		{
			Console.WriteLine("Finish. Press enter to continue...");
			Console.ReadKey();
			return;
		}
	}
	
	public class Transofmrations
	{
		// public Matrix(double m11, double m12)
		// {

		// }
	}
	public class Projections
	{

	}
	

	public class Program
	{
		/*TODO: Tuple creations soon™*/
		// static double start(double x, double y)
		// {
		// 	// var nums = new Tuple<double, double>(x, y); Check this one out instead of Tuple.Create()
		// 	Console.Write("Give x and y value: ");
		// 	VectorMaths values = new VectorMaths(x, y);
		// 	var line = Console.ReadLine();
		// 	var data = line.Split(' ');
		// 	values.x = double.Parse(data[0]);
		// 	values.y = double.Parse(data[1]);
		// 	var nums = Tuple.Create(values.x, values.y);
		// 	Console.WriteLine("This is a tuple with their item values: {0} {1}\n", nums.Item1, nums.Item2);
		// 	Console.WriteLine("This is a data test: {0} {1}\n", data[0], data[1]);
		// 	Console.Write("Tuple values of x and y: {0}\n", nums);
		// 	return values.x; //return it to x and y with out?
		// }
		
		/*TODO: Maybe try to figure out how to take the vector values in the parameters?*/
		// 	static double start(double v1_x, double v1_y, double v2_x, double v2_y)
		// {
		// 	// var nums = new Tuple<double, double>(x, y); Check this one out instead of Tuple.Create()
		// 	VectorMaths v1 = new VectorMaths(v1_x, v1_y);
		// 	VectorMaths v2 = new VectorMaths(v2_x, v2_y);
		// 	Console.Write("Give first vector x and y values: ");
		// 	Console.Write("Give second vector x and y values: ");
		// 	var line = Console.ReadLine();
		// 	var data = line.Split(' ');
		// 	values.x_ = double.Parse(data[0]);
		// 	values.y = double.Parse(data[1]);
		// 	var nums = Tuple.Create(values.x_, values.y_);
		// 	Console.WriteLine("This is a tuple with their item values: {0} {1}\n", nums.Item1, nums.Item2);
		// 	Console.WriteLine("This is a data test: {0} {1}\n", data[0], data[1]);
		// 	Console.Write("Tuple values of x and y: {0}\n", nums);
		// 	return values.x_; //return it to x and y with out?
		// }
		public static void Main(string[] args)
		{
			var stdout = Console.OpenStandardOutput();
			var con = new StreamWriter(stdout, System.Text.Encoding.ASCII);
			con.AutoFlush = true;
			Console.SetOut(con);

			VectorMaths v1 = new VectorMaths(2, 6);
			VectorMaths v2 = new VectorMaths(10.15, 0.02);
			VectorMaths v3 = new VectorMaths();
			VectorMaths v4 = new VectorMaths(2, 3, 4);
			VectorMaths v5 = new VectorMaths(5, 6, 7);
			VectorMaths v6 = new VectorMaths(6, 8);
			VectorMaths v7 = new VectorMaths(-6, 5);
			VectorMaths v8 = new VectorMaths(8, 12);
			VectorMaths v11 = new VectorMaths(2, 6);
			VectorMaths v22 = new VectorMaths(10.15, 0.02);
			VectorMaths v12 = new VectorMaths(1, 2, 3);
			VectorMaths v13 = new VectorMaths(4, 5, 6);
			VectorMaths v14 = new VectorMaths(1, 2, 3);
			VectorMaths v15 = new VectorMaths(4, 5, 6);

			double mag_val = VectorMaths.Magnitude(v6);
			VectorMaths res = VectorMaths.Add(v1, v2);
			VectorMaths res0 = VectorMaths.Substraction(v11, v22);
			VectorMaths res2 = VectorMaths.Multiply(v14, v15);
			double res3 = VectorMaths.Dot(v12, v13);
			VectorMaths res1 = VectorMaths.Cross(v4, v5);

			Console.WriteLine("~~~~Vectors~~~~");
			Console.WriteLine($"Magnitude of vector is: {mag_val}");
			Console.WriteLine($"Add vectors: ({res.x}, {res.y})");
			Console.WriteLine($"Substract vectors: ({res0.x}, {res0.y})");
			Console.WriteLine($"Multiply vectors: ({res2.x}, {res2.y}, {res2.z})");
			Console.WriteLine($"Dot Product: {res3}");
			Console.WriteLine($"Cross Product: ({res1.x}, {res1.y}, {res1.z})");

			Console.WriteLine("~~~~Transformations~~~~");

			Console.WriteLine("\x1b[36mTEST\x1b[0m");
			Console.WriteLine("colorize me".Pastel("#1E90FF"));
		}
	}
}
