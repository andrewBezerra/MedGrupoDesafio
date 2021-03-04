using MedGrupo.BackEnd.Business.Shared;
using MedGrupo.BackEnd.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MedGrupo.BackEnd.Business.ContactsArea.UseCases.DisableContact
{
    public class DisableContactHandler : IRequestHandler<DisableContactCommand, ApiResult>
    {
        private readonly IContactRepository _contactRepository;

        public DisableContactHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<ApiResult> Handle(DisableContactCommand request,
                                             CancellationToken cancellationToken)
        {
            var validator = new DisableContactValidator();

            var validationresults = await validator.ValidateAsync(request);

            if (!validationresults.IsValid)
                return new ApiResult() { 
                    Errors = validationresults.Errors, 
                    ResultCode = StatusCodes.Status400BadRequest };

            var disabledContact = await _contactRepository.GetByIdAsync(request.ID);

            disabledContact.Disable();

            var result = await _contactRepository.UpdateAsync(disabledContact);

            return new ApiResult() { ResultCode = StatusCodes.Status200OK };

        }
    }
}
