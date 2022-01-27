using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPractice.Entities
{
    public class Dataset //модель для записи данных в БД
    {
        public int id { get; init; } //id записи
        [Required(ErrorMessage = "Укажите Подразделение")]
        public string division { get; init; }
        public string service { get; init; }
        public string date { get; init; }
        public string time { get; init; }
        public string email { get; set; } //почта пользователя
        public string phone { get; set; } //телефон пользователя
        public bool finished { get; set; } //завершен
        public bool cancelled { get; set; } //отменён

    }
}
