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
        private List<Order> _orders = new List<Order>();

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

        [Required]
        [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
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
        [Required]
        [StringLength(10, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 10)]
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
