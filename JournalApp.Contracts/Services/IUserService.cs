namespace JournalApp.Contracts.Services;

public interface IUserService
{
    Task<int> CreateUserAsync(string userName, string password);
    Task<UserDetails?> GetUserByIdAsync(Guid userId);
    Task<UserDetails?> GetUserByEmailAsync(string email);

    Task UpdateUserAsync(Guid userId, string firstName, string lastName, DateTime birthDate, string email,
        string password);

    Task DeleteUserAsync(Guid userId);

    Task GetUserDetailsAsync(Guid userId, CancellationToken cancellationToken = default);
}