using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.api.SolTourBolivia.Core.Entities
{
    [BsonCollection("TouristPlace")]
    public class TouristPlaceEntity : Document
    {
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("location")]
        public Location Location { get; set; }
        [BsonElement("image64")]
        public string Image64 { get; set; }
    }
    public class Location
    {
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("latitude")]
        public double Latitude { get; set; }
        [BsonElement("longitude")]
        public double Longitude{ get; set; }
        [BsonElement("urlGoogleMap")]
        public string UrlGoogleMap { get; set; }
    }
}
