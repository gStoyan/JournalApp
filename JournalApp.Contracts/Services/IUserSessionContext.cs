using JournalApp.Contracts;

namespace JournalApp.Contracts.Services;

public interface IUserSessionContext
{
    UserDto? CurrentUser { get; }
    bool IsAuthenticated { get; }
    void SetCurrentUser(UserDto user);
    void Clear();
}
