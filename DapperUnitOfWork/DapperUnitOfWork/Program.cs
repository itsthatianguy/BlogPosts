using DapperUnitOfWork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperUnitOfWork
{
    class Program
    {
        private static string _connectionString = @"<your-connection-string>";

        static void Main(string[] args)
        {
            using (var unitOfWork = new DapperUnitOfWork(_connectionString))
            {
                var newEmployee = new Employee
                {
                    FirstName = "Ian",
                    LastName = "Rufus",
                    JobTitle = "Developer"
                };

                newEmployee.EmployeeId = unitOfWork.EmployeeRepository.Add(newEmployee);

                newEmployee.JobTitle = "Fired!";

                unitOfWork.EmployeeRepository.Update(newEmployee);
            }
        }
    }
}
