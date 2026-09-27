using JournalApp.Domain.Journal;
using Microsoft.EntityFrameworkCore;

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

    public async Task Delete(int journalId)
    {
        var journal = await dbContext.Journals.FirstOrDefaultAsync(item => item.Id == journalId)
                      ?? throw new InvalidOperationException($"Journal with ID '{journalId}' not found.");

        dbContext.Journals.Remove(journal);
        await dbContext.SaveChangesAsync();
    }

    public Journal GetBy(int id)
    {
        return dbContext.Journals.FirstOrDefault(item => item.Id == id)
               ?? throw new InvalidOperationException($"Journal with ID '{id}' not found.");
    }
}