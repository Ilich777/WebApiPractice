using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPractice.Entities;

namespace WebApiPractice.Controllers
{
    [Route("[controller]")]//настройка маршрута
    [ApiController]//тип контроллера
    public class TimeController : ControllerBase
    {
        Context context;
        public TimeController(Context context)//принимамем переменную класса Context в конструкторе
        {
            this.context = context;
            if (!this.context.Times.Any())//если Times не содержит что-либо
            {
                this.context.Times.Add(new Time { date = "23.01.2022", time = "10:00", dateID = 1, IsAvailable = true }); //добавление
                this.context.Times.Add(new Time { date = "23.01.2022", time = "11:00", dateID = 1, IsAvailable = false });  //добавление
                this.context.Times.Add(new Time { date = "24.01.2022", time = "10:00", dateID = 2, IsAvailable = false }); //добавление
                this.context.Times.Add(new Time { date = "24.01.2022", time = "11:00", dateID = 2, IsAvailable = true });  //добавление
                this.context.Times.Add(new Time { date = "25.01.2022", time = "10:00", dateID = 3, IsAvailable = true }); //добавление
                this.context.Times.Add(new Time { date = "25.01.2022", time = "11:00", dateID = 3, IsAvailable = false });  //добавление
                this.context.SaveChanges(); //сохранение изменений
            }
        }
        [HttpGet] //Invoke-RestMethod http://localhost:44051/Time -Method GET
        public async Task<ActionResult<IEnumerable<Time>>> Get()
        {
            return await context.Times.ToListAsync();//возвращает список Times при GET запросе
        }

        //// GET time/23.01.2022
        //[HttpGet("{id}")]
        //public IActionResult Get(string id)
        //{
        //    SelectList time = new SelectList(context.Dates
        //        .Where(x => x.date == id && x.IsAvailable == true), "dateID", "time");

        //    if (time == null)
        //        return NotFound();
        //    return new ObjectResult(time);
        //}

        // GET time/23.01.2022
        [HttpGet("{id}")] 
        public IActionResult Get(string id)
        {
            var time = from d in context.Times
                       where d.date == id
                       where d.IsAvailable == true
                       select d;
            if (time == null)
                return NotFound();
            return new ObjectResult(time);
        }
    }
}
