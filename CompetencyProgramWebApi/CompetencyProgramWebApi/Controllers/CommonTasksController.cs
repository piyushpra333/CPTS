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
            if (logincheck)
            {
                var currentUser = temp.Select(x => new { x.EmpID, x.Role });
                string userrole = temp.Select(e => e.Role).FirstOrDefault();
                if (userrole.Equals("Trainee"))
                {
                    var statuscheck = entities.Trainings.Where(t => t.Status == "Active").Any();
                    if (statuscheck)
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

        //select t.TrainingID,a.Employee_EmpID,SUM(a.Score) from Trainings t left outer join Questions q on t.TrainingID = q.Training_TrainingID
        // left outer join Answers a on q.QuestionID = a.Question_QuestionID group by t.TrainingID, a.Employee_EmpID order by t.TrainingID


        //select t.TrainingID,q.QuestionID,a.Employee_EmpID,a.Score from Trainings t left outer join Questions q on t.TrainingID = q.Training_TrainingID
        //left outer join Answers a on q.QuestionID = a.Question_QuestionID

        //public HttpResponseMessage Get()
        //{
        //    var highmarks = entities.Answers.Select(a => new { a.Question.Training_TrainingID, a.Question_QuestionID, a.Employee_EmpID, a.Score }).GroupBy(a => a.Training_TrainingID, a => a.Employee_EmpID);
  
        //    return Request.CreateResponse(HttpStatusCode.OK, highmarks);
        //}

    }
}
