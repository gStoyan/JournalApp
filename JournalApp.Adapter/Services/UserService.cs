using JournalApp.Application.Commands.CreateUser;
using JournalApp.Contracts;
using JournalApp.Contracts.Services;
using MediatR;

namespace JournalApp.Adapter.Services;

public class UserService(IMediator mediator) : IUserService
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    public Task<UserDetails?> GetUserByIdAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<UserDetails?> GetUserByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task UpdateUserAsync(Guid userId, string firstName, string lastName, DateTime birthDate, string email,
        string password)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUserAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task GetUserDetailsAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<int> CreateUserAsync(string userName,
        string password)
    {
        var command = new CreateUserCommand(userName, password);
        var result = await _mediator.Send(command);

        return result;
    }
}