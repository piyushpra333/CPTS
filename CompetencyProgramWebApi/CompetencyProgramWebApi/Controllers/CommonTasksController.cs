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
        public void Post([FromBody]Employee emp)
        {
            bool logincheck = entities.Employees.Where(e => e.UserName == emp.UserName).Where(e => e.Password == emp.Password).Any();
            if(logincheck)
            {
                Console.WriteLine("Login");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
