using FluentValidation;
using QuipuWeb.Dto;

namespace QuipuWeb.Validators
{
    public class ClientCreateUpdateRequestDTOValidator : AbstractValidator<ClientCreateUpdateRequestDTO>
    {
        public ClientCreateUpdateRequestDTOValidator()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("Please specify a Name!");
            RuleFor(x => x.email).NotEmpty().WithMessage("Please specify a Email!");

            RuleFor(x => x.name).MaximumLength(120).WithMessage("Maximum length of Name is 120 characters!");
            RuleFor(x => x.email).MaximumLength(120).WithMessage("Maximum length of Email is 120 characters!");
            RuleFor(x => x.phone).MaximumLength(6).WithMessage("Maximum length of Phone is 30 characters!");
        }

    }
}