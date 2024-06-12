using AndreGarageUseTerms.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace AndreGarageUseTerms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UseTermsController : ControllerBase
    {
        private readonly UseTermsService _useTermsService;

        public UseTermsController(UseTermsService useTermsService)
        {
            _useTermsService = useTermsService;
        }

        [HttpGet]
        public ActionResult<List<UseTerms>> Get() => _useTermsService.GetAll();

        [HttpGet("{id:length(24)}", Name = "GetUseTerms")]
        public ActionResult<UseTerms> GetById(string id)
        {
            var useTerms = _useTermsService.GetById(id);

            if (useTerms == null)
            {
                return NotFound();
            }

            return useTerms;
        }

        [HttpPost]
        public ActionResult<UseTerms> Create(UseTerms useTerms)
        {
            _useTermsService.Create(useTerms);

            return CreatedAtRoute("GetUseTerms", new { id = useTerms.Id.ToString() }, useTerms);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, UseTerms useTermsIn)
        {
            var useTerms = _useTermsService.GetById(id);

            if (useTerms == null)
            {
                return NotFound();
            }

            _useTermsService.Update(useTermsIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var useTerms = _useTermsService.GetById(id);

            if (useTerms == null)
            {
                return NotFound();
            }

            _useTermsService.Remove(useTerms);

            return NoContent();
        }
    }
}
