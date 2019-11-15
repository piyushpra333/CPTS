using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CompetencyProgramWebApi.Controllers
{
    public class TrainingsController : ApiController
    {
        CompetencyTrainingEntities entities = new CompetencyTrainingEntities();

        //Admin :- Display All Training 
        public HttpResponseMessage Get()
        {
            var alltraining = entities.Trainings.Select(t => new { t.TrainingID, t.TrainingName, t.Employee_EmpID, t.Employee.Name, t.Discription, t.DateOfTraining, t.Status });
            return Request.CreateResponse(HttpStatusCode.OK, alltraining);
        }

        //Trainer :- Data Of Current Training
        public HttpResponseMessage Get(int id)
        {
            var alltraining = entities.Trainings.Where(t => t.TrainingID == id).Select(t => new { t.TrainingID, t.TrainingName, t.Employee_EmpID, t.Employee.Name, t.Discription, t.DateOfTraining, t.Status });
            return Request.CreateResponse(HttpStatusCode.OK, alltraining);
            
        }

        //Admin :- Add new Training
        public void Post([FromBody]Training train)
        {
            train.Status = "Active";
            entities.Trainings.Add(train);
            entities.SaveChanges();
        }



        //Trainer :- End Training
        public void Put([FromBody]Training train)
        {
            train.Status = "DeActive";
            entities.Entry(train).State = EntityState.Modified;
            entities.SaveChanges();
        }
    }
}
