using DatingApp.Application.Interfaces;
using DatingApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Infrastructure.Service
{
    public class PostServie : IPostService
    {
        // public List<PostUser> ConectionsPosts(int id, int take, int skip)
        // {

        //     var list = new int[] { id }.AsQueryable();


        //     List<PostUser> posts = (from p in _context.Posts.Select(p => new PostUser
        //     {
        //         Author = p.Author,
        //         Text = p.Text,
        //         CreatedDate = p.CreatedDate,
        //         PostId = p.PostId
        //     })
        //                         join t2 in (from f1 in _context.Users where f1.User2Id == id && f1.Status.Status == 1 select f1.User1Id)
        //                                     .Union(from f1 in _context.Users where f1.User1Id == id && f1.Status.Status == 1 select f1.User2Id)
        //                                     .Union(from f1 in _context.Users where f1.Id == id select f1.Id)
        //                                     on p.PostId equals t2
        //                         select p)
        //         .Skip(skip)
        //         .Take(take)
        //         .AsNoTracking()
        //         .ToList();

        //     return posts;
        // }   
    }
}
