using System;
using AutoMapper;
using System.Collections.Generic;
using InTravels.DAL.Entities;
using InTravels.DAL.Interfaces;
using InTravels.BLL.DTO;
using InTravels.BLL.Interfaces;
using InTravels.BLL.Infrastructure;

namespace InTravels.BLL.Services
{
    public class PostService : IPostService
    {
        IUnitOfWork DB { get; set; }

        public PostService(IUnitOfWork dbContext)
        {
            DB = dbContext;
        }

        public void CreateNew(PostDTO postDTO)
        {
            Mapper.Initialize(c => c.CreateMap<PostDTO, Post>());
            Post post = Mapper.Map<PostDTO, Post>(postDTO);
            DB.Posts.Create(post);
            DB.Save();
        }

        public PostDTO GetPostById(int? id)
        {
            if (id == null)
                throw new ValidationException("PostId parameter is null!", "id");
            var post = DB.Posts.GetById(id.Value);
            if (post == null)
                throw new ValidationException("The post not finded!", "");
            Mapper.Initialize(c => c.CreateMap<Post, PostDTO>());
            return Mapper.Map<Post, PostDTO>(post);
        }

        public IEnumerable<PostDTO> GetPostsByUserId(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ValidationException("UserId parameter is null!", "userId");
            var posts = DB.Posts.Find(x => x.UserProfileId == userId);
            if (posts == null)
                throw new ValidationException("The posts not finded!", "");
            Mapper.Initialize(c => c.CreateMap<Post, PostDTO>());
            return Mapper.Map<IEnumerable<Post>, List<PostDTO>>(posts);
        }

        public void Dispose()
        {
            DB.Dispose();
        }

        public IEnumerable<PostDTO> GetAllPosts()
        {
            var posts = DB.Posts.GetAll();
            if (posts == null)
                throw new ValidationException("The posts not finded!", "");
            Mapper.Initialize(cfg => cfg.CreateMap<Post, PostDTO>());
            return Mapper.Map<IEnumerable<Post>, List<PostDTO>>(posts);
        }
    }
}
