using DigitalData.Domain.Entities.Address;
using DigitalData.Domain.Entities.Company;
using DigitalData.WebApiStarter.Models.Entities.Address;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalData.WebApiStarter.Models.Entities.Company
{
    public class CompanyRead
    {
        public int Id  { get; set; }

        public string Name { get; set; }

        public string Cnpj { get; set; }
        
        public string WebSite { get; set; }

        public string Email { get; set; }

        public AddressSummary Address { get; set; }

        public CompanyRead()
        {

        }

        public CompanyRead(CompanyEntity companyEntity)
        {
            Id = companyEntity.Id;
            Name = companyEntity.Name;
            Cnpj = companyEntity.Cnpj;
            WebSite = companyEntity.WebSite;
            Email = companyEntity.Email;
            Address = new AddressSummary(companyEntity.Address);
        }        

        public CompanyEntity ToEntity()
        {
            var addressEntity = Address.ToEntity();
            var companyentity = new CompanyEntity(Id, Name, Cnpj, WebSite, Email, true, DateTime.Now, DateTime.Now);
            companyentity.Address = addressEntity;
            return companyentity;
        }
    }

    public class CompanyReadValidator : AbstractValidator<CompanyRead>
    {
        public CompanyReadValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id Obrigatório");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome obrigatório")               
                .Length(0, 50).WithMessage("O Nome deve ter no máximo 50 caracteres ");            

            RuleFor(x => x.Cnpj)
                .NotEmpty().WithMessage("Cnpj obrigatório")
                .Length(0, 14).WithMessage("Cnpj deve ter 14 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email obrigatório")
                .EmailAddress().WithMessage("A valid email is required");            
        }
    }
}