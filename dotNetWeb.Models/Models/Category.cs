﻿using System.ComponentModel.DataAnnotations;

namespace dotNetWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]

        [MaxLength(30)]
        public string? Name { get; set; }
        [Range(1, 100, ErrorMessage = "The field DisplayOrder must be between 1 - 100.")]
        public int DisplayOrder { get; set; } 

    }
}
