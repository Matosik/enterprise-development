using System.Runtime.Intrinsics.X86;

namespace EmploymentAgency.Class
{
    public class User
    {
        public int Id { get; set; }
        public DateTime Registration { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Number { get; set; }
        public string? FullName { get; set; }

    }
    
    public class Slave : User // класс для соискателя  
    {
        public byte Age { get; set; }
        public virtual ICollection<Resume> Resumes { get; set; }
        public virtual ICollection<Response> Responses { get; set; }
    }

    public class Master : User// класс для работодателя
    {
        public string? Company { get; set; }
        public virtual ICollection<Vacancy> Offers { get; set; } = new List<Vacancy>();

    }

}
