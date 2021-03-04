using MedGrupo.BackEnd.Business.Shared;
using MedGrupo.BackEnd.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MedGrupo.BackEnd.Business.ContactsArea.UseCases.RemoveContact
{
    public class RemoveContactHandler : IRequestHandler<RemoveContactCommand, ApiResult>
    {
        private readonly IContactRepository _contactRepository;

        public RemoveContactHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<ApiResult> Handle(RemoveContactCommand request, 
                                            CancellationToken cancellationToken)
        {
            var validator = new RemoveContactValidator();

            var validationresults = await validator.ValidateAsync(request);

            if (!validationresults.IsValid)
                return new ApiResult()
                {
                    Errors = validationresults.Errors,
                    ResultCode = StatusCodes.Status400BadRequest
                };

            var newContact = await _contactRepository.GetByIdAsync(request.ID);

             await _contactRepository.RemoveAsync(newContact);

            return new ApiResult() { ResultCode = StatusCodes.Status200OK };
        }
    }
}
