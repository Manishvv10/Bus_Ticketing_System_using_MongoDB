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
    class Buses
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string BusId { get; set; }

        [BsonElement("Unique"), BsonRepresentation(BsonType.String)]
        public string unique { get; set; }

        [BsonElement("Origin"), BsonRepresentation(BsonType.String)]
        public string Origin { get; set; }

        [BsonElement("Destination"), BsonRepresentation(BsonType.String)]
        public string Destination { get; set; }

        [BsonElement("Departure Date"), BsonRepresentation(BsonType.String)]
        public string DepartureDate { get; set; }

        [BsonElement("Departure Time"), BsonRepresentation(BsonType.String)]
        public string DepartureTime { get; set; }

        [BsonElement("Arrival Date"), BsonRepresentation(BsonType.String)]
        public string ArrDate { get; set; }

        [BsonElement("Arrival Time"), BsonRepresentation(BsonType.String)]
        public string ArrTime { get; set; }

        [BsonElement("Available Seats"), BsonRepresentation(BsonType.Int32)]
        public Int32 AvailSeats { get; set; }

        [BsonElement("Fare"), BsonRepresentation(BsonType.Int32)]
        public Int32 fare { get; set; }
    }
}
