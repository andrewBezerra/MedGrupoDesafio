using FluentValidation;

namespace MedGrupo.BackEnd.Business.ContactsArea.UseCases.RemoveContact
{
    class RemoveContactValidator : AbstractValidator<RemoveContactCommand>
    {
        public RemoveContactValidator()
        {
            RuleFor(x => x.ID)
               .NotNull()
               .WithMessage("Informe o id do contato.");

        }
    }
}
