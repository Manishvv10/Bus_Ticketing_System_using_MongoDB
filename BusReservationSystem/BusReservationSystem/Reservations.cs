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
    class Reservations
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        [BsonElement("User ID"), BsonRepresentation(BsonType.String)]
        public string uid { get; set; }

        [BsonElement("PNR"), BsonRepresentation(BsonType.String)]
        public string pnr { get; set; }

        [BsonElement("Bus No."), BsonRepresentation(BsonType.String)]
        public string busnum { get; set; }

        [BsonElement("Passenger Name"), BsonRepresentation(BsonType.String)]
        public string p_name { get; set; }

        [BsonElement("Passenger Age"), BsonRepresentation(BsonType.Int32)]
        public Int32 p_age { get; set; }

        [BsonElement("Gender"), BsonRepresentation(BsonType.String)]
        public string p_gen { get; set; }

        [BsonElement("Seat no"), BsonRepresentation(BsonType.Int32)]
        public Int32 Seatno { get; set; }

        [BsonElement("Email ID"), BsonRepresentation(BsonType.String)]
        public string email { get; set; }

        [BsonElement("Phone Number"), BsonRepresentation(BsonType.String)]
        public string phone { get; set; }

        [BsonElement("Unique"), BsonRepresentation(BsonType.String)]
        public string uni { get; set; }

        [BsonElement("Booking Date&Time"), BsonRepresentation(BsonType.String)]
        public string currtime { get; set; }


    }
}
