namespace JournalApp.Domain.User;

public interface IUserRepository
{
    Task<User> GetByUsername(string userName);
    Task<int> Add(User customer);
    void Update(User customer);
    void Delete(Guid customerId);
    User GetById(int id);
}