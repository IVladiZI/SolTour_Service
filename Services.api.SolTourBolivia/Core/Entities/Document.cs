using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.api.SolTourBolivia.Core.Entities
{
    public class Document : IDocument
    {
        public ObjectId Id { get; set; }
        public DateTime Createdate => Id.CreationTime;

    }
}
