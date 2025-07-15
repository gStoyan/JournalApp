using JournalApp.Application.Commands.SaveJournal;
using JournalApp.Contracts.Services;
using JournalApp.Domain.Journal;
using MediatR;

namespace JournalApp.Adapter.Services;

public class JournalService(IJournalRepository journalRepository, IMediator mediator) : IJournalService
{
    private readonly IMediator _mediator = mediator;

    public async Task<int> SaveJournal(string content, int userId)
    {
        var command = new SaveJournalCommand(content, userId);
        return await _mediator.Send(command);
    }
}