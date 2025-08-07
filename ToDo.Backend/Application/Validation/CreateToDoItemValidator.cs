
using Application.DTOs;
using FluentValidation;

namespace Application.Validation
{
    public class CreateToDoItemValidator : AbstractValidator<CreateToDoItemDTO>
    {
        public CreateToDoItemValidator()
        {
            RuleFor(dto => dto.Title).NotEmpty().WithMessage("Title is required").MaximumLength(100).WithMessage("Title is more than 100 chars");
            RuleFor(dto => dto.Description).MaximumLength(500).WithMessage("Desc cannot more then 500 chars");
            RuleFor(dto => dto.DeadLine).GreaterThanOrEqualTo(DateTime.UtcNow).WithMessage("Deadline is too early");
            
        }
    }
}
