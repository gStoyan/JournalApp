namespace JournalApp.Contracts.Services;

public interface IJournalService
{
    Task<int> CreateJournal(string title, string content, int userId, List<string>? images = null);
    Task<int> SaveJournal(int? journalId, string title, string content, int userId);
    Task DeleteJournal(int journalId);
}