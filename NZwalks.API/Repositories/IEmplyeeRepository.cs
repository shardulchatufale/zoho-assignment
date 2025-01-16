using NZwalks.API.Models.Domain;

namespace NZwalks.API.Repositories
{
    public interface IEmplyeeRepository
    {
        Task<Employee> createEmployee(Employee employee);
    }
}
