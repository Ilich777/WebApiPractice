using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using WebApiPractice.Entities;

namespace WebApiPractice.Controllers
{
    [ApiController]//тип контроллера
    [Route("[controller]")]//настройка маршрута
    public class LoginController : ControllerBase
    {
        Context context;

        public LoginController(Context context)//принимамем переменную класса Context в конструкторе
        {
            this.context = context;
        }

        public string ToSHA256(string pass)
        {
            using var sha256 = SHA256.Create();
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(pass));

            var sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }

        [HttpPost]//Invoke-RestMethod http://localhost:44051/Login -Method POST -Body (@{login = "admin"; password = "nimda"} | ConvertTo-Json) -ContentType "application/json; charset=utf-8"
        public IActionResult Post(Login login)
        {
            if (login.login == null || login.password == null) //если присланные поля пусты
            {
                return BadRequest();
            }
            else
            {
                var user = from d in context.Login
                              where d.login == login.login
                              select d;
                var user_password = from d in context.Login
                           where d.login == login.login
                           select d.password;
                string password = Convert.ToString(user_password);
                if (user == null)
                    return NotFound();
                else
                {
                    string recieved = ToSHA256(Convert.ToString(login.password));
                    if (password == recieved)
                        return Ok(new {Message = "ACCESS GRANTED!"});
                    else
                        return Forbid();
                }
            }
            
            //return new ObjectResult(time);
            
            //if (login.division == null)
            //{
            //    ModelState.AddModelError("division", "Выберите необходимое подразделение");
            //}
            //// если есть ошибки - возвращаем ошибку 400
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            //// если ошибок нет, сохраняем в базу данных

            //context.Login.Add(login); //при адекватном запросе post добавляем данные в таблицу Dataset
            //await context.SaveChangesAsync(); //сохранение изменений

            //return Ok(); //возвращает id записи
        }
        [Route("/registration")]
        public async Task<ActionResult<Login>> Registration(Login login)
        {
            if (login == null) //если присланные поля пусты
                return BadRequest();
            else
            {
                login.password = ToSHA256(Convert.ToString(login.password));
                login.rights = "Оператор";
            }

            context.Login.Add(login); //при адекватном запросе post добавляем данные в таблицу Dataset
            await context.SaveChangesAsync(); //сохранение изменений

            return Ok();
        }
    }
}
