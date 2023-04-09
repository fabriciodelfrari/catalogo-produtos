﻿using System.ComponentModel.DataAnnotations;

namespace CatalogAPI.Infra.CrossCutting.ViewModels
{
    public class ViewModelLoginRequest
    {
        [Required(ErrorMessage = "E-mail is required.")]
        [EmailAddress(ErrorMessage = "Invalid e-mail format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(10, ErrorMessage = "The password needs to have between 6 and 10 characters.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}