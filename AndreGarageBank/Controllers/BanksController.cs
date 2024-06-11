using AndreGarageBank.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace AndreGarageBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly BankService _bankService;

        public BanksController(BankService bank)
        {
            _bankService = bank;
        }

        [HttpGet]
        public ActionResult<List<Bank>> GetAll() =>
            _bankService.GetAll();

        [HttpGet("{cnpj}")]
        public ActionResult<Bank> Get(string cnpj)
        {
            var bank = _bankService.Get(cnpj);

            if (bank == null)
            {
                return NotFound();
            }

            return bank;
        }
        [HttpPost]
        public ActionResult<Bank> Create(Bank bank)
        {
            _bankService.Create(bank);
            return bank;
        }
        [HttpPut("{cnpj}")]
        public IActionResult Update(string cnpj, Bank bankIn)
        {
            var bank = _bankService.Get(cnpj);

            if (bank == null)
            {
                return NotFound();
            }

            _bankService.Update(bankIn);

            return NoContent();
        }

        [HttpDelete("{cnpj}")]
        public IActionResult Delete(string cnpj)
        {
            var bank = _bankService.Get(cnpj);

            if (bank == null)
            {
                return NotFound();
            }

            _bankService.Remove(bank);

            return NoContent();
        }
    }
}
