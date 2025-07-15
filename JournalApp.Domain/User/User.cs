namespace JournalApp.Domain.User;

public class User()
{
    public User(string userName, string password) : this()
    {
        UserName = userName;
        Password = password;
    }

    public int Id { get; init; }
    public string UserName { get; init; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public List<Journal.Journal> Journals { get; init; } = new();
}