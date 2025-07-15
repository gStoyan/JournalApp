using JournalApp.Domain.Journal;

namespace JournalApp.Infrastructure.Repositories;

public class JournalRepository(JournalAppDbContext dbContext) : IJournalRepository
{
    public async Task<int> Add(Journal journal)
    {
        dbContext.Journals.Add(journal);
        await dbContext.SaveChangesAsync();
        return journal.Id;
    }

    public async Task<int> Update(Journal journal)
    {
        dbContext.Journals.Update(journal);
        await dbContext.SaveChangesAsync();
        return journal.Id;
    }

    public void Delete(Guid journalId)
    {
        throw new NotImplementedException();
    }

    public Journal GetBy(Guid id)
    {
        throw new NotImplementedException();
    }
}