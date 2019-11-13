using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CompetencyProgramWebApi.Controllers
{
    public class QuestionsController : ApiController
    {
        CompetencyTrainingEntities entities = new CompetencyTrainingEntities();

        //Admin :- Display All Question of All Trainings 
        public HttpResponseMessage Get()
        {
            var allquestion = entities.Questions.Select(q => new { q.Training_TrainingID, q.Training.TrainingName, q.Training.Employee_EmpID, q.Training.Employee.Name, q.QuestionID, q.QueDescription });
            return Request.CreateResponse(HttpStatusCode.OK, allquestion);
        }


        public void Post([FromBody]Employee emp)
        {
        }


        public void Put([FromBody]Employee emp)
        {
            
        }
    }
}
