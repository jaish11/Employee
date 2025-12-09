using Emp.Entities;
using Emp.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Emp.Application
{
    public class EmployeeRepository : IEmployee
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(Employee employee)
        {
           await _context.Employees.AddAsync(employee);
           await  _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var employees = await _context.Employees.ToListAsync();
            return employees;
        }

        public async Task<Employee> GetById(int id)
        {
           return await _context.Employees.FindAsync(id);
        }

        public async Task Update(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}
