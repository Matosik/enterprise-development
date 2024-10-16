using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentAgency.Class
{
    public class Resume
    {
        public int Id { get; set; }
        public int IdSlave { get; set; }
        public decimal Exp { get; set; } // опыт работы 
        public JobPosition? Position { get; set; }
        public uint? WnatSalary { get; set; }
        public string? Summary { get; set; }
    }
}
