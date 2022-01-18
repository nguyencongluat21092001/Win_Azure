using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebApplicationAPI.Models;

namespace WebApplicationAPI.Controllers
{
    public class StudentAPIController : ApiController
    {
        private sem32009eEntities dbContext = new sem32009eEntities();
        [HttpGet]
        public JsonResult<List<student>> GetStudents()
        {
            List<student> list = new List<student>();
            foreach(student item in dbContext.students)
            {
                list.Add(item);
            }
            return Json<List<student>>(list);
        }
        [HttpGet]
        public JsonResult<student> GetStudentById(int id)
        {
            return Json<student> ( dbContext.students.Find(id) );           
        }
        [HttpPost]
        public bool PostStudent(student stu)
        {
            dbContext.students.Add(stu);
            return (dbContext.SaveChanges() > 0);
        }
    }
}
