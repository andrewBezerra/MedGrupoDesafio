using MedGrupo.BackEnd.Business.Shared;
using MediatR;
using System;


namespace MedGrupo.BackEnd.Business.ContactsArea.UseCases.DisableContact
{
    public class DisableContactCommand : IRequest<ApiResult>
    {
        public Guid ID { get; set; }
      

    }
}
