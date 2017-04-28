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
    public class CustomerRepository
    {
        private IDbTransaction _transaction;
        private IDbConnection _connection { get { return _transaction.Connection; } }

        public CustomerRepository(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public int Add(Customer entity)
        {
            return _connection.ExecuteScalar<int>(@"INSERT INTO Customers(Email, Address, BankDetails)
                                                    VALUES(@Email, @Address, @BankDetails);
                                                    SELECT SCOPE_IDENTITY()",
                                                    new
                                                    {
                                                        Email = entity.Email,
                                                        Address = entity.Address,
                                                        BankDetails = entity.BankDetails
                                                    }, _transaction);
        }

        public void Update(Customer entity)
        {
            _connection.Execute(@"UPDATE Customers
                                    SET Email = @Email
                                        Address = @Address
                                        BankDetails = @BankDetails
                                    WHERE CustomerId = @CustomerId",
                                    new
                                    {
                                        Email = entity.Email,
                                        Address = entity.Address,
                                        BankDetails = entity.BankDetails
                                    }, _transaction);
        }

        public void Remove(int customerId)
        {
            _connection.Execute(@"DELETE FROM Customers WHERE CustomerId = @CustomerId",
                                new
                                {
                                    CustomerId = customerId
                                }, _transaction);
        }
    }
}
