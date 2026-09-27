using MediatR;

namespace JournalApp.Application.Commands.DeleteJournal;

public class DeleteJournalCommand(int journalId) : IRequest
{
    public int JournalId { get; } = journalId;
}