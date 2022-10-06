/*
** [STAThread]?
** Zork Text game base:	https://social.msdn.microsoft.com/Forums/vstudio/en-US/fe4d77f3-c3d2-4851-b5f4-b500e7f1716c/c-zork?forum=csharpgeneral
**						http://programmingisfun.com/learn/c-sharp-adventure-game/c_sharp_03_programming_concepts/
** Chrome's T-Rex running game: https://www.mooict.com/c-tutorial-create-a-t-rex-endless-runner-game-in-visual-studio/

** Nullable Value Types => datatype?
** Null Coalescing Operator => foo ?? bar
** Assembly references: https://stackoverflow.com/questions/42000798/how-do-i-add-assembly-references-in-visual-studio-code
** Use the NuGet package manager to get what you want.
** StringBuilder or concat?: https://learn.microsoft.com/en-us/dotnet/csharp/how-to/concatenate-multiple-strings#stringbuilder
** Checking if a file/directory exists: https://www.c-sharpcorner.com/UploadFile/dbeniwal321/check-if-a-file-exists-in-C-Sharp/
** Creating a CLI command for afplay: https://khalidabuhakmeh.com/play-audio-files-with-net
** Snake and Ladders idea for game loop: https://www.codeproject.com/Questions/1089109/I-need-a-gameturn-method-and-help-with-main-game-l
** Cool video of someone progressing his game dev skills: https://youtu.be/XxBZw2FEdK0
** TODO:	Tiny functions for File existance and directory or even OO.
**			Have a file creation after giving an input
**			afplay after time is up
*/

using System.Timers;

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
	class myMain
	{
		static void OnTimer(Object src, ElapsedEventArgs e)
		{
			System.Timers.Timer theTimer = (System.Timers.Timer)src;
			theTimer.Interval += 1;
			Console.WriteLine("\n Elapsed: {0:HH:mm:ss}", e.SignalTime);
		}
		private static Task HandleTimer()
		{
			Console.Clear();
			Console.WriteLine("\n\n\nTime's up!\n\n");
			throw new NotImplementedException("Time's up!");
		}
		public static void PlaySound(string filename)
		{
			var buffer = new SFML.Audio.SoundBuffer(filename);
			var sound = new SFML.Audio.Sound(buffer);
			sound.Play();
		}
		// private static void PlaySound()
		// {
		// 	SFML.Audio.SoundBuffer Buffer = new SFML.Audio.SoundBuffer("/Users/ztisnes/Desktop/C-Sharp-Playground/everything/game_loop/youdied.wav");
		// 	SFML.Audio.Sound Sound = new SFML.Audio.Sound(Buffer);
		// 	Console.WriteLine(Buffer);
		// 	Sound.Play();
		// }
		
		// private NAudio.Wave.WaveFileReader wave = null;
		// private NAudio.Wave.DirectSoundOut output = null;
		static void Main(string[] args)
		{
			// SFML.Audio.SoundBuffer youdied = new SFML.Audio.SoundBuffer("youdied.wav");
			// youdied.Play();
			PlaySound("youdied.wav");
			// wave = new NAudio.Wave.WaveFileReader("youdied.mp3");

			System.Timers.Timer newTimer = new System.Timers.Timer(1000);
			System.Timers.Timer stopTimer = new System.Timers.Timer(6000);
			stopTimer.Elapsed += async ( sender, e) => await HandleTimer();
			newTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimer);
			newTimer.AutoReset = false;
			
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

			Console.Clear();
			if (!(Directory.Exists(directory)))
			{
				Console.WriteLine("Creating a journal folder...");
				Directory.CreateDirectory(directory);
			}

			if (File.Exists(fileName))
			{
				Console.WriteLine("I exist already. BE GONE!");
				return ;
			}
			else
			{
				while (true)
				{
					Console.WriteLine("~~~~~~Press 1 to start~~~~~~");
					// Console.WriteLine("Name of your journal: ");
					// fileName = Console.Read();
					// Console.WriteLine(fileName);
					if (Console.ReadLine() == "1")
					{
						//Add a 5 seconds timer before it expires
						Console.WriteLine(" $ YOU HAVE 5 SECONDS TO RESPOND THE FOLLOWING!");
						newTimer.Start();
						stopTimer.Start();
						if (firstName == null && lastName == null)
						{
							if (newTimer.Interval >= 1005)
							{
								Console.WriteLine(" $ YOU RAN OUT OF TIME. GG!");
								return ;
							}
							Console.WriteLine(" $ Who are you?");
							Console.Write(" > ");
							firstName = Console.ReadLine();
							Console.WriteLine(" $ And last name?");
							Console.Write(" > ");
							lastName = Console.ReadLine();
							if (newTimer.Interval >= 1005)
							{
								Console.WriteLine(" $ YOU RAN OUT OF TIME. GG!");
								return ;
							}
							yourName = firstName + " " + lastName;
						}
						Console.WriteLine($" $ Sup {yourName}. How are you feeling today?");
						if (mood == null)
						{
							if (newTimer.Interval >= 1005)
							{
								Console.WriteLine(" $ YOU RAN OUT OF TIME. GG!");
								return ;
							}
							Console.Write(" > ");
							mood = Console.ReadLine();
						}
						Console.WriteLine($"${mood} you say {yourName}? Interesting. What hobbies do you have?");
						if (hobby == null)
						{
							if (newTimer.Interval >= 1005)
							{
								Console.WriteLine("$YOU RAN OUT OF TIME. GG!");
								return ;
							}
							Console.Write(" > ");
							hobby = Console.ReadLine();
						}
						Console.WriteLine($"You like to {hobby}?. Sounds inducing... I made a journal for you saved somewhere.\n\n\n");
						story = $"Dear diary, \n\nMy name is {firstName} {lastName}. I have a passion in {hobby} and I feel {mood}.\nIf you find this, let others know how is their day too and what they are passionate about.\n\n\n{dateString}";
						Console.WriteLine(" $ Program is over");
						FileStream fParameter = new FileStream(filePath, FileMode.Create, FileAccess.Write);
						StreamWriter myFile = new StreamWriter(fParameter);
						myFile.BaseStream.Seek(0, SeekOrigin.End);
						myFile.Write(story);
						myFile.Flush();
						myFile.Close();
						break ;
					}	
				}
				Console.WriteLine("Game loop done...");
			}
		}
	}
}
