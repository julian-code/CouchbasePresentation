using Couchbase;
using Couchbase.KeyValue;
using Fremlæggelse.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fremlæggelse.Repos
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        private ICouchbaseCollection _collection;
        public async Task HestRepository()
        {
            var cluster = await Cluster.ConnectAsync("couchbase://localhost", "admin", "123456");
            var bucket = await cluster.BucketAsync($"{typeof(T).Name}");
            _collection = bucket.DefaultCollection();

        }
        public async Task Delete(T entity)
        {
            await _collection.RemoveAsync(entity.DocumentId());
        }

        public async Task Insert(T entity)
        {
            await _collection.InsertAsync(entity.DocumentId(), entity);
        }

        public async Task<T> Read(Guid Id)
        {
            var getResult = await _collection.GetAsync($"{typeof(T).Name}-{Id}");
            return  getResult.ContentAs<T>();
        }

        public async Task Update(T entity)
        {
            await _collection.ReplaceAsync(entity.DocumentId(), entity);
        }

    }
}
