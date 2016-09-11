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
    public class CommentService : ICommentService
    {
        IUnitOfWork DB { get; set; }

        public CommentService(IUnitOfWork dbContext)
        {
            DB = dbContext;
        }

        public void CreateNew(CommentDTO commentDTO)
        {
            Mapper.Initialize(c => c.CreateMap<CommentDTO, Comment>());
            Comment comment = Mapper.Map<CommentDTO, Comment>(commentDTO);
            DB.Comments.Create(comment);
            DB.Save();
        }

        public CommentDTO GetCommentById(int? id)
        {
            if (id == null)
                throw new ValidationException("CommentId parameter is null!", "id");
            var comment = DB.Comments.GetById(id.Value);
            if (comment == null)
                throw new ValidationException("The comment not finded!", "");
            Mapper.Initialize(c => c.CreateMap<Comment, CommentDTO>());
            return Mapper.Map<Comment, CommentDTO>(comment);
        }

        public IEnumerable<CommentDTO> GetCommentsByUserId(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ValidationException("UserId parameter is null!", "userId");
            var comments = DB.Comments.Find(x => x.Post.User.Id == userId);
            if (comments == null)
                throw new ValidationException("The comments not finded!", "");
            Mapper.Initialize(c => c.CreateMap<Comment, CommentDTO>());
            return Mapper.Map<IEnumerable<Comment>, List<CommentDTO>>(comments);
        }

        public IEnumerable<CommentDTO> GetAllComments()
        {
            var comments = DB.Comments.GetAll();
            if (comments == null)
                throw new ValidationException("The comments not finded!", "");
            Mapper.Initialize(cfg => cfg.CreateMap<Comment, CommentDTO>());
            return Mapper.Map<IEnumerable<Comment>, List<CommentDTO>>(comments);
        }

        public IEnumerable<CommentDTO> GetAllCommentsByPostId(int postId)
        {
            if (postId == 0)
                throw new ValidationException("PostId parameter is null!", "postId");
            var comments = DB.Comments.Find(x => x.Post.Id == postId);
            if (comments == null)
                throw new ValidationException("The comments not finded!", "");
            Mapper.Initialize(c => c.CreateMap<Comment, CommentDTO>());
            return Mapper.Map<IEnumerable<Comment>, List<CommentDTO>>(comments);
        }

        public IEnumerable<CommentDTO> GetChildCommentById(int parentCommentId)
        {
            if (parentCommentId == 0)
                throw new ValidationException("ParentCommentId parameter is null!", "parentCommentId");
            var comments = DB.Comments.Find(x => x.ParentComment.Id == parentCommentId);
            if (comments == null)
                throw new ValidationException("The comments not finded!", "");
            Mapper.Initialize(c => c.CreateMap<Comment, CommentDTO>());
            return Mapper.Map<IEnumerable<Comment>, List<CommentDTO>>(comments);
        }

        public void Dispose()
        {
            DB.Dispose();
        }

    }
}
