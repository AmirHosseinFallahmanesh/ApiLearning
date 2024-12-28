using Demo1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public async Task<IActionResult> GetAll()
        {
            ApiResponse<IEnumerable<Employee>> response = new ApiResponse<IEnumerable<Employee>>();
            
            try
            {
                response.Data= await employeeRepository.GetAllEmployeesAsync();
                response.Code = 200;
                return Ok(response);
                
            }
            catch (Exception ex)
            {
                ApiError apiError = new ApiError()
                {
                    Code = "5x",
                    Message = ex.Message
                };
                response.Errors.Add(apiError);
                return BadRequest(response);
            }


          
        }


        [HttpGet("{id}")]
        public async Task<Employee> Get(int id)
        {
            return await employeeRepository.GetEmployeeByIdAsync(id);
        }

    }
}
