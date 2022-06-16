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
        IEnumerable<AppUser> GetAll();
        AppUser GetById(int userID);
        void Insert(AppUser user);
        void Update(AppUser user);
        void Delete(int userID);
        void Save();
        Task<bool> CheckEmailExist(string userEmail);
        Task<bool> CheckUsernameExist(string username);
    }
}
