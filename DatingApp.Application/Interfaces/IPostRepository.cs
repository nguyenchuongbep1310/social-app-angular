using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingApp.Core.Entities;

namespace DatingApp.Application.Interfaces
{
    public interface IPostRepository
    {
        void Insert(PostUser postUser);
        void Update(PostUser postUser);
        void Delete(int PostId);
        void Save();
        Task<IEnumerable<PostUser>> Post();
    }
}
