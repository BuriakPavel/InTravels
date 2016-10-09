using AutoMapper;
using InTravels.BLL.DTO;
using InTravels.BLL.Interfaces;
using InTravels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InTravels.ControllersApi
{
    public class PostApiController : BaseApiController
	{
		IPostService postService;
		public PostApiController()
		{ }

		public PostApiController(IPostService serv)
		{
			postService = serv;
		}

		public IEnumerable<PostViewModel> GetPosts()
		{
			var posts = postService.GetAllPosts();
			Mapper.Initialize(cfg => cfg.CreateMap<PostDTO, PostViewModel>());
			var postViewModels = Mapper.Map<IEnumerable<PostDTO>, List<PostViewModel>>(posts);

			return postViewModels;
		}

		public PostViewModel GetPost(int id)
		{
			PostDTO postDto = postService.GetPostById(id);
			Mapper.Initialize(cfg => cfg.CreateMap<PostDTO, PostViewModel>());
			PostViewModel postVM = Mapper.Map<PostDTO, PostViewModel>(postDto);
			return postVM;
		}

		[HttpPost]
		public void CreatePost([FromBody]PostViewModel postViewModel)
		{
            Mapper.Initialize(cfg => cfg.CreateMap<PostViewModel, PostDTO>());
            PostDTO postDto = Mapper.Map<PostViewModel, PostDTO>(postViewModel);
            postService.CreateNew(postDto);
		}

		//[HttpPut]
		//public void EditPost(int id, [FromBody]PostViewModel Post)
		//{
		//	if (id == Post.Id)
		//	{
		//		db.Entry(Post).State = EntityState.Modified;

		//		db.SaveChanges();
		//	}
		//}

		//public void DeletePost(int id)
		//{
		//	PostViewModel Post = db.Posts.Find(id);
		//	if (Post != null)
		//	{
		//		db.Posts.Remove(Post);
		//		db.SaveChanges();
		//	}
		//}
	}
}
