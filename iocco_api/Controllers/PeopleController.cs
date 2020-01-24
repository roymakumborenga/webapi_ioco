using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using iocco_api.BusinessLayer;
using iocco_api.DataLayer;
namespace iocco_api.Controllers
{   [AllowAnonymous]
    [RoutePrefix("api/People")]
    public class PeopleController : ApiController
    {
        private IBaseRepository<DataLayer.Person> _repository;

        public PeopleController(IBaseRepository<Person> repository)
        {
            _repository = repository;
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            return Ok(_repository.GetById(id));
        }
        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                _repository.Insert(person);
                return Ok();
            }
            catch (Exception ex) { } //log errors
            return BadRequest();
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                _repository.Update(person);
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