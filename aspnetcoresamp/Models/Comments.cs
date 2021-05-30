using System;
using System.Collections.Generic;

namespace aspnetcoresamp.Models
{
    public partial class Comments
    {
        public long Id { get; set; }
        public string Comment { get; set; }
        public long? CourseId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Author { get; set; }

        public Courses1 Course { get; set; }
    }
}
