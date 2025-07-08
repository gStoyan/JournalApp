using JournalApp.Domain.User;
using MediatR;

namespace JournalApp.Application.Commands.LoginUser;

public class LoginUserCommandHandler(IUserRepository userRepository) : IRequestHandler<LoginUserCommand, User>
{
    public Task<User> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = userRepository.GetByUsername(request.UserName);
        
       if(BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
       {
           return Task.FromResult(user);
       }
        
       throw new UnauthorizedAccessException("Invalid username or password.");
    }
}