namespace EmploymentAgency.Class
{
    /// <summary>
    ///  Класс соискателя работы
    /// </summary>
    public class Slave : User
    {
        public byte Age { get; set; }
        public virtual ICollection<Resume> Resumes { get; set; }
        public virtual ICollection<Response> Responses { get; set; }
    }
}
