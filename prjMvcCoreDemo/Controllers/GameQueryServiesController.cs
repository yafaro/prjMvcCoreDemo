using Microsoft.AspNetCore.Mvc;
using prjMvcCoreDemo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace prjMvcCoreDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameQueryServiesController : ControllerBase
    {
        // GET: api/<GameQueryServiesController>
        [HttpGet]
        public IEnumerable<TProduct> Get()
        {
            var datas = from p in (new dbDemoContext()).TProducts
                        select p;
            return datas;
        }

        // GET api/<GameQueryServiesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GameQueryServiesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GameQueryServiesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GameQueryServiesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
