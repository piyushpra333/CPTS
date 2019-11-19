using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CompetencyTrainingWebAPi.Models
{
    public class TrainingDBOperation
    {
        private CompetencyTrainingEntities entities = new CompetencyTrainingEntities();

        public object AllTrainings()
        {
            var alltraining = entities.Trainings.Select(t => new { t.TrainingID, t.TrainingName, t.Employee_EmpID, t.Employee.Name, t.Discription, t.DateOfTraining, t.Status });
            return alltraining;
        }

        public object CurrentTraining(int id)
        {
            var currenttraining = entities.Trainings.Where(t => t.TrainingID == id).Select(t => new { t.TrainingID, t.TrainingName, t.Employee_EmpID, t.Employee.Name, t.Discription, t.DateOfTraining, t.Status });
            return currenttraining;
        }

        public void AddNewTraining(Training train)
        {
            train.Status = "Active";
            entities.Trainings.Add(train);
            entities.SaveChanges();
        }

        public void EndTraining(Training train)
        {
            train.Status = "DeActive";
            entities.Entry(train).State = EntityState.Modified;
            entities.SaveChanges();
        }
    }
}