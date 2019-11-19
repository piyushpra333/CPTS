using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CompetencyProgramWebApi.Models
{
    public class EmployeeDBOperation
    {
        private CompetencyTrainingEntities entities = new CompetencyTrainingEntities();

        public object AllEmployeeData()
        {
            var allemployeee = entities.Employees.Select(x => new { x.EmpID, x.Name, x.UserName, x.Password, x.DateOfCreation, x.IsActive, x.Role });
            return allemployeee;
        }

        public object AllTraineeData()
        {
            var allTrainee = entities.Employees.Where(e => e.Role == "Trainee").Where(e => e.IsActive == true).Select(x => new { x.EmpID, x.Name });
            return allTrainee;
        }

      
        public bool CheckForExistingEmployee(Employee emp)
        {
            var isExist = entities.Employees.Where(e => e.UserName == emp.UserName).Any();
            return isExist;
        }

        public void AddNewEmployee(Employee emp)
        {
            emp.DateOfCreation = DateTime.Today;
            emp.IsActive = true;
            entities.Employees.Add(emp);
            entities.SaveChanges();
        }

        public void UpdateEmployee(Employee emp)
        {
            entities.Entry(emp).State = EntityState.Modified;
            entities.SaveChanges();
        }
    }

}