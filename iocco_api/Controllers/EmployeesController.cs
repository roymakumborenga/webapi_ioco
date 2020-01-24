using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using iocco_api.BusinessLayer;
using iocco_api.DataLayer;
namespace iocco_api.Controllers
{
    public class EmployeesController : ApiController
    {
        private IBaseRepository<DataLayer.Employee> _repository;

        public EmployeesController(IBaseRepository<Employee> repository)
        {
            _repository = repository;
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            return Ok(_repository.GetById(id));
        }
        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                _repository.Insert(employee);
                return Ok();
            }
            catch (Exception ex) { } //log errors
            return BadRequest();
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                _repository.Update(employee);
                return Ok();
            }
            catch (Exception ex) { } //log errors
            //probably id non existent
            return BadRequest();
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                return Ok();
            }
            catch (Exception ex) { } //log errors
            //probably id non existent
            return BadRequest();
        }
    }
}