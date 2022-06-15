using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTests.Web.Data;
using AspNetCoreTests.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreTests.Web.Services
{
    public class OrderService : IOrderService
    {
        private readonly DemoDbContext _dataContext;

        public OrderService(DemoDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<OrderModel> GetOrder(int id)
        {
            var order = await _dataContext.Orders.FindAsync(id);
            if(order == null)
            {
                return null;
            }

            var model = new OrderModel();
            model.Id = order.Id;
            model.shippingAddress = order.shippingAddress;
            model.destinationAddress = order.destinationAddress;
            model.numberPassengers = order.numberPassengers;
            model.Customer = order.Customer;
            model.Executor = order.Executor;
            model.Status = order.Status;
            model.Created = order.Created;

            return model;
        }

        public async Task<IList<OrderModel>> List()
        {
            return await _dataContext.Orders
                                     .OrderBy(c => c.Customer)
                                     .Select(c => new OrderModel 
                                     { 
                                        Id = c.Id,
                                        Created = c.Created,
                                        Price = c.Price,
                                        Status = c.Status
                                     })
                                     .ToListAsync();
        }

        public async Task SaveOrder(OrderModel model)
        {
            var order = new Order();
            if(model.Id != 0)
            {
                order = await _dataContext.Orders.FirstOrDefaultAsync(c => c.Id == model.Id);
            }
            else
            {
                await _dataContext.Orders.AddAsync(order);
            }

            order.shippingAddress = model.shippingAddress;
            order.destinationAddress = model.destinationAddress;
            order.numberPassengers = model.numberPassengers;
            order.Customer = model.Customer;
            order.Executor = model.Executor;
            order.Created = model.Created;

            await _dataContext.SaveChangesAsync();
        }
    }
}