using DigitalData.Domain.Entities.Address;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalData.WebApi.Models.Entities.Address
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
                .NotEmpty().WithMessage("Address is required")
                .Length(0, 100).WithMessage("Company Name cannot be more than 100 characters.");

            RuleFor(x => x.Number)
                .NotEmpty().WithMessage("Number is required")
                .Length(0, 6).WithMessage("Number must have 6 maximum caracteres.");

            RuleFor(x => x.Zipcode)
                .NotEmpty().WithMessage("Zipcode is required")
                .Length(0, 8).WithMessage("Zipcode must have 8 maximum caracteres.");

            RuleFor(x => x.Neighborhood)
                .NotEmpty().WithMessage("Neighborhood is required")
                .Length(0, 25).WithMessage("Neighborhood must have 25 maximum caracteres.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required")
                .Length(0, 25).WithMessage("City must have 25 maximum caracteres.");

            RuleFor(x => x.State)
                .NotEmpty().WithMessage("State is required")
                .Length(0, 2).WithMessage("State must have 2 maximum caracteres.");


            //RuleFor(x => x.StartDate).LessThan(DateTime.Today).WithMessage("You cannot enter a birth date in the future.");

            //RuleFor(x => x.Username).Length(8, 999).WithMessage("The user name must be at least 8 characters long.");
        }
    }
}