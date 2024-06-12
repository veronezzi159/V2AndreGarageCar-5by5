using AndreGarageUseTerms.Utils;
using Models;
using MongoDB.Driver;

namespace AndreGarageUseTerms.Services
{
    public class UseTermsService
    {
        private readonly IMongoCollection<UseTerms> _useTerms;

        public UseTermsService(IDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _useTerms = database.GetCollection<UseTerms>(settings.UseTermsCollectionName);
        }
        public List<UseTerms> GetAll() => _useTerms.Find(useTerms => true).ToList();
        public UseTerms GetById(string id) => _useTerms.Find<UseTerms>(u => u.Id == id).FirstOrDefault();
        public UseTerms Create(UseTerms useTerms)
        {
            _useTerms.InsertOne(useTerms);
            return useTerms;
        }
        public UseTerms Update(UseTerms useTerms) 
        {
            _useTerms.ReplaceOne(u => u.Id == useTerms.Id, useTerms);
            return useTerms;
        }
        public void Remove(UseTerms useTerms) => _useTerms.DeleteOne(u => u.Id == useTerms.Id);

        public UseTerms GetLastVersion() => _useTerms.Find(useTerms => true).SortByDescending(u => u.Version).FirstOrDefault();
    }
}
