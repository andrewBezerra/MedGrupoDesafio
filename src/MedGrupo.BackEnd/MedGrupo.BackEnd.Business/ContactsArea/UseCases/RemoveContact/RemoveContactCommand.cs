using MedGrupo.BackEnd.Business.Shared;
using MediatR;
using System;

namespace MedGrupo.BackEnd.Business.ContactsArea.UseCases.RemoveContact
{
    public class RemoveContactCommand : IRequest<ApiResult>
    {
        public Guid ID { get; set; }
    }
}
