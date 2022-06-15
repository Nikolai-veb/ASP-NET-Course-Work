using System;
using AspNetCoreTests.Web.Models;
namespace AspNetCoreTests.Web.Data

{
    public class Order
    {
        public int Id { get; set; }
        public ushort Price { get; set; }
        public DateTime Created { get; set; }
        public string shippingAddress { get; set; }
        public string destinationAddress { get; set; }
        public int numberPassengers { get; set; }
        public virtual CustomerModel Customer { get; set; }
        public virtual CustomerModel Executor { get; set; }
        public StatusOrder Status = StatusOrder.Waiting;
    }
}
