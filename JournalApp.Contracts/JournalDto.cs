namespace JournalApp.Contracts;

public class JournalDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public UserDto User { get; set; } = null!;
}