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

    class admincredentials
    {

        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name"), BsonRepresentation(BsonType.String)]
        public string adminfname { get; set; }

        [BsonElement("Username"), BsonRepresentation(BsonType.String)]
        public string adminusername { get; set; }

        [BsonElement("Password"), BsonRepresentation(BsonType.String)]
        public string adminpassword { get; set; }
    }
}

