using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CompetencyProgramWebApi.Controllers
{
    public class AnswersController : ApiController
    {

        CompetencyTrainingEntities entities = new CompetencyTrainingEntities();

        //Admin :- Display All Answers of All Trainees 
        public HttpResponseMessage Get()
        {
            var allanswers = entities.Answers.Where(a => a.Employee.IsActive == true).Select(a => new { a.Employee_EmpID, a.Employee.Name,  a.Question.Training.TrainingName, a.Question.QueDescription, a.AnsDescription, a.Score});
            return Request.CreateResponse(HttpStatusCode.OK, allanswers);
        }


        public void Post([FromBody]Employee emp)
        {

        }


        public void Put([FromBody]Employee emp)
        {

        }
    }
}
