using aspnetcoresamp.Models;
using System;
using System.Collections.Generic;

namespace Skillbakery.Models
{
    public partial class Courses
    {
        public Courses()
        {
            Comments = new HashSet<Comments>();
        }

        public long CourseId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime? PublishedOn { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }
    }
}
