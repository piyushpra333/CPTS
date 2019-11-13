﻿using System;
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

        //Trainer :- Display All Question which are added in current Training.
        public HttpResponseMessage Get(int id)
        {
            var currentquestions = entities.Questions.Where(q => q.Training_TrainingID == id).Select(q => new { q.QuestionID, q.QueDescription, q.Duration });
            return Request.CreateResponse(HttpStatusCode.OK, currentquestions);
        }

        //Trainer :- Add Questions.
        public void Post([FromBody]Question que)
        {
            entities.Questions.Add(que);
            entities.SaveChanges();
        }


        public void Put([FromBody]Employee emp)
        {
            
        }
    }
}
