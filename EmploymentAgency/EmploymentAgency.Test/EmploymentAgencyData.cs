using EmploymentAgency.Class;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmploymentAgency.Test;
internal class EmploymentAgencyData
{
    public List<Applicant> Applicants { get; set; }
    public List<JobPosition> Jobs { get; set; }
    public List<Employer> Employers { get; set; }
    public List<Vacancy> Vacancies { get; set; }
    public List<Resume> Resumes { get; set; }
    public List<Response> Responses { get; set; }
    public List<Status> Statuses { get; set; }
    public EmploymentAgencyData()
    {
        Statuses =
        [
           new Status
           {
               IdStatus = 0,
               StatusName = "На рассмотрении"
           },
           new Status
           {
               IdStatus = 1,
               StatusName = "Принято"
           },
           new Status
           {
               IdStatus = 2,
               StatusName = "Отклнонено"
           }
        ];
        Applicants = 
        [
            new Applicant 
            { 
                IdApplicant = 1,
                FirstName = "Иван",
                LastName = "",
                Birthday = (new DateOnly(2003,01,01)),
                Registration = DateTime.Now,
                Number = "+79097329147" 
            },
            new Applicant 
            {
                IdApplicant = 2,
                FirstName = "Мария",
                LastName = "Петрова",
                Birthday = new DateOnly(1999,06,15),
                Registration = DateTime.Now,
                Number = "+79151112233"
            },
            new Applicant 
            {
                IdApplicant = 3,
                FirstName = "Алексей",
                LastName = "Смирнов",
                Birthday = new DateOnly(1990,12,20),
                Registration = DateTime.Now,
                Number = "+79261234567"
            },
            new Applicant 
            {
                IdApplicant = 4,
                FirstName = "Ольга",
                LastName = "Соколова",
                Birthday = new DateOnly(1985,03,05),
                Registration = DateTime.Now,
                Number = "+79052223344"
            },

            new Applicant 
            {
                IdApplicant = 5,
                FirstName = "Дмитрий",
                LastName = "Кузнецов",
                Birthday = new DateOnly(1995,11,11),
                Registration = DateTime.Now,
                Number = "+79005556677"
            },
            new Applicant 
            {
                IdApplicant = 6,
                FirstName = "Елена",
                LastName = "Новикова",
                Birthday = new DateOnly(1992,07,07),
                Registration = DateTime.Now,
                Number = "+79161113355"
            },
            new Applicant 
            {
                IdApplicant = 7,
                FirstName = "Антон",
                LastName = "Киселев",
                Birthday = new DateOnly(1988,09,09),
                Registration = DateTime.Now,
                Number = "+79094445522"
            },
            new Applicant 
            {
                IdApplicant = 8,
                FirstName = "Юлия",
                LastName = "Борисова",
                Birthday = new DateOnly(2001,08,25),
                Registration = DateTime.Now,
                Number = "+79132225511"
            },
            new Applicant 
            {
                IdApplicant = 9,
                FirstName = "Игорь",
                LastName = "Морозов",
                Birthday = new DateOnly(2000,04,15),
                Registration = DateTime.Now,
                Number = "+79009998844"
            },
            new Applicant {
                IdApplicant = 10,
                FirstName = "Александр",
                LastName = "Федоров",
                Birthday = new DateOnly(1997,05,13),
                Registration = DateTime.Now,
                Number = "+79173339922"
            }
        ];
        Jobs = 
        [
            new JobPosition 
            {
                IdJobPosition = 1,
                Section = "IT",
                PositionName = "backend developer C#" },
            new JobPosition 
            {
                IdJobPosition = 2,
                Section = "IT",
                PositionName = "backend developer python" 
            },
            new JobPosition 
            {
                IdJobPosition = 0,
                Section = "Маркетинг",
                PositionName = "Специалист по цифровому маркетингу"
            },
            new JobPosition 
            {
                IdJobPosition = 3,
                Section = "Финансы",
                PositionName = "Финансовый аналитик"
            },
            new JobPosition 
            {
                IdJobPosition = 4,
                Section = "Отдел кадров",
                PositionName = "HR"}
        ];
        Employers = 
        [
            new Employer
            {
                IdEmployer = 1,
                Company = "ООО Татнефть",
                FirstName = "Александр",
                LastName = "Иванов",
                Registration = DateTime.Now,
                Number = "+79093671948"
            },
            new Employer 
            {
                IdEmployer = 2,
                Company = "ПАО Сбербанк",
                FirstName = "Мария",
                LastName = "Сергеева",
                Registration = DateTime.Now,
                Number = "+79095551122"
            },
            new Employer 
            {
                IdEmployer = 3,
                Company = "АО Газпром",
                FirstName = "Игорь",
                LastName = "Петров",
                Registration = DateTime.Now,
                Number = "+79102233455"
            },
            new Employer 
            {
                IdEmployer = 4,
                Company = "АО Лукойл",
                FirstName = "Елена",
                LastName = "Кузнецова",
                Registration = DateTime.Now,
                Number = "+79051234567"
            }
        ];
        Vacancies = 
        [
            new Vacancy 
            {
                IdVacancy = 0,
                IdEmployer = 2,
                IdJobPosition = 3,
                NameVacancy = "Аналитик с БОЛЬШОЙ ЗП",
                IsActive = true,
                DateVacancy = DateTime.Now,
                Salary = 123213,
                Experience = 1.5f,
                Summary = "Лучшая работа в мире приходите к нам"},
            new Vacancy 
            {
                IdVacancy = 1,
                IdEmployer = 1,
                IdJobPosition = 0,
                NameVacancy = "Цифровой маркетолог с опытом",
                IsActive = false,
                DateVacancy = DateTime.Now,
                Salary = 80000,
                Experience = 2.0f,
                Summary = "Работа в крупной компании, активное участие в развитии маркетинговых кампаний." 
            },
            new Vacancy 
            {
                IdVacancy = 2,
                IdEmployer = 2,
                IdJobPosition = 1,
                NameVacancy = "Backend-разработчик C# (с перспективой роста)",
                IsActive = true,
                DateVacancy = DateTime.Now,
                Salary = 150000,
                Experience = 3.0f,
                Summary = "Ищем талантливого разработчика C# для работы над интересными проектами."
            },
            new Vacancy 
            {
                IdVacancy = 3,
                IdEmployer = 3,
                IdJobPosition = 2,
                NameVacancy = "Python Backend Developer",
                IsActive = true,
                DateVacancy = DateTime.Now,
                Salary = 140000,
                Experience = 2.5f,
                Summary = "Присоединяйтесь к нашей команде Python-разработчиков, работа над масштабными проектами."
            },
            new Vacancy 
            {
                IdVacancy = 4,
                IdEmployer = 4,
                IdJobPosition = 3,
                NameVacancy = "Финансовый аналитик в растущую компанию",
                IsActive = true,
                DateVacancy = DateTime.Now,
                Salary = 120000,
                Experience = 3.0f,
                Summary = "Требуется аналитик с опытом для работы в финансовом отделе."
            },
            new Vacancy 
            {
                IdVacancy = 5,
                IdEmployer = 1,
                IdJobPosition = 4,
                NameVacancy = "HR специалист",
                IsActive = true,
                DateVacancy = DateTime.Now,
                Salary = 90000,
                Experience = 1.0f,
                Summary = "Ищем HR специалиста для ведения кадровых вопросов и поиска талантов."
            }
        ];
        Resumes = 
        [
            new Resume 
            {
                IdResume = 0,
                IdApplicant = 1,
                Experience = 1.5f,
                IdPosition = 1,
                WantSalary = 40000,
                Education = "11 классов МБУ школа 1488"
            },
            new Resume 
            {
                IdResume = 1,
                IdApplicant = 2,
                Experience = 3.0f,
                IdPosition = 2,
                WantSalary = 75000,
                Education = "Бакалавр, Казанский федеральный университет, Программная инженерия" 
            },
            new Resume 
            {
                IdResume = 2,
                IdApplicant = 3,
                Experience = 2.5f,
                IdPosition = 3,
                WantSalary = 90000,
                Education = "Магистр, Санкт-Петербургский государственный университет, Финансы и кредит"
            },
            new Resume 
            {
                IdResume = 3,
                IdApplicant = 4,
                Experience = 5.0f,
                IdPosition = 4,
                WantSalary = 55000,
                Education = "Среднее специальное, Московский колледж управления и права"
            },
            new Resume 
            {
                IdResume = 4,
                IdApplicant = 1,
                Experience = 1.0f,
                IdPosition = 0,
                WantSalary = 60000,
                Education = "Бакалавр, Российский университет дружбы народов, Маркетинг"
            }
        ];
        Responses =
        [
            new Response
            {
                IdResponse = 0,
                IdVacancy = 1,
                IdApplicant = 2,
                DateResponse = new DateTime(2022, 2, 15),
                IdStatus = 0,
                SummaryResponse = "Очень нужна работа иначе дети умрут"
            },
            new Response
            {
                IdResponse = 1,
                IdVacancy = 2,
                IdApplicant = 3,
                DateResponse = new DateTime(2023, 3, 12),
                IdStatus = 1,
                SummaryResponse = "Опыт и навыки идеально подходят для данной позиции."
            },
            new Response
            {
                IdResponse = 2,
                IdVacancy = 3,
                IdApplicant = 4,
                DateResponse = new DateTime(2023, 4, 8),
                IdStatus = 2,
                SummaryResponse = "Ищу работу в вашей компании, так как хочу развиваться в данной области."
            },
            new Response
            {
                IdResponse = 3,
                IdVacancy = 1,
                IdApplicant = 1,
                DateResponse = new DateTime(2023, 5, 21),
                IdStatus = 2,
                SummaryResponse = "Готов на любые условия, работа в этой сфере — мечта."
            },
            new Response
            {
                IdResponse = 4,
                IdVacancy = 4,
                IdApplicant = 2,
                DateResponse = new DateTime(2023, 6, 17),
                IdStatus = 2,
                SummaryResponse = "Имею большой опыт, уверен, что подхожу на эту должность."
            },
            new Response
            {
                IdResponse = 5,
                IdVacancy = 2,
                IdApplicant = 4,
                DateResponse = new DateTime(2023, 7, 19),
                IdStatus = 0,
                SummaryResponse = "Ваши условия совпадают с моими ожиданиями, жду вашего ответа."
            }
        ];
    }
}