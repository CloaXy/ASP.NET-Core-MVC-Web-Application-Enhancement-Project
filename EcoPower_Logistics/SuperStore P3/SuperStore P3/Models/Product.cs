using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [DisplayName("Product ID")]
        public int ProductId { get; set; }
        [DisplayName("Product Name")]
        public string ProductName { get; set; } = null!;
        [DisplayName("Product Description")]
        public string? ProductDescription { get; set; }
        [DisplayName("Units in Stock")]
        public int? UnitsInStock { get; set; }

        [DisplayName("Order Details")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
