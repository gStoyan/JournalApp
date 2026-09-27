using MediatR;

namespace JournalApp.Application.Commands.SaveJournal;

public class SaveJournalCommand(int? journalId, string title, string content, int userId) : IRequest<int>
{
    public int? JournalId { get; set; } = journalId;
    public string Title { get; set; } = title;
    public string Content { get; set; } = content;
    public int UserId { get; set; } = userId;
}