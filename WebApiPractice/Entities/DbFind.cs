using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebApiPractice.Entities
{
    public class DbFind : ControllerBase
    {
        Context context;

        public DbFind(Context context)
        {
            this.context = context;
        }

        public string Get_pass(string login)
        {
            var log = context.Login
                .Where(a => a.login == login)
                .Select(a => a.password)
                .First();
            return log;
        }
    }
}
