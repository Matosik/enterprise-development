﻿using System.ComponentModel.DataAnnotations;

namespace EmploymentAgency.Domain.Dto.ApplicantDtos;
/// <summary>
/// DTO изменения Applicant
/// нельзя изменить дату рождения 
/// нельзя  дату регистрации
/// </summary>
public class ApplicantPutDto
{
    /// <summary>
    /// Контактный номер пользователя
    /// </summary>
    [Phone(ErrorMessage = "Неверный формат номера телефона")]
    public string? Number { get; set; }
    /// <summary>
    /// Имя Пользователя
    /// </summary>
    public string? FirstName { get; set; }
    /// <summary>
    /// Фамилия пользователя
    /// </summary>
    public string? LastName { get; set; }
}
