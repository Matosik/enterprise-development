using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentAgency.Class
{
    public class JobPosition
    {
        public int Id { get; set; }  
        public string Section { get; set; }  // Раздел (IT, финансы, реклама и т.д.)
        public string PositionName { get; set; }  //  должность (программист, дизайнер и т.д.)
    }
}
