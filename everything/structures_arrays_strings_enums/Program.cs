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
	*/

	public struct Monster
	{
		public string name_;
		public int scare_;
		public int size_;

		public Monster(string name, int scare, int size)
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
			Console.WriteLine("Size: " + size_);
			Console.WriteLine("Scare: " + scare_);
		}

	}
	//Structure exercise
	// public class myMain
	// {
	// 	public static void Main(string[] args)
	// 	{
	// 		Monster Mike = new Monster("Mike", 10, 15);
	// 		// Console.WriteLine(Mike.name_);
	// 		Mike.print();

	// 		Monster Jack = new Monster();
	// 		Jack.print();
	// 	}
	// }
	
	public class myMain
	{
		public static void Main(string[] args)
		{
			//not dynamic
			// int[] mynewarray;
			// mynewarray = new int[10];

			//dynamic arrays (Generic list)
			List<Monster> list = new List<Monster>();
			list.Add(new Monster("Joemoma"));
			list.Add(new Monster("Baba"));
			Monster joe = list[1];
			Console.WriteLine(joe);


			// Console.WriteLine(mynewarray[0]);
			// Console.WriteLine(mynewarray[3]);
			// Console.WriteLine(mynewarray[9]);
		}
	}
}