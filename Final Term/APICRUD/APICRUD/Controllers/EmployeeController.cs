using APICRUD.EF;
using APICRUD.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APICRUD.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpGet]
        [Route("api/employees")]
        public HttpResponseMessage AllEmployees() {
            EmpContext db = new EmpContext();
            var data = db.Employees.ToList();
            if (data.Count > 0) {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
           
        }
        [HttpGet]
        [Route("api/employees/{id}")]
        public HttpResponseMessage GetEmployee(int id) {
            EmpContext db = new EmpContext();
            var data = db.Employees.Find(id);
            if(data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "User not found");
        }
        [HttpPost]
        [Route("api/employees/add")]
        public HttpResponseMessage AddEmp(Employee emp) {
            EmpContext db = new EmpContext();
            try
            {
                
                db.Employees.Add(emp);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Inserted");
            }
            catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }  
        }
        [HttpPost]
        [Route("api/employees/update")]
        public HttpResponseMessage EditEmp(Employee emp)
        {
            EmpContext db = new EmpContext();
            var exemp = db.Employees.Find(emp.Id);
            if (exemp != null)
            {
                try
                {
                    db.Entry(exemp).CurrentValues.SetValues(emp);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Updated");

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Employee Not found");
        }
    }
}
