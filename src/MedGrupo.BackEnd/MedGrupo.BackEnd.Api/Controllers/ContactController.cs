using MedGrupo.BackEnd.Business.ContactsArea.UseCases.AddContact;
using MedGrupo.BackEnd.Business.ContactsArea.UseCases.DisableContact;
using MedGrupo.BackEnd.Business.ContactsArea.UseCases.GetContact;
using MedGrupo.BackEnd.Business.ContactsArea.UseCases.ListContact;
using MedGrupo.BackEnd.Business.ContactsArea.UseCases.RemoveContact;
using MedGrupo.BackEnd.Business.ContactsArea.UseCases.UpdateContact;
using MedGrupo.BackEnd.Business.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedGrupo.BackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<ContactController>
        [HttpGet]
        public async Task<ApiResult> Get() => await _mediator.Send(new ListContactCommand());

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public async Task<ApiResult> Get(Guid id) => await _mediator.Send(new GetContactCommand() { ID = id });

        // GET api/<ContactController>/5
        [HttpPost("{id}/disable")]
        public async Task<ApiResult> Disable(Guid id) => await _mediator.Send(new DisableContactCommand() { ID = id });

        // POST api/<ContactController>
        [HttpPost]
        public async Task<ApiResult> Post([FromBody] AddContactCommand command) => await _mediator.Send(command);

        [HttpPut]
        public async Task<ApiResult> Put([FromBody] UpdateContactCommand command) => await _mediator.Send(command);

        // DELETE api/<ContactController>/5
        [HttpDelete]
        public async Task<ApiResult> Delete([FromBody] RemoveContactCommand command) => await _mediator.Send(command);

    }
}
