using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [DisplayName("Order ID")]
        public int OrderId { get; set; }
        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }
        [DisplayName("Customer ID")]
        public int CustomerId { get; set; }
        [DisplayName("Delivery Address")]
        public string? DeliveryAddress { get; set; }

        [DisplayName("Customer")]
        public virtual Customer Customer { get; set; } = null!;
        [DisplayName("Order Details")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
