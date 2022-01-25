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
        //private readonly IDivisionsRepository repository;
        Context context;

        public DateController(/*IDivisionsRepository repository*/Context context) //принимамем переменную класса Context в конструкторе
        {
            this.context = context;
            if (!this.context.Dates.Any())//если Dates не содержит что-либо
            {
                this.context.Dates.Add(new Date { date = "23.01.2022" }); //добавление
                this.context.Dates.Add(new Date { date = "24.01.2022" }); //добавление
                this.context.Dates.Add(new Date { date = "25.01.2022" }); //добавление
                this.context.SaveChanges(); //сохранение изменений
            }
        }

        //public IEnumerable<Divisions> GetDivisions()
        //{
        //    return repository.GetDivisions();
        //}

        [HttpGet] //Invoke-RestMethod http://localhost:44051/Divisions -Method GET
        public async Task<ActionResult<IEnumerable<Date>>> Get()
        {
            return await context.Dates.ToListAsync();//возвращает список Dates при GET запросе
        }

    }
}
