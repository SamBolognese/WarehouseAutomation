using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseAutomation.Data
{
    public class Product : IProduct
    {
        private int _id;
        private string _name;
        private string _description;
        private double _price;
        private int _stock;
        private DateTime _restockingDate;
        /// <summary>
        /// sets the value of the product ID
        /// </summary> 
        [Required]
        [Range(0, 9999)] //Id får inte vara negativt
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
        /// sets the value of the product name
        /// </summary>  
        [Required]
        [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 1)]
        public string Name 
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        /// <summary>
        /// sets the description of a product
        /// </summary> 
        [Required]
        [StringLength(maximumLength: 1000)]
        public string Description
        {
            get
            {
                return _description;

            }
            set
            {
                _description = value;
            }
        }
        /// <summary>
        /// sets the value of the product price
        /// </summary> 
        [Required]
        [Range(1, Double.PositiveInfinity)]
        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }
        /// <summary>
        /// sets the value of the product stock
        /// </summary> 
        [Required]
        [Range(0, 100)]
        public int Stock
        {
            get
            {
                return _stock;
            }
            set
            {
                _stock = value;
            }
        }
        /// <summary>
        /// sets the value of restocking date
        /// </summary> 
        [Required]
        public DateTime RestockingDate
        {
            get
            {
                return _restockingDate;
            }
            set
            {
                _restockingDate = value;
            }
        }
    }
}
