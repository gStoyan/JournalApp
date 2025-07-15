namespace JournalApp.Contracts;

public class UserDto
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public List<JournalDto> Journals { get; set; } = new();
}