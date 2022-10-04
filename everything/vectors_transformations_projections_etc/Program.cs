/*
** Enumerables (IEnumerators and IEnumerables): https://www.youtube.com/watch?v=UfT-st9dl8Q&ab_channel=AngelSix
** IEnumerator vs. IEnumerable difference
** TODO:	Vector math class
**			Transofmration class (scaling, translation, rotation)
** A-B:		Create a GUI with the implementation
**			Add code and interactive with inputs (readkey?)
**			Read it from a file?
**
** note -> A-B above and beyond™
*/



namespace procedural_files_etc
{
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
		public void finish()
		{
			Console.WriteLine("Finish. Press enter to continue...");
			Console.ReadKey();
			return;
		}
	}
	
	public class Transofmrations
	{

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


			Console.WriteLine($"Magnitude of vector is: {mag_val}");
			Console.WriteLine($"Add vectors: ({res.x}, {res.y})");
			Console.WriteLine($"Substract vectors: ({res0.x}, {res0.y})");
			Console.WriteLine($"Multiply vectors: ({res2.x}, {res2.y}, {res2.z})");
			Console.WriteLine($"Dot Product: {res3}");
			Console.WriteLine($"Cross Product: ({res1.x}, {res1.y}, {res1.z})");
		}
	}
}
