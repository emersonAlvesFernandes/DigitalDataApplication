using DigitalData.Domain.Entities.SubItem;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalData.WebApi.Models.Entities.SubItem
{
    public class SubItemSummaryRead
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


        public SubItemSummaryRead ToSubItemRead(SubItemEntity entity)
        {
            return new SubItemSummaryRead
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            };            
        }

        public List<SubItemSummaryRead> ToSubItemReadCollection(IEnumerable<SubItemEntity> entityCollection)
        {
            var readCollection = new List<SubItemSummaryRead>();

            foreach(var entity in entityCollection)
            {
                var subItemRead = new SubItemSummaryRead
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description
                };

                readCollection.Add(subItemRead);
            }
            return readCollection;
        }

        public SubItemEntity ToEntity()
        {
            var entity = new SubItemEntity(Id, Name, Description, true, DateTime.Now, DateTime.Now);
            return entity;
        }
    }

    public class SubItemSummaryReadValidator : AbstractValidator<SubItemSummaryRead>
    {
        public SubItemSummaryReadValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("Id obrigatório.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O Nome do sub item é obrigatório.")
                .Length(0, 35).WithMessage("O Nome do sub item tem um limite de 50 caracteres.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required")
                .Length(0, 200).WithMessage("Descrição deve no máximo 200 caracteres.");
        }
    }
}