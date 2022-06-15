
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AspNetCoreTests.Web.Models
{
    public enum StatusOrder {
    Waiting,
    Processing,
    Completed
    }

    [ExcludeFromCodeCoverage]
    public class OrderModel
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