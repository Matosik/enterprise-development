using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentAgency.Class
{
    public class Response
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int IdVacancy { get; set; }
        public int IdUser { get; set; }
        public bool? ResponseStatus { get; set; } //null - rewiew, true - accepted, false - rejected
        public string? Summary { get; set; } // Сообщение при отклике
    }
}
