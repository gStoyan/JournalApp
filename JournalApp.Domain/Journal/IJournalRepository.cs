namespace JournalApp.Domain.Journal;

public interface IJournalRepository
{
    Task<int> Add(Journal journal);
    Task<int> Update(Journal journal);
    Task Delete(int journalId);
    Journal GetBy(int id);
}