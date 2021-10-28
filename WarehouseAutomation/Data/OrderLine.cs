using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WarehouseAutomation.Data
{
    public class OrderLine : IOrderLine
    {
        private int _id;
        private int _productId;
        private Product _product;
        private int _orderId;
        private Order _order;
        private int _quantity;

        /// <summary>
        /// Sets the value of an orderline id and prevents the value from being negative
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
        /// Sets the value of the product id and prevents the value from being negative
        /// </summary> 
        [Required]
        [Range(0, 9999)]
        public int ProductId
        {
            get
            {
                return _productId;
            }
            set
            {
                _productId = value;
            }
        }
        /// <summary>
        /// Sets the value of a product object
        /// </summary> 
        [Required]
        public Product Product
        {
            get
            {
                return _product;
            }
            set
            {
                _product = value;
            }
        }
        /// <summary>
        /// Sets the value of a order Id and prevents it from being negative
        /// </summary>
        [Required]
        [Range(0, 9999)]
        public int OrderId
        {
            get
            {
                return _orderId;
            }
            set
            {
                _orderId = value;
            }
        }
        /// <summary>
        /// sets the value of an order 
        /// </summary>
        public Order Order
        {
            get
            {
                return _order;
            }
            set
            {
                _order = value;
            }
        }
        /// <summary>
        /// sets the value of the quantity
        /// </summary> 
        [Required]
        [Range(1, 9999)]
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }
    }
}
