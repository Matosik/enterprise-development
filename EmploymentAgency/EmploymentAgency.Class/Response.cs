namespace EmploymentAgency.Class
{
    public class Response
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int IdVacancy { get; set; }
        public int IdSlave { get; set; }
        /// <summary>
        /// Статус отклика 
        /// <list>
        ///     <item>null - rewiew </item>
        ///     <item>true - accept</item>
        ///     <item>fasle - rejected</item>
        /// </list>   
        /// </summary>
        public bool? ResponseStatus { get; set; }

        /// <summary>
        /// Сообщение соискателя при отклике
        /// </summary>
        public string? Summary { get; set; }
    }
}
