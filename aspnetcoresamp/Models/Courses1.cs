using System;
using System.Collections.Generic;

namespace aspnetcoresamp.Models
{
    public partial class Courses1
    {
        public Courses1()
        {
            Comments = new HashSet<Comments>();
        }

        public long CourseId { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public DateTime Publishedon { get; set; }

        public ICollection<Comments> Comments { get; set; }
    }
}
