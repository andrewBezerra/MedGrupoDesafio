using MedGrupo.BackEnd.Business.Shared;
using MedGrupo.BackEnd.Core.Entities;
using MedGrupo.BackEnd.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MedGrupo.BackEnd.Business.ContactsArea.UseCases.UpdateContact
{
    public class UpdateContactHandler : IRequestHandler<UpdateContactCommand, ApiResult>
    {
        private readonly IContactRepository _contactRepository;

        public UpdateContactHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<ApiResult> Handle(UpdateContactCommand request,
                                             CancellationToken cancellationToken)
        {
            var validator = new UpdateContactValidator();

            var validationresults = await validator.ValidateAsync(request);

            if (!validationresults.IsValid)
                return new ApiResult()
                {
                    Errors = validationresults.Errors,
                    ResultCode = StatusCodes.Status400BadRequest
                };

            var contactResult = await _contactRepository.GetByIdAsync(request.ID);

            contactResult.Update(
                request.FirstName,
                request.Surname,
                request.BirthDate,
                request.Gender);

            var result = await _contactRepository.UpdateAsync(contactResult);

            return new ApiResult<Contact>() { ResultCode = StatusCodes.Status200OK, Data = result };
        }
    }
}
