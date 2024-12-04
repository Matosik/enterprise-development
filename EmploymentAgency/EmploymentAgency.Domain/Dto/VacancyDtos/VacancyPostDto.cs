﻿using EmploymentAgency.Domain.Dto.JobPositionDtos;

namespace EmploymentAgency.Domain.Dto.VacancyDtos;

public class VacancyPostDto
{
    /// <summary>
    /// Название рабочей позиции
    /// </summary>
    public required JobPositionDto Job { get; set; }
    /// <summary>
    /// Название рабочей 
    /// </summary>
    public required string NameVacancy { get; set; }
    /// <summary>
    /// Статус вакансии активна/неактивна
    /// </summary>
    public bool IsActive { get; set; }
    /// <summary>
    /// Зарплата на данную вакансию
    /// </summary>
    public uint? Salary { get; set; }
    /// <summary>
    /// Опыть работы в годах
    /// </summary>
    public float Experience { get; set; }
    /// <summary>
    ///  Описание вакансии
    /// </summary>
    public string? Summary { get; set; }
}