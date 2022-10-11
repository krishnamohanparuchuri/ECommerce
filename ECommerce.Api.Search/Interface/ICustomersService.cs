using ECommerce.Api.Search.Models;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Interface
{
    public interface ICustomersService
    {
        Task<(bool IsSuccess,dynamic Customer, string ErrorMessage)> GetCustomerAsync(int customerId);
    }
}
