namespace PlayerBackend;

using CommonClasses;

public interface IPlayer
{
	TimeSpan? CurrentPosition { get; }
	TimeSpan? TotalLength { get; }
	Song? CurrentlyPlaying { get; }
	public void Play(Song song);
	public void Stop();
}