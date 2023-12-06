using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using silentAPI.Models;

namespace silentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        AppDbContext _db;
        public EmployeeController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = _db.Employees.ToList();
            return Ok(employees);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employee))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Please correct Employee id");

            Employee emp = _db.Employees.Find(id);
            if (emp != null)
            {
                return Ok(emp);
            }

            return NotFound($"{id} Employee does not exiata");
        }



        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Employee))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost]
        public IActionResult Create(EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Employee emp = new Employee()
                    {
                        Name = employee.Name,
                        Gender = employee.Gender,
                        Mobile = employee.Mobile,
                        Address = employee.Address,
                        PanNumber = employee.PanNumber,
                        AdharNumber = employee.AdharNumber,
                        Email = employee.Email,
                        CurrentDate = employee.CurrentDate
                    };
                    _db.Employees.Add(emp);
                    _db.SaveChanges();

                    return Created("Create" , emp);
                }
                catch (Exception ex)
                {

                    return StatusCode(StatusCodes.Status500InternalServerError , ex.Message);
                }

            }
            return BadRequest("Please Check Input Data");
            
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employee))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPut]
        public IActionResult Update(int id, EmployeeModel employee)
        {
            if (id != employee.Id)
                return BadRequest("Please correct Category Id");

            if (ModelState.IsValid)
            {
                try
                {
                    Employee emp = new Employee()
                    {
                        Id=employee.Id,
                        Name = employee.Name,
                        Gender = employee.Gender,
                        Mobile = employee.Mobile,
                        Address = employee.Address,
                        PanNumber = employee.PanNumber,
                        AdharNumber = employee.AdharNumber,
                        Email = employee.Email,
                        CurrentDate = employee.CurrentDate
                    };
                    _db.Employees.Update(emp);
                    _db.SaveChanges();

                    return Ok(emp);
                }
                catch (Exception ex)
                {

                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }

            }
            return BadRequest("Please Check Input Data");

        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employee))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Please correct Category Id");

            if (ModelState.IsValid)
            {
                try
                {
                   Employee emp =  _db.Employees.Find(id);
                    _db.Employees.Remove(emp);
                    _db.SaveChanges();

                    return Ok(emp);
                }
                catch (Exception ex)
                {

                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }

            }
            return BadRequest("Please Check Input Data");

        }




    }
}
