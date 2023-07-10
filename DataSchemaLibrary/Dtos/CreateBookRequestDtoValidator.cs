using FluentValidation;

namespace DataSchemaLibrary.Dtos
{
    public class CreateBookRequestDtoValidator : AbstractValidator<CreateBookRequestDto>
    {
        public CreateBookRequestDtoValidator() 
        {
            RuleFor(dto => dto.Title).NotEmpty().WithMessage("Title is required.");
            RuleFor(dto => dto.Author).NotEmpty().WithMessage("Author is required.");
            RuleFor(dto => dto.Year).InclusiveBetween(1800, DateTime.Now.Year).WithMessage("Year must be between 1800 and current year.");
        }

    }
}
