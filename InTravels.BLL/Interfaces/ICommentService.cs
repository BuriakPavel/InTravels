using InTravels.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTravels.BLL.Interfaces
{
    public interface ICommentService : IDisposable
    {
        void CreateNew(CommentDTO comment);
        CommentDTO GetCommentById(int? id);
        IEnumerable<CommentDTO> GetAllCommentsByPostId(int postId);
        IEnumerable<CommentDTO> GetCommentsByUserId(string userId);
        IEnumerable<CommentDTO> GetChildCommentById(int parentCommentId);
    }
}
