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


        [Required(ErrorMessage = "Укажите подразделение")]
        public string division { get; init; }


        [Required(ErrorMessage = "Укажите услугу")]
        public string service { get; init; }


        [Required(ErrorMessage = "Укажите дату")]
        public string date { get; init; }


        [Required(ErrorMessage = "Укажите время")]
        public string time { get; init; }


        [Required(ErrorMessage = "Укажите почту")]
        public string email { get; set; } //почта пользователя


        [Required(ErrorMessage = "Укажите телефон")]
        public string phone { get; set; } //телефон пользователя


        public bool finished { get; set; } //завершен
        public bool cancelled { get; set; } //отменён

    }
}
