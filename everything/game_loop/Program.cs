/*
** [STAThread]
** Nullable Value Types => datatype?
** Null Coalescing Operator => foo ?? bar
** Assembly references: https://stackoverflow.com/questions/42000798/how-do-i-add-assembly-references-in-visual-studio-code
** Use the NuGet package manager to get what you want.
** StringBuilder or concat?: https://learn.microsoft.com/en-us/dotnet/csharp/how-to/concatenate-multiple-strings#stringbuilder
** Checking if a file/directory exists: https://www.c-sharpcorner.com/UploadFile/dbeniwal321/check-if-a-file-exists-in-C-Sharp/
** TODO: Tiny functions for File existance and directory.
*/

namespace game_loop
{

	// Check later:
	//public struct Biography
	// {
	// 	string journal;
	// 	string ?firstName_ = null;
	// 	string ?lastName_ = null;
	// 	string ?hobby_ = null;
	// 	string ?yourName_ = null;
	// 	string ?mood_ = null;
	// 	string ?story_ = null;
	// 	public Biography(string journal, string firstName, string lastName, string hobby, string ?yourName, string mood, string story);
	// 	// public Biography(int NoOp);
	// 	// ~Biography();
	// 	public void storyPiece()
	// 	{
	// 		story = $"Dear diary, \n\nMy name is {firstName} {lastName}. I have a passion in {hobby} and I feel {mood}.\nIf you find this, let others know how is their day too and what they are passionate about.\n\n\n{dateString}";
	// 	}
		
	// }
	public class myMain
	{
		public static void Main(string[] args)
		{
			string fileName = "The Story of Soonertem.txt"; //Have this as the name of the file as an input choice
			string directory = Directory.GetCurrentDirectory() + "/stories";
			string filePath = Directory.GetCurrentDirectory() + "/stories/" + fileName;
			string dateString = DateTime.Today.ToShortDateString();
			string ?firstName = null;
			string ?lastName = null;
			string ?hobby = null;
			string ?yourName = null;
			string ?mood = null;
			string ?story = null;
			// int flag = 1;
			// if (!(Directory.Exists(directory)))
			// {
			// 	Console.WriteLine("Creating a journal folder...");
			// 	Directory.CreateDirectory(directory);
			// }
			// Console.WriteLine(fileName);
			// Console.WriteLine(filePath);
			// Console.WriteLine(directory);
			if (File.Exists(fileName))
			{
				Console.WriteLine("I exist already. BE GONE!");
				return ;
			}
			else
			{
				Console.WriteLine("~~~~~~Press 1 to start~~~~~~");
				Console.WriteLine("Name of your journal: ");
				// fileName = Console.Read();
				Console.WriteLine(fileName);
				if (Console.ReadLine() == "1")
				{
					while (true)
					{
						if (firstName == null && lastName == null)
						{
							Console.WriteLine("Who are you?");
							firstName = Console.ReadLine();
							Console.WriteLine("And last name?");
							lastName = Console.ReadLine();
							yourName = firstName + " " + lastName;
						}
						Console.WriteLine($"Sup {yourName}. How are you feeling today?");
						if (hobby == null)
							mood = Console.ReadLine();
						Console.WriteLine($"{mood} you say {yourName}? Interesting. What hobbies do you have?");
						if (hobby == null)
							hobby = Console.ReadLine();
						Console.WriteLine($"You like to {hobby}?. Sounds inducing... I made a journal for you saved somewhere.");
						story = $"Dear diary, \n\nMy name is {firstName} {lastName}. I have a passion in {hobby} and I feel {mood}.\nIf you find this, let others know how is their day too and what they are passionate about.\n\n\n{dateString}";
						Console.WriteLine("Program is over");
						FileStream fParameter = new FileStream(filePath, FileMode.Create, FileAccess.Write);
						StreamWriter myFile = new StreamWriter(fParameter);
						myFile.BaseStream.Seek(0, SeekOrigin.End);
						myFile.Write(story);
						myFile.Flush();
						myFile.Close();
						break ;
					}
					Console.WriteLine("Game loop done...");
					}	
			}
		}
	}
}
