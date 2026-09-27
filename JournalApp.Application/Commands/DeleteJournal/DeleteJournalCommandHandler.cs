using JournalApp.Domain.Journal;
using MediatR;

namespace JournalApp.Application.Commands.DeleteJournal;

public class DeleteJournalCommandHandler(IJournalRepository journalRepository) : IRequestHandler<DeleteJournalCommand>
{
    public async Task Handle(DeleteJournalCommand request, CancellationToken cancellationToken)
    {
        await journalRepository.Delete(request.JournalId);
    }
}