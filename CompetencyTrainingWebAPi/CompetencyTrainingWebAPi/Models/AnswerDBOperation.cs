using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CompetencyTrainingWebAPi.Models
{
    public class AnswerDBOperation
    {
        private CompetencyTrainingEntities entities = new CompetencyTrainingEntities();

        public object AllAnswers()
        {
            var allanswers = entities.Answers.Where(a => a.Employee.IsActive == true).Select(a => new { a.Employee_EmpID, a.Employee.Name, a.Question.Training.TrainingName, a.Question.QueDescription, a.AnsDescription, a.Score });
            return allanswers;
        }


        public void AddAnswer(Answer ans)
        {
            ans.Score = 0;
            entities.Answers.Add(ans);
            entities.SaveChanges();
        }

        public void UpdateScore(Answer ans)
        {
            //var tmp = entities.Answers.Where(a => a.Employee_EmpID == ans.Employee_EmpID).Where(a => a.Question_QuestionID == ans.Question_QuestionID).FirstOrDefault();
            //tmp.Score = ans.Score;
            //ans = tmp;
            entities.Entry(ans).State = EntityState.Modified;
            entities.SaveChanges();
        }
    }
}