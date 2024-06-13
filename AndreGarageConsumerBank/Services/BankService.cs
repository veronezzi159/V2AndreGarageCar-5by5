using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreGarageConsumerBank.Services
{
    public class BankService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<Bank> PostBankMongo(Bank bank)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(bank), Encoding.UTF8, "application/json");
                var response = await BankService._httpClient.PostAsync("https://localhost:7075/api/Banks", content);
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Bank>(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
