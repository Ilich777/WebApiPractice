using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPractice.Entities;

namespace WebApiPractice
{
    public class Context : DbContext
    {
        public DbSet<Divisions> Divisions { get; set; } //создание свойств

        public DbSet<Services> Services { get; set; } // для получения данных 

        public DbSet<DateAndTime> DateAndTime { get; set; }

        public DbSet<Date> Dates { get; set; }

        public DbSet<Time> Times { get; set; }

        public DbSet<Dataset> Dataset { get; set; } //класса из БД

        
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            Database.EnsureCreated();//Создание БД при её отсутствии
        }
    }
}
