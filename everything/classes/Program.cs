/*
** Resources
** public, private, and protected inherit derivations example (in C++): https://www.programiz.com/cpp-programming/public-protected-private-inheritance
** override property: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/override
** Arrow thingy (called lambda expression/statement):	https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions?redirectedfrom=MSDN
** 														https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-operator#code-try-0
*/

namespace Classes_test
{
	//Regular classe
	public class Monster
	{
		public string name_;
		public int size_;
		public const int legs_ = 2;
		private int scare_;
		public static int nMonster_;
		
		public Monster()
		{
			name_ = "default";
			size_ = 20;
			scare_ = 10;
			nMonster_++;
		}
		public Monster(string name, int size, int scare)
		{
			name_ = name;
			size_ = size;
			scare_ = scare;
			nMonster_++;
		}
		public void print()
		{
			Console.WriteLine("Monster's name: " + name_);
			Console.WriteLine("Monster's size: " + size_);
			Console.WriteLine("Monster's scare: " + scare_);

		}

		// public ~Monster();
	}
	//Abstract class
	public abstract class Character
	{
		public string name_;
		public int speed_;
		public int health_;
		public int test_ = 2;
		public abstract void print(); //MUST BE modified in inheriting classes
		// {
		// 	Console.WriteLine("Create your character...");
		// }
		public int testFunction()
		{
			test_ *= 2;
			return test_;
		}

		public virtual void Swing()
		{
			Console.WriteLine("SWING!");
		}
	}
	public class Swordsman : Character
	{
		public Swordsman()
		{
			name_ = "Zeid";
			speed_ = 10;
			health_ = 100;
		}
		//To implement abstract class, we must use the "override"
		public override void print()
		{
			Console.WriteLine("My name is " + name_);
			Console.WriteLine("Health: " + health_);
			Console.WriteLine("and I am " + speed_ + " fast");
		}
		public override void Swing()
		{
			Console.WriteLine("I'm not going to swing!");
		}
	}
	// public class Program
	// {
	// 	public static void Main(string[] args)
	// 	{
	// 		Monster Dinosaur = new Monster();

	// 		Console.WriteLine(Dinosaur.name_);
	// 		Dinosaur.name_ = "Zeid";
	// 		Console.WriteLine(Dinosaur.name_);
	// 		// Dinosaur.legs_ = 3;
	// 		// Console.WriteLine(Dinosaur.legs_);
	// 		// Console.WriteLine(Dinosaur.scare_);
	// 		Monster Dragon = new Monster("Vorkath", 30, 90);
	// 		Console.WriteLine(Dragon.name_);
	// 		Console.WriteLine(Monster.nMonster_);
	// 		Monster Zombie = new Monster("Zombie", 6, 7);
	// 		Console.WriteLine(Zombie.name_);
	// 		Console.WriteLine(Monster.nMonster_);
	// 		Zombie.print();
	// 		Dinosaur.print();
	// 		Dragon.print();
	// 	}
	// }
	public class Program
	{
		public static void Main(string[] args)
		{
			// Character myChar = new Character();
			Swordsman Zeid = new Swordsman();
			Zeid.print();
			Zeid.testFunction();
			Zeid.Swing();
			Console.WriteLine(Zeid.test_);
		}
	}
}