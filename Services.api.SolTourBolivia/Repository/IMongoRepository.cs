using Services.api.SolTourBolivia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Services.api.SolTourBolivia.Repository
{
    public interface IMongoRepository<TDocument> where TDocument : IDocument
    {
        Task<IEnumerable<TDocument>> GetAll();
        Task<TDocument> GetById(string id);
        Task InserDocument(TDocument document);
        Task UpdateDocument(TDocument document);
        Task DeleteDocument(string id);
        Task<PaginationEntity<TDocument>> PaginationBy(
            Expression<Func<TDocument,bool>> filterExpression,
            PaginationEntity<TDocument> paginationEntity
        );
        Task<PaginationEntity<TDocument>> PaginationByFilter(
            PaginationEntity<TDocument> paginationEntity
        );
    }
}
