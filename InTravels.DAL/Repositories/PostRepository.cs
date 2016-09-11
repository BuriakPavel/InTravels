using InTravels.DAL.EF;
using InTravels.DAL.Entities;
using InTravels.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTravels.DAL.Repositories
{
    public class PostRepository : IRepository<Post>
    {
        private ApplicationContext db;

        public PostRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public void Create(Post item)
        {
            db.Posts.Add(item);
        }

        public void Delete(int id)
        {
            var post = db.Posts.Find(id);
            if (post != null)
            {
                db.Posts.Remove(post);
            }
        }

        public IEnumerable<Post> Find(Func<Post, bool> predicate)
        {
            return db.Posts.Where(predicate).ToList();
        }

        public Post GetById(int id)
        {
            return db.Posts.Find(id);
        }

        public IEnumerable<Post> GetAll()
        {
           return db.Posts.ToList();
        }

        public void Update(Post item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
