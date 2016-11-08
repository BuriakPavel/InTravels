using AutoMapper;
using InTravels.BLL.DTO;
using InTravels.BLL.Interfaces;
using InTravels.WebAPI.Controllers;
using InTravels.WebAPI.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace InTravels.ControllersApi
{
    [RoutePrefix("api/Posts")]
    public class PostApiController : BaseApiController
    {
		IPostService postService;
		public PostApiController()
		{ }

		public PostApiController(IPostService serv)
		{
			postService = serv;
		}
        /// <summary>
        /// Get all posts
        /// </summary>
        /// <returns></returns>
		public IEnumerable<PostViewModel> GetPosts()
		{
			var posts = postService.GetAllPosts();
			Mapper.Initialize(cfg => cfg.CreateMap<PostDTO, PostViewModel>());
			var postViewModels = Mapper.Map<IEnumerable<PostDTO>, List<PostViewModel>>(posts);

            // TODO: remove this test functionality
            //string json = File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath(@"~/App_Data/posts.json"));
            //var postViewModels = JsonConvert.DeserializeObject<List<PostViewModel>>(json);
            // ---------------
            return postViewModels;
		}

        /// <summary>
        /// Get post by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = false)]
        public PostViewModel GetPost(int id)
		{
			PostDTO postDto = postService.GetPostById(id);
			Mapper.Initialize(cfg => cfg.CreateMap<PostDTO, PostViewModel>());
			PostViewModel postVM = Mapper.Map<PostDTO, PostViewModel>(postDto);
			return postVM;
		}

		[HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
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
