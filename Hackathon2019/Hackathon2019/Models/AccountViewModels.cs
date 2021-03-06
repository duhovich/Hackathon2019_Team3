﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hackathon2019.Models
{
    public class ExternalLoginConfirmationViewModel
    { 
        [Required(ErrorMessage = "Введіть Email!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введіть Ваше Прізвище!")]
        [Display(Name = "Введіть Ваше Прізвище")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Введіть Ім*я!")]
        [Display(Name = "Введіть Ваше Ім*я")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Введіть пароль!")]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Підтвердження пароля")]
        [Compare("Password", ErrorMessage = "Паролі не співпадають")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Введіть Ваш університет!")]
        [Display(Name = "Введіт Ваш університет")]
        public string Institution { get; set; }

        [Required(ErrorMessage = "Введіть Ваш факультет!")]
        [Display(Name = "Введіть Ваш факультет")]
        public string Faculty { get; set; }

        [Required(ErrorMessage = "Введіть Ваш курс(рік навчання)!")]
        [Display(Name = "Введіть Ваш курс(рік навчання)")]
        public int InstitutionCourse { get; set; }

        [Required(ErrorMessage = "Введіть інформацію про себе!")]
        [Display(Name = "Розкажіть про свої вміння в галузі ІТ, технології з якими працювали, мови програмування, якими володієте, навичками. Що хітіли б дізнатися ще у свері ІТ?")]
        public string AboutMe { get; set; }

    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Код")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Запомнить браузер?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Адрес электронной почты")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Адрес электронной почты")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Введіть Email!")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введіть Ваше Прізвище!")]
        [Display(Name = "Введіть Ваше Прізвище")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Введіть Ім*я!")]
        [Display(Name = "Введіть Ваше Ім*я")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Введіть пароль!")]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Підтвердження пароля")]
        [Compare("Password", ErrorMessage = "Паролі не співпадають")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Введіть Ваш університет!")]
        [Display(Name = "Введіт Ваш університет")]
        public string Institution { get; set; }

        [Required(ErrorMessage = "Введіть Ваш факультет!")]
        [Display(Name = "Введіть Ваш факультет")]
        public string Faculty { get; set; }

        [Required(ErrorMessage = "Введіть Ваш курс(рік навчання)!")]
        [Display(Name = "Введіть Ваш курс(рік навчання)")]
        public int InstitutionCourse { get; set; }

        [Required(ErrorMessage = "Введіть інформацію про себе!")]
        [Display(Name = "Розкажіть про свої вміння в галузі ІТ, технології з якими працювали, мови програмування, якими володієте, навичками. Що хітіли б дізнатися ще у свері ІТ?")]
        public string AboutMe { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Адрес электронной почты")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароль и его подтверждение не совпадают.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Почта")]
        public string Email { get; set; }
    }
}
