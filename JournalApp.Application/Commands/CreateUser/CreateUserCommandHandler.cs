using JournalApp.Domain.User;
using MediatR;

namespace JournalApp.Application.Commands.CreateUser;

public class CreateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, int>
{
    public Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(request.UserName, request.Password);

        // Validate the user data here if necessary
        var userId = userRepository.Add(user);

        return Task.FromResult(userId);
    }
}