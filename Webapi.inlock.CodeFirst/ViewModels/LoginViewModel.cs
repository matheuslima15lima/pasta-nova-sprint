﻿using System.ComponentModel.DataAnnotations;

namespace Webapi.inlock.CodeFirst.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email obrigatório!!!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Senha obrigatória!!!")]
        public string? Senha { get; set; }
    }
}
