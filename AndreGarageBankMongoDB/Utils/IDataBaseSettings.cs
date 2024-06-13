namespace AndreGarageBankMongoDB.Utils
{
    public interface IDataBaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string BankCollectionName { get; set; }
    }
}
