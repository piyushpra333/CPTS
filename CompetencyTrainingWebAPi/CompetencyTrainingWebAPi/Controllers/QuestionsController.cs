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


        //Trainer :- Display Selected Question
        [Route("api/Questions/GetQue/{id}")]
        public HttpResponseMessage GetQue(int id)
        {
            var selectque = _dbque.DisplaySelectedQue(id);
            return Request.CreateResponse(HttpStatusCode.OK, selectque);

        }


        //Trainee :- Display Active Question
        [Route("api/Questions/GetActiveque")]
        public HttpResponseMessage GetActiveQue()
        {
            bool isActive = _dbque.CheckForActiveQue();

            if(isActive)
            {
                var activeque = _dbque.GetActiveQue();
                return Request.CreateResponse(HttpStatusCode.OK, activeque);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            

        }


        //Trainer :- Add Questions.
        public HttpResponseMessage Post([FromBody]Question que)
        {
            bool isExist = _dbque.CheckForExistingQuestion(que);

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


        //Trainer :- Update Question status(Make it active and deactive).
        public void Put([FromBody]Question que)
        {
            _dbque.UpdateQuestionStatus(que);
        }
    }
}
