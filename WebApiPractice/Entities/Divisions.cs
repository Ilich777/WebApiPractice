using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebApiPractice.Entities //1
{
    public class Divisions //подразделения
    {
        public int id { get; init; } //id подразделения для БД

        //public string service { get; set; }
       
        public string name_div { get; init; } //название подразделения

        //public List<Services> Services { get; set; } //список услуг
    }
}
