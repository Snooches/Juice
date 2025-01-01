namespace DebugConsoleUI;

using CommonClasses;
using PlayerBackend;
using SimpleInjector;

class Program
{
	private static readonly Container container;

	static Program()
	{
		container = new Container();
		container.Register<Settings, Settings>(Lifestyle.Singleton);
		container.Register<IPlayer, Player>(Lifestyle.Transient);
		container.Register<Ui, Ui>(Lifestyle.Transient);
		container.Verify();
	}

	static void Main()
	{
		Settings settings = container.GetInstance<Settings>();
		settings.LibraryPathPrefix = "C:/MusicOrganized/";
		container.GetInstance<Ui>().Run();
	}
}