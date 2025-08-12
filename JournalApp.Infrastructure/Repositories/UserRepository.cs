using JournalApp.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace JournalApp.Infrastructure.Repositories;

public class UserRepository(JournalAppDbContext dbContext) : IUserRepository
{
    public async Task<int> Add(User user)
    {
        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();
        return user.Id;
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
        return dbContext.Users.Include(u => u.Journals).FirstOrDefault(u => u.Id == id)
               ?? throw new InvalidOperationException($"User with ID '{id}' not found.");
    }

    public async Task<User> GetByUsername(string userName)
    {
        return await dbContext.Users.Include(u => u.Journals).FirstOrDefaultAsync(u => u.UserName == userName)
               ?? throw new InvalidOperationException($"User with username '{userName}' not found.");
    }
}