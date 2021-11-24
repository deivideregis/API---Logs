using FluentValidation; //(AbstractValidator)

namespace DevIO.Business.Models.Validations
{
    public class LogValidation : AbstractValidator<Log>
    {
        public LogValidation()
        {
            RuleFor(c => c.Detalhe)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 500)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Acao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 50)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }            
    }
}
