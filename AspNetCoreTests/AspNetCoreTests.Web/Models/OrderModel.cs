
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
        public ushort price { get; set; }
        public DateTime created { get; set; }
        public string Address { get; set; }
        public virtual CustomerModel customer { get; set; }
        public virtual CustomerModel executor { get; set; }
        public StatusOrder status = StatusOrder.Waiting;
    }

}