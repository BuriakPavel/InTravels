using InTravels.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTravels.BLL.Interfaces
{
    public interface IPostService : IDisposable
    {
        void CreateNew(PostDTO post);
        PostDTO GetPostById(int? id);
        IEnumerable<PostDTO> GetAllPosts();
        IEnumerable<PostDTO> GetPostsByUserId(string userId);
    }
}
