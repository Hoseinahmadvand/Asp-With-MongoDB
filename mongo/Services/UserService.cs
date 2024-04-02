using mongo.Common;
using mongo.Models;
using MongoDB.Driver;

namespace mongo.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(MongoSettings settings, IMongoClient clinet) : base(settings, clinet)
        {
        }
    }
}
