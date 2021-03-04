using MedGrupo.BackEnd.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedGrupo.BackEnd.Core.Repositories
{
    public interface IContactRepository 
    {
        Task<IEnumerable<Contact>> GetAllAsync(int skip = 0,
                                               int take = 200,
                                               bool status=true);
        Task<Contact> GetByIdAsync(Guid id);
        Task<Contact> AddAsync(Contact contact);
        Task<Contact> UpdateAsync(Contact contact);
        Task<Contact> RemoveAsync(Contact contact);

    }
}
