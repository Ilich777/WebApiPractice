using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPractice.Entities;

namespace WebApiPractice.Controllers
{
    [Route("[controller]")]//настройка маршрута
    [ApiController]//тип контроллера
    public class DatasetController : ControllerBase
    {
        Context context;

        public DatasetController(Context context)//принимамем переменную класса Context в конструкторе
        {
            this.context = context;
        }

        [HttpGet] //Invoke-RestMethod http://localhost:44051/Dataset -Method GET
        public IActionResult Get()
        {
            var obj = from item in context.Dataset
                       where item.cancelled == false && item.finished == false
                       select item;
            if (obj == null)
                return NotFound();
            return new ObjectResult(obj);
        }
        [Route("/canceled")]
        public IActionResult Get_с()
        {
            var obj = from item in context.Dataset
                      where item.cancelled == true && item.finished == false
                      select item;
            if (obj == null)
                return NotFound();
            return new ObjectResult(obj);
        }
        [Route("/finished")]
        public IActionResult Get_f()
        {
            var obj = from item in context.Dataset
                      where item.cancelled == false && item.finished == true
                      select item;
            if (obj == null)
                return NotFound();
            return new ObjectResult(obj);
        }

        [HttpPost]//Invoke-RestMethod http://localhost:44051/Dataset -Method POST -Body (@{division = "Абитуриент"; service = "ШИТИС"} | ConvertTo-Json) -ContentType "application/json; charset=utf-8"
        public async Task<ActionResult<Dataset>> Post(Dataset dataset)
        {

            if (dataset == null) //если присланные поля пусты
            {
                return BadRequest();
            }

            // обработка частных случаев валидации
            //if (dataset.division == null)
            //    ModelState.AddModelError("division", "Выберите необходимое подразделение");
            //else if (dataset.service == null)
            //    ModelState.AddModelError("service", "Выберите необходимую услугу");
            // если есть ошибки - возвращаем ошибку 400
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // если ошибок нет, сохраняем в базу данных

            context.Dataset.Add(dataset); //при адекватном запросе post добавляем данные в таблицу Dataset
            await context.SaveChangesAsync(); //сохранение изменений

            return Ok(dataset.id); //возвращает id записи
        }
        [HttpPut]
        public async Task<ActionResult<Dataset>> Put(ListFormData data)
        {
            Dataset dataset = context.Dataset
                .Where(a => a.id == data.Dataset_id)
                .Select(a => a)
                .First();

            dataset.phone = data.Phone;
            dataset.email = data.Email;
            context.Dataset.Update(dataset);

            await context.SaveChangesAsync(); //сохранение изменений

            return Ok();
        }
        [Route("/cancel/{id:int}")]
        public async Task<ActionResult<Dataset>> Put_c(int id)
        {
            Dataset dataset = context.Dataset
                .Where(a => a.id == id)
                .Select(a => a)
                .First();

            dataset.cancelled = true;
            dataset.finished = false;
            context.Dataset.Update(dataset);

            await context.SaveChangesAsync(); //сохранение изменений

            return Ok();
        }
        [Route("/finish/{id:int}")]
        public async Task<ActionResult<Dataset>> Put_f(int id)
        {
            Dataset dataset = context.Dataset
                .Where(a => a.id == id)
                .Select(a => a)
                .First();

            dataset.finished = true;
            dataset.cancelled = false;
            context.Dataset.Update(dataset);

            await context.SaveChangesAsync(); //сохранение изменений

            return Ok();
        }
        [Route("/restore/{id:int}")]
        public async Task<ActionResult<Dataset>> Put_r(int id)
        {
            Dataset dataset = context.Dataset
                .Where(a => a.id == id)
                .Select(a => a)
                .First();

            dataset.finished = false;
            dataset.cancelled = false;
            context.Dataset.Update(dataset);

            await context.SaveChangesAsync(); //сохранение изменений

            return Ok();
        }
    }
}
