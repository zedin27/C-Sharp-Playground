/*
** Procedural programming is making calls to functions/routines/subroutines
** Tuples return value in a class
** Enumerables (IEnumerators and IEnumerables): https://www.youtube.com/watch?v=UfT-st9dl8Q&ab_channel=AngelSix
** IEnumerator vs. IEnumerable difference
** TODO:	Vector math class
** 			Transofmration class (scaling, translation, rotation)
** A-B:		Create a GUI with the implementation
** 			Add code and interactive with inputs (readkey?)
**			Read it from a file?
**
** A-B = above and beyond
*/



namespace procedural_files_etc
{
	public class VectorMaths
	{
		public double x;
		public double y;
		public double z;
		public VectorMaths()
		{

		}
		public VectorMaths(double value)
		{
			this.x = value;
			this.y = value;
			this.z = value;
		}
		public VectorMaths(double x, double y)
		{
			this.x = x; //or this.x
			this.y = y; //or this.y
		}
		public VectorMaths(double x, double y, double z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
		public static VectorMaths Add(VectorMaths value1, VectorMaths value2)
		{
			value1.x += value2.x;
			value1.y += value2.y;
			return value1;
		}
		public static void Add(ref VectorMaths value1, ref VectorMaths value2, out VectorMaths result)
		{
			result = new VectorMaths();
			result.x = value1.x + value2.x;
			result.y = value1.y + value2.y;
		}
		public double substraction()
		{
			return 0;
		}
		public double dot()
		{
			return 0;
		}
		public double cross()
		{
			return 0;
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
		//TODO: Tuple creations soon(tm)
		static double start(double x, double y)
		{
			// var nums = new Tuple<double, double>(x, y); Check this one out instead of Tuple.Create()
			Console.Write("Give x and y value: ");
			VectorMaths values = new VectorMaths(x, y);
			var line = Console.ReadLine();
			var data = line.Split(' ');
			values.x = double.Parse(data[0]);
			values.y = double.Parse(data[1]);
			var nums = Tuple.Create(values.x, values.y);
			Console.WriteLine("This is a tuple with their item values: {0} {1}\n", nums.Item1, nums.Item2);
			Console.WriteLine("This is a data test: {0} {1}\n", data[0], data[1]);
			Console.Write("Tuple values of x and y: {0}\n", nums);
			return values.x; //return it to x and y with out?
		}
		//TODO: Maybe try to figure out how to take the vector values in the parameters?
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
			VectorMaths res = VectorMaths.Add(v1, v2);
			Console.WriteLine(res.x + " " + res.y);
		}
	}
}
