﻿namespace SocialNetwork_UWP.Presentation.Models
{
    class RegistrationModel
    {

        public class RegisterBindingModel
        {
            public string Email { get; set; }
            
            public string Password { get; set; }
            
            public string ConfirmPassword { get; set; }
        }
    }
}
