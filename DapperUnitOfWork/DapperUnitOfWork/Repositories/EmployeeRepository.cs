using Dapper;
using DapperUnitOfWork.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperUnitOfWork.Repositories
{
    public class EmployeeRepository
    {
        private IDbTransaction _transaction;
        private IDbConnection _connection { get { return _transaction.Connection; } }

        public EmployeeRepository(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public int Add(Employee entity)
        {
            return _connection.ExecuteScalar<int>(@"INSERT INTO Employees(FirstName, LastName, JobTitle) 
                                                    VALUES(@FirstName, @LastName, @JobTitle);
                                                    SELECT SCOPE_IDENTITY()",
                                                    new {
                                                        FirstName = entity.FirstName,
                                                        LastName = entity.LastName,
                                                        JobTitle = entity.JobTitle
                                                    }, _transaction);
        }

        public void Update(Employee entity)
        {
            _connection.Execute(@"UPDATE Employees 
                                    SET FirstName = @FirstName, 
                                        LastName = @LastName, 
                                        JobTitle = @JobTitle 
                                    WHERE EmployeeId = @EmployeeId",
                                    new
                                    {
                                        FirstName = entity.FirstName,
                                        LastName = entity.LastName,
                                        JobTitle = entity.JobTitle,
                                        EmployeeId = entity.EmployeeId
                                    }, _transaction);
        }

        public void Remove(int employeeId)
        {
            _connection.Execute(@"DELETE FROM Employees WHERE EmployeeId = @EmployeeId",
                                new
                                {
                                    EmployeeId = employeeId
                                }, _transaction);
        }
    }
}
