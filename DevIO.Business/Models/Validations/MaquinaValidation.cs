using FluentValidation;

namespace DevIO.Business.Models.Validations
{
    public class MaquinaValidation : AbstractValidator<Maquina>
    {
        public MaquinaValidation()
        {
            RuleFor(c => c.NomeMaquina)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 25)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.IP)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 20)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.MAC)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 30)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
