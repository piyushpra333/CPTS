using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompetencyTrainingWebAPi.Models
{
    public class CommonDBOperation
    {
        private CompetencyTrainingEntities entities = new CompetencyTrainingEntities();

        public object TotalScore()
        {
            var totalmarks = entities.Answers.GroupBy(a => new { a.Question.Training_TrainingID, a.Question.Training.TrainingName, a.Employee_EmpID, a.Employee.Name }).Select(s => new
            {
                TrainingID = s.Key.Training_TrainingID,
                Name = s.Key.TrainingName,
                EmpID = s.Key.Employee_EmpID,
                EmpName = s.Key.Name,
                Marks = s.Sum(a => a.Score)
            }).OrderBy(o => o.TrainingID).ThenByDescending(o => o.Marks);

            return totalmarks;
        }
    }
}