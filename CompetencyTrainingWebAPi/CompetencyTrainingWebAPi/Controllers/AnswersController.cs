using CompetencyTrainingWebAPi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CompetencyTrainingWebAPi.Controllers
{
    public class AnswersController : ApiController
    {
        CompetencyTrainingEntities entities = new CompetencyTrainingEntities();
        private readonly AnswerDBOperation _dbans;

        public AnswersController()
        {
            _dbans = new AnswerDBOperation();
        }

        //Admin :- Display All Answers of All Trainees 
        public HttpResponseMessage Get()
        {
            var allanswers = _dbans.AllAnswers();
            return Request.CreateResponse(HttpStatusCode.OK, allanswers);
        }


        public void Post([FromBody]Answer ans)
        {
            _dbans.AddAnswer(ans);
        }


        public void Put([FromBody]Answer ans)
        {
            _dbans.UpdateScore(ans);
        }
    }
}
