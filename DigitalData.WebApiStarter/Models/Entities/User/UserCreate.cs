using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalData.WebApiStarter.Models.Entities.User
{
    public class UserCreate
    {        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Document { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Phone1 { get; set; }

        public string Phone2 { get; set; }
        
        public int CompanyId { get; set; }

        public int RoleId { get; set; }
    }

    public class UserCreateValidator : AbstractValidator<UserCreate>
    {
        public UserCreateValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Primeiro nome obrigatório")
                .Length(0, 20).WithMessage("Limite de 20 caracteres para o primeiro nome");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Sobrenome obrigatório")
                .Length(0, 100).WithMessage("Limite de 100 caracteres para o sobrenome");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email obrigatório")
                .EmailAddress().WithMessage("Email inválido");

            RuleFor(x => x.CompanyId)
                .NotEmpty().WithMessage("Id da empresa obrigatório");

            RuleFor(x => x.RoleId)
                .NotEmpty().WithMessage("Id do perfil obrigatório");

            //TODO : validar todos os campos

            //RuleFor(x => x.StartDate).LessThan(DateTime.Today).WithMessage("You cannot enter a birth date in the future.");

            //RuleFor(x => x.Username).Length(8, 999).WithMessage("The user name must be at least 8 characters long.");
        }
    }
}