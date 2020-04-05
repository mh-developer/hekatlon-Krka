﻿using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Account
{
    public class ForgotPasswordModel
    {
        [Required(ErrorMessage = "E-mail je obvezen.")]
        [EmailAddress(ErrorMessage = "Vnesen ni veljaven e-mail naslov.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}