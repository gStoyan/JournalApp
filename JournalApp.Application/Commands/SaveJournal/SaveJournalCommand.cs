using MediatR;

namespace JournalApp.Application.Commands.SaveJournal;

public class SaveJournalCommand(string content, int userId) : IRequest<int>
{
    public string Content { get; set; } = content;
    public int UserId { get; set; } = userId;
}