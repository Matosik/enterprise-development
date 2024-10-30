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
    public EmploymentAgencyData()
    {
        Applicants = [
            new Applicant { IdApplicant = 1,
                        FirstName = "Иван",
                        LastName = "",
                        Birthday = (new DateOnly(2003,01,01)),
                        Registration = DateTime.Now,
                        Email = "ivanov@mail.com",
                        Password = "9ecb33083488a632c5eb87ba38b2b0e03d4a0bf87fdc0dc6058b2da41c0b852d",
                        Number = "+79097329147" },
            new Applicant {
                        IdApplicant = 2,
                        FirstName = "Мария",
                        LastName = "Петрова",
                        Birthday = new DateOnly(1999,06,15),
                        Registration = DateTime.Now,
                        Email = "maria1999@mail.com",
                        Password = "e4a19a7b5db841e37f35e1f945846b9e3c1c1c11c0cf65a3b6cf2f2df95e6df1",
                        Number = "+79151112233"},

            new Applicant {
                        IdApplicant = 3,
                        FirstName = "Алексей",
                        LastName = "Смирнов",
                        Birthday = new DateOnly(1990,12,20),
                        Registration = DateTime.Now,
                        Email = "alex.smirnov@mail.com",
                        Password = "2ff3bbff0c9c558a342c3dc8a3dbd82cc5826f945a59b918c3a2f3bf048b1d63",
                        Number = "+79261234567"},

            new Applicant {
                        IdApplicant = 4,
                        FirstName = "Ольга",
                        LastName = "Соколова",
                        Birthday = new DateOnly(1985,03,05),
                        Registration = DateTime.Now,
                        Email = "olga85@mail.com",
                        Password = "af1b4be6d995dc6c5e6f6ddc908fd909e4f063d1f8cfb3b6d40a843b9a7f1e94",
                        Number = "+79052223344"},

            new Applicant {
                    IdApplicant = 5,
                    FirstName = "Дмитрий",
                    LastName = "Кузнецов",
                    Birthday = new DateOnly(1995,11,11),
                    Registration = DateTime.Now,
                    Email = "d.kuznetsov@mail.com",
                    Password = "f3f79d9a2b29bdf2784fa45c340d91a9f4df5b8dcf1e8fa75e9c70bd503c11d2",
                    Number = "+79005556677"},

            new Applicant {
                    IdApplicant = 6,
                    FirstName = "Елена",
                    LastName = "Новикова",
                    Birthday = new DateOnly(1992,07,07),
                    Registration = DateTime.Now,
                    Email = "elena_nov@mail.com",
                    Password = "a2b6d3c7f3b1f473ba0aef476b528d4e7c34f6d648fd883f52d75e0e6c94e87a",
                    Number = "+79161113355"},

            new Applicant {
                    IdApplicant = 7,
                    FirstName = "Антон",
                    LastName = "Киселев",
                    Birthday = new DateOnly(1988,09,09),
                    Registration = DateTime.Now,
                    Email = "anton88@mail.com",
                    Password = "e3b776f83e70bc97de965df18e5d9be3c9c7303f82c8e7277f3b5d6c5d96c7de",
                    Number = "+79094445522"},

            new Applicant {
                    IdApplicant = 8,
                    FirstName = "Юлия",
                    LastName = "Борисова",
                    Birthday = new DateOnly(2001,08,25),
                    Registration = DateTime.Now,
                    Email = "y.borisova@mail.com",
                    Password = "3ed9f2a3b1a2a7a8e7d1f2b0c2a5e2c2f6e7a3a5d7c2e3b8a5d8e2a7a5e8a9d6",
                    Number = "+79132225511"},

            new Applicant {
                    IdApplicant = 9,
                    FirstName = "Игорь",
                    LastName = "Морозов",
                    Birthday = new DateOnly(2000,04,15),
                    Registration = DateTime.Now,
                    Email = "igor.morozov@mail.com",
                    Password = "4b3b2a5c1d6e7f4c8a9d5b8a3c6e4f1d7b6a2c9d3e2a8b4c7e5a9d2f3c1b7e8f",
                    Number = "+79009998844"},

            new Applicant {
                IdApplicant = 10,
                FirstName = "Александр",
                LastName = "Федоров",
                Birthday = new DateOnly(1997,05,13),
                Registration = DateTime.Now,
                Email = "a.fedorov97@mail.com",
                Password = "b1d8f7c6a2e3b5d7f4c8a9b6e7f3d1b2c5e4a6c7f1d3e9b2a4d5f6c3b8e7d2a1",
                Number = "+79173339922"}
        ];
        Jobs = [
            new JobPosition {
                IdJobPosition = 1,
                Section = "IT",
                PositionName = "backend developer C#" },
            new JobPosition {
                IdJobPosition = 2,
                Section = "IT",
                PositionName = "backend developer python" },
            new JobPosition {
                IdJobPosition = 0,
                Section = "Маркетинг",
                PositionName = "Специалист по цифровому маркетингу"},
            new JobPosition {
                IdJobPosition = 3,
                Section = "Финансы",
                PositionName = "Финансовый аналитик"
            },
            new JobPosition {
                IdJobPosition = 4,
                Section = "Отдел кадров",
                PositionName = "HR"}
            ];
        Employers = [
            new Employer{
                IdEmployer = 1,
                Company = "ООО Татнефть",
                FirstName = "Александр",
                LastName = "Иванов",
                Registration = DateTime.Now,
                Email = "tatneft@mail.com",
                Password = "57cb69544a1d6d69278b096513cb06a62a1d45eb38e41624a92025673be2e005",
                Number = "+79093671948"},
            new Employer {
                IdEmployer = 2,
                Company = "ПАО Сбербанк",
                FirstName = "Мария",
                LastName = "Сергеева",
                Registration = DateTime.Now,
                Email = "sberbank@mail.com",
                Password = "4e07408562bedb8b60ce05c1decfe3ad16b822d2f389931e646179cb2519d1f4",
                Number = "+79095551122"},
            new Employer {
                IdEmployer = 3,
                Company = "АО Газпром",
                FirstName = "Игорь",
                LastName = "Петров",
                Registration = DateTime.Now,
                Email = "gazprom@mail.com",
                Password = "66f041e16a60928b05a7e228a89c379c65e6b298c4a65bde7e1a0c057d1a57ff",
                Number = "+79102233455"},
            new Employer {
                IdEmployer = 4,
                Company = "АО Лукойл",
                FirstName = "Елена",
                LastName = "Кузнецова",
                Registration = DateTime.Now,
                Email = "lukoil@mail.com",
                Password = "4b43b0aee35624cd95b910189b3dc231e02f172dc076e0fa3f4c8e32d0f8fd1b",
                Number = "+79051234567"}
            ];
        Vacancies = [
            new Vacancy {
                    IdVacancy = 0,
                    IdEmployer = 2,
                    IdJobPosition = 3,
                    NameVacancy = "Аналитик с БОЛЬШОЙ ЗП",
                    IsActive = true,
                    DateVacancy = DateTime.Now,
                    Salary = 123213,
                    Experience = 1.5f,
                    MinAge = 20,
                    MaxAge = 45,
                    Summary = "Лучшая работа в мире приходите к нам"},
            new Vacancy {
                IdVacancy = 1,
                IdEmployer = 1,
                IdJobPosition = 0,
                NameVacancy = "Цифровой маркетолог с опытом",
                IsActive = false,
                DateVacancy = DateTime.Now,
                Salary = 80000,
                Experience = 2.0f,
                MinAge = 25,
                MaxAge = 40,
                Summary = "Работа в крупной компании, активное участие в развитии маркетинговых кампаний." },
            new Vacancy {
                IdVacancy = 2,
                IdEmployer = 2,
                IdJobPosition = 1,
                NameVacancy = "Backend-разработчик C# (с перспективой роста)",
                IsActive = true,
                DateVacancy = DateTime.Now,
                Salary = 150000,
                Experience = 3.0f,
                MinAge = 23,
                MaxAge = 45,
                Summary = "Ищем талантливого разработчика C# для работы над интересными проектами."},
            new Vacancy {
                IdVacancy = 3,
                IdEmployer = 3,
                IdJobPosition = 2,
                NameVacancy = "Python Backend Developer",
                IsActive = true,
                DateVacancy = DateTime.Now,
                Salary = 140000,
                Experience = 2.5f,
                MinAge = 24,
                MaxAge = 50,
                Summary = "Присоединяйтесь к нашей команде Python-разработчиков, работа над масштабными проектами."},
            new Vacancy {
                IdVacancy = 4,
                IdEmployer = 4,
                IdJobPosition = 3,
                NameVacancy = "Финансовый аналитик в растущую компанию",
                IsActive = true,
                DateVacancy = DateTime.Now,
                Salary = 120000,
                Experience = 3.0f,
                MinAge = 27,
                MaxAge = 45,
                Summary = "Требуется аналитик с опытом для работы в финансовом отделе."},
            new Vacancy {
                IdVacancy = 5,
                IdEmployer = 1,
                IdJobPosition = 4,
                NameVacancy = "HR специалист",
                IsActive = true,
                DateVacancy = DateTime.Now,
                Salary = 90000,
                Experience = 1.0f,
                MinAge = 22,
                MaxAge = 40,
                Summary = "Ищем HR специалиста для ведения кадровых вопросов и поиска талантов."}
        ];
        Resumes = [
            new Resume {
            IdResume = 0,
            IdApplicant = 1,
            Experience = 1.5f,
            IdPosition = 1,
            WantSalary = 40000,
            Education = "11 классов МБУ школа 1488"
            },
            new Resume {
                IdResume = 1,
                IdApplicant = 2,
                Experience = 3.0f,
                IdPosition = 2,
                WantSalary = 75000,
                Education = "Бакалавр, Казанский федеральный университет, Программная инженерия" },
            new Resume {
                IdResume = 2,
                IdApplicant = 3,
                Experience = 2.5f,
                IdPosition = 3,
                WantSalary = 90000,
                Education = "Магистр, Санкт-Петербургский государственный университет, Финансы и кредит"},
            new Resume {
                IdResume = 3,
                IdApplicant = 4,
                Experience = 5.0f,
                IdPosition = 4,
                WantSalary = 55000,
                Education = "Среднее специальное, Московский колледж управления и права"},
            new Resume {
                IdResume = 4,
                IdApplicant = 1,
                Experience = 1.0f,
                IdPosition = 0,
                WantSalary = 60000,
                Education = "Бакалавр, Российский университет дружбы народов, Маркетинг"}
        ];
        Responses = [
            new Response {
                IdResponse = 0,
                IdVacancy = 1,
                IdApplicant = 2,
                DateResponse = new DateTime(2022, 2, 15),
                SummaryResponse = "Очень нужна работа иначе дети умрут"},
            new Response {
                IdResponse = 1,
                IdVacancy = 2,
                IdApplicant = 3,
                DateResponse = new DateTime(2023, 3, 12),
                SummaryResponse = "Опыт и навыки идеально подходят для данной позиции."},
            new Response {
                IdResponse = 2,
                IdVacancy = 3,
                IdApplicant = 4,
                DateResponse = new DateTime(2023, 4, 8),
                SummaryResponse = "Ищу работу в вашей компании, так как хочу развиваться в данной области."},
            new Response {
                IdResponse = 3,
                IdVacancy = 1,
                IdApplicant = 1,
                DateResponse = new DateTime(2023, 5, 21),
                SummaryResponse = "Готов на любые условия, работа в этой сфере — мечта."},
            new Response {
                IdResponse = 4,
                IdVacancy = 4,
                IdApplicant = 2,
                DateResponse = new DateTime(2023, 6, 17),
                SummaryResponse = "Имею большой опыт, уверен, что подхожу на эту должность."},
            new Response {
                IdResponse = 5,
                IdVacancy = 2,
                IdApplicant = 4,
                DateResponse = new DateTime(2023, 7, 19),
                SummaryResponse = "Ваши условия совпадают с моими ожиданиями, жду вашего ответа."}
        ];
    }
}
