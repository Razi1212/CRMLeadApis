
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
        public async Task<IActionResult> GetUser(int pageNumber = 1, int pageSize = 10)
        {
            var users = await _authservice.GetLead();

            if (users == null || !users.Any())
            {
                return NotFound(new
                {
                    Message = "No Record Found"
                });
            }

            var totalRecords = users.Count();

            var pagedData = users
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Ok(new
            {
                pageNumber,
                pageSize,
                totalRecords,
                totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize),
                records = pagedData
            });
        }


    }
}
