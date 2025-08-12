using JournalApp.Application.Commands.SaveJournal;
using JournalApp.Contracts.Services;
using MediatR;

namespace JournalApp.Adapter.Services;

public class JournalService(IMediator mediator) : IJournalService
{
    public async Task<int> SaveJournal(string content, int userId)
    {
        var command = new SaveJournalCommand(content, userId);
        return await mediator.Send(command);
    }
}