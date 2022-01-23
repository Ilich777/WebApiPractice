using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPractice.Entities
{
    public class DateAndTime
    {
        public int id { get; init; } //id свободного времени для БД

        public DateTime datetime { get; init; } //время

        public bool IsAvailable { get; init; } //свободно/занято
    }
}
