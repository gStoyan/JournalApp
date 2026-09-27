using JournalApp.Contracts;
using JournalApp.Contracts.Services;

namespace JournalApp.Business.Services;

public class UserSessionContext : IUserSessionContext
{
    public UserDto? CurrentUser { get; private set; }

    public bool IsAuthenticated => CurrentUser is not null;

    public void SetCurrentUser(UserDto user)
    {
        CurrentUser = user ?? throw new ArgumentNullException(nameof(user));
    }

    public void Clear()
    {
        CurrentUser = null;
    }
}
