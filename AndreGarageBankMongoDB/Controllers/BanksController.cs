using AndreGarageBankMongoDB.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace AndreGarageBankMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly BankServiceMongo _bankService;
        public BanksController(BankServiceMongo bank)
        {
            _bankService = bank;
        }

        [HttpPost]
        public ActionResult<Bank> Create(Bank bank)
        {
            var bank1 = _bankService.Create(bank);
            if (bank1 == null)
            {
                return NotFound();
            }

            return bank1;
        }

    }
}
