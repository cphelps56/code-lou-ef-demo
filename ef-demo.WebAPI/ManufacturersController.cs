using ef_demo.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ef_demo.WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        
        // GET: api/<ManufacturersController>
        [HttpGet]
        public IEnumerable<Manufacturer> Get()
        {
            var context = new VendingMachineContext();
            return context.Manufacturers;
        }

        // GET api/<ManufacturersController>/5
        [HttpGet("{id}")]
        public ActionResult<Manufacturer> Get(int id)
        {
            var context = new VendingMachineContext();
            return context.Manufacturers.FirstOrDefault(x=> x.Id == id) ?? new Manufacturer();
        }

        // POST api/<ManufacturersController>
        [HttpPost]
        public void Post([FromBody] Manufacturer value)
        {
            var context = new VendingMachineContext();
            context.Manufacturers.Add(value);
            context.SaveChanges();
        }

        // PUT api/<ManufacturersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Manufacturer value)
        {
            var context = new VendingMachineContext();
            var selectedManufacturer = context.Manufacturers.FirstOrDefault(x=> x.Id == id);

            if (selectedManufacturer != null)
            {
                selectedManufacturer.Name = value.Name;
                context.SaveChanges();
                return Ok();
            }
            else
                return NoContent();
        }

        // DELETE api/<ManufacturersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var context = new VendingMachineContext();
            var selectedManufacturer = context.Manufacturers.FirstOrDefault(x => x.Id == id);
            if (selectedManufacturer != null)
            {
                context.Manufacturers.Remove(selectedManufacturer);
                context.SaveChanges();
                return Ok();
            }
            else
                return NoContent();
        }
    }
}
