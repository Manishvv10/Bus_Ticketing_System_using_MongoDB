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

    class usercredentials
    {

        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name"), BsonRepresentation(BsonType.String)]
        public string fname { get; set; }


        [BsonElement("Username"), BsonRepresentation(BsonType.String)]
        public string username { get; set; }

        [BsonElement("Password"), BsonRepresentation(BsonType.String)]
        public string password { get; set; }
    }
}
