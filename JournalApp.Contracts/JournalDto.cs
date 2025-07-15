namespace JournalApp.Contracts;

public class JournalDto
{
    public int Id { get; set; }
    public string Content { get; set; }
    public UserDto User { get; set; }
}