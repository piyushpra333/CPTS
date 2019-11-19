using CompetencyTrainingWebAPi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CompetencyTrainingWebAPi.Controllers
{
    public class TrainingsController : ApiController
    {
        private readonly TrainingDBOperation _dbtrain;

        public TrainingsController()
        {
            _dbtrain = new TrainingDBOperation();
        }

        //Admin :- Display All Training 
        public HttpResponseMessage Get()
        {
            var alltraining = _dbtrain.AllTrainings();
            return Request.CreateResponse(HttpStatusCode.OK, alltraining);
        }

        //Trainer :- Display Current Training
        public HttpResponseMessage Get(int id)
        {
            var alltraining = _dbtrain.CurrentTraining(id);
            return Request.CreateResponse(HttpStatusCode.OK, alltraining);

        }

        //Admin :- Add new Training
        public void Post([FromBody]Training train)
        {
            _dbtrain.AddNewTraining(train);
        }

        //Trainer :- End Training
        public void Put([FromBody]Training train)
        {
            _dbtrain.EndTraining(train);
        }
    }
}
