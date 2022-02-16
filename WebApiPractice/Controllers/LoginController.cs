using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpPost]//Invoke-RestMethod http://localhost:44051/Login -Method POST -Body (@{login = "admin"; password = "nimda"} | ConvertTo-Json) -ContentType "application/json; charset=utf-8"
        public async Task<ActionResult<Login>> Post(Login login)
        {
            if (login == null) //если присланные поля пусты
            {
                return BadRequest();
            }

            //if (login.division == null)
            //{
            //    ModelState.AddModelError("division", "Выберите необходимое подразделение");
            //}
            //// если есть ошибки - возвращаем ошибку 400
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            //// если ошибок нет, сохраняем в базу данных

            context.Login.Add(login); //при адекватном запросе post добавляем данные в таблицу Dataset
            await context.SaveChangesAsync(); //сохранение изменений

            return Ok(login.id); //возвращает id записи
        }
    }
}
