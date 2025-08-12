namespace JournalApp.Domain.Journal;

public class Journal()
{
    public Journal(int userId, string content, string title, List<string> images) : this()
    {
        Content = content;
        UserId = userId;
        Title = title;
        Images = images;
    }

    public int Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int UserId { get; init; }
    public User.User User { get; init; } = null!;

    public List<string> Images { get; set; } = new();

    public void EditContent(string newContent)
    {
        if (string.IsNullOrWhiteSpace(newContent))
            throw new ArgumentException("Content cannot be empty.", nameof(newContent));

        Content = newContent;
    }
}