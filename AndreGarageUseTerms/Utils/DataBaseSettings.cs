namespace AndreGarageUseTerms.Utils
{
    public class DataBaseSettings : IDataBaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string UseTermsCollectionName { get; set; }
    }
}
