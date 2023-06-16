﻿using System.ComponentModel.DataAnnotations;

namespace Store.Catalog.Application.DTOs;

public class CategoryDTO
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "The field {0} is required.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "The field {0} is required.")]
    public int Code { get; set; }
}