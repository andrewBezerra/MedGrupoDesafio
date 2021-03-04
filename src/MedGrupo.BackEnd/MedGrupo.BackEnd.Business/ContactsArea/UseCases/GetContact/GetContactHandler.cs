using MedGrupo.BackEnd.Business.Shared;
using MedGrupo.BackEnd.Core.Entities;
using MedGrupo.BackEnd.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MedGrupo.BackEnd.Business.ContactsArea.UseCases.GetContact
{
    public class GetContactHandler : IRequestHandler<GetContactCommand, ApiResult>
    {
        private readonly IContactRepository _contactRepository;

        public GetContactHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<ApiResult> Handle(GetContactCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetContactValidator();

            var validationresults = await validator.ValidateAsync(request);

            if (!validationresults.IsValid)
                return new ApiResult()
                {
                    Errors = validationresults.Errors,
                    ResultCode = StatusCodes.Status400BadRequest
                };

            var returnContact = await _contactRepository.GetByIdAsync(request.ID);

            return new ApiResult<Contact>() { ResultCode = StatusCodes.Status200OK,Data= returnContact };
        }
    }
}
