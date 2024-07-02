using DomainLayer.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.CustomerServices
{
    public interface ICustomerServices
    {
        void ValidateModel(CustomerModel customerModel);
    }
}
