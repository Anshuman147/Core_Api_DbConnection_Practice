using Core_Api_DbConnection_Practice.DbConnection;
using Core_Api_DbConnection_Practice.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Core_Api_DbConnection_Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
       private EmployeeDbContext context;
        public EmployeeController(EmployeeDbContext _Context)
        {
            context = _Context;   
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return context.employees;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return context.employees.FirstOrDefault(e => e.ID == id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] Employee emp)
        {
            context.employees.Add(emp);
            context.SaveChanges();
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee emp)
        {
            var data=context.employees.FirstOrDefault(e=>e.ID== id);
            if(data!=null)
            {
                data.Salary = emp.Salary;
                data.Name = emp.Name;
                context.SaveChanges();
            }
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var data= context.employees.FirstOrDefault(e=>e.ID== id);
            context.employees.Remove(data);
            context.SaveChanges();
        }
    }
}
