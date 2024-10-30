# Разработка корпоративных приложений

## Задание на 1 ЛР 
подготовить структуру классов, описывающих предметную область, определяемую в задании. 
В каждом из заданий присутствует часть, связанная с обработкой данных, представленная в разделе «Запросы». 
Данную часть необходимо реализовать в виде unit-тестов: подготовить тестовые данные, выполнить запрос 
с использованием LINQ, проверить результаты
## Класы:
### User
+ Registration(Время создания)
+ Email
+ Password
+ Number
+ FirstName
+ LastName

#### Applicant(соискатель)
+ IdApplicant
+ Birthday
  

#### Employer(Работодатель)
+ Company
+ IdEmployer

### JobPosition
+ IdJobPosition
+ Section
+ PositionName

### Response - отклик
+ IdResponse
+ DateResponse
+ IdVacancy
+ IdApplicant
+ ResponseStatus
+ SummaryResponse

#### Vacancy
+ IdVacancy
+ IdEmployer
+ IdJobPosition
+ NameVacancy
+ DateVacancy
+ IsActive
+ Salary
+ Experience
+ MinAge
+ MaxAge
+ Summary
