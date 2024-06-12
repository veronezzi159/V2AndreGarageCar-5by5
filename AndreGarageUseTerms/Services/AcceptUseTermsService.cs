using AndreGarageUseTerms.Utils;
using Models;
using MongoDB.Driver;

namespace AndreGarageUseTerms.Services
{
    public class AcceptUseTermsService
    {
        private readonly IMongoCollection<AcceptUseTerms> _acceptUseTerms;

        public AcceptUseTermsService(IDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _acceptUseTerms = database.GetCollection<AcceptUseTerms>(settings.AcceptUseTermsCollectionName);
        }
        public List<AcceptUseTerms> GetAll() => _acceptUseTerms.Find(acceptUseTerms => true).ToList();
        public AcceptUseTerms GetById(string id) => _acceptUseTerms.Find<AcceptUseTerms>(u => u.Id == id).FirstOrDefault();
        public AcceptUseTerms Create(AcceptUseTerms acceptUseTerms)
        {
            _acceptUseTerms.InsertOne(acceptUseTerms);
            return acceptUseTerms;
        }
        public AcceptUseTerms Update(AcceptUseTerms acceptUseTerms) 
        {
            _acceptUseTerms.ReplaceOne(u => u.Id == acceptUseTerms.Id, acceptUseTerms);
            return acceptUseTerms;
        }
        public void Remove(AcceptUseTerms acceptUseTerms) => _acceptUseTerms.DeleteOne(u => u.Id == acceptUseTerms.Id);        
    }
}
