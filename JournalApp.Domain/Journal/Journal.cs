namespace JournalApp.Domain.Journal;

public class Journal()
{
    public Journal(string content, int userId) : this()
    {
        Content = content;
        UserId = userId;
    }

    public int Id { get; init; }
    public string Content { get; set; } = string.Empty;
    public int UserId { get; init; }
    public User.User User { get; init; } = null!;

    public void EditContent(string newContent)
    {
        if (string.IsNullOrWhiteSpace(newContent))
            throw new ArgumentException("Content cannot be empty.", nameof(newContent));

        Content = newContent;
    }
}