using FluentValidation;
using TechChallenge.Domain.Models;

namespace TechChallenge.Domain.Validators
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator() 
        {
            RuleFor(c => c.Email).NotEmpty().WithMessage("Campo de preenchimento obrigatório.")
                .EmailAddress().WithMessage("Informe um endereço de e-mail válido. Ex.: nome@dominio.com.br");

            RuleFor(c => c.Phone).NotEmpty().WithMessage("Campo de preenchimento obrigatório.")
                .Must(IsOnlyNumberString).WithMessage("O telefone deve conter apenas números.")
                .Length(10, 11).WithMessage("O telefone deve conter entre 10 e 11 digitos.");

            RuleFor(c => c.Name).NotEmpty().WithMessage("Campo de preenchimento obrigatório.")
                .Length(4, 64).WithMessage("Campo com limite entre 4 e 64 caracteres.");

            RuleFor(c => c.StateId).Must(BeAValidGuid).WithMessage("Campo de preenchimento obrigatório.")
                .NotEmpty().WithMessage("Campo de preenchimento obrigatório.");
        }

        // Check if the string passed contains only numeric characters
        private bool IsOnlyNumberString(string numericString)
        {
            return long.TryParse(numericString, out _);
        }

        private bool BeAValidGuid(Guid id)
        {
            return id != Guid.Empty;
        }
    }
}
