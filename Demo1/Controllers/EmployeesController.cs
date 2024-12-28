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

        [HttpGet]
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
        public async Task<IActionResult> Get(int id)
        {
            
                ApiResponse<Employee> response = new ApiResponse<Employee>();

                try
                {
                if (id==0)
                {
                    throw new ArgumentException("id not valid");
                }
                    response.Data = await employeeRepository.GetEmployeeByIdAsync(id);
                    response.Code = 200;
                    return Ok(response);

                }
                catch (ArgumentException ex)
                {
                ApiError apiError = new ApiError()
                {
                    Code = "4x",
                    Message = ex.Message
                };
                response.Errors.Add(apiError);
                return BadRequest(response);
            }
                catch (Exception ex)
                {
                    ApiError apiError = new ApiError()
                    {
                        Code = "5x",
                        Message = ex.Message
                    };
                    response.Errors.Add(apiError);
                    return NotFound(response);
                }



            }
            
     
        [HttpPost]
        public async Task<IActionResult>Post(Employee employee)
        {
            ApiResponse<int> response = new ApiResponse<int>();
            try
            {
                response.Data = await employeeRepository.AddEmployeeAsync(employee);
                response.Code = 201;
                return Created($"api/employees/{response.Data}", response);
            }
            catch (Exception ex)
            {

                ApiError apiError = new ApiError()
                {
                    Code = "4x",
                    Message = ex.Message
                };
                response.Errors.Add(apiError);
                return BadRequest(response);
            }
        }



    }
}
