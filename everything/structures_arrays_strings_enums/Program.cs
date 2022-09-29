/*
** Generic lists? Read into it
*/

namespace Structures
{
	/*
	** Structures are similar to classes in the sense
	** of having public and private data members
	** Structures are a value type, while classes are not.
	** Classes support inheritance and polymorphism, but
	** structures dont.
	** Also, the default in classes are private, while
	** structs are public.
	*/

	public struct Monster
	{
		public string? name_;
		public int? scare_;
		public double? size_;

		public Monster(string name, double? size = null, int? scare = null)
		{
			name_ = name;
			scare_ = scare;
			size_ = size;
		}
		public void print()
		{
			if (name_ != null)
				Console.WriteLine("New monster created named: " + name_ + "!");
			else
			{
				Console.WriteLine("No name monster. Give name first");
				return ;
			}
			if (size_ >= 0 || scare_ > 0)
			{
				Console.WriteLine("Size: " + size_);
				Console.WriteLine("Scare: " + scare_);
			}
			else
			{
				Console.WriteLine("error: Monster's scare or/and size is less than 1. Needs a number higher than 1");
				return ;
			}
		}

	}
	//Structure exercise
	public class myMain
	{
		public static void Main(string[] args)
		{
			Monster Mike = new Monster("Mike", 1);
			Monster Jack = new Monster();
			// Console.WriteLine(Mike.name_);
			Mike.print();
			Jack.print();
		}
	}
	

	//Array testing
	//TODO: Test out how to make it dynamic
	
	//Arrays
	// public class myMain
	// {
	// 	public static void Main(string[] args)
	// 	{
	// 		//not dynamic
	// 		// int[] mynewarray;
	// 		// mynewarray = new int[10];
			
	// 		//dynamic arrays (Generic list)
	// 		List<Monster> list = new List<Monster>();
	// 		list.Add(new Monster("Joemoma", 10, 15));
	// 		list.Add(new Monster("Baba", 10, 15));
	// 		Monster joe = list[1];
	// 		Console.WriteLine(list[0]);


	// 		// Console.WriteLine(mynewarray[0]);
	// 		// Console.WriteLine(mynewarray[3]);
	// 		// Console.WriteLine(mynewarray[9]);
	// 	}
	// }
	
	//Enum exercise
	// public class myMain
	// {
	// 	enum Direction
	// 	{
	// 		INVALID_DIRECTION,
	// 		Left,
	// 		Up,
	// 		Right,
	// 		Down
	// 	}
	// 	public static void Main(string[] args)
	// 	{
	// 		// Direction dir_ = new Direction();
		
	// 		// string dir;

	// 		// while(true)
	// 		// {
	// 		// 	dir = Console.ReadKey().Key;
	// 		// 	if (dir == "1")
	// 		// 		Console.WriteLine("Go Left");
	// 		// 	else if (dir == "2")
	// 		// 		Console.WriteLine("Go Up");
	// 		// 	else if (dir == "3")
	// 		// 		Console.WriteLine("Go Right");
	// 		// 	else if (dir == "4")
	// 		// 		Console.WriteLine("Go Down");
	// 		// 	else
	// 		// 		Console.WriteLine("Invalid direction value");
	// 		// }
	// 		ConsoleKeyInfo cki;

	// 		Console.TreatControlCAsInput = true;

	// 		Console.WriteLine("Press any combination of CTL, ALT, and SHIFT, and a console key.");
	// 		Console.WriteLine("Press the Escape (Esc) key to quit: \n");
	// 		while (true)
	// 		{
	// 			cki = Console.ReadKey();
	// 			Console.Write(" --- You've pressed: ");
	// 			if ((cki.Modifiers & ConsoleModifiers.Alt) != 0)
	// 				Console.Write("ALT+");
	// 			if ((cki.Modifiers & ConsoleModifiers.Shift) != 0)
	// 				Console.Write("SHIFT+");
	// 			if ((cki.Modifiers & ConsoleModifiers.Control) != 0)
	// 			{
	// 				Console.Write("CTRL+");
	// 				Console.Write("Exiting program now...");
	// 				return ;
	// 			}
	// 			Console.WriteLine(cki.Key.ToString());
	// 		}
	// 	}
	// }
}