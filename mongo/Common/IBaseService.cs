using mongo.Models;
using MongoDB.Driver;

namespace mongo.Common
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid id);
        TEntity GetById(Guid id);
        List<TEntity> GetAll();
    }

    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IMongoCollection<TEntity> _collection;
        public BaseService(MongoSettings settings, IMongoClient clinet)
        {
            var dataBase = clinet.GetDatabase(settings.DatabaseName);
            _collection = dataBase.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public void Delete(Guid id)
        {
           _collection.DeleteOne(e=>e.Id == id);
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
            _collection.InsertOne(entity);
        }

        public void Update(TEntity entity)
        {
           _collection.ReplaceOne(e=>e.Id==entity.Id, entity);  
        }
    }
}
