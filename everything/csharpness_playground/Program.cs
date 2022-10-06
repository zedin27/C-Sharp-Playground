/*
** Resources to see:
** Old program style? np: https://learn.microsoft.com/en-us/dotnet/core/tutorials/top-level-templates#use-the-old-program-style
** Official .NET documentation: https://learn.microsoft.com/en-us/dotnet/core/tutorials/debugging-with-visual-studio-code?pivots=dotnet-6-0
** Debugging: https://code.visualstudio.com/docs/editor/debugging#_launch-configurations
** Read about "Solutions" in the .NET documentations
*/

// .NET 6.0+ template
// Console.WriteLine("Hello, World!");

// .NET 5.0 template

using System.Collections;

namespace Program
{
	public class MyInfiniteEnumerable : IEnumerable<int>
	{
		private int[] myData = new [] {4, 5, 6};
		public IEnumerator<int> GetEnumerator()
		{
			return new MyInfiniteEnumerator(myData);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new MyInfiniteEnumerator(myData);
		}
	}

	public class MyInfiniteEnumerator : IEnumerator<int>
	{
		private int[] mValues;
		private int mIndex = -1;
		public int Current => mValues[mIndex];

		object IEnumerator.Current => Current;

		public MyInfiniteEnumerator(int[] values)
		{
			mValues = values;
		}

		public void Dispose()
		{
			
		}

		public bool MoveNext()
		{
			mIndex++;
			return mIndex < mValues.Length;
		}

		public void Reset()
		{
			mIndex = 0;
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			// private static Tuple<double, double> Nameofthething(IEnumerable<double> values)

			// static int add(int x, int y)
			// {
			// 	int result = x + y;
			// 	return result;
			// }

			int MAX_INT = 0b1111111111111111111111111111111;
			int MIN_INT = 0b1111111111111111111111111111111 << 31;
			int x = 60;
			double y = 60.60;
			char z = 'z';
			string str = "my string";

			// Console.WriteLine(add(2, 2));
			// float floatA = 2.3f;
			double doubleA = 12;
			// sbyte sbyteA = 14;

			int intA = (int)doubleA;
			short shortA = (short)intA;
			Console.WriteLine(intA);
			double doubleB = 2.123456789;
			float floatB = (float)doubleB;
			Console.WriteLine(floatB);

			// var array = new int[] {1, 2 , 3};
			// array.GetEnumerator();
			// foreach (var a in array)
			// 	Console.WriteLine($"A is {a}");

			// var enumerator = array.GetEnumerator();
			// while (enumerator.MoveNext())
			// 	Console.WriteLine($"Enumerator is {enumerator.Current}");

			var infiniteEnumerable = new MyInfiniteEnumerable();
			var enumerator = infiniteEnumerable.GetEnumerator();
			
			// foreach (var i in infiniteEnumerable)
			// 	Console.WriteLine($"I is {i}");
			
			while (enumerator.MoveNext())
				Console.WriteLine($"Enumerator is {enumerator.Current}");
			// Console.ReadLine();
			// Look into ToInt, ToString, and so on...
		}
	}
}

