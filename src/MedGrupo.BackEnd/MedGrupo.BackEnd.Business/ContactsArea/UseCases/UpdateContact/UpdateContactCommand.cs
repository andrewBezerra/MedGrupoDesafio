using MedGrupo.BackEnd.Business.Shared;
using MedGrupo.BackEnd.Core.Enums;
using MediatR;
using System;

namespace MedGrupo.BackEnd.Business.ContactsArea.UseCases.UpdateContact
{
    public class UpdateContactCommand:IRequest<ApiResult>
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public bool Enabled { get; set; }
        public DateTime BirthDate { get; set; }
        public GenderType Gender { get; set; }
        public int Age { get => CalculateAge(); }
        public string FullName { get => $"{FirstName} {Surname}"; }
        private int CalculateAge()
        {
            return DateTime.Now.DayOfYear < BirthDate.DayOfYear ?
                (DateTime.Now.Year - BirthDate.Year) - 1 :
                DateTime.Now.Year - BirthDate.Year;
        }
    }
}
