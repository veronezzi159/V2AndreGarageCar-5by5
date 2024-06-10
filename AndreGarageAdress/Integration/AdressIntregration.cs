using AndreGarageAdress.Integration.Interfaces;
using AndreGarageAdress.Integration.Refit;
using Models.APIs;

namespace AndreGarageAdress.Integration
{
    public class AdressIntregration : IAdressIntegration
    {
        private readonly IAdressRefit _adressRefit;
        public AdressIntregration(IAdressRefit adressRefit)
        {
            _adressRefit = adressRefit;
        }
        public async Task<ConsumingAPI> GetAdress(string cep)
        {
            var adress = await _adressRefit.GetAdress(cep);
            return adress.Content ?? null;
        }
    }
}
