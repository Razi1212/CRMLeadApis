
using CRMAPI.IService;
using Microsoft.AspNetCore.Mvc;

namespace CRMAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CRMController : Controller
    {
        private readonly iAuthservice _authservice;

        public CRMController(iAuthservice authservice)
        {
            _authservice = authservice;
        }

        [HttpGet ("GetUser")]
        public async Task<IActionResult> GetUser()
        {
            var users = await _authservice.GetLead();

            if (users == null || !users.Any())
            {
                return NotFound(new
                {
                    Message = "No Record Found"

                });
            }
            return Ok(new
            {
                count = users.Count(),
                records = users
            });
        }

    }
}
