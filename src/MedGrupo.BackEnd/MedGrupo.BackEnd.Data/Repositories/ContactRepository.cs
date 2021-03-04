using MedGrupo.BackEnd.Core.Entities;
using MedGrupo.BackEnd.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedGrupo.BackEnd.Data.Repositories
{
    class ContactRepository : IContactRepository
    {
        private readonly Context _context;

        public ContactRepository(Context context)
        {
            _context = context;
        }
    
        public async Task<IEnumerable<Contact>> GetAllAsync(int skip = 0, int take = 200, bool status=true)
        {
            return await _context.Contacts.Where(x=>x.Enabled==status)
               .Skip(skip)
               .Take(take)
               .ToListAsync();

        }

        public async Task<Contact> GetByIdAsync(Guid id)
        {
            return await _context.Contacts
                .Where(x => x.ID == id)
                .SingleOrDefaultAsync();
        }
        public async Task<Contact> AddAsync(Contact contact)
        {
            var contactentity = await _context.Set<Contact>().AddAsync(contact);
            await _context.SaveChangesAsync();
            return contactentity.Entity;

        }

        public async Task<Contact> RemoveAsync(Contact contact)
        {
            var contactentity = _context.Set<Contact>().Remove(contact);
            await _context.SaveChangesAsync();
            return contactentity.Entity;
        }

        public async Task<Contact> UpdateAsync(Contact contact)
        {
            var contactentity = _context.Set<Contact>().Update(contact);
            await _context.SaveChangesAsync();
            return contactentity.Entity;
        }
    }
}
