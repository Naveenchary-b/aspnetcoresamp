using Microsoft.AspNetCore.Mvc;
using Skillbakery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skillbakery.ViewComponents
{
    //[ViewComponent]
    public class UpcomingEventsViewComponent : ViewComponent 
    {
        private readonly CourseDC _courses;
        public UpcomingEventsViewComponent(CourseDC courses)
        {
            _courses = courses;
        }
        public IViewComponentResult Invoke()
        {

            var course = _courses.getTopCourse();
            return View(course);

            //return View();
        }
    }
}
