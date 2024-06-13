using AndreGarageBank.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using RabbitMQ.Client;
using System.Text;

namespace AndreGarageBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly BankService _bankService;
        private readonly ConnectionFactory _factory;
        private const string _QueueName = "Bank";
        public BanksController(BankService bank, ConnectionFactory connectionFactory)
        {
            _bankService = bank;
            _factory = connectionFactory;
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
        public IActionResult PostBank([FromBody] Bank bank)
        {
            using (var connection = _factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: _QueueName,
                                        durable: false,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null
                    );
                    var stringBank = Newtonsoft.Json.JsonConvert.SerializeObject(bank);
                    var body = Encoding.UTF8.GetBytes(stringBank);

                    channel.BasicPublish(exchange: "",
                                        routingKey: _QueueName,
                                        basicProperties: null,
                                        body: body
                    );
                }
            }       
            return Accepted();
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
