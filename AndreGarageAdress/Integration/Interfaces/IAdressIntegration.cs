using Models.APIs;

namespace AndreGarageAdress.Integration.Interfaces
{
    public interface IAdressIntegration
    {
        Task<ConsumingAPI> GetAdress(string cep);
    }
}
