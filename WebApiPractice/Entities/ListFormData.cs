using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPractice.Entities
{
    public class ListFormData
    {
        public int Division { get; init; }
        public int Service { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public int Dataset_id { get; set; }
    }
}
