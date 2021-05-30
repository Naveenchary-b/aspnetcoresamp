using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skillbakery.Models;
using aspnetcoresamp.Models;
using Microsoft.AspNetCore.Authorization;

namespace Skillbakery.Controllers
{
    public class HomeController : Controller
    {
        private readonly SkillbakeryContext _db;
        public HomeController(SkillbakeryContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "pass";
            var firstcourses = _db.Courses1.Take(1).FirstOrDefault();
            var course = new Course();
            course.Title = firstcourses.Title;
            _db.Entry(firstcourses).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            var courses = _db.Courses1.ToList();
            courses.Select(c => { c.Author = "naveen studios"; return c; }).ToList();
            return View(course);
            //return  new ContentResult { Content = "ASp" };
        }
        public IActionResult About()
        {
            return View();
            //return  new ContentResult { Content = "ASp" };
        }
        [Authorize]
        [Route("course/{title}/{id:int}")]
        public IActionResult Courses(string title,int id=0)
        {
            //if(id==null)
            //{
            //    return new ContentResult { Content = "gnull -"};
            //}
            //return View();
            return new ContentResult { Content = "ASp -" + id+"titele"+title};
        }
        public IActionResult Course()
        {

            var course = new CourseViewModel();
            
            return View(course);
            //return  new ContentResult { Content = "ASp" };
        }
     
        public IActionResult Course1(Course model)
        {
            model.publishedOn = DateTime.Now;
            

            return View(model);
            //return  new ContentResult { Content = "ASp" };
        }
        [Authorize]
        [HttpPost]
        public IActionResult Course(CourseViewModel model)
        {
            if(ModelState.IsValid)
            {
                model.publishedOn = DateTime.Now;
                var course = new Courses1();
                course.Author = model.Author;
                course.Title = model.Title;
                course.Publishedon = model.publishedOn;
                _db.Courses1.Add(course);
                _db.SaveChanges();
                return View(model);
            }


            return View();
            //return  new ContentResult { Content = "ASp" };
        }

        public IActionResult SingleFeature()
        {
            var firstcourses = _db.Courses1.Take(1).FirstOrDefault();
            var course = new Course();
            course.Title = firstcourses.Title;
            if(firstcourses.Publishedon==DateTime.MinValue)
            {
                course.publishedOn = firstcourses.Publishedon;

            }
            return PartialView("_SingleFeature", course);
        }
    }
}
