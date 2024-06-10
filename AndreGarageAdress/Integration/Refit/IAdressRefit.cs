using Models.APIs;
using Refit;

namespace AndreGarageAdress.Integration.Refit
{
    public interface IAdressRefit
    {
        [Get("/ws/{cep}/json")]
        Task<ApiResponse<ConsumingAPI>> GetAdress(string cep);
    }
}
