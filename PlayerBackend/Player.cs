namespace PlayerBackend;

using CommonClasses;
using NAudio.Wave;

public class Player(Settings settings) : IPlayer
{
	public Song? CurrentlyPlaying { get; private set; }
	public TimeSpan? CurrentPosition => audioFile?.CurrentTime;
	public TimeSpan? TotalLength => audioFile?.TotalTime;
	
	private Task? currentPlay;
	private CancellationTokenSource cts = new();
	private AudioFileReader? audioFile;
	private WaveOutEvent? outputDevice;
	
	public void Play(Song song)
	{
		if (song?.Path is null)
			return;

		Stop();
		
		CurrentlyPlaying = song;
		cts = new();

		currentPlay = Task.Run(()=>PlayInternal(cts.Token));
	}

	public void Stop()
	{
		if (currentPlay is null)
			return;
		cts.Cancel();
		while (!currentPlay.IsCompleted)
			Thread.Sleep(100);
		currentPlay.Dispose();
		currentPlay = null;
		CurrentlyPlaying = null;
	}

	private void PlayInternal(CancellationToken cancellationToken)
	{
		audioFile = new ($"{settings.LibraryPathPrefix}{CurrentlyPlaying.Path}");
		outputDevice = new();
		outputDevice.Init(audioFile);
		outputDevice.Play();
		while (!cancellationToken.IsCancellationRequested && outputDevice.PlaybackState == PlaybackState.Playing)
			Thread.Sleep(100);
		outputDevice.Stop();
		outputDevice.Dispose();
		outputDevice = null;
		audioFile.Dispose();
		audioFile = null;
		CurrentlyPlaying = null;
	}
}