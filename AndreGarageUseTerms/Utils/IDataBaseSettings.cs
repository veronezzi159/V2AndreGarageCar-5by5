namespace AndreGarageUseTerms.Utils
{
    public interface IDataBaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string UseTermsCollectionName { get; set; }

        string AcceptUseTermsCollectionName { get; set; }
    }
}
