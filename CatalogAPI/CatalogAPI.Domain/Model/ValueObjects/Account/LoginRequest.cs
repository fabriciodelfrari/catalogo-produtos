﻿namespace CatalogAPI.Domain.Model.ValueObjects.Account
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
