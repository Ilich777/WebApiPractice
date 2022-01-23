using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPractice.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApiPractice.Controllers
{
    [Route("[controller]")]//настройка маршрута
    [ApiController]//тип контроллера
    public class DateAndTimeController : ControllerBase
    {
        Context context;
        public DateAndTimeController(Context context)//принимамем переменную класса Context в конструкторе
        {
            this.context = context;
            if (!this.context.DateAndTime.Any())//если DateAndTime не содержит что-либо
            {
                this.context.DateAndTime.Add(new DateAndTime { datetime = new DateTime(2022, 01, 20, 10, 00, 00), IsAvailable = true}); //добавление
                this.context.DateAndTime.Add(new DateAndTime { datetime = new DateTime(2022, 01, 20, 10, 30, 00), IsAvailable = false});  //добавление
                this.context.DateAndTime.Add(new DateAndTime { datetime = new DateTime(2022, 01, 20, 11, 00, 00), IsAvailable = true}); //добавление
                this.context.SaveChanges(); //сохранение изменений
            }
        }
        
        //[HttpGet] //Invoke-RestMethod http://localhost:44051/DateAndTime -Method GET
        //public async Task<ActionResult<IEnumerable<DateAndTime>>> Get()
        //{
        //    DateAndTime dateandtime = context.DateAndTime
        //        .Where(a => a.IsAvailable == true)
        //        .Select(a => a)
        //        .First();

        //    return await dateandtime.ToListAsync();//возвращает список Divisions при GET запросе
        //}
        [HttpGet] //Invoke-RestMethod http://localhost:44051/DateAndTime -Method GET
        public IActionResult Get()
        {
            var date = from time in context.DateAndTime
                       where time.IsAvailable == true
                       select time;
            if (date == null)
                return NotFound();
            return new ObjectResult(date);
        }

    }
}
