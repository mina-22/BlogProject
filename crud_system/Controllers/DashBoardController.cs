using crud_system.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace crud_system.Controllers
{
    public class DashBoardController : Controller
    {
        private static List<Blog> blogs = new List<Blog>();
        private static int MaxId=0; 
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewBlog()
        {
            return View(blogs);
        }
        public IActionResult Delete(int id)
        {     
            blogs.RemoveAll(item  => item.Id == id);
            return RedirectToAction("ViewBlog");
        }
        

        public IActionResult AddBlog(int id=0)
        {
            // if you Add new item id will be 0 else you update item and pass id in parametar
            Blog blog;
            if (id == 0)
            {
                //so we create new address in memory for new item
                blog = new Blog();
            }
            else
            {
                 // so we take same address in the list and bass it to form 
                blog = blogs.Find(item => item.Id == id);
            }
           
          // blog you passed
            return View(blog);
        }

        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {

            if (blog.Id == 0)
            {
                blog.Id = ++MaxId;
                blogs.Add(blog);
            }
            else
            {
              Blog NewBlog =  blogs.Find(item => item.Id == blog.Id);
                NewBlog.Name= blog.Name;
                NewBlog.Discription = blog.Discription;
                NewBlog.Enable = blog.Enable;
                NewBlog.type.Id= blog.type.Id;

            }
            
            return RedirectToAction("ViewBlog");
        }


    }
}
