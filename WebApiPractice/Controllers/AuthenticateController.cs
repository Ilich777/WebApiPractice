using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiPractice.Entities;
using WebApiPractice.Repositories;

namespace WebApiPractice.Controllers
{
    [Authorize]
    [Route("[controller]")]//настройка маршрута
    [ApiController]
    public class AuthenticateController : Controller
    {
        IJwtAuthenticationManager jwtAuthenticationManager;
        public AuthenticateController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }
        //// GET: AuthenticateController
        //public ActionResult Index()
        //{
        //    return View();
        //}
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "val1", "val2" };
        }

        //// GET: AuthenticateController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: AuthenticateController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
            var token = jwtAuthenticationManager.Authenticate(userCred.Username, userCred.Password);
            if (token == null)
                return Unauthorized();
            return Ok();

        }


    }
}
