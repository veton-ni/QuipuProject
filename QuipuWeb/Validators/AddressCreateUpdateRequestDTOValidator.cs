using FluentValidation;
using QuipuWeb.Dto;

namespace QuipuWeb.Validators
{
    public class AddressCreateUpdateRequestDTOValidator : AbstractValidator<AddressCreateUpdateRequestDTO>
    {
        public AddressCreateUpdateRequestDTOValidator()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("Please specify a Name!");
            RuleFor(x => x.postCode).NotEmpty().WithMessage("Please specify a PostCode!");
            RuleFor(x => x.type).NotEmpty().WithMessage("Please specify a Type!");

            RuleFor(x => x.name).MaximumLength(120).WithMessage("Maximum length of Name is 120 characters!");
            RuleFor(x => x.postCode).MaximumLength(6).WithMessage("Maximum length of PostCode is 6 characters!");
        }

    }
}
