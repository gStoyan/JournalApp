using MediatR;

namespace JournalApp.Application.Commands.CreateJournal;

public class CreateJournalCommand(string title, string content, List<string> images) : IRequest<int>
{
    public string Title { get; } = title;
    public List<string> Images { get; } = images;
    public string Content { get; } = content;
}