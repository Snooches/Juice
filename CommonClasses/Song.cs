namespace CommonClasses;

public record Song
{
	public string? Path { get; init; }
	public string? Artist { get; init; }
	public string? Title { get; init; }
}