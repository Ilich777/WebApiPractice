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
        [HttpPost]//Invoke-RestMethod http://localhost:44051/Dataset -Method POST -Body (@{division = "Абитуриент"; service = "ШИТИС"} | ConvertTo-Json) -ContentType "application/json; charset=utf-8"
        public async Task<ActionResult<Dataset>> Post(Dataset dataset)
        {
            


            if (dataset == null) //если присланные поля пусты
            {
                return BadRequest();
            }

            if (dataset.division == null)
            {
                ModelState.AddModelError("division", "Выберите необходимое подразделение");
            }
            // если есть ошибки - возвращаем ошибку 400
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // если ошибок нет, сохраняем в базу данных

            context.Dataset.Add(dataset); //при адекватном запросе post добавляем данные в таблицу Dataset
            await context.SaveChangesAsync(); //сохранение изменений

            return Ok(dataset.id); //возвращаем состояние ok
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

    }
}
