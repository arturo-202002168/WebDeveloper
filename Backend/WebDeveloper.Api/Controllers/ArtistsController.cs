using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebDeveloper.Core.Entities;
using WebDeveloper.Core.Interfaces;
using WebDeveloper.Infra.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebDeveloper.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("All")]
    public class ArtistsController : Controller
    {
        private readonly IChinookContext _context;
        public ArtistsController(IChinookContext context)
        {
            _context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult<int> Post([FromBody]Artist artist)
        {
            if (string.IsNullOrEmpty(artist.Name)){
                return BadRequest("Nombre no especificado");
            }
            _context.Artists.Add(artist);
            _context.SaveChanges();
            return Ok(artist.ArtistId);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
