using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentAgency.Class;
/// <summary>
/// Класс статус заявки на вакансию
/// </summary>
public class Status
{
    /// <summary>
    /// Уникальный номер статуса
    /// </summary>
    public int IdStatus { get; set; }
    /// <summary>
    /// Имя статуса
    /// </summary>
    public required string StatusName { get; set; }
}
