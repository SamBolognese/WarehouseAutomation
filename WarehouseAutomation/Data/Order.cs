using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WarehouseAutomation.Data
{
    public class Order : IOrder
    {
        private int _id;
        private int _customerId;
        private Customer _customer;
        private DateTime _orderDate;
        private string _deliveryAddress;
        private bool _paymentCompleted;
        private bool _dispatched;
        private List<OrderLine> _items = new();

        [Required]
        [Range(0, 9999)]
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        [Required]
        [Range(0, 9999)]
        public int CustomerId
        {
            get
            {
                return _customerId;
            }
            set
            {
                _customerId = value;
            }
        }
        [Required]
        public Customer Customer
        {
            get
            {
                return _customer;
            }
            set
            {
                _customer = value;
            }
        }
        [Required]
        public DateTime OrderDate
        {
            get
            {
                return _orderDate;
            }
            set
            {
                _orderDate = value;
            }
        }
        [Required]
        [StringLength(50, ErrorMessage = "", MinimumLength = 1)]
        public string DeliveryAddress
        {
            get
            {
                return _deliveryAddress;
            }
            set
            {
                _deliveryAddress = value;
            }
        }
        [Required]
        public bool PaymentCompleted
        {
            get
            {
                return _paymentCompleted;
            }
            set
            {
                _paymentCompleted = value;
            }
        }
        [Required]
        public bool Dispatched
        {
            get
            {
                return _dispatched;
            }
            set
            {
                _dispatched = value;
            }
        }
        [Required]
        public List<OrderLine> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
            }
        }
    }
}
