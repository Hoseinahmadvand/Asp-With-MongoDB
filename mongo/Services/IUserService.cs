using mongo.Models;

namespace mongo.Services
{
    public interface IUserService
    {
        void Insert(User user);
        void Update(User user);
        void Delete(Guid userId);
        User GetById(Guid userId);
        List<User> GetUsers();

    }
}
