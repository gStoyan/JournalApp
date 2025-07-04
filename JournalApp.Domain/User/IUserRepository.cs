namespace JournalApp.Domain.User;

public interface IUserRepository
{
    int Add(User customer);
    void Update(User customer);
    void Delete(Guid customerId);
    User GetBy(Guid id);
}