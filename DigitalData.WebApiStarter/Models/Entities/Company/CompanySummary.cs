using DigitalData.Domain.Entities.Company;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalData.WebApiStarter.Models.Entities.Company
{
    public class CompanySummary
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Cnpj { get; set; }

        public byte[] Logo { get; set; }

        public string WebSite { get; set; }

        public string Email { get; set; }

        public CompanyEntity ToEntity()
        {
            var companyEntity = new CompanyEntity(Id,
                this.Name,
                this.Cnpj,
                this.WebSite,
                this.Email,
                true,
                DateTime.Now,
                DateTime.Now);

            return companyEntity;
        }
    }

    public class CompanySummaryValidator : AbstractValidator<CompanySummary>
    {
        public CompanySummaryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .Length(0, 100).WithMessage("Company Name cannot be more than 100 characters.");

            RuleFor(x => x.Cnpj)
                .NotEmpty().WithMessage("Cnpj is required")
                .Length(0, 14).WithMessage("Cnpj deve ter 14 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("A valid email is required");


            //RuleFor(x => x.StartDate).LessThan(DateTime.Today).WithMessage("You cannot enter a birth date in the future.");

            //RuleFor(x => x.Username).Length(8, 999).WithMessage("The user name must be at least 8 characters long.");
        }        
    }
}