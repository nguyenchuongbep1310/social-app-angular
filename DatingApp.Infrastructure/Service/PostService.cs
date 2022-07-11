using DatingApp.Application.DTO.Posts;
using DatingApp.Application.Interfaces;
using DatingApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Infrastructure.Service
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<AddPostResponse> CreateNewPost(AddPostRequest request)
        {
            string nameOfPostPicture = string.Empty;
            if (request.Image != null)
            {
                var folderSave = Path.Combine("Share", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderSave);
                nameOfPostPicture = Guid.NewGuid().ToString() + "-" + request.Image.FileName;
                var fullPath = Path.Combine(pathToSave, nameOfPostPicture);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                request.Image.CopyTo(stream);
                }
            }

            PostUser newPost = new PostUser();
            newPost.Text = request.Text;
            newPost.Image = nameOfPostPicture;
            newPost.UserId = request.UserId;
            newPost.CreatedDate = DateTime.Now;
            await _postRepository.Add(newPost);

            return new AddPostResponse {
                Id = newPost.PostId,
                Text = newPost.Text,
                Image = newPost.Image,
                UserId = newPost.UserId,
                CreatedDate = newPost.CreatedDate,
            };
        }

        public async Task DeletePost(DeletePostRequest request)
        {
            PostUser postToDelete = await _postRepository.GetById(request.Id);
            await _postRepository.Delete(postToDelete);
        }

        public async Task<List<GetUserPostResponse>> GetAllPostOfUser(GetUserPostRequest request)
        {
            var postUsers =  await _postRepository.GetAll(request.UserId);

            return postUsers.Select(post => new GetUserPostResponse() {
                Id = post.PostId,
                UserId = post.UserId,
                Text = post.Text,
                Image = post.Image,
                CreatedDate = post.CreatedDate,
            }).ToList();
        }

        public async Task<GetPostResponse> GetPostById(GetPostRequest request)
        {
            PostUser postUser = await _postRepository.GetById(request.Id);
            return new GetPostResponse()
            {
                Id = postUser.PostId,
                Text = postUser.Text,
                Image = postUser.Image,
                UserId = postUser.UserId,
                CreatedDate = postUser.CreatedDate,
            };
        }
    }
}
