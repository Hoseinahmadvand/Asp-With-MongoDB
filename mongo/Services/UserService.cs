using mongo.Models;
using MongoDB.Driver;

namespace mongo.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _users;
        public UserService(MongoSettings settings)
        {
            var clinet = new MongoClient(settings.ConnectionString);
            var dataBase = clinet.GetDatabase(settings.DatabaseName);
            _users = dataBase.GetCollection<User>("Users");
        }

        public void Delete(Guid userId)
        {
            _users.DeleteOne(u=>u.Id == userId);
        }

        public User GetById(Guid userId)
        {
            return _users.Find(u=>u.Id==userId).FirstOrDefault();
        }

        public List<User> GetUsers()
        {
            return _users.Find(u=>true).ToList();
        }

        public void Insert(User user)
        {
            _users.InsertOne(user);
        }

        public void Update(User user)
        {
            _users.ReplaceOne(u=>u.Id==user.Id,user);
        }
    }
}
