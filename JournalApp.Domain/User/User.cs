namespace JournalApp.Domain.User;

public class User()
{
    public User(string userName, string password) : this()
    {
        UserName = userName;
        Password = password;
    }

    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
}