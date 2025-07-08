namespace JournalApp.Contracts.Services;

public interface IUserService
{
    Task<int> CreateUserAsync(string userName, string password);
    Task<UserDto> LoginAsync(string userName, string password);
    Task<UserDto> GetUserByIdAsync(int userId);
    Task<UserDto> GetUserByEmailAsync(string email);

    Task UpdateUserAsync(Guid userId, string firstName, string lastName, DateTime birthDate, string email,
        string password);

    Task DeleteUserAsync(Guid userId);

    Task GetUserDetailsAsync(Guid userId, CancellationToken cancellationToken = default);
}