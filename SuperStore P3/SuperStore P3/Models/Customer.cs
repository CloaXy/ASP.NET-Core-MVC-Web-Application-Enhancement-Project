using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        [DisplayName("Customer ID")]
        public int CustomerId { get; set; }
        [DisplayName("Customer Title")]
        public string? CustomerTitle { get; set; }
        [DisplayName("Customer Name")]
        public string? CustomerName { get; set; }
        [DisplayName("Customer Surname")]
        public string? CustomerSurname { get; set; }
        [DisplayName("Customer Cellphone")]
        public string? CellPhone { get; set; }
        [DisplayName("Orders")]

        public virtual ICollection<Order> Orders { get; set; }
    }
}
