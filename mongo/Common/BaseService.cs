using mongo.DataBase;
using mongo.Models;
using MongoDB.Driver;

namespace mongo.Common
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IMongoCollection<TEntity> _collection;
        private readonly MongoDbContext _context;

        public BaseService(MongoDbContext context)
        {
            _context = context;
            var dataBase =context.GetDatabase();
            _collection = dataBase.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        //public BaseService(MongoSettings settings, IMongoClient clinet)
        //{
        //    var dataBase = clinet.GetDatabase(settings.DatabaseName);
        //    _collection = dataBase.GetCollection<TEntity>(typeof(TEntity).Name);
        //}

        public void Delete(Guid id)
        {
            _context.StartTransaction();
           _collection.DeleteOne(_context.GetSession(),e=>e.Id == id);
        }

        public List<TEntity> GetAll()
        {
            return _collection.Find(e=>true).ToList();
        }

        public TEntity GetById(Guid id)
        {
            return _collection.Find(e=>e.Id==id).FirstOrDefault();
        }

        public void Insert(TEntity entity)
        {
            _context.StartTransaction();
            _collection.InsertOne(_context.GetSession(), entity);
        }

        public void Update(TEntity entity)
        {
            _context.StartTransaction();
           _collection.ReplaceOne(_context.GetSession(), e =>e.Id==entity.Id, entity);  
        }
    }
}
