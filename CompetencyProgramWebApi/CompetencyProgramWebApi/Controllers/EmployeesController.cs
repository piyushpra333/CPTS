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

        //Trainer :- Display all Trainees with id and name for perticular Question


        [Route("api/Employees/GetTrainees")]
        public HttpResponseMessage GetTrainees()
        {
            var allTrainee = entities.Employees.Where(e => e.Role ==  "Trainee").Where(e => e.IsActive == true).Select(x => new { x.EmpID, x.Name });
            return Request.CreateResponse(HttpStatusCode.OK, allTrainee);
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
