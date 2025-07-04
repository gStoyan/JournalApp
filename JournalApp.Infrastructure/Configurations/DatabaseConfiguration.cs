namespace JournalApp.Infrastructure.Configurations;

public static class DatabaseConfiguration
{
    public static string GetDatabasePath()
    {
        var folderPath = "/Users/sgrancharov/dev/dotnet/JournalApp/JournalApp.Infrastructure";
        return Path.GetFullPath(Path.Combine(AppContext.BaseDirectory,
            "../../../../JournalApp.Infrastructure/JournalApp.db"));
    }
}