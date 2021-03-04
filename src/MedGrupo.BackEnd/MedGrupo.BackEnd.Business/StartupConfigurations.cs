using MedGrupo.BackEnd.Business.ContactsArea.UseCases.AddContact;
using MedGrupo.BackEnd.Business.ContactsArea.UseCases.DisableContact;
using MedGrupo.BackEnd.Business.ContactsArea.UseCases.GetContact;
using MedGrupo.BackEnd.Business.ContactsArea.UseCases.ListContact;
using MedGrupo.BackEnd.Business.ContactsArea.UseCases.RemoveContact;
using MedGrupo.BackEnd.Business.ContactsArea.UseCases.UpdateContact;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MedGrupo.BackEnd.Business
{
    public static class StartupConfigurations
    {


        public static IServiceCollection ConfigureMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(AddContactHandler).Assembly);
            services.AddMediatR(typeof(DisableContactHandler).Assembly);
            services.AddMediatR(typeof(GetContactHandler).Assembly);
            services.AddMediatR(typeof(ListContactHandler).Assembly);
            services.AddMediatR(typeof(RemoveContactHandler).Assembly);
            services.AddMediatR(typeof(UpdateContactHandler).Assembly);

            return services;
        }



    }
}
