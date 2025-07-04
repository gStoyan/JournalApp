namespace JournalApp.Contracts;

public class UserDetails
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; } = DateTime.MinValue;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}