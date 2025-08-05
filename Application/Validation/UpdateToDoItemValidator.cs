using Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validation
{
    public class UpdateToDoItemValidator : AbstractValidator<UpdateToDoTitemDTO>
    {
        public UpdateToDoItemValidator()
        {
            RuleFor(dto => dto.Title).NotEmpty().WithMessage("Title is required").MaximumLength(100).WithMessage("Title is more than 100 chars");
            RuleFor(dto => dto.Decription).MaximumLength(500).WithMessage("Desc cannot more then 500 chars");
        }
    }
}
