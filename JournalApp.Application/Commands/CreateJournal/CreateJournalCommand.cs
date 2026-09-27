using MediatR;

namespace JournalApp.Application.Commands.CreateJournal;

public class CreateJournalCommand(int userId, string title, string content, List<string> images) : IRequest<int>
{
    public int UserId { get; } = userId;
    public string Title { get; } = title;
    public List<string> Images { get; } = images;
    public string Content { get; } = content;
}