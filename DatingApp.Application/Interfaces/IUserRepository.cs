using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DatingApp.Core.Entities;

namespace DatingApp.Application.Interfaces
{
    public interface IUserRepository
    {     
        void Insert(AppUser user);
        void Update(AppUser user);
        void Delete(int userID);
        void Save();
        IEnumerable<AppUser> GetAll();
        AppUser GetById(int userID); 
        Task<bool> CheckEmailExist(string userEmail);
        Task<bool> CheckUsernameExist(string username);
        Task<AppUser> GetByUsername(string userName);
    }
}
