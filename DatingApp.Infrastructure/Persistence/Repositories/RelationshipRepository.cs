using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Application.Interfaces;
using DatingApp.Core.Entities;
using DatingApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Infrastructure.Persistence.Repositories
{
    public class RelationshipRepository : IRelationshipRepository
    {
        private readonly DataContext _context;
        public RelationshipRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Delete(int Id)
        {
            Relationships relationshipsToDelete = await _context.Relationships.FindAsync(Id);
            _context.Relationships.Remove(relationshipsToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Relationships>> GetAllOfAUser(int Id)
        {
            return await _context.Relationships.Where(p => p.Id == Id).ToListAsync();
        }

        public async Task<Relationships> Insert(Relationships relationships)
        {
             _context.Relationships.Add(relationships);
            await _context.SaveChangesAsync();

            return relationships;
        }

        public async Task Update(Relationships relationships)
        {
            _context.Entry(relationships).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

