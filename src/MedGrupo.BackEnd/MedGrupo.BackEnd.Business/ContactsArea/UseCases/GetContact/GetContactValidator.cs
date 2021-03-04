using FluentValidation;

namespace MedGrupo.BackEnd.Business.ContactsArea.UseCases.GetContact
{
    public class GetContactValidator : AbstractValidator<GetContactCommand>
    {
        public GetContactValidator()
        {
            RuleFor(x => x.ID)
               .NotNull()
               .WithMessage("Informe o id do contato.");
        }
    }
}
