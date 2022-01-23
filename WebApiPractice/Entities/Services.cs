using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPractice.Entities
{
    public class Services //услуги
    {
            public int id { get; init; } //id услуги для БД

            public string name_ser { get; init; } //название услуги

            public string name_div { get; init; } //название подразделения

            public int divisionID { get; init; } //id подразделения

            public Divisions division { get; set; } //переменная класса подразделения,
                                            //для получения выбранного подразделения

    }
}
