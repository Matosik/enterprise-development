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
        public DateTime Date { get; set; }
        public int IdCompany { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Profession { get; set; }
        public uint? Salary { get; set; } // надеюсь нет зарплат больше 2^32, если есть я буду плакать
        public string? Requirements { get; set; }
        public string? PhoneNumber { get; set; } // по дефолту берется из компании
        public string? Email { get; set; } // по дефолту берется из компании
    }
}
