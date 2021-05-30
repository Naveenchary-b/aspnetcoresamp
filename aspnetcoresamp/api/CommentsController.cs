using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetcoresamp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skillbakery.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Skillbakery.api
{
    [Route("api/courses/{courseId}/comments")]
    public class CommentsController : Controller
    {
        private readonly SkillbakeryContext _db;
        public CommentsController(SkillbakeryContext db)
        {
            _db = db;
        }
        // GET: api/<controller>
        [HttpGet]
        public IQueryable<Comments> Get(long courseId)
        {
            return _db.Comments.Where(x => x.Course.CourseId == courseId);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        
        [HttpPost]
        public Comments Post(long courseId, [FromBody]Comments comment)
        {
            var course = _db.Courses1.FirstOrDefault(x => x.CourseId == courseId);
            if (course == null)
                return null;

            comment.CourseId = courseId;
            comment.Author = User.Identity.Name;
            comment.CreatedDate = DateTime.Now;

           _db.Comments.Add(comment);
            _db.SaveChanges();

            return comment;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
