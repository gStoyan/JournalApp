using JournalApp.Domain.User;
using MediatR;

namespace JournalApp.Application.Commands.LoginUser;

public class LoginUserCommand(string userName, string password) : IRequest<User>
{
    public string UserName { get; set; } = userName;
    public string Password { get; set; } = password;
}