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
            model.Address = order.Address;
            model.price = order.price;

            return model;
        }

        public async Task<IList<OrderModel>> List()
        {
            return await _dataContext.Orders
                                     .OrderBy(c => c.Address)
                                     .Select(c => new OrderModel 
                                     { 
                                        Id = c.Id,
                                        Address = c.Address,
                                        price = c.price
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

            order.Address = model.Address;
            order.price = model.price;

            await _dataContext.SaveChangesAsync();
        }
    }
}