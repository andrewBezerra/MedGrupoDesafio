using MedGrupo.BackEnd.Business.ContactsArea.UseCases.ListContact;
using MedGrupo.BackEnd.Business.Shared;
using MedGrupo.BackEnd.Core.Entities;
using MedGrupo.BackEnd.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MedGrupo.BackEnd.Business.ContactsArea.UseCases.ListContact
{
    public class ListContactHandler : IRequestHandler<ListContactCommand, ApiResult<IEnumerable<Contact>>>
    {
        private readonly IContactRepository _contactRepository;

        public ListContactHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<ApiResult<IEnumerable<Contact>>> Handle(ListContactCommand request, 
                                            CancellationToken cancellationToken)
        {
            var validator = new ListContactValidator();

            var validationresults = await validator.ValidateAsync(request);

            if (!validationresults.IsValid)
                return new ApiResult<IEnumerable<Contact>>()
                {
                    Data = null,
                    Errors = validationresults.Errors,
                    ResultCode = StatusCodes.Status400BadRequest
                };

            var returnlist = await _contactRepository.GetAllAsync(status:request.Status);

            return new ApiResult<IEnumerable<Contact>>() { ResultCode = StatusCodes.Status200OK, Data = returnlist };
        }

       
    }
}
