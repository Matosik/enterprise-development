using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EmploymentAgency.Class
{
    internal class ProfessionCategory
    {
        public string Category { get; set; }
        public List<string> Professions { get; set; }
        public ProfessionCategory(string name, List<string> professions)
        {
            Category = name;
            Professions = professions;
        }
    }


    internal class ProfessionStorage
    {
        // Список всех сфер и профессий
        public static readonly List<ProfessionCategory> Categories = new List<ProfessionCategory>
        {
            new ProfessionCategory("Автомобильный бизнес", new List<string>
            {
                new string("Автомойщик"),
                new string("Автослесарь"),
                new string("Мастер-приёмщик"),
                new string("Менеджер по продажам")
            }),
            new ProfessionCategory("Информационные технологии", new List<string>
            {
                new string("Программист"),
                new string("Аналитик"),
                new string("Системный администратор")
            }),
            new ProfessionCategory("Медицина", new List<string>
            {
                new string("Врач"),
                new string("Медсестра"),
                new string("Фармацевт")
            })
        };

    }
}
