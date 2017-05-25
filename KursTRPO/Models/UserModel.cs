using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;

namespace KursTRPO.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string _UserName { get; set; }
        public string _UserLasName { get; set; }

        public string _UserFIO { get; set; } // Всё всборе

        public string _RoleString { get; set; } // Должность пользователя

        public string _CompanyName { get; set; } // Название компании (Хорошо бы из БД, но потом)

        public ApplicationUser()
        {

        }
    }

    public class RegisterModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

        public string _UserName { get; set; }
        public string _UserLasName { get; set; }

        public string _RoleString { get; set; } // Должность пользователя

        public string _CompanyName { get; set; } // Название компании (Хорошо бы из БД, но потом)
    }

    public class LoginModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}