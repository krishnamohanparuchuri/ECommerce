using ECommerce.Api.Customers.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Api.Customers.Interface
{
    public interface ICustomersProvider
    {
        Task<(bool IsSuccess,IEnumerable<Customer> Customers, string Errormessage)> GetCustomersAsync();

        Task<(bool IsSuccess, Customer Customer, string ErrorMessage)> GetCustomerAsync(int id);
    }
}
