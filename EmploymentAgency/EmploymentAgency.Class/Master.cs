using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentAgency.Class
{
    /// <summary>
    /// Класс для работодателя
    /// </summary>
    public class Master : User
    {
        public string? Company { get; set; }
        public virtual ICollection<Vacancy> Offers { get; set; } = new List<Vacancy>();
    }
}
