/*
** Find these commands and figure how to run them in the debugger:
**		!eeheap -gc
**		!dumpheap -stat
** Learn more about the Garbage Collector for memory leaks: https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/
** Tracking with DisplayMemory() method: https://stackoverflow.com/questions/18739892/finding-memory-leaks-in-c-sharp
** PrintArray example (and maaaaybe find something related with strings?): https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/passing-arrays-as-arguments
** 
*/
namespace Mammoth
{
	public class myMain
	{
	static void DisplayMemory()
	{
		Console.WriteLine("Total memory: {0:###,###,###,##0} bytes", GC.GetTotalMemory(true));
		Console.WriteLine("Private bytes {0}", System.Diagnostics.Process.GetCurrentProcess().PrivateMemorySize64);
		Console.WriteLine("Handle count: {0}", System.Diagnostics.Process.GetCurrentProcess().HandleCount);
		Console.WriteLine();
	}
	void PrintArray(int[] arr)
	{
		for (int i = 0; i < arr.GetLength(0); i++)
			Console.Write(arr[i] + " ");
		return ;
	}
	public static void Main(string[] args)
		{
			//Control flow basically means which function goes top-bottom
			List<int> random_nums = new List<int>(); //Dynamic Array
			List<string> Bosses = new List<string>();
			List<string> Monsters = new List<string>();
			int[] nums = new int[10]; //Static Array
			int[,] array2d = new int[2, 2] {{1, 2}, {3, 4}}; //2D Array
			int[,,] array3d = new int[2, 2, 3] {{{1, 2, 3},{4, 5, 6}},{{7, 8, 9},{10, 11, 12}}}; //3D Arrays
			int[][] array_jagged = new int [3][]; //Jagged Arrays (list of lists)
			array_jagged[0] = new int[3] {1, 2, 3};
			array_jagged[1] = new int[7] {4, 5, 6, 7, 8, 9, 10};
			array_jagged[2] = new int[1] {11};
			Random r = new Random(); //RNG
			
			Bosses.Add("Dragon");
			Bosses.Add("Mordekaiser");
			Bosses.Add("Gorilla");
			Bosses.Add("Dinosaur");
			Bosses.Add("Rat");
			Bosses.Add("Broccoli");

			Console.WriteLine("Bosses list size is: " + Bosses.Count());
			Bosses.Remove("Rat");
			Console.WriteLine("Removed \"Rat\" boss");
			Console.WriteLine("Bosses list size is: " + Bosses.Count());
			Bosses.RemoveAt(4);
			Console.WriteLine("Removed 4th index boss");
			Console.WriteLine("Bosses list size is: " + Bosses.Count());
			Monsters.Add("Ghost");
			Monsters.Add("Monke");
			Monsters.AddRange(Bosses);
			Console.WriteLine("Monsters list size is: " + Monsters.Count);

			for (int i = 0; i < Monsters.Count; i++)
				Console.WriteLine("Monster[{0}]: {1}", i, Monsters[i]);

			Console.WriteLine("3D array from arrayd3d[1, 0, 2]: " + array3d[1, 0, 2]);
			Console.WriteLine("My Jagged Array[1][6] (or list of lists) is: " + array_jagged[1][6]);
			Console.WriteLine("Input your number: ");
			switch(Convert.ToInt64(Console.ReadLine()))
			{
				case 42:
					Console.WriteLine("Meaning of life");
					break;
				case 9000:
					Console.WriteLine("IT'S OVER 9000!!!");
					break;
				case 69420:
					Console.WriteLine("Nice");
					break ;
				case 101010:
					Console.WriteLine("Thanks for the fish");
					break ;
				default:
					Console.WriteLine("Nothing interesting happens...");
					break ;
			}
			Console.Write("Before sorted elements: ");
			for (int i = 0; i < nums.GetLength(0); i++)
			{
				nums[i] = r.Next(100);
				random_nums.Add(nums[i]);
				Console.Write(random_nums[i] + " ");
			}
			Console.Write('\n');
			random_nums.Sort();
			Console.Write("After sorted elements: ");
			foreach(int i in random_nums)
				Console.Write(i + " ");
			Console.Write('\n');
			random_nums.AddRange(nums);
			DisplayMemory();
			GC.Collect();
			GC.WaitForPendingFinalizers();
			DisplayMemory();
		}
	}
}