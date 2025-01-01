namespace DebugConsoleUI;

using CommonClasses;
using PlayerBackend;

public class Ui
{
	private static Song[] songs =
	[
		new() { Artist = "AFI", Title = "6 To 8", Path = "AFI/6 To 8 - AFI.mp3" },
		new() { Artist = "Blondie", Title = "Call Me", Path = "Blondie/Call Me - Blondie.mp3" },
		new() { Artist = "Jack White", Title = "Alone in My Home", Path = "Jack White/Alone in My Home - Jack White.mp3" },
	];

	private IPlayer player;

	public Ui(IPlayer player)
	{
		this.player = player;
	}

	public void Run()
	{
		char? command = null;
		while (command != 'e')
		{
			if (player.CurrentlyPlaying is not null)
				PrintPlayer();
			PrintMenu();
			command = BackgroundKeyListener.ReadKey();
			switch (command)
			{
				case '1':
				case '2':
				case '3':
					player.Play(songs[int.Parse(command.Value.ToString()) - 1]);
				break;
			}
		}
	}

	private void PrintPlayer()
	{
		bool quit = false;
		while (!quit)
		{
			Console.Clear();
			Console.WriteLine($"{player.CurrentlyPlaying?.Title ?? "Unknown Song"} by {player.CurrentlyPlaying?.Artist ?? "Unknown Artist"}");
			Console.WriteLine($"{player.CurrentPosition:mm\\:ss} - {player.TotalLength:mm\\:ss}");
			Console.WriteLine("Press any key to go back to menu.");
			quit = BackgroundKeyListener.Listen(200);
		}
		player.Stop();
	}

	private void PrintMenu()
	{
		Console.Clear();
		Console.WriteLine("Please choose an action to perform:");
		Console.WriteLine("1 -> Play '6 To 8' by AFI");
		Console.WriteLine("2 -> Play 'Call Me' by Blondie");
		Console.WriteLine("3 -> Play 'Alone in My Home' by Jack White");
		Console.WriteLine("e -> quit the app.");
		Console.WriteLine();
	}

	private static class BackgroundKeyListener
	{
		private static readonly AutoResetEvent GetInputEvent, GotInputEvent;
		private static char? lastInput = null;
		
		static BackgroundKeyListener()
		{
			GetInputEvent = new AutoResetEvent(false);
			GotInputEvent = new AutoResetEvent(false);
			Thread inputThread = new(ReadInfinite);
			inputThread.IsBackground = true;
			inputThread.Start();
		}

		private static void ReadInfinite()
		{
			while (true)
			{
				GetInputEvent.WaitOne();
				lastInput = Console.ReadKey(true).KeyChar;
				GotInputEvent.Set();
			}
		}

		public static bool Listen(int timeOutMilliseconds = Timeout.Infinite)
		{
			GetInputEvent.Set();
			bool success = GotInputEvent.WaitOne(timeOutMilliseconds);
			return success;
		}

		public static char? ReadKey(int timeOutMilliseconds = Timeout.Infinite)
		{
			lastInput = null;
			Listen(timeOutMilliseconds);
			return lastInput;
		}
	}
}