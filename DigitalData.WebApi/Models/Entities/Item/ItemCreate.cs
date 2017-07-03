using DigitalData.Domain.Entities.Item;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalData.WebApi.Models.Entities.Item
{
    public class ItemCreate
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Desdobramento { get; set; }

        public ItemEntity ToEntity()
        {
            var entity = new ItemEntity(0, this.Name, this.Description, this.Desdobramento);
            return entity;
        }

    }
    public class ItemCreateValidator : AbstractValidator<ItemCreate>
    {
        public ItemCreateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .Length(0, 100).WithMessage("Item Name cannot be more than 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Cnpj is required")
                .Length(0, 200).WithMessage("Descrição deve no máximo 200 caracteres.");


            //RuleFor(x => x.StartDate).LessThan(DateTime.Today).WithMessage("You cannot enter a birth date in the future.");

            //RuleFor(x => x.Username).Length(8, 999).WithMessage("The user name must be at least 8 characters long.");

        }
    }
}