using System.Collections.Generic;
using WebApiPractice.Entities;

namespace WebApiPractice.Repositories
{
    public interface IDivisionsRepository
    {
        IEnumerable<Divisions> GetDivisions();
    }
}