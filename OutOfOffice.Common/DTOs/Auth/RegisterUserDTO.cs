﻿namespace OutOfOffice.Common.DTOs.Auth
{
    public class RegisterUserDTO
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password {  get; set; } = string.Empty;
    }
}
