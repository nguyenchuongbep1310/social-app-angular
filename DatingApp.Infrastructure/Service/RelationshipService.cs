using System;
using System.Threading.Tasks;
using DatingApp.Application.DTO;
using DatingApp.Application.Interfaces;

namespace DatingApp.Infrastructure.Service
{
	public class RelationshipService: IRelationshipService
	{
		public RelationshipService()
		{
		}

        public Task<RelationshipDto> Create(RelationshipDto relationshipDto)
        {
            throw new NotImplementedException();
        }

        public Task<RelationshipDto> Delete(RelationshipDto relationshipDto)
        {
            throw new NotImplementedException();
        }

        public Task<RelationshipDto> GetUser(string status)
        {
            throw new NotImplementedException();
        }
    }
}

