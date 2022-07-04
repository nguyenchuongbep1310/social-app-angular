using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.Core.Entities;

namespace DatingApp.Application.Interfaces
{
	public interface IRelationshipRepository
	{
        Task<Relationships> Insert(Relationships relationships);
        Task Update(Relationships relationships);
        Task Delete(int Id);
        Task<IEnumerable<Relationships>> GetAllOfAUser(int Id);
    }
}

