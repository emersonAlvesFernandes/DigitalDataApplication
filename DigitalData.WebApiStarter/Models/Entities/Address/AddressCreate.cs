using DigitalData.Domain.Entities.Address;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalData.WebApiStarter.Models.Entities.Address
{
    public class AddressCreate
    {        
        public string Address { get; set; }

        public string Number { get; set; }

        public string Complement { get; set; }

        public string Zipcode { get; set; }

        public string Neighborhood { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        
        public AddressEntity ToEntity()
        {
            var a = new AddressEntity(0, Address, Number, Complement, Zipcode, Neighborhood, City, State);
            return a;
        }
    }
    public class AddressCreateValidator : AbstractValidator<AddressCreate>
    {
        public AddressCreateValidator()
        {
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Campo Logradouro obrigatório")
                .Length(0, 100).WithMessage("Logradouro deve ter no máximo 100 characters.");

            RuleFor(x => x.Number)
                .NotEmpty().WithMessage("Campo Número obrigatório")
                .Length(0, 6).WithMessage("Número deve ter no máximo 6 characters.");


            RuleFor(x => x.Zipcode)
                .NotEmpty().WithMessage("Campo CEP obrigatório")
                .Length(0, 8).WithMessage("CEP deve ter no máximo 8 caracteres.");

            RuleFor(x => x.Neighborhood)
                .NotEmpty().WithMessage("Campo Bairro obrigatório.")
                .Length(0, 25).WithMessage("Bairro deve ter no máximo 8 caracteres.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("Campo Cidade obrigatório.")
                .Length(0, 25).WithMessage("Campo Bairro deve ter no máximo 8 caracteres.");

            RuleFor(x => x.State)
                .NotEmpty().WithMessage("Campo Estado obrigatório.")
                .Length(0, 2).WithMessage("Campo Estado deve ter no máximo 2 caracteres.");


            //RuleFor(x => x.StartDate).LessThan(DateTime.Today).WithMessage("You cannot enter a birth date in the future.");

            //RuleFor(x => x.Username).Length(8, 999).WithMessage("The user name must be at least 8 characters long.");
        }
    }
}