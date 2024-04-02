using mongo.Common;
using mongo.DataBase;
using mongo.Models;
using MongoDB.Driver;

namespace mongo.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(MongoDbContext context) : base(context)
        {
        }
    }
}
