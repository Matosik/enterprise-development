#  Кадровое агенство HAHAHA.ру
## Задание 
подготовить структуру классов, описывающих предметную область, определяемую в задании. 
В каждом из заданий присутствует часть, связанная с обработкой данных, представленная в разделе «Запросы». 
Данную часть необходимо реализовать в виде unit-тестов: подготовить тестовые данные, выполнить запрос 
с использованием LINQ, проверить результаты.
## Класы
### User
+ ID
+ DateTime(Время создания)
+ Email
+ Password
+ Number
+ FullName

#### Slave(соискатель)
+ Age

#### Master(Работодатель)
+ Company

### JobPosition
+ Id
+ Section
+ PositionName

### Response - отклик
+ Id
+ date
+ IdVacancy
+ IdSlave
+ ResponseStatus
+ Summary

### Vacancy- вакансия
+ Id 
+ IdMaster
+ IdJob
+ NameVacancy
+ Date
+ IsActive
+ Salary
+ Exp
+ MinAge
+ MaxAge
+ PhoneNumber
+ Email
+ Summary
+ Job

### Resume - категория профессий
+ Id
+ IdSlave
+ Exp
+ Position
+ WantSalary
+ Summary