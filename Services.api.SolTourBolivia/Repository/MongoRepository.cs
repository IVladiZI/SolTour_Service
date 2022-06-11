using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Services.api.SolTourBolivia.Core;
using Services.api.SolTourBolivia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Services.api.SolTourBolivia.Repository
{
    public class MongoRepository <TDocument> : IMongoRepository<TDocument> where TDocument : IDocument
    {
        private readonly IMongoCollection<TDocument> _collection;
        public MongoRepository(IOptions<MongoSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            var db = client.GetDatabase(options.Value.Database);

            _collection = db.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }

        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault()).CollectionName;
        }
        public async Task<IEnumerable<TDocument>> GetAll()
        {
            return await _collection.Find(p=>true).ToListAsync();
        }

        public async Task<TDocument> GetById(string id)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, id);
            return await _collection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task InserDocument(TDocument document)
        {
            await _collection.InsertOneAsync(document);
        }

        public async Task UpdateDocument(TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
            await _collection.FindOneAndReplaceAsync(filter,document);
        }

        public async Task DeleteDocument(string id)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, id);
            await _collection.FindOneAndDeleteAsync(filter);
        }

        public async Task<PaginationEntity<TDocument>> PaginationBy(Expression<Func<TDocument, bool>> filterExpression, PaginationEntity<TDocument> paginationEntity)
        {
            var sort = Builders<TDocument>.Sort.Ascending(paginationEntity.Sort);
            if (paginationEntity.SortDirection == "desc")
                sort = Builders<TDocument>.Sort.Descending(paginationEntity.Sort);
            if (String.IsNullOrEmpty(paginationEntity.filter))
            {
                paginationEntity.Document = await _collection.Find(p => true)
                    .Sort(sort)
                    .Skip((paginationEntity.Page-1)*paginationEntity.PageSize)
                    .Limit(paginationEntity.PageSize)
                    .ToListAsync();
            }else
                paginationEntity.Document = await _collection.Find(filterExpression)
                    .Sort(sort)
                    .Skip((paginationEntity.Page - 1) * paginationEntity.PageSize)
                    .Limit(paginationEntity.PageSize)
                    .ToListAsync();
            long totalDocument = await _collection.CountDocumentsAsync(FilterDefinition<TDocument>.Empty);
            var totalPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(totalDocument / paginationEntity.PageSize)));

            paginationEntity.PageQuantity = totalPages;

            return paginationEntity;
        }
    }
}
