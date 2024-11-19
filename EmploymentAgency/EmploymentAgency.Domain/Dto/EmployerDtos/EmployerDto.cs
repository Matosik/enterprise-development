﻿using System.ComponentModel.DataAnnotations;

namespace EmploymentAgency.Domain.Dto.EmployerDtos;
/// <summary>
/// DTO Employer для Get по Id 
/// </summary>
public class EmployerDto 
{
    /// <summary>
    /// Контактный номер пользователя
    /// </summary>
    [Phone(ErrorMessage = "Неверный формат номера телефона")]
    public string? Number { get; set; }
    /// <summary>
    /// Имя Пользователя
    /// </summary>
    public required string FirstName { get; set; }
    /// <summary>
    /// Фамилия пользователя
    /// </summary>
    public required string LastName { get; set; }
    /// <summary>
    /// Название компании
    /// </summary>
    public string? Company { get; set; }
}
