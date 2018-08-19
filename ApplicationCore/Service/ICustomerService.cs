using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Service
{
    public interface ICustomerService
    {
        Task<Customer> AuthenticateAsync(string username, string password);

        Task<Customer> FindbyIdAsync(int id);
    }
}
