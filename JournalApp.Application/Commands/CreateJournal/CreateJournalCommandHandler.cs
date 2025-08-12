using JournalApp.Domain.Journal;
using MediatR;

namespace JournalApp.Application.Commands.CreateJournal;

public class CreateJournalCommandHandler(IJournalRepository journalRepository)
    : IRequestHandler<CreateJournalCommand, int>
{
    public Task<int> Handle(CreateJournalCommand request, CancellationToken cancellationToken)
    {
        var journal = new Journal();

        return journalRepository.Add(journal);
    }
}