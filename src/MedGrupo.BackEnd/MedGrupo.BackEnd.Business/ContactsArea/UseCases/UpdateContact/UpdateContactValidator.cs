using FluentValidation;

namespace MedGrupo.BackEnd.Business.ContactsArea.UseCases.UpdateContact
{
    public class UpdateContactValidator :AbstractValidator<UpdateContactCommand>
    {
        public UpdateContactValidator()
        {
            RuleFor(x => x.BirthDate)
              .NotNull()
              .WithMessage("Informe a data de nascimento.");
            RuleFor(x => x.Age)
                .GreaterThanOrEqualTo(18)
                .WithMessage("Contato deve ser maior de idade.");
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("Informe o primeiro nome.");
            RuleFor(x => x.Surname)
                .NotEmpty()
                .WithMessage("Informe o sobrenome.");
            RuleFor(x => x.Gender)
                .IsInEnum()
                .WithMessage("Informe o sexo");
        }
    }
}
