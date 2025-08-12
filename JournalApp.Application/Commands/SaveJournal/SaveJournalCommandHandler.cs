using JournalApp.Domain.Journal;
using JournalApp.Domain.User;
using MediatR;

namespace JournalApp.Application.Commands.SaveJournal;

public class SaveJournalCommandHandler(IJournalRepository journalRepository, IUserRepository userRepository)
    : IRequestHandler<SaveJournalCommand, int>
{
    public async Task<int> Handle(SaveJournalCommand request, CancellationToken cancellationToken)
    {
        var user = userRepository.GetById(request.UserId);
        var journal = user.Journals.FirstOrDefault();
        if (journal == null)
            //TODO: Fix this, should not be null
            return await journalRepository
                .Add(new Journal(request.UserId, request.Content, "", new List<string>()));

        journal.EditContent(request.Content);
        return await journalRepository.Update(journal);
    }
}