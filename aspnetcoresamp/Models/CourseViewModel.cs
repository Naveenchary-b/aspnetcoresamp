using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Skillbakery.Models
{
    public class CourseViewModel
    {
       
            [Display(Name = "Course Name", Order = 1,
            Prompt = "Enter Course Name", Description = "Course Name")]
            [DataType(DataType.Text)]
            [Required]
            [StringLength(150,MinimumLength=5,ErrorMessage ="Title must be between 5 and 150 characters long")]
            public string Title { get; set; }
            [Required]
            [MinLength(5,ErrorMessage ="Author must be atleast 5 characters long")]
            public string Author { get; set; }
            public DateTime publishedOn { get; set; }

        
        
    }
}
