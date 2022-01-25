using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPractice.Entities;

namespace WebApiPractice.Controllers
{
    //GET /date

    [ApiController]//тип контроллера
    [Route("[controller]")]//настройка маршрута
    public class DateController : ControllerBase
    {
        Context context;
        public DateController(Context context) //принимамем переменную класса Context в конструкторе
        {
            this.context = context;
            if (!this.context.Dates.Any())//если Dates не содержит что-либо
            {
                this.context.Dates.Add(new Date { date = "23.01.2022", IsAvailable = true }); //добавление
                this.context.Dates.Add(new Date { date = "24.01.2022", IsAvailable = false }); //добавление
                this.context.Dates.Add(new Date { date = "25.01.2022", IsAvailable = true }); //добавление
                this.context.SaveChanges(); //сохранение изменений
            }
        }

        [HttpGet] //Invoke-RestMethod http://localhost:44051/Date -Method GET
        public IActionResult Get()
        {
            var date = from d in context.Dates
                       where d.IsAvailable == true
                       select d;
            if (date == null)
                return NotFound();
            return new ObjectResult(date);
        }

    }
}
