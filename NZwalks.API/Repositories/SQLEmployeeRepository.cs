using NZwalks.API.Data;
using NZwalks.API.Models.Domain;

namespace NZwalks.API.Repositories
{
    public class SQLEmployeeRepository:IEmplyeeRepository
    {
        private readonly NZWalksDBContext dBb;

        public SQLEmployeeRepository(NZWalksDBContext dBb)
        {
            this.dBb = dBb;
        }

    

         public async   Task<Employee> createEmployee(Employee employee)
            {
            await dBb.Employees.AddAsync(employee);
            await dBb.SaveChangesAsync();
            return employee;
        }


       


    }
}
