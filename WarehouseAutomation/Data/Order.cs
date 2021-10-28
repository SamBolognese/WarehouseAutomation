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

        /// <summary>
        /// sets the value of the order ID
        /// </summary> 
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
        /// <summary>
        /// sets the value of the customer ID
        /// </summary> 
        [Required]
        [Range(0, 999999)]
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
        /// <summary>
        /// sets the value of the customer object
        /// </summary> 
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
        /// <summary>
        /// sets the date time of an order
        /// </summary> 
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
        /// <summary>
        /// sets the value of the delivery adress
        /// </summary>  
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
        /// <summary>
        /// sets the value true or false if payment is completed or not
        /// </summary> 
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
        /// <summary>
        /// sets the value true or false if an order is dispatched or not
        /// </summary> 
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
        /// <summary>
        /// sets the value of a list of orderlines 
        /// </summary> 
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
