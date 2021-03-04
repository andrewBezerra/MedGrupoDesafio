using MedGrupo.BackEnd.Business.Shared;
using MedGrupo.BackEnd.Core.Entities;
using MediatR;
using System.Collections.Generic;

namespace MedGrupo.BackEnd.Business.ContactsArea.UseCases.ListContact
{
    public class ListContactCommand : IRequest<ApiResult<IEnumerable<Contact>>>
    {
        public bool Status { get; set; } = true;
    }
}
