using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPractice.Entities;
using WebApiPractice.Repositories;

namespace WebApiPractice.Controllers
{
    //GET /divisions

    [ApiController]//тип контроллера
    [Route("[controller]")]//настройка маршрута
    public class DivisionsController : ControllerBase
    {
        //private readonly IDivisionsRepository repository;
        Context context;

        public DivisionsController(/*IDivisionsRepository repository*/Context context) //принимамем переменную класса Context в конструкторе
        {
            this.context = context;
            if (!this.context.Divisions.Any())//если Divisions не содержит что-либо
            {
                this.context.Divisions.Add(new Divisions { name_div = "Абитуриент" }); //добавление
                this.context.Divisions.Add(new Divisions { name_div = "Библиотека" }); //добавление
                this.context.SaveChanges(); //сохранение изменений
            }
        }

        //public IEnumerable<Divisions> GetDivisions()
        //{
        //    return repository.GetDivisions();
        //}

        [HttpGet] //Invoke-RestMethod http://localhost:44051/Divisions -Method GET
        public async Task<ActionResult<IEnumerable<Divisions>>> Get()
        {
            return await context.Divisions.ToListAsync();//возвращает список Divisions при GET запросе
        }

    }
}

