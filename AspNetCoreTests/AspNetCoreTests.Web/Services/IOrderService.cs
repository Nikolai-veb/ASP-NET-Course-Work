
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreTests.Web.Models;

namespace AspNetCoreTests.Web.Services
{
    public interface IOrderService
    {
        Task<IList<OrderModel>> List();
        Task<OrderModel> GetOrder(int id);
        Task SaveOrder(OrderModel order);
    }
}