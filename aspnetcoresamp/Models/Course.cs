using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Skillbakery.Models
{
    public class Course
    {
        
        public string Title { get; set; }
        public DateTime publishedOn { get; set; }
        
    }

    public class CourseDC
    {
        public Course getTopCourse()
        {
            var course = new Course
            {
                Title = "Learning ASP.Net Core",
                publishedOn = DateTime.Now
            };
            return course;
        }
    }
    
}
