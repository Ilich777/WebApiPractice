using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiPractice.JwtAuth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizeController : Controller
    {
        [Authorize]
        [HttpGet]
        [Route("get_access")]
        public IActionResult Get()
        {
            return Ok("Hello World!");
        }
    }
}
