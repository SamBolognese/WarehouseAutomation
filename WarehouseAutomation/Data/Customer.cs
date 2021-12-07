using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WarehouseAutomation.Data
{
    public class Customer : ICustomer
    {
        private int _id;
        private string _name;
        private string _phone;
        private string _email;
        private List<Order> _orders = new();

        /// <summary>
        /// Sets the value of the Customer ID
        /// </summary>
        [Required]
        [Range(0, 999999)] 
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
        /// Sets the value of the Customer name, must be between 1 and 40 characters
        /// </summary>
        [Required]
        [StringLength(40, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 1)]
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
        /// Sets the value of the Customer Phonenumber, must be 10 characters long and may only contain numbers
        /// </summary>
        [Required]
        [StringLength(10, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 10)]
        [RegularExpression("[^[0-9]+$]", ErrorMessage = "Phone numbers can only contain numbers.")]
        public string Phone 
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
            }
        }

        /// <summary>
        /// Sets the value of the Customer Email, must be between 5 and 100 characters long
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 5)]
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        /// <summary>
        /// Sets the value to the list of Orders
        /// </summary>
        public List<Order> Orders
        {
            get
            {
                return _orders;
            }
            set
            {
                _orders = Orders;
            }
        }
    }
}
