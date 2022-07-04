using System;
using System.Threading.Tasks;
using DatingApp.Application.DTO;
using DatingApp.Core.DTO;
using DatingApp.Core.Entities;

namespace DatingApp.Application.Interfaces
{
	public interface IRelationshipService
	{
     
        Task<RelationshipDto> Create(RelationshipDto relationshipDto);

        Task<RelationshipDto> Delete(RelationshipDto relationshipDto);

        Task<RelationshipDto> GetUser(string status);

    }
}

