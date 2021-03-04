using FluentValidation;

namespace MedGrupo.BackEnd.Business.ContactsArea.UseCases.ListContact
{
    public class ListContactValidator : AbstractValidator<ListContactCommand>
    {
        public ListContactValidator()
        {
            RuleFor(x => x.Status)
              .NotNull()
              .WithMessage("Informe o status.");
        }
    }
}
