using DapperUnitOfWork.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperUnitOfWork
{
    public class DapperUnitOfWork : IDisposable
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        private EmployeeRepository _employeeRepository;
        private CustomerRepository _customerRepository;

        public DapperUnitOfWork(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public EmployeeRepository EmployeeRepository
        {
            get
            {
                return _employeeRepository ?? (_employeeRepository = new EmployeeRepository(_transaction));
            }
        }

        public CustomerRepository CustomerRepository
        {
            get
            {
                return _customerRepository ?? (_customerRepository = new CustomerRepository(_transaction));
            }
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                ResetRepositories();
            }
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }

            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }

        private void ResetRepositories()
        {
            _employeeRepository = null;
        }
    }
}
