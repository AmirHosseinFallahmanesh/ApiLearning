using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo1.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private static List<Employee> context  = new List<Employee>()
        {
                new Employee { Id = 1, FirstName = "علی", LastName = "احمدی", Age = 30 },
                new Employee { Id = 2, FirstName = "فاطمه", LastName = "محمدی", Age = 25 },
                new Employee { Id = 3, FirstName = "حسین", LastName = "رضایی", Age = 40 },
                new Employee { Id = 4, FirstName = "زهرا", LastName = "کریمی", Age = 35 },
                new Employee { Id = 5, FirstName = "مهدی", LastName = "سلیمانی", Age = 28 },
                new Employee { Id = 6, FirstName = "سارا", LastName = "حسینی", Age = 32 },
                new Employee { Id = 7, FirstName = "امیر", LastName = "نیکو", Age = 45 },
                new Employee { Id = 8, FirstName = "لیلا", LastName = "علیزاده", Age = 29 },
                new Employee { Id = 9, FirstName = "رضا", LastName = "موسوی", Age = 38 },
                new Employee { Id = 10, FirstName = "نگار", LastName = "بهرامی", Age = 27 }
        };

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await Task.Factory.StartNew<IEnumerable<Employee>>(()=> {
                return context;
            });
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {

            return await Task.Factory.StartNew<Employee>(() => {
                return  context.Single(a => a.Id == id);
            });
           
        }

        public async Task<int> AddEmployeeAsync(Employee employee)
        {
            await Task.Delay(100);
            employee.Id = context.Count + 1;
            context.Add(employee);
            return employee.Id;
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            //_context.Employees.Update(employee);
            //await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            //var employee = await _context.Employees.FindAsync(id);
            //if (employee != null)
            //{
            //    _context.Employees.Remove(employee);
            //    await _context.SaveChangesAsync();
            //}
        }
    }
}
