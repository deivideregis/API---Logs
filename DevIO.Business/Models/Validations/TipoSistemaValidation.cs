using FluentValidation;

namespace DevIO.Business.Models.Validations
{
    public class TipoSistemaValidation : AbstractValidator<TipoSistema>
    {
        public TipoSistemaValidation()
        {
            RuleFor(c => c.NumeroSistema)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 3)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.NomeSistema)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(5, 50)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
