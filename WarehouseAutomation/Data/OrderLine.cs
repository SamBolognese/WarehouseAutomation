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
        [Required]
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
        [Required]
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
