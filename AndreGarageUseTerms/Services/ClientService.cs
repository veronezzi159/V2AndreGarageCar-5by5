using Dapper;
using Microsoft.Data.SqlClient;
using Models;

namespace AndreGarageUseTerms.Services
{
    public class ClientService
    {
        private readonly string Conn = "Data Source=127.0.0.1; Initial Catalog=AndreVehiclesAPI; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=true;";

        public Client? GetClient(string document)
        {
            using(var conn = new SqlConnection(Conn))
            {
                conn.Open();
                
                var client = conn.Query<Client,Adress,Client>(Client.SELECT_WHERE_DOC, (client, adress) =>
                {
                    client.Adress = adress;
                    return client;
                }, new { Document = document }, splitOn: "Id").FirstOrDefault();
                
                return client;
            }

        }
    }
}
