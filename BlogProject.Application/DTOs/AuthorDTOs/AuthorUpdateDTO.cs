﻿namespace BlogProject.Application.DTOs.AuthorDTOs;

public class AuthorUpdateDTO
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; }= null!;
    public string Email { get; set; } = null!;
}
