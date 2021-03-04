using FluentValidation;

namespace MedGrupo.BackEnd.Business.ContactsArea.UseCases.DisableContact
{
    public class DisableContactValidator :AbstractValidator<DisableContactCommand>
    {
        public DisableContactValidator()
        {
            RuleFor(x => x.ID)
               .NotNull()
               .WithMessage("Informe o id do contato.");       

        }
    }
}
