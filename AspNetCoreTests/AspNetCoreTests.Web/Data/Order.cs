using System;
namespace AspNetCoreTests.Web.Data
{
    public enum StatusOrder {
        Waiting,
        Processing,
        Completed
        }


    public class Order
    {
        public int Id { get; set; }
        public ushort price { get; set; }
        public DateTime created { get; set; }
        public string Address { get; set; }
        public virtual Customer customer { get; set; }
        public virtual Customer executor { get; set; }
        public StatusOrder status = StatusOrder.Waiting;
    }
}
