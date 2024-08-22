
using System.ComponentModel.DataAnnotations;

namespace TechChallenge.Core.DTO
{
    public class ContactDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage ="O nome é obrigatório")]
        [StringLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        [StringLength(15, MinimumLength = 10,  ErrorMessage = "O telefone deve ter entre 10 e 11 números")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "O email é inválido")]
        public string Email { get; set; }

        [NotEmptyGuid]
        public Guid StateId { get; set; }

        public StateDto State { get; set; }
    }

    public class NotEmptyGuidAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || value is not Guid guidValue || guidValue == Guid.Empty)
            {
                return new ValidationResult("O estado é obrigatório");
            }

            return ValidationResult.Success;
        }
    }
}