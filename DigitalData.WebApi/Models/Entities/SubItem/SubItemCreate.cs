using DigitalData.Domain.Entities.SubItem;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalData.WebApi.Models.Entities.SubItem
{
    public class SubItemCreate
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public SubItemEntity ToEntity()
        {
            return new SubItemEntity(0, Name, Description, true,  DateTime.Now, DateTime.Now);
        }
    }

    public class SubItemCreateValidator : AbstractValidator<SubItemCreate>
    {
        public SubItemCreateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O Nome do sub item é obrigatório.")
                .Length(0, 35).WithMessage("O Nome do sub item tem um limite de 50 caracteres.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required")
                .Length(0, 200).WithMessage("Descrição deve no máximo 200 caracteres.");            
        }
    }
}