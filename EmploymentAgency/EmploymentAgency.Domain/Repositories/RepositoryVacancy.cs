using EmploymentAgency.Domain.Dto.VacancyDtos;
using EmploymentAgency.Domain.Models;
using Microsoft.EntityFrameworkCore;
using EmploymentAgency.Domain.Dto;
using AutoMapper;

namespace EmploymentAgency.Domain.Repositories;
public class RepositoryVacancy(EmploymentAgencyContext context, IRepository<Employer> repositoryEmployer, IMapper mapper) : IRepository<Vacancy>
{
    public async Task<List<Vacancy>> GetAllAsync() => await context.Vacancies.ToListAsync();
    public async Task<Vacancy>? GetByIdAsync(int id) => await context.Vacancies.FirstOrDefaultAsync(v => v.IdVacancy == id);

    public async Task PostAsync(VacancyPostDto vacancy)
    {
        var job = await context.JobPositions
            .FirstOrDefaultAsync(j => j.Section == vacancy.Job.Section && j.PositionName == vacancy.Job.PositionName);
        if (job == null)
        {
            throw new Exception("Такой вакансии не найдено, можете создать свою рабочубю поизицию");
        }

        var added = mapper.Map<Vacancy>(vacancy);
        added.IdJobPosition = job.IdJobPosition;
        try { await PostAsync(added); }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task PostAsync(Vacancy vacancy)
    {
        if (await context.JobPositions.FirstOrDefaultAsync(j => j.IdJobPosition == vacancy.IdJobPosition) == null)// не очень конечно проверять второй раз если мы вызвали этот метод из 
            throw new Exception("Не найдет JobPosition");                                                     // PostAsync для Dto, но я просто хз как еще это реализовать 
                                                                                                              // я пытался добаваить переменную check, в которую из функции PostAsync для Dto 
        if (await repositoryEmployer.GetByIdAsync(vacancy.IdEmployer) == null)                                    // передовалось бы true и мы бы проверяли но это как мне кажется выглядит еще хуже 
            throw new Exception("Не найден Employer");                                                           // так что пусть будет пока так 
        vacancy.DateVacancy = DateTime.UtcNow;                                                                    // этот метод я хочу оставить так как вруг в дальнейшем придется вызывать передавая именно Vacancy, а не VacancyDto
        await context.Vacancies.AddAsync(vacancy);                                                                // с другой стороны можно в интерфейсе добавить чтобы именно метод Post во всех принимал Dto, но хз
    }                                                                                                             // мб я вообще фигню какую то делаю и вообще ничего не понимаю в программировании. Если скажете в чем ошибки и как лучше сделать буду очень признателен 
    public async Task<bool> PutAsync(int id, Vacancy vacancy)
    {
        var old = await GetByIdAsync(id);
        if (old == null)
            return false;

        context.Entry(old).CurrentValues.SetValues(vacancy);
        await context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var vacancy = await GetByIdAsync(id);
        if (vacancy == null)
            return false;
        var responses = await context.Responses
            .Where(r => r.IdVacancy == id)
            .ToListAsync();
        responses.ForEach(r => context.Remove(r));
        context.Vacancies.Remove(vacancy);
        await context.SaveChangesAsync();
        return true;
    }
}
