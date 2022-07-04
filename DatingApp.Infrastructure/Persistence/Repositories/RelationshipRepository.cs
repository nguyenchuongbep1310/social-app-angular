using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.Application.Interfaces;
using DatingApp.Core.Entities;
using DatingApp.Infrastructure.Data;

namespace DatingApp.Infrastructure.Persistence.Repositories
{
    public class RelationshipRepository : IRelationshipRepository
    {
        private readonly DataContext _context;
        public RelationshipRepository(DataContext context)
        {
            _context = context;
        }

        public Task Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Relationships>> GetAllOfAUser(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Relationships> Insert(Relationships relationships)
        {
            throw new NotImplementedException();
        }

        public Task Update(Relationships relationships)
        {
            throw new NotImplementedException();
        }
    }
}

