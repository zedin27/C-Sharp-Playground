/*
** [STAThread] ?
** 
*/

namespace game_loop
{
	static class Program
	{

	}
	[STAThread]
	static void Main()
	{
		Application.EnableVisualStyles();
		ApplicationId
	}
	
	// public class myMain
	// {
	// 	public static void Main(string[] args)
	// 	{
	// 		double previous = getCurrenttTime();
	// 		double lag = 0.0;
	// 		while (true)
	// 		{
	// 			double current = getCurrentTime();
	// 			double elapsed = current - previous;
	// 			previous = current;
	// 			lag += elapsed;

	// 			processInput();

	// 			while (lag >= MS_PER_UPDATE)
	// 			{
	// 				update();
	// 				lag -= MS_PER_UPDATE;
	// 			}
	// 			render();
	// 		}
	// 		// double lastTime = getCurrentTime();
	// 		// while (true)
	// 		// {
	// 		// 	double current = getCurrentTime();
	// 		// 	double elapsed = current = lastTime; //Each frame determines how much real time passed since the last game update
	// 		// 	Console.WriteLine("hi");
	// 		// 	processInput();
	// 		// 	update();
	// 		// 	render();
	// 		// 	lastTime = current;

	// 		// 	// sleep(start + MS_PER_FRAME - getCurrentTime());
	// 		// }
			
	// 	}
	// }
}
