using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeePayroll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePayRollApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        public readonly IEmployeeRepository employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpPost]
        public IActionResult AddEmployeePayroll(EmployeeModel model)
        {
            EmployeeModel result = this.employeeRepository.AddEmployee(model);
            if (result != null)
            {
                return this.Ok(result);
            }
            else
            {
                return this.BadRequest();
            }
        }
        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            var result = this.employeeRepository.DeleteEmployee(id);
            if (result != null)
            {
                return this.Ok(result);
            }
            else
            {
                return this.BadRequest();
            }
        }
        [HttpPut]
        public IActionResult UpdateEmployee(EmployeeModel model)
        {
            try
            {
                var result=this.employeeRepository.UpdateEmployee(model, model.EmployeeID);
                if (result != null)
                {
                    return this.Ok(result);
                }
                else
                {
                    return this.BadRequest();
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }
        [HttpGet]
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            return this.employeeRepository.GetAllEmployeeDetails();
        }
    }
}
