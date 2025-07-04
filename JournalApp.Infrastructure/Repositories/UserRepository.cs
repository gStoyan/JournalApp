using JournalApp.Domain.User;

namespace JournalApp.Infrastructure.Repositories;

public class UserRepository(JournalAppDbContext dbContext) : IUserRepository
{
    public int Add(User user)
    {
        dbContext.Users.Add(user);
        dbContext.SaveChanges();
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

    public User GetBy(Guid id)
    {
        throw new NotImplementedException();
    }
}