using System.Diagnostics.Metrics;
using System.Numerics;
using EmploymentAgency.Class;
namespace EmploymentAgency.Test
{
    public class Tests
    {
        public class AgencyQueries
        {
            private List<Slave> _slaves;
            private List<Master> _masters;

            public AgencyQueries(List<Slave> slaves, List<Master> masters)
            {
                _slaves = slaves;
                _masters = masters;
            }

            // 1. Соискатели по должности, упорядоченные по ФИО
            public List<Slave> GetSlavesByJobPosition(string positionName)
            {
                return _slaves
                    .Where(s => s.Resumes.Any(r => r.Position.PositionName == positionName))
                    .OrderBy(s => s.FullName)
                    .ToList();
            }

            // 2. Соискатели, оставившие заявки за период
            public List<Slave> GetSlavesByResponsePeriod(DateTime startDate, DateTime endDate)
            {
                return _slaves
                    .Where(s => s.Responses.Any(r => r.Date >= startDate && r.Date <= endDate))
                    .ToList();
            }

            // 3. Соискатели, соответствующие вакансии
            public List<Slave> GetSlavesForVacancy(int vacancyId)
            {
                return _slaves
                    .Where(s => s.Responses.Any(r => r.IdVacancy == vacancyId))
                    .ToList();
            }



            // 4. Количество заявок по разделу и должности

            public class VacancyStats
            {
                public string Section { get; set; }
                public string PositionName { get; set; }
                public int Count { get; set; }
            }

            public List<VacancyStats> GetVacancyCountBySectionAndPosition()
            {
                return _masters
                    .SelectMany(m => m.Offers)
                    .GroupBy(v => new { v.Job.Section, v.Job.PositionName })
                    .Select(g => new VacancyStats
                    {
                        Section = g.Key.Section,
                        PositionName = g.Key.PositionName,
                        Count = g.Count()
                    })
                    .ToList();
            }
            // 5. Топ 5 работодателей по количеству заявок
            public List<Master> GetTop5MastersByVacancyCount()
            {
                return _masters
                    .OrderByDescending(m => m.Offers.Count)
                    .Take(5)
                    .ToList();
            }

            // 6. Работодатели с максимальной зарплатой
            public List<Master> GetMastersWithMaxSalary()
            {
                var maxSalary = _masters.SelectMany(m => m.Offers).Max(v => v.Salary);
                return _masters
                    .Where(m => m.Offers.Any(v => v.Salary == maxSalary))
                    .ToList();
            }
        }
    }
}