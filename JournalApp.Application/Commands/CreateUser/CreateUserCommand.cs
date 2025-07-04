using MediatR;

namespace JournalApp.Application.Commands.CreateUser;

public class CreateUserCommand(string userName, string password)
    : IRequest<int>
{
    public string UserName { get; } = userName;
    public string Password { get; } = password;
}