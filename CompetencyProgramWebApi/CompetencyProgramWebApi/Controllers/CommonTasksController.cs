using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CompetencyProgramWebApi.Controllers
{
    public class CommonTasksController : ApiController
    {
        CompetencyTrainingEntities entities = new CompetencyTrainingEntities();
        public HttpResponseMessage Post([FromBody]Employee emp)
        {
            var temp = entities.Employees.Where(e => e.UserName == emp.UserName).Where(e => e.Password == emp.Password).Where(e => e.IsActive == true);
            bool logincheck = temp.Any();
            if(logincheck)
            {
                var currentUser = temp.Select(x => new { x.EmpID, x.Role });
                string userrole = temp.Select(e => e.Role).FirstOrDefault();
                if(userrole.Equals("Trainee"))
                {
                    var statuscheck = entities.Trainings.Where(t => t.Status == "Active").Any();
                    if(statuscheck)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, currentUser);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.Forbidden);
                    }
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, currentUser);
                }
                
               
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
    }
}
