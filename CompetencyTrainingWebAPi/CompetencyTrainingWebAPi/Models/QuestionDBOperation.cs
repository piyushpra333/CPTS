﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CompetencyTrainingWebAPi.Models
{
    public class QuestionDBOperation
    {
        private CompetencyTrainingEntities entities = new CompetencyTrainingEntities();

        public object AllQuestions()
        {
            var allquestion = entities.Questions.Select(q => new { q.Training_TrainingID, q.Training.TrainingName, q.Training.Employee_EmpID, q.Training.Employee.Name, q.QuestionID, q.QueDescription });
            return allquestion;
        }

        public object CurrentTrainingQuestions(int id)
        {
            var currentquestions = entities.Questions.Where(q => q.Training_TrainingID == id).Select(q => new { q.QuestionID, q.QueDescription, q.Duration });
            return currentquestions;
        }

        public bool CheckForExistingQuestion(Question que)
        {
            var isExist = entities.Questions.Where(e => e.Training_TrainingID == que.Training_TrainingID).Where(e => e.QueDescription == que.QueDescription).Any();
            return isExist;
        }

        public void AddNewQuestion(Question que)
        {
            
            entities.Questions.Add(que);
            entities.SaveChanges();
        }

        public object DisplaySelectedQue(int id)
        {
            var selectque = entities.Questions.Where(q => q.QuestionID == id).Select(q => new { q.QuestionID, q.QueDescription, q.Duration }).FirstOrDefault();
            return selectque;
        }

        public bool CheckForActiveQue()
        {
            bool isActive = entities.Questions.Where(q => q.IsActiveQue == true).Any();
            return isActive;
        }

        public object GetActiveQue()
        {
            var activeque = entities.Questions.Where(q => q.IsActiveQue == true).Select(q => new { q.QuestionID, q.QueDescription, q.Duration }).FirstOrDefault();
            return activeque;
        }

        public void UpdateQuestionStatus(Question que)
        {
            entities.Entry(que).State = EntityState.Modified;
            entities.SaveChanges();
        }

    }
}