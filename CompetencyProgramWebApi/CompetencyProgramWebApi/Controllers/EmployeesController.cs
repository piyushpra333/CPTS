using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CompetencyProgramWebApi.Controllers
{
    public class EmployeesController : ApiController
    {
        CompetencyTrainingEntities entities = new CompetencyTrainingEntities();

        //Admin :- Display All User Data
        public HttpResponseMessage Get()
        {
            var allemployeee = entities.Employees.Select(x => new { x.EmpID, x.Name, x.UserName, x.DateOfCreation, x.IsActive , x.Role});    
            return Request.CreateResponse(HttpStatusCode.OK, allemployeee);           
        }


        //Admin :- Add new User
        public void Post([FromBody]Employee emp)
        {
            emp.DateOfCreation = DateTime.Today;
            emp.IsActive = true;
            entities.Employees.Add(emp);
            entities.SaveChanges();
        }

        //Admin :- Update User
        public void Put([FromBody]Employee emp)
        {
            entities.Entry(emp).State = EntityState.Modified;
            entities.SaveChanges();
        }


    }
}
