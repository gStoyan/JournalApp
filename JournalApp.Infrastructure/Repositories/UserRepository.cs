using JournalApp.Domain.User;

namespace JournalApp.Infrastructure.Repositories;

public class UserRepository(JournalAppDbContext dbContext) : IUserRepository
{
    public async Task<int> Add(User user)
    {
        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();
        return user.Id;
    }

    public User GetByUsername(string userName)
    {
        return dbContext.Users.FirstOrDefault(u => u.UserName == userName)
               ?? throw new InvalidOperationException($"User with username '{userName}' not found.");
    }

    public void Update(User customer)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid customerId)
    {
        throw new NotImplementedException();
    }

    public User GetById(int id)
    {
        return dbContext.Users.FirstOrDefault(u => u.Id == id)
               ?? throw new InvalidOperationException($"User with ID '{id}' not found.");
    }
}