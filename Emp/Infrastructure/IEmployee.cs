using Emp.Entities;

namespace Emp.Infrastructure
{
    public interface IEmployee
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task Add(Employee employee);
        Task Update(Employee employee);
        Task Delete(int id);

    }
}
