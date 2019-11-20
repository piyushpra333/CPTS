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

        public object GetTotalMarks(int id)
        {
            var totalscore = entities.Answers.GroupBy(a => new { a.Question.Training_TrainingID, a.Question.Training.TrainingName, a.Employee_EmpID, a.Employee.Name }).Select(s => new
            {
                TrainingID = s.Key.Training_TrainingID,
                Name = s.Key.TrainingName,
                EmpID = s.Key.Employee_EmpID,
                EmpName = s.Key.Name,
                Marks = s.Sum(a => a.Score)
            }).Where(x=>x.TrainingID == id).OrderBy(o => o.TrainingID).ThenByDescending(o => o.Marks);

            return totalscore;
        }


        public object GetTraineeAnswer(int queid,int empid)
        {
            var getans = entities.Answers.Where(a => a.Question_QuestionID == queid).Where(a => a.Employee_EmpID == empid).Select(s=>new { s.AnswerID,s.AnsDescription,s.Score,s.Employee_EmpID,s.Question_QuestionID});
            return getans;
        }
    }
}