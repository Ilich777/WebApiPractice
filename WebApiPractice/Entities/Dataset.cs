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

        public string phone { get; set; } //телефон пользователя

        public string email { get; set; } //почта пользователя

        public DateTime dateTime { get; set; } //дата+время

        public bool finished { get; set; } //завершен

        public bool cancelled { get; set; } //отменён
        [Required(ErrorMessage = "Укажите Подразделение")]
        public string division { get; init; }
        //public virtual Divisions division { get; set; } //переменная класса подразделения

        public int divisionID { get; set; } //id подразделения

        public string service { get; init; }
        //public virtual Services service { get; set; } //переменная класса услуг

        public int serviceID { get; set; } //id услуги
    }
}
