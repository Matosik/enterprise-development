using EmploymentAgency.Class;

namespace EmploymentAgency.Test
{
    public class EmploymentAgencyTest
    {
        /// <summary>
        /// 1.������� �������� � ���� �����������, ������ ������ �� �������� 
        /// </summary>
        [Fact]
        public void Test_GetAllSlavesByJobPosition_SortedByName()
        {

            var jobPosition = new JobPosition { Id = 1, Section = "IT", PositionName = "�����������" };
            var slaves = new List<Slave>
            {
                new Slave { Id = 1, FullName = "������ ����", Age = 30, Resumes = new List<Resume> { new Resume { Position = jobPosition } } },
                new Slave { Id = 2, FullName = "������ ����", Age = 25, Resumes = new List<Resume> { new Resume { Position = jobPosition } } },
                new Slave { Id = 3, FullName = "������� �����", Age = 35, Resumes = new List<Resume> { new Resume { Position = new JobPosition { Id = 2, Section = "�������", PositionName = "���������" } } } },
                new Slave { Id = 3, FullName = "������� �����", Age = 35, Resumes = new List<Resume> { new Resume { Position = new JobPosition { Id = 2, Section = "�������", PositionName = "���������" } } } }
            };


            var result = slaves
                .Where(s => s.Resumes.Any(r => r.Position.PositionName == "�����������"))
                .OrderBy(s => s.FullName)
                .ToList();

            Assert.Equal(2, result.Count);
            Assert.Equal("������ ����", result[0].FullName);
            Assert.Equal("������ ����", result[1].FullName);
        }
        /// <summary>
        /// 2. ������� ���� �����������, ���������� ������ �� �������� ������.
        /// </summary>
        [Fact]
        public void Test_GetSlavesByResponsesWithinPeriod()
        {
            // 1. ���������� �������� ������
            var startDate = new DateTime(2023, 1, 1);
            var endDate = new DateTime(2023, 12, 31);

            var slaves = new List<Slave>
            {
                new Slave { Id = 1, FullName = "������ ����", Responses = new List<Response> { new Response { Date = new DateTime(2023, 5, 1) } } },
                new Slave { Id = 2, FullName = "������ ����", Responses = new List<Response> { new Response { Date = new DateTime(2022, 10, 1) } } },
                new Slave { Id = 3, FullName = "������� �����", Responses = new List<Response> { new Response { Date = new DateTime(2023, 3, 15) } } }
            };

            // 2. ���������� ������������ �������
            var result = slaves
                .Where(s => s.Responses.Any(r => r.Date >= startDate && r.Date <= endDate))
                .ToList();

            // 3. �������� �����������
            Assert.Equal(2, result.Count);
            Assert.Contains(result, s => s.FullName == "������ ����");
            Assert.Contains(result, s => s.FullName == "������� �����");
        }
        /// <summary>
        /// 3. ������� �������� � �����������, ��������������� ������������ ������ ������������.
        /// </summary>
        [Fact]
        public void Test_GetSlavesForSpecificVacancy()
        {
            // 1. ���������� �������� ������
            var vacancy = new Vacancy
            {
                Id = 1,
                NameVacancy = "�����������",
                Job = new JobPosition { Id = 1, Section = "IT", PositionName = "�����������" },
                MinAge = 25,
                MaxAge = 35,
                Salary = 60000
            };

            var slaves = new List<Slave>
            {
                new Slave { Id = 1, FullName = "������ ����", Age = 30, Resumes = new List<Resume> { new Resume { Position = vacancy.Job, WantSalary = 55000 } } },
                new Slave { Id = 2, FullName = "������ ����", Age = 25, Resumes = new List<Resume> { new Resume { Position = vacancy.Job, WantSalary = 70000 } } },
                new Slave { Id = 3, FullName = "������� �����", Age = 40, Resumes = new List<Resume> { new Resume { Position = new JobPosition { Id = 2, Section = "�������", PositionName = "���������" } } } }
            };

            // 2. ���������� ������������ �������
            var result = slaves
                .Where(s => s.Age >= vacancy.MinAge && s.Age <= vacancy.MaxAge &&
                            s.Resumes.Any(r => r.Position.PositionName == vacancy.Job.PositionName && r.WantSalary <= vacancy.Salary))
                .ToList();

            // 3. �������� �����������
            Assert.Single(result);
            Assert.Equal("������ ����", result[0].FullName);
        }
        /// <summary>
        ///4. ������� ���������� � ���������� ������ �� ������� ������� � ���������
        /// </summary>
        [Fact]
        public void Test_GetVacancyCountBySectionAndPosition()
        {
            // 1. ���������� �������� ������
            var vacancies = new List<Vacancy>
            {
                new Vacancy { Id = 1, NameVacancy = "�����������", Job = new JobPosition { Id = 1, Section = "IT", PositionName = "�����������" } },
                new Vacancy { Id = 2, NameVacancy = "��������", Job = new JobPosition { Id = 1, Section = "IT", PositionName = "��������" } },
                new Vacancy { Id = 3, NameVacancy = "���������", Job = new JobPosition { Id = 2, Section = "�������", PositionName = "���������" } }
            };

            // 2. ���������� ������������ �������
            var result = vacancies
                .GroupBy(v => new { v.Job.Section, v.Job.PositionName })
                .Select(g => new { Section = g.Key.Section, PositionName = g.Key.PositionName, Count = g.Count() })
                .ToList();

            // 3. �������� �����������
            Assert.Equal(3, result.Count);
            Assert.Contains(result, r => r.Section == "IT" && r.PositionName == "�����������" && r.Count == 1);
            Assert.Contains(result, r => r.Section == "�������" && r.PositionName == "���������" && r.Count == 1);
        }

        /// <summary>
        /// 5.������� ��� 5 ������������� �� ���������� ������
        /// </summary>
        [Fact]
        public void Test_GetTop5EmployersByVacancyCount()
        {
            // 1. ���������� �������� ������
            var employers = new List<Master>
    {
        new Master { Id = 1, Company = "�������� A", Offers = new List<Vacancy> { new Vacancy(), new Vacancy() } },
        new Master { Id = 2, Company = "�������� B", Offers = new List<Vacancy> { new Vacancy(), new Vacancy(), new Vacancy() } },
        new Master { Id = 3, Company = "�������� C", Offers = new List<Vacancy> { new Vacancy() } },
        new Master { Id = 4, Company = "�������� D", Offers = new List<Vacancy> { new Vacancy(), new Vacancy(), new Vacancy(), new Vacancy() } },
        new Master { Id = 5, Company = "�������� E", Offers = new List<Vacancy> { new Vacancy(), new Vacancy() } },
        new Master { Id = 6, Company = "�������� F", Offers = new List<Vacancy> { new Vacancy(), new Vacancy(), new Vacancy() } }
    };

            // 2. ���������� ������������ �������
            var result = employers
                .OrderByDescending(e => e.Offers.Count)
                .Take(5)
                .Select(e => new { e.Company, VacancyCount = e.Offers.Count })
                .ToList();

            // 3. �������� �����������
            Assert.Equal(5, result.Count);
            Assert.Equal("�������� D", result[0].Company);
            Assert.Equal(4, result[0].VacancyCount);
            Assert.Equal("�������� B", result[1].Company);
            Assert.Equal(3, result[1].VacancyCount);
        }
        /// <summary>
        /// 6.������� ���������� � �������������, ��������� ������ � ������������ ������� ��������.
        /// </summary>
        [Fact]
        public void Test_GetEmployersWithMaxSalaryVacancies()
        {
            // 1. ���������� �������� ������
            var employers = new List<Master>
            {
                new Master { Id = 1, Company = "�������� A", Offers = new List<Vacancy> { new Vacancy { Salary = 50000 }, new Vacancy { Salary = 70000 } } },
                new Master { Id = 2, Company = "�������� B", Offers = new List<Vacancy> { new Vacancy { Salary = 90000 }, new Vacancy { Salary = 80000 } } },
                new Master { Id = 3, Company = "�������� C", Offers = new List<Vacancy> { new Vacancy { Salary = 90000 } } }
            };

            // ���������� ������������ ��������
            var maxSalary = employers
                .SelectMany(e => e.Offers)
                .Max(v => v.Salary);

            // 2. ���������� ������������ �������
            var result = employers
                .Where(e => e.Offers.Any(v => v.Salary == maxSalary))
                .Select(e => new { e.Company, MaxSalary = maxSalary })
                .ToList();

            // 3. �������� �����������
            Assert.Equal(2, result.Count); // ��� �������� � ������������ ���������
            Assert.Contains(result, e => e.Company == "�������� B");
            Assert.Contains(result, e => e.Company == "�������� C");
            Assert.All(result, e => Assert.Equal(90000u, e.MaxSalary));
        }

    }
}