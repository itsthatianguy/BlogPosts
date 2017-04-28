using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperUnitOfWork.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string BankDetails { get; set; }
    }
}
