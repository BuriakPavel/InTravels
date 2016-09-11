using AutoMapper;
using InTravels.BLL.DTO;
using InTravels.BLL.Infrastructure;
using InTravels.BLL.Interfaces;
using InTravels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InTravels.Controllers
{
    public class HomeController : Controller
    {
        IPostService postService;

        public HomeController(IPostService serv)
        {
            postService = serv;
        }
         
        public ActionResult Index()
        {
            var posts = postService.GetAllPosts();
            Mapper.Initialize(cfg => cfg.CreateMap<PostDTO, PostViewModel>());
            return View(Mapper.Map<IEnumerable<PostDTO>, List<PostViewModel>>(posts));
        }

        [HttpPost]
        public ActionResult CreateNewPost(PostViewModel post)
        {
            try
            {
                Mapper.Initialize(c => c.CreateMap<PostViewModel, PostDTO>());
                PostDTO postDTO = Mapper.Map<PostViewModel, PostDTO>(post);
                postService.CreateNew(postDTO);
            }
            catch (ValidationException exp)
            {
                ModelState.AddModelError(exp.Property, exp.Message);
            }

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Site's description";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contacts";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            postService.Dispose();
            base.Dispose(disposing);
        }
    }
}