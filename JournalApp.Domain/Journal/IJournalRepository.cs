namespace JournalApp.Domain.Journal;

public interface IJournalRepository
{
    Task<int> Add(Journal journal);
    Task<int> Update(Journal journal);
    void Delete(Guid journalId);
    Journal GetBy(Guid id);
}