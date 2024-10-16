using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentAgency.Class
{
    internal class Vacancy
    {
        public int Id { get; set; }
        public int IdMaster { get; set; }
        public string NameVacancy { get; set; }
        public JobPosition Job { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
        public uint? Salary { get; set; } // надеюсь нет зарплат больше 2^32, если есть я буду плакать
        public decimal Exp { get; set; } // опыть работы в годах float чтобы можно было юзать 0.5  1.5 и тд  
        public byte MinAge { get; set; }
        public byte MaxAge { get; set; }
        public string? PhoneNumber { get; set; } // по дефолту берется из Master
        public string? Email { get; set; } // по дефолту берется из Master
        public string? Summary { get; set; }
    }
}
