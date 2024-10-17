namespace EmploymentAgency.Class
{
    public class Vacancy
    {
        public int Id { get; set; }
        public int IdMaster { get; set; }
        public int IdJob { get; set; }
        public string NameVacancy { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
        public uint? Salary { get; set; }
        /// <summary>
        /// опыть работы в годах
        /// </summary>
        public decimal Exp { get; set; }  
        public byte MinAge { get; set; }
        public byte MaxAge { get; set; }
        /// <summary>
        /// по дефолту берется из Master
        /// </summary>
        public string? PhoneNumber { get; set; }
        /// <summary>
        /// по дефолту берется из Master
        /// </summary>
        public string? Email { get; set; }
        public string? Summary { get; set; }
        public JobPosition Job { get; set; }
    }
}
