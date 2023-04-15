using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APIAppLayer.Controllers
{
    [EnableCors("*","*","*")]
    public class EmployeeController : ApiController
    {
        [HttpGet]
        [Route("api/employees")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = EmployeeService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,ex.Message);
                
            }
        }
        [HttpPost]
        [Route("api/employees/insert")]
        public HttpResponseMessage Add(EmployeeDTO data)
        {
            try
            {
                var res = EmployeeService.Insert(data);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
