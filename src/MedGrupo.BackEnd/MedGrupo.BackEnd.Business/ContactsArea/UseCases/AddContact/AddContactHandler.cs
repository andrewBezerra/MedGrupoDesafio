using MedGrupo.BackEnd.Business.Shared;
using MedGrupo.BackEnd.Core.Entities;
using MedGrupo.BackEnd.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MedGrupo.BackEnd.Business.ContactsArea.UseCases.AddContact
{
    public class AddContactHandler : IRequestHandler<AddContactCommand, ApiResult>
    {
        private readonly IContactRepository _contactRepository;

        public AddContactHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<ApiResult> Handle(AddContactCommand request,
                                             CancellationToken cancellationToken)
        {
            var validator = new AddContactValidator();

            var validationresults = await validator.ValidateAsync(request);

            if (!validationresults.IsValid)
                return new ApiResult() { 
                    Errors = validationresults.Errors, 
                    ResultCode = StatusCodes.Status400BadRequest };

            var newContact = new Contact(
                                     request.FirstName,
                                     request.Surname,
                                     true,
                                     request.BirthDate,
                                     request.Gender);

            var result = await _contactRepository.AddAsync(newContact);

            return new ApiResult<Contact>() { ResultCode = StatusCodes.Status200OK, Data=result };

        }
    }
}
