using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interface;

namespace ApplicationCore.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IAsyncRepository<Customer> _customerRepository;

        public Task<Customer> AuthenticateAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> FindbyIdAsync(int id)
        {
            return _customerRepository.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
