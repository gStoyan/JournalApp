namespace JournalApp.Contracts.Services;

public interface IJournalService
{
    Task<int> SaveJournal(string content, int userId);
}