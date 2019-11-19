using CompetencyTrainingWebAPi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CompetencyTrainingWebAPi.Controllers
{
    public class QuestionsController : ApiController
    {
        private readonly QuestionDBOperation _dbque;

        public QuestionsController()
        {
            _dbque = new QuestionDBOperation();
        }

        //Admin :- Display All Question of All Trainings 
        public HttpResponseMessage Get()
        {
            var allquestion = _dbque.AllQuestions();
            return Request.CreateResponse(HttpStatusCode.OK, allquestion);
        }


        //Trainer :- Display All Question which are added in current Training.
        public HttpResponseMessage Get(int id)
        {
            var currentquestions = _dbque.CurrentTrainingQuestions(id);
            return Request.CreateResponse(HttpStatusCode.OK, currentquestions);
        }


        //Trainer :- Display Active Question
        [Route("api/Questions/GetQue/{id}")]
        public HttpResponseMessage GetQue(int id)
        {
            var activeque = _dbque.DisplayActiveQue(id);
            return Request.CreateResponse(HttpStatusCode.OK, activeque);

        }

        //Trainer :- Add Questions.
        public HttpResponseMessage Post([FromBody]Question que)
        {
            var isExist = _dbque.CheckForExistingQuestion(que);

            if (isExist)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                _dbque.AddNewQuestion(que);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
        }


        //Trainer :- Update Question status.
        public void Put([FromBody]Question que)
        {
            _dbque.UpdateQuestionStatus(que);
        }
    }
}
