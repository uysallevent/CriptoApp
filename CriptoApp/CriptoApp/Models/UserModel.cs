using CriptoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriptoApp.Models
{
    public class UserModel:BaseModel
    {
        public string Name { get; set; }

        public string SurName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }

    }
}
