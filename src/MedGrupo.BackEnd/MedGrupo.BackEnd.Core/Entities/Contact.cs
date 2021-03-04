using MedGrupo.BackEnd.Core.Enums;
using System;

namespace MedGrupo.BackEnd.Core.Entities
{
    public class Contact : EntityBase
    {
        public Contact(string firstName,
                       string surname,
                       bool enabled,
                       DateTime birthDate,
                       GenderType gender)
        {
            FirstName = firstName;
            Surname = surname;
            Enabled = enabled;
            BirthDate = birthDate;
            Gender = gender;
        }

        public string FirstName { get; private set; }
        public string Surname { get; private set; }
        public bool Enabled { get; private set; }
        public DateTime BirthDate { get; private set; }
        public GenderType Gender { get; private set; }
        public int Age { get => CalculateAge(); }
        public string FullName { get => $"{FirstName} {Surname}"; }
        private int CalculateAge()
        {
            return DateTime.Now.DayOfYear < BirthDate.DayOfYear ?
                (DateTime.Now.Year - BirthDate.Year) - 1 :
                DateTime.Now.Year - BirthDate.Year;
        }

        public void Enable() => Enabled = true;
        public void Disable() => Enabled = false;
        public void Update(string fistname,
            string surname,
            DateTime birthdate,
            GenderType gender)
        {
            this.FirstName = fistname;
            this.Surname = surname;
            this.BirthDate = birthdate;
            this.Gender = gender;
        }


    }
}
