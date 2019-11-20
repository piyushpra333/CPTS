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


        //Admin :- Add Answer
        public void Post([FromBody]Answer ans)
        {
            _dbans.AddAnswer(ans);
        }


        //Admin :- Update Score
        public void Put([FromBody]Answer ans)
        {
            _dbans.UpdateScore(ans);
        }

        ////Trainer and Trainee :- Total Marks Trainee get in Perticular Training
        [Route("api/Answers/GetMarks/{id}")]
        public HttpResponseMessage GetTotalScore(int id)
        {
            var totalscore = _dbans.GetTotalMarks(id);
            return Request.CreateResponse(HttpStatusCode.OK, totalscore);
        }


        [Route("api/Answers/GetAns/{queid}/{empid}")]
        public HttpResponseMessage GetTraineeAns(int queid ,int empid)
        {
            var getans = _dbans.GetTraineeAnswer(queid,empid);
            return Request.CreateResponse(HttpStatusCode.OK, getans);
        }

    }
}
