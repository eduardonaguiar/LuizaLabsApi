﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LuizaLabs.Application.ViewModels
{
    public class CustomerViewModel
    {
        public Guid Id { get; set; }
        [Key]        
        [Required(ErrorMessage = "O nome é requerido.")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O e-mail é requerido.")]
        [EmailAddress]
        [DisplayName("E-mail")]
        public string Email { get; set; }
    }
}
