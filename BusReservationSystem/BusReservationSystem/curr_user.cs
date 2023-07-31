using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservationSystem
{
    [Serializable]
    class curr_user
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        [BsonElement("Name"), BsonRepresentation(BsonType.String)]
        public string Fname { get; set; }

        [BsonElement("Username"), BsonRepresentation(BsonType.String)]
        public string userid { get; set; }

   
    }
}
