using CompetencyProgramWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CompetencyProgramWebApi.Controllers
{
    public class EmployeesController : ApiController
    {

        private readonly EmployeeDBOperation _empdb;

        public EmployeesController()
        {
            _empdb = new EmployeeDBOperation();
        }

        //Admin :- Display All Employee Data
        public HttpResponseMessage Get()
        {
            var allemployeee = _empdb.AllEmployeeData();  
            return Request.CreateResponse(HttpStatusCode.OK, allemployeee);           
        }


        //Trainer :- Display all Trainees with id and name for perticular Question
        [Route("api/Employees/GetTrainees")]
        public HttpResponseMessage GetTrainees()
        {
            var allTrainee = _empdb.AllTraineeData();
            return Request.CreateResponse(HttpStatusCode.OK, allTrainee);
        }


        //Admin :- Add new Employee
        public HttpResponseMessage Post([FromBody]Employee emp)
        {
            var isExist = _empdb.CheckForExistingEmployee(emp);

            if (isExist)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                _empdb.AddNewEmployee(emp);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
        }


        //Admin :- Update User
        public void Put([FromBody]Employee emp)
        {
            _empdb.UpdateEmployee(emp);
        }


    }
}
