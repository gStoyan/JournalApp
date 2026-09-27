using JournalApp.Application.Commands.CreateJournal;
using JournalApp.Application.Commands.DeleteJournal;
using JournalApp.Application.Commands.SaveJournal;
using JournalApp.Contracts.Services;
using MediatR;

namespace JournalApp.Adapter.Services;

public class JournalService(IMediator mediator) : IJournalService
{
    public async Task<int> CreateJournal(string title, string content, int userId, List<string>? images = null)
    {
        var command = new CreateJournalCommand(userId, title, content, images ?? []);
        return await mediator.Send(command);
    }

    public async Task<int> SaveJournal(int? journalId, string title, string content, int userId)
    {
        var command = new SaveJournalCommand(journalId, title, content, userId);
        return await mediator.Send(command);
    }

    public async Task DeleteJournal(int journalId)
    {
        var command = new DeleteJournalCommand(journalId);
        await mediator.Send(command);
    }
}