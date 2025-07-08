using JournalApp.Domain.User;
using MediatR;

namespace JournalApp.Application.Commands.CreateUser;

public class CreateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, int>
{
    public Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var hash = BCrypt.Net.BCrypt.HashPassword(request.Password);
        var user = new User(request.UserName, hash);
        
        var userId = userRepository.Add(user);
        return Task.FromResult(userId);
    }
}