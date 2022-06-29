using DatingApp.Application.DTO;
using DatingApp.Application.Interfaces;
using DatingApp.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

        public async Task<bool> Create(PostDto postDto)
        {
            try
            {
                string nameOfPostPic = string.Empty;
                if (postDto.Images != null)
                {
                    var folderSave = Path.Combine("Share", "Images");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderSave);
                    nameOfPostPic = Guid.NewGuid().ToString() + "-" + postDto.Images.FileName;
                    var fullPath = Path.Combine(pathToSave, nameOfPostPic);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        postDto.Images.CopyTo(stream);
                    }
                }

                PostUser newPost = new PostUser();
                newPost.Text = postDto.Text;
                newPost.Images = nameOfPostPic;
                newPost.CreatedDate = postDto.CreatedDate;
                newPost.ModifiedDate = postDto.ModifiedDate;
                newPost.UserId = postDto.UserId;

                await _postRepository.Insert(newPost);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public async Task<bool> Delete(int postId, int userId)
        {

            PostUser postToDelete = await _postRepository.GetById(postId);
            if (postToDelete.UserId != userId) return false;

            await _postRepository.Delete(postId);

            return true;
        }

        public Task<IEnumerable<PostUser>> GetAllPostsOfUser(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<PostUser> GetById(int postId, int userId)
        {
            PostUser postUser = await _postRepository.GetById(postId);
            if (postUser.UserId != userId) throw new Exception();

            return postUser;
        }

        public async Task<bool> Update(PostDto postDto, int postId)
        {
            try
            {           
                PostUser postToUpdate = await _postRepository.GetById(postId);
                if (postToUpdate.UserId != postDto.UserId) return false;

                string nameOfPostPic = string.Empty;
                if (postDto.Images != null)
                {
                    var folderSave = Path.Combine("Share", "Images");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderSave);
                    nameOfPostPic = Guid.NewGuid().ToString() + "-" + postDto.Images.FileName;
                    var fullPath = Path.Combine(pathToSave, nameOfPostPic);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        postDto.Images.CopyTo(stream);
                    }
                    postToUpdate.Text = postDto.Text;
                    postToUpdate.Images = nameOfPostPic;
                    postToUpdate.CreatedDate = postDto.CreatedDate;
                    postToUpdate.ModifiedDate = postDto.ModifiedDate;
                }

                await _postRepository.Update(postToUpdate);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
