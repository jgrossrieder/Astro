using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Astro.Common.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Astro.Retrievers.Common;

namespace Astro.Clients.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Horoscopes")]
    public class HoroscopesController : Controller
    {
	    private readonly IAstroRepository _repository;

	    public HoroscopesController(IAstroRepository repository)
	    {
		    _repository = repository;
	    }


		// GET: api/Horoscopes
		[HttpGet]
        public async Task<IEnumerable<Horoscope>>  Get()
		{
			return (await _repository.GetHoroscopes(DateTime.Today)).Horoscopes;

		}
		/*
        // GET: api/Horoscopes/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Horoscopes
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Horoscopes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
