using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DTO;

namespace Models
{
    public class AcceptUseTerms
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public UseTerms? UseTerms { get; set; }
        public DateTime AcceptanceDate { get; set; }
        public Client? Client { get; set; }
        public AcceptUseTerms() { }
        public AcceptUseTerms(UseTerms useTerms, Client client)
        {
            this.UseTerms = useTerms;
            this.AcceptanceDate = DateTime.Now;
            this.Client = client;
        }
    }
}
