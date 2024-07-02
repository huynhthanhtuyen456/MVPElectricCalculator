using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models.Customer
{
    public class CustomerModel : ICustomerModel
    {
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "First Name must be between 1 and 50 characters")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Last Name must be between 1 and 50 characters")]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Range(1, 10, ErrorMessage = "Value must be between 1 to 10")]
        public int Gender { get; set; }

        [Range(1, 10, ErrorMessage = "Value must be between 1 to 10")]
        public int Occupation { get; set; }
    }
}
