using AndreGarageUseTerms.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;

namespace AndreGarageUseTerms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcceptUseTermsController : ControllerBase
    {
        private readonly AcceptUseTermsService _acceptUseTermsService;
        private readonly UseTermsService _useTermsService;
        private readonly ClientService _clientService;
        public AcceptUseTermsController(AcceptUseTermsService service, UseTermsService uService, ClientService client)
        {
            _acceptUseTermsService = service;
            _useTermsService = uService;
            _clientService = client;
        }

        [HttpGet]
        public ActionResult<List<AcceptUseTerms>> Get() => _acceptUseTermsService.GetAll();

        [HttpGet("{id:length(24)}", Name = "GetAcceptUseTerms")]
        public ActionResult<AcceptUseTerms> GetById(string id)
        {
            var acceptUseTerms = _acceptUseTermsService.GetById(id);

            if (acceptUseTerms == null)
            {
                return NotFound();
            }

            return acceptUseTerms;
        }
        [HttpPost]
        public ActionResult<AcceptUseTerms> Create(AcceptDTO dto)
        {
            var client = _clientService.GetClient(dto.ClientDocument);
            var useTerms = _useTermsService.GetLastVersion();
            var acceptUseTerms = new AcceptUseTerms(useTerms,client);
            _acceptUseTermsService.Create(acceptUseTerms);

            return CreatedAtRoute("GetAcceptUseTerms", new { id = acceptUseTerms.Id.ToString() }, acceptUseTerms);
        }
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, AcceptUseTerms acceptUseTermsIn)
        {
            var acceptUseTerms = _acceptUseTermsService.GetById(id);

            if (acceptUseTerms == null)
            {
                return NotFound();
            }

            _acceptUseTermsService.Update(acceptUseTermsIn);

            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var acceptUseTerms = _acceptUseTermsService.GetById(id);

            if (acceptUseTerms == null)
            {
                return NotFound();
            }

            _acceptUseTermsService.Remove(acceptUseTerms);

            return NoContent();
        }
    }
}
