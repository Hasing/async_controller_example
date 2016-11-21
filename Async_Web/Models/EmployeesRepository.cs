using System.Collections.Generic;
using System.Threading.Tasks;

namespace Async_Web.Models
{
    public class EmployeesRepository
    {
        private readonly List<Employee> employees = new List<Employee>();

        public EmployeesRepository()
        {
            employees.AddRange(new List<Employee>
            {
                new Employee {ID = 1, Name = "Tim"},
                new Employee {ID = 2, Name = "Elton"},
                new Employee {ID = 3, Name = "LuLu"},
                new Employee {ID = 4, Name = "Jason"},
                new Employee {ID = 5, Name = "Eason"}
            });
        }


        public async Task<List<Employee>> GetAllAsync()
        {
            return await Task.Run(() =>
            {
                Task.Delay(3000).Wait();
                return employees;
            });
        }
    }
}