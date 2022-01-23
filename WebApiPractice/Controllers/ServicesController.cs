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
    public class ServicesController : ControllerBase
    {
        Context context;

        public ServicesController(Context context)//принимамем переменную класса Context в конструкторе
        {
            this.context = context;
            if (!this.context.Services.Any())//если Services не содержит что-либо
            {
                this.context.Services.Add(new Services { name_div = "Абитуриент", name_ser = "ШИТИС", divisionID = 1}); //добавление
                this.context.Services.Add(new Services { name_div = "Абитуриент", name_ser = "ШБП", divisionID = 1 });  //добавление
                this.context.Services.Add(new Services { name_div = "Библиотека", name_ser = "Взять книгу", divisionID = 2 }); //добавление
                this.context.Services.Add(new Services { name_div = "Библиотека", name_ser = "Сдать книгу", divisionID = 2 }); //добавление
                this.context.SaveChanges(); //сохранение изменений
            }
        }
        [HttpGet] //Invoke-RestMethod http://localhost:44051/Services -Method GET
        public async Task<ActionResult<IEnumerable<Services>>> Get()
        {
            return await context.Services.ToListAsync();//возвращает список Services при GET запросе
        }

        // GET services/Абитуриент
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            SelectList services =  new SelectList(context.Services
                .Where(x => x.name_div == id), "divisionID", "name_ser");
                
            if (services == null)
                return NotFound();
            return new ObjectResult(services);
        }

        //[HttpGet]
        //[Route("{id?}")]
        //public object Get(string id)
        //{

        //    Services services = context.Services
        //        .Where(x => x.name_div == id)
        //        .Select(a => a)
        //        .First();
        //    if (services == null)
        //        return NotFound();
        //    return services;
        //}

    }
}
