using MedGrupo.BackEnd.Business.Shared;
using MediatR;
using System;

namespace MedGrupo.BackEnd.Business.ContactsArea.UseCases.GetContact
{
    public class GetContactCommand : IRequest<ApiResult>
    {
        public Guid ID { get; set; }
    }
}
