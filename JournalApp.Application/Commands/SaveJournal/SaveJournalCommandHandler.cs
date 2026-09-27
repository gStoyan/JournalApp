using JournalApp.Domain.Journal;
using MediatR;

namespace JournalApp.Application.Commands.SaveJournal;

public class SaveJournalCommandHandler(IJournalRepository journalRepository)
    : IRequestHandler<SaveJournalCommand, int>
{
    public async Task<int> Handle(SaveJournalCommand request, CancellationToken cancellationToken)
    {
        if (!request.JournalId.HasValue)
            return await journalRepository
                .Add(new Journal(request.UserId, request.Content, request.Title, new List<string>()));

        var journal = journalRepository.GetBy(request.JournalId.Value);
        journal.Edit(request.Title, request.Content);
        return await journalRepository.Update(journal);
    }
}